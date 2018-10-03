#!/usr/bin/python
import os
import re
from os import walk

header_path = "/usr/include/SDL2/"
out_folder = "generated/"

included = list(map(re.compile, [
    r"^SDL_(.*)"
]))
excluded = list(map(re.compile, [
    r"^SDL_test(.*)",
    r"^SDL_opengl(.*)",
]))
excluded.extend(map(lambda n: re.compile("SDL_" + n + ".h"), [
    "assert", "atomic", "bits", "config", "endian", "filesystem", "loadso",
    "log", "main", "mutex", "name", "platform", "quit", "revision", "rwops",
    "shape", "stdinc", "system", "syswm", "thread", "types", 
]))

def useful_names(name):
    for regex in included:
        if not regex.match(name):
            return False
    for regex in excluded:
        if regex.match(name):
            return False
    return True

header_filenames = []
for (dirpath, dirnames, filenames) in walk(header_path):
    header_filenames.extend(filenames)
header_filenames = list(filter(useful_names, header_filenames))
header_filenames.sort()
headers = list(map(lambda f: (f, os.path.join(header_path, f)), header_filenames))


# -------------------------- Source transformation -----------------------------
CONST_REGEX = re.compile(r"#define\s+(?P<name>[a-zA-Z]\w*)\s+\(?(?P<value>[\w\d&|<>+\-*/\"]*)[\s\)]", re.MULTILINE)
STRUCT_REGEX = re.compile(r"(?<=typedef struct)(?:[\s\w]*)\{(?P<contents>[^}]*)\}(?:\s*)(?:\w*?)(?:\s*)(?P<name>\w*);")
ENUM_REGEX = re.compile(r"(?<=typedef enum)(?:[\s\w]*)\{(?P<contents>[^}]*)\}(?:\s*)(?:\w*?)(?:\s*)(?P<name>\w*);")
FUNCTION_REGEX = re.compile(r"(?<=extern DECLSPEC )(?P<return_type>[\w\s\*]*)(?:SDLCALL)\s*(?P<name>[\w\d]*)\((?P<params>[\w\d\s,\*]*)\);")
TYPE_MAP = {
    'Uint8': 'byte',
    'Sint8': 'sbyte',
    'Uint16': 'ushort',
    'Sint16': 'short',
    'Uint32': 'uint',
    'Sint32': 'int',
    'Uint64': 'ulong',
    'Sint64': 'long',
    'char': 'IntPtr'
}

def sanitize(source):
    return source.replace("@{", "").replace("@}", "")

def extract_defines(source):
    result = ""
    matches = [m.groupdict() for m in CONST_REGEX.finditer(source)]
    for match in matches:
        if not match["value"]:
            continue
        const_type = "int"
        if "\"" in match["value"]:
            const_type = "string"
        result += "public const " + const_type + " " + match["name"] + " = "
        result += match["value"] + ";\n"
    return result + "\n"


def extract_structs(source):
    result = ""
    matches = [m.groupdict() for m in STRUCT_REGEX.finditer(source)]
    for match in matches:
        result += "public struct " + match["name"] + "\n{\n"
        result += match["contents"]
        result += "\n}\n"
    return result + "\n"

def extract_enums(source):
    result = ""
    matches = [m.groupdict() for m in ENUM_REGEX.finditer(source)]
    for match in matches:
        result += "public enum " + match["name"] + "\n{\n"
        result += match["contents"]
        result += "\n}\n"
    return result + "\n"

def rewrite_function_return_type(name):
    if name.startswith('const '):
        name = name[6:]
    if '*' not in name:
        if name in TYPE_MAP:
            name = TYPE_MAP[name]
        return name
    return 'IntPtr'


def rewrite_function_param(param):
    if '*' not in param:
        return param
    (p_type, p_name) = (param.split('*')[0].strip(), param.split('*')[1].strip())
    if p_type in TYPE_MAP:
        p_type = TYPE_MAP[p_type]
    if p_type != 'IntPtr':
        p_type = 'ref ' + p_type
    return p_type + " " + p_name

def rewrite_function_params(params_str):
    if params_str == "void":
        return ""
    params = map(lambda s: s.strip(), params_str.split(","))
    params = map(lambda s: s[6:] if s.startswith('const ') else s, params)
    params = map(rewrite_function_param, params)
    return ", ".join(params)

def extract_functions(source):
    result = ""
    matches = [m.groupdict() for m in FUNCTION_REGEX.finditer(source)]
    for match in matches:
        result += "[DllImport(\"SDL2.dll\")]\n"
        result += "public static extern "
        result += rewrite_function_return_type(match["return_type"])
        result += " " + match["name"]
        result += "(" + rewrite_function_params(match["params"]) + ");\n"
    return result + "\n"


def build_source(class_name, contents, all_classes):
    contents = sanitize(contents)
    result = "using System;\nusing System.Runtime.InteropServices;\n\n"
    result += "using SDL2;\n"
    for other_class in all_classes:
        if other_class != class_name:
            result += "using static SDL2." + other_class + ";\n"
    result +="\nnamespace SDL2\n{\npublic static class "
    result += class_name
    result += "\n{\n"
    result += extract_defines(contents)
    result += extract_enums(contents)
    result += extract_structs(contents)
    result += extract_functions(contents)
    result += "}\n}\n"
    return result

# ------------------------------------------------------------------------------


all_classes = list(map(lambda h_p: h_p[0][:-2], headers))
os.makedirs(out_folder, exist_ok=True)
for (header, path) in headers:
    header_file = open(path, mode='r')
    contents = header_file.read()
    header_file.close()
    source_file = open(os.path.join(out_folder, header[:-2] + ".cs"), mode="w")
    source_file.write(build_source(header[:-2], contents, all_classes))
    source_file.close()


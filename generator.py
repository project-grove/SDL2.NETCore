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
header_filenames = filter(useful_names, header_filenames)
headers = map(lambda f: (f, os.path.join(header_path, f)), header_filenames)


# -------------------------- Source transformation -----------------------------
CONST_REGEX = re.compile(r"#define\s+(?P<name>[a-zA-Z]\w*)\s+\(?(?P<value>[\w\d&|<>+\-*/\"]*)[\s\)]", re.MULTILINE)
STRUCT_REGEX = re.compile(r"(?<=typedef struct)(?:[\s\w]*)\{(?P<contents>[^}]*)\}(?:\s*)(?:\w*?)(?:\s*)(?P<name>\w*);")
ENUM_REGEX = re.compile(r"(?<=typedef enum)(?:[\s\w]*)\{(?P<contents>[^}]*)\}(?:\s*)(?:\w*?)(?:\s*)(?P<name>\w*);")
FUNCTION_REGEX = re.compile(r"(?<=extern DECLSPEC )(?P<return_type>[\w\s\*]*)(?:SDLCALL)\s*(?P<name>[\w\d]*)\((?P<params>[\w\d\s,\*]*)\);")

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

def extract_functions(source):
    result = ""
    matches = [m.groupdict() for m in FUNCTION_REGEX.finditer(source)]
    for match in matches:
        result += "[DllImport]\n"
        result += "public static extern " + match["return_type"] + " " + match["name"]
        result += "(" + match["params"] + ");\n"
    return result + "\n"


def build_source(class_name, contents):
    contents = sanitize(contents)
    result = "using System;\n\nnamespace SDL2\n{\npublic static class "
    result += class_name
    result += "\n{\n"
    result += extract_defines(contents)
    result += extract_enums(contents)
    result += extract_structs(contents)
    result += extract_functions(contents)
    result += "}\n}\n"
    return result

# ------------------------------------------------------------------------------



os.makedirs(out_folder, exist_ok=True)
for (header, path) in headers:
    header_file = open(path, mode='r')
    contents = header_file.read()
    header_file.close()
    source_file = open(os.path.join(out_folder, header[:-2] + ".cs"), mode="w")
    source_file.write(build_source(header[:-2], contents))
    source_file.close()


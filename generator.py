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
    "stdinc", "system", "syswm", "thread", "types", 
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

STRUCT_REGEX = re.compile(r"(?<=typedef struct)(?:[\s\w]*)\{(?P<contents>[^}]*)\}(?:\s*)(?:\w*?)(?:\s*)(\w*);")
ENUM_REGEX = re.compile(r"(?<=typedef enum)(?:[\s\w]*)\{(?P<contents>[^}]*)\}(?:\s*)(?:\w*?)(?:\s*)(\w*);")
FUNCTION_REGEX = re.compile(r"(?<=extern DECLSPEC )(?P<return_type>[\w\s\*]*)(?:SDLCALL)\s*(?P<name>[\w\d]*)\((?P<params>[\w\d\s,\*]*)\);")

os.makedirs(out_folder, exist_ok=True)
for (header, path) in headers:
    header_file = open(path, mode='r')
    contents = header_file.read()
    header_file.close()
    source_file = open(os.path.join(out_folder, header[:-2] + ".cs"), mode="w")
    # TODO
    source_file.close()
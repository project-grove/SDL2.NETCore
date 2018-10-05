#!/usr/bin/python
import os
from os import listdir, makedirs
from os.path import join
from subprocess import check_output

src_dir = 'src'
dest_dir = join('generated', 'processed')

files = list(filter(lambda n: n.endswith(".cs"), listdir(src_dir)))
src_files = map(lambda n: join(src_dir, n), files)
dest_files = map(lambda n: join(dest_dir, n), files)

makedirs(dest_dir, exist_ok=True)
for src, dest in zip(src_files, dest_files):
    print(src + " -> " + dest)
    result = check_output(['extern-nll-gen', src])
    f = open(dest, mode='wb')
    f.write(result)
    f.close()

![Stability: alpha](https://img.shields.io/badge/stability-alpha-orange.svg)

# Cross-platform SDL2 bindings for .NET Core/Standard

This library is an almost 1-to-1 cross-platform wrapper around [SDL2](https://libsdl.org/), generated from header files.

Why almost? Some function signatures (like the ones accepting char*, etc.) was 
edited to be a little more ergonomical to use.

# Projects using this library
* [Imagini](https://github.com/project-grove/imagini) - cross-platform .NET Standard game/multimedia app engine - the wrapper was developed for it

# Supported platforms
|Windows|Linux|OSX|
|-|-|-|
|?|✓|?|

Note: the library should work under Windows and OSX, because the loading code is mostly identical to the code used in the [Veldrid](https://github.com/mellinoe/veldrid) project.

I just need to get my hands on my other testing machines to confirm (if you happen to confirm it before me, it'll be great).

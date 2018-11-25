using System;
using System.Runtime.InteropServices;
using NativeLibraryLoader;
using static System.Runtime.InteropServices.RuntimeInformation;

namespace SDL2.Internal
{
    internal static class Loader_SDL2
    {
        static NativeLibrary _sdl2;
        static NativeLibrary _sdl2mixer;

        internal static NativeLibrary Sdl2
        {
            get
            {
                if (_sdl2 == null)
                    _sdl2 = LoadSDL2();
                return _sdl2;
            }
        }

        internal static NativeLibrary SdlMixer
        {
            get
            {
                if (_sdl2mixer == null)
                    _sdl2mixer = LoadSDLMixer();
                return _sdl2mixer;
            }
        }

        static NativeLibrary LoadSDL2() =>
            Load(
                windows: new[] {
                    "SDL2.dll"
                },
                osx: new[] {
                    "libSDL2.dylib"
                },
                linux: new[] {
                    "libSDL2-2.0.so",
                    "libSDL2-2.0.so.0",
                    "libSDL2-2.0.so.1"
                });

        static NativeLibrary LoadSDLMixer() =>
            TryLoad(
                windows: new[] { 
                    "SDL_mixer.dll"
                },
                osx: new[] {
                    "libSDL2_mixer.dylib"
                },
                linux: new[] {
                    "libSDL2_mixer.so",
                    "libSDL2_mixer.so.0",
                    "libSDL2_mixer.so.1"
                }
            );

        static NativeLibrary Load(string[] windows, string[] osx, string[] linux)
        {
            var names = linux;
            if (IsOSPlatform(OSPlatform.Windows))
                names = windows;
            else if (IsOSPlatform(OSPlatform.OSX))
                names = osx;
            return new NativeLibrary(names);
        }

        static NativeLibrary TryLoad(string[] windows, string[] osx, string[] linux)
        {
            try
            {
                return Load(windows, osx, linux);
            }
#pragma warning disable
            catch (Exception ex) { }
#pragma warning enable
            return null;
        }

        internal static T LoadFunction<T>(string name)
        {
            return Sdl2.LoadFunction<T>(name);
        }

        internal static T LoadFunction<T>(this NativeLibrary library,
            string name)
        {
            return library.LoadFunction<T>(name);
        }
    }
}
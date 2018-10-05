using System.Runtime.InteropServices;
using NativeLibraryLoader;
using static System.Runtime.InteropServices.RuntimeInformation;

namespace SDL2.Internal
{
    internal static class Loader_SDL2
    {
        static NativeLibrary _sdl2;        

        internal static NativeLibrary Sdl2 {
            get {
                if (_sdl2 == null) {
                    _sdl2 = LoadSDL2();
                }
                return _sdl2;
            }
        }

        static NativeLibrary LoadSDL2()
        {
            string[] names = null;
            if (IsOSPlatform(OSPlatform.Windows)) {
                names = new [] { "SDL2.dll" };
            } else if (IsOSPlatform(OSPlatform.OSX)) {
                names = new [] { "libSDL2.dylib" };
            } else {
                names = new [] {
                    "libSDL2-2.0.so.0",
                    "libSDL2.so"
                };
            }
            return new NativeLibrary(names);
        }

        internal static T LoadFunction<T>(string name)
        {
            return Sdl2.LoadFunction<T>(name);
        }
    }
}
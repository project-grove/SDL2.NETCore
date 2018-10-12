using System.Runtime.InteropServices;
using NativeLibraryLoader;

namespace SDL2
{
    public static class SDL_timer
    {
        private delegate uint SDL_GetTicks__t();

        private static SDL_GetTicks__t s_SDL_GetTicks__t = __LoadFunction<SDL_GetTicks__t>("SDL_GetTicks");

        public static uint SDL_GetTicks() => s_SDL_GetTicks__t();
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}

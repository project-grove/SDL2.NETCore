using System;
using System.Runtime.InteropServices;

using SDL2;
using static SDL2.SDL_audio;
using static SDL2.SDL_blendmode;
using static SDL2.SDL_clipboard;
using static SDL2.SDL_error;
using static SDL2.SDL_events;
using static SDL2.SDL_gamecontroller;
using static SDL2.SDL_gesture;
using static SDL2.SDL_haptic;
using static SDL2.SDL_hints;

using static SDL2.SDL_joystick;
using static SDL2.SDL_keyboard;
using static SDL2.SDL_keycode;
using static SDL2.SDL_messagebox;
using static SDL2.SDL_mouse;
using static SDL2.SDL_pixels;
using static SDL2.SDL_power;
using static SDL2.SDL_rect;
using static SDL2.SDL_render;
using static SDL2.SDL_scancode;
using static SDL2.SDL_surface;

using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

using SDL_bool = System.Int32;
using NativeLibraryLoader;

namespace SDL2
{
    public static class SDL_cpuinfo
    {
        public const int SDL_CACHELINE_SIZE = 128;

        private delegate int SDL_GetCPUCount__t();

        private static SDL_GetCPUCount__t s_SDL_GetCPUCount__t = __LoadFunction<SDL_GetCPUCount__t>("SDL_GetCPUCount");

        public static int SDL_GetCPUCount() => s_SDL_GetCPUCount__t();

        private delegate int SDL_GetCPUCacheLineSize__t();

        private static SDL_GetCPUCacheLineSize__t s_SDL_GetCPUCacheLineSize__t = __LoadFunction<SDL_GetCPUCacheLineSize__t>("SDL_GetCPUCacheLineSize");

        public static int SDL_GetCPUCacheLineSize() => s_SDL_GetCPUCacheLineSize__t();

        private delegate SDL_bool SDL_HasRDTSC__t();

        private static SDL_HasRDTSC__t s_SDL_HasRDTSC__t = __LoadFunction<SDL_HasRDTSC__t>("SDL_HasRDTSC");

        public static SDL_bool SDL_HasRDTSC() => s_SDL_HasRDTSC__t();

        private delegate SDL_bool SDL_HasAltiVec__t();

        private static SDL_HasAltiVec__t s_SDL_HasAltiVec__t = __LoadFunction<SDL_HasAltiVec__t>("SDL_HasAltiVec");

        public static SDL_bool SDL_HasAltiVec() => s_SDL_HasAltiVec__t();

        private delegate SDL_bool SDL_HasMMX__t();

        private static SDL_HasMMX__t s_SDL_HasMMX__t = __LoadFunction<SDL_HasMMX__t>("SDL_HasMMX");

        public static SDL_bool SDL_HasMMX() => s_SDL_HasMMX__t();

        private delegate SDL_bool SDL_Has3DNow__t();

        private static SDL_Has3DNow__t s_SDL_Has3DNow__t = __LoadFunction<SDL_Has3DNow__t>("SDL_Has3DNow");

        public static SDL_bool SDL_Has3DNow() => s_SDL_Has3DNow__t();

        private delegate SDL_bool SDL_HasSSE__t();

        private static SDL_HasSSE__t s_SDL_HasSSE__t = __LoadFunction<SDL_HasSSE__t>("SDL_HasSSE");

        public static SDL_bool SDL_HasSSE() => s_SDL_HasSSE__t();

        private delegate SDL_bool SDL_HasSSE2__t();

        private static SDL_HasSSE2__t s_SDL_HasSSE2__t = __LoadFunction<SDL_HasSSE2__t>("SDL_HasSSE2");

        public static SDL_bool SDL_HasSSE2() => s_SDL_HasSSE2__t();

        private delegate SDL_bool SDL_HasSSE3__t();

        private static SDL_HasSSE3__t s_SDL_HasSSE3__t = __LoadFunction<SDL_HasSSE3__t>("SDL_HasSSE3");

        public static SDL_bool SDL_HasSSE3() => s_SDL_HasSSE3__t();

        private delegate SDL_bool SDL_HasSSE41__t();

        private static SDL_HasSSE41__t s_SDL_HasSSE41__t = __LoadFunction<SDL_HasSSE41__t>("SDL_HasSSE41");

        public static SDL_bool SDL_HasSSE41() => s_SDL_HasSSE41__t();

        private delegate SDL_bool SDL_HasSSE42__t();

        private static SDL_HasSSE42__t s_SDL_HasSSE42__t = __LoadFunction<SDL_HasSSE42__t>("SDL_HasSSE42");

        public static SDL_bool SDL_HasSSE42() => s_SDL_HasSSE42__t();

        private delegate SDL_bool SDL_HasAVX__t();

        private static SDL_HasAVX__t s_SDL_HasAVX__t = __LoadFunction<SDL_HasAVX__t>("SDL_HasAVX");

        public static SDL_bool SDL_HasAVX() => s_SDL_HasAVX__t();

        private delegate int SDL_GetSystemRAM__t();

        private static SDL_GetSystemRAM__t s_SDL_GetSystemRAM__t = __LoadFunction<SDL_GetSystemRAM__t>("SDL_GetSystemRAM");

        public static int SDL_GetSystemRAM() => s_SDL_GetSystemRAM__t();
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


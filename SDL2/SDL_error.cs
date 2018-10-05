using System;
using System.Runtime.InteropServices;

using SDL2;
using static SDL2.SDL_audio;
using static SDL2.SDL_blendmode;
using static SDL2.SDL_clipboard;
using static SDL2.SDL_cpuinfo;
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
using NativeLibraryLoader;

namespace SDL2
{
    public static class SDL_error
    {

        public enum SDL_errorcode
        {

            SDL_ENOMEM,
            SDL_EFREAD,
            SDL_EFWRITE,
            SDL_EFSEEK,
            SDL_UNSUPPORTED,
            SDL_LASTERROR

        }

        private delegate IntPtr SDL_GetError__t();

        private static SDL_GetError__t s_SDL_GetError__t = __LoadFunction<SDL_GetError__t>("SDL_GetError");

        static IntPtr _SDL_GetError() => s_SDL_GetError__t();
        public static string SDL_GetError() => Marshal.PtrToStringAnsi(_SDL_GetError());

        private delegate void SDL_ClearError__t();

        private static SDL_ClearError__t s_SDL_ClearError__t = __LoadFunction<SDL_ClearError__t>("SDL_ClearError");

        public static void SDL_ClearError() => s_SDL_ClearError__t();

        private delegate int SDL_Error_SDL_errorcode_t(SDL_errorcode code);

        private static SDL_Error_SDL_errorcode_t s_SDL_Error_SDL_errorcode_t = __LoadFunction<SDL_Error_SDL_errorcode_t>("SDL_Error");

        public static int SDL_Error(SDL_errorcode code) => s_SDL_Error_SDL_errorcode_t(code);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


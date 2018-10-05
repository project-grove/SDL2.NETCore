using System;
using System.Runtime.InteropServices;

using SDL2;
using static SDL2.SDL_audio;
using static SDL2.SDL_blendmode;
using static SDL2.SDL_cpuinfo;
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
    public static class SDL_clipboard
    {
        private delegate int SDL_SetClipboardText_IntPtr_t(IntPtr text);

        private static SDL_SetClipboardText_IntPtr_t s_SDL_SetClipboardText_IntPtr_t = __LoadFunction<SDL_SetClipboardText_IntPtr_t>("SDL_SetClipboardText");

        public static int SDL_SetClipboardText(IntPtr text) => s_SDL_SetClipboardText_IntPtr_t(text);

        private delegate IntPtr SDL_GetClipboardText__t();

        private static SDL_GetClipboardText__t s_SDL_GetClipboardText__t = __LoadFunction<SDL_GetClipboardText__t>("SDL_GetClipboardText");

        public static IntPtr SDL_GetClipboardText() => s_SDL_GetClipboardText__t();

        private delegate SDL_bool SDL_HasClipboardText__t();

        private static SDL_HasClipboardText__t s_SDL_HasClipboardText__t = __LoadFunction<SDL_HasClipboardText__t>("SDL_HasClipboardText");

        public static SDL_bool SDL_HasClipboardText() => s_SDL_HasClipboardText__t();
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


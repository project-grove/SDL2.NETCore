using System;
using System.Runtime.InteropServices;

using SDL2;
using static SDL2.SDL_audio;
using static SDL2.SDL_blendmode;
using static SDL2.SDL_clipboard;
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
using static SDL2.SDL_video;

namespace SDL2
{
    public static class SDL_version
    {
        public const int SDL_MAJOR_VERSION = 2;
        public const int SDL_MINOR_VERSION = 0;
        public const int SDL_PATCHLEVEL = 2;


        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Version
        {

            public byte major;        /**< major version */
            public byte minor;        /**< minor version */
            public byte patch;        /**< update version */

        }

        [DllImport("libSDL2.so")]
        public static extern void SDL_GetVersion(out SDL_Version ver);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetRevision();
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetRevisionNumber();

    }
}

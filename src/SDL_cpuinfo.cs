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

namespace SDL2
{
    public static class SDL_cpuinfo
    {
        public const int SDL_CACHELINE_SIZE = 128;



        [DllImport("libSDL2.so")]
        public static extern int SDL_GetCPUCount();
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetCPUCacheLineSize();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_HasRDTSC();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_HasAltiVec();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_HasMMX();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_Has3DNow();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_HasSSE();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_HasSSE2();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_HasSSE3();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_HasSSE41();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_HasSSE42();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_HasAVX();
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetSystemRAM();

    }
}

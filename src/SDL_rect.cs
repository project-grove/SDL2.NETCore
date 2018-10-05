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
using static SDL2.SDL_render;
using static SDL2.SDL_scancode;
using static SDL2.SDL_surface;

using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

using SDL_bool = System.Int32;

namespace SDL2
{
    public static class SDL_rect
    {


        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Point
        {

            public int x;
            public int y;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Rect
        {

            public int x, y;
            public int w, h;

        }

        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_HasIntersection(ref SDL_Rect A, ref SDL_Rect B);
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_IntersectRect(ref SDL_Rect A, ref SDL_Rect B, ref SDL_Rect result);
        [DllImport("libSDL2.so")]
        public static extern void SDL_UnionRect(ref SDL_Rect A, ref SDL_Rect B, ref SDL_Rect result);
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_EnclosePoints(ref SDL_Point points, int count, ref SDL_Rect clip, ref SDL_Rect result);
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_IntersectRectAndLine(ref SDL_Rect rect, ref int X1, ref int Y1, ref int X2, ref int Y2);

    }
}

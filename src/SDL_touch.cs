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

using static SDL2.SDL_version;
using static SDL2.SDL_video;

using SDL_TouchID = System.Int64;
using SDL_FingerID = System.Int64;

namespace SDL2
{
    public static class SDL_touch
    {


        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Finger
        {

            SDL_FingerID id;
            float x;
            float y;
            float pressure;

        }

        [DllImport("libSDL2.so")]
        public static extern int SDL_GetNumTouchDevices();
        [DllImport("libSDL2.so")]
        public static extern SDL_TouchID SDL_GetTouchDevice(int index);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetNumTouchFingers(SDL_TouchID touchID);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetTouchFinger(SDL_TouchID touchID, int index);

    }
}

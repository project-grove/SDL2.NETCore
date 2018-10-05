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
using NativeLibraryLoader;

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

        private delegate int SDL_GetNumTouchDevices__t();

        private static SDL_GetNumTouchDevices__t s_SDL_GetNumTouchDevices__t = __LoadFunction<SDL_GetNumTouchDevices__t>("SDL_GetNumTouchDevices");

        public static int SDL_GetNumTouchDevices() => s_SDL_GetNumTouchDevices__t();

        private delegate SDL_TouchID SDL_GetTouchDevice_int_t(int index);

        private static SDL_GetTouchDevice_int_t s_SDL_GetTouchDevice_int_t = __LoadFunction<SDL_GetTouchDevice_int_t>("SDL_GetTouchDevice");

        public static SDL_TouchID SDL_GetTouchDevice(int index) => s_SDL_GetTouchDevice_int_t(index);

        private delegate int SDL_GetNumTouchFingers_SDL_TouchID_t(SDL_TouchID touchID);

        private static SDL_GetNumTouchFingers_SDL_TouchID_t s_SDL_GetNumTouchFingers_SDL_TouchID_t = __LoadFunction<SDL_GetNumTouchFingers_SDL_TouchID_t>("SDL_GetNumTouchFingers");

        public static int SDL_GetNumTouchFingers(SDL_TouchID touchID) => s_SDL_GetNumTouchFingers_SDL_TouchID_t(touchID);

        private delegate IntPtr SDL_GetTouchFinger_SDL_TouchID_int_t(SDL_TouchID touchID, int index);

        private static SDL_GetTouchFinger_SDL_TouchID_int_t s_SDL_GetTouchFinger_SDL_TouchID_int_t = __LoadFunction<SDL_GetTouchFinger_SDL_TouchID_int_t>("SDL_GetTouchFinger");

        public static IntPtr SDL_GetTouchFinger(SDL_TouchID touchID, int index) => s_SDL_GetTouchFinger_SDL_TouchID_int_t(touchID, index);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


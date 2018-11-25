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
using SDL_TouchID = System.Int64;
using SDL_FingerID = System.Int64;
using SDL_GestureID = System.Int64;
using SDL_RWops = System.IntPtr;
using NativeLibraryLoader;

namespace SDL2
{
    public static class SDL_gesture
    {
        private delegate int SDL_RecordGesture_SDL_TouchID_t(SDL_TouchID touchId);

        private static SDL_RecordGesture_SDL_TouchID_t s_SDL_RecordGesture_SDL_TouchID_t = __LoadFunction<SDL_RecordGesture_SDL_TouchID_t>("SDL_RecordGesture");

        public static int SDL_RecordGesture(SDL_TouchID touchId) => s_SDL_RecordGesture_SDL_TouchID_t(touchId);

        private delegate int SDL_SaveAllDollarTemplates_SDL_RWops_t(IntPtr dst);

        private static SDL_SaveAllDollarTemplates_SDL_RWops_t s_SDL_SaveAllDollarTemplates_SDL_RWops_t = __LoadFunction<SDL_SaveAllDollarTemplates_SDL_RWops_t>("SDL_SaveAllDollarTemplates");

        public static int SDL_SaveAllDollarTemplates(IntPtr dst) => s_SDL_SaveAllDollarTemplates_SDL_RWops_t(dst);

        private delegate int SDL_SaveDollarTemplate_SDL_GestureID_SDL_RWops_t(SDL_GestureID gestureId, IntPtr dst);

        private static SDL_SaveDollarTemplate_SDL_GestureID_SDL_RWops_t s_SDL_SaveDollarTemplate_SDL_GestureID_SDL_RWops_t = __LoadFunction<SDL_SaveDollarTemplate_SDL_GestureID_SDL_RWops_t>("SDL_SaveDollarTemplate");

        public static int SDL_SaveDollarTemplate(SDL_GestureID gestureId, IntPtr dst) => s_SDL_SaveDollarTemplate_SDL_GestureID_SDL_RWops_t(gestureId, dst);

        private delegate int SDL_LoadDollarTemplates_SDL_TouchID_SDL_RWops_t(SDL_TouchID touchId, IntPtr src);

        private static SDL_LoadDollarTemplates_SDL_TouchID_SDL_RWops_t s_SDL_LoadDollarTemplates_SDL_TouchID_SDL_RWops_t = __LoadFunction<SDL_LoadDollarTemplates_SDL_TouchID_SDL_RWops_t>("SDL_LoadDollarTemplates");

        public static int SDL_LoadDollarTemplates(SDL_TouchID touchId, IntPtr src) => s_SDL_LoadDollarTemplates_SDL_TouchID_SDL_RWops_t(touchId, src);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


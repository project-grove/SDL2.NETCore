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
    public static class SDL_power
    {

        public enum SDL_PowerState
        {

            SDL_POWERSTATE_UNKNOWN,      /**< cannot determine power status */
            SDL_POWERSTATE_ON_BATTERY,   /**< Not plugged in, running on the battery */
            SDL_POWERSTATE_NO_BATTERY,   /**< Plugged in, no battery available */
            SDL_POWERSTATE_CHARGING,     /**< Plugged in, charging battery */
            SDL_POWERSTATE_CHARGED       /**< Plugged in, battery charged */

        }

        private delegate SDL_PowerState SDL_GetPowerInfo_int_int_t(ref int secs, ref int pct);

        private static SDL_GetPowerInfo_int_int_t s_SDL_GetPowerInfo_int_int_t = __LoadFunction<SDL_GetPowerInfo_int_int_t>("SDL_GetPowerInfo");

        public static SDL_PowerState SDL_GetPowerInfo(ref int secs, ref int pct) => s_SDL_GetPowerInfo_int_int_t(ref secs, ref pct);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


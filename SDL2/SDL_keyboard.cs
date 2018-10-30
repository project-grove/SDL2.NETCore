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
    public static class SDL_keyboard
    {


        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Keysym
        {

            public SDL_Scancode scancode;      /**< SDL physical key code - see ::SDL_Scancode for details */
            public SDL_Keycode sym;            /**< SDL virtual key code - see ::SDL_Keycode for details */
            public UInt16 mod;                 /**< current key modifiers */
            public UInt32 unused;

        }

        private delegate IntPtr SDL_GetKeyboardFocus__t();

        private static SDL_GetKeyboardFocus__t s_SDL_GetKeyboardFocus__t = __LoadFunction<SDL_GetKeyboardFocus__t>("SDL_GetKeyboardFocus");

        public static IntPtr SDL_GetKeyboardFocus() => s_SDL_GetKeyboardFocus__t();

        private delegate IntPtr SDL_GetKeyboardState_int_t(ref int numkeys);

        private static SDL_GetKeyboardState_int_t s_SDL_GetKeyboardState_int_t = __LoadFunction<SDL_GetKeyboardState_int_t>("SDL_GetKeyboardState");

        public static IntPtr SDL_GetKeyboardState(ref int numkeys) => s_SDL_GetKeyboardState_int_t(ref numkeys);

        private delegate SDL_Keymod SDL_GetModState__t();

        private static SDL_GetModState__t s_SDL_GetModState__t = __LoadFunction<SDL_GetModState__t>("SDL_GetModState");

        public static SDL_Keymod SDL_GetModState() => s_SDL_GetModState__t();

        private delegate void SDL_SetModState_SDL_Keymod_t(SDL_Keymod modstate);

        private static SDL_SetModState_SDL_Keymod_t s_SDL_SetModState_SDL_Keymod_t = __LoadFunction<SDL_SetModState_SDL_Keymod_t>("SDL_SetModState");

        public static void SDL_SetModState(SDL_Keymod modstate) => s_SDL_SetModState_SDL_Keymod_t(modstate);

        private delegate SDL_Keycode SDL_GetKeyFromScancode_SDL_Scancode_t(SDL_Scancode scancode);

        private static SDL_GetKeyFromScancode_SDL_Scancode_t s_SDL_GetKeyFromScancode_SDL_Scancode_t = __LoadFunction<SDL_GetKeyFromScancode_SDL_Scancode_t>("SDL_GetKeyFromScancode");

        public static SDL_Keycode SDL_GetKeyFromScancode(SDL_Scancode scancode) => s_SDL_GetKeyFromScancode_SDL_Scancode_t(scancode);

        private delegate SDL_Scancode SDL_GetScancodeFromKey_SDL_Keycode_t(SDL_Keycode key);

        private static SDL_GetScancodeFromKey_SDL_Keycode_t s_SDL_GetScancodeFromKey_SDL_Keycode_t = __LoadFunction<SDL_GetScancodeFromKey_SDL_Keycode_t>("SDL_GetScancodeFromKey");

        public static SDL_Scancode SDL_GetScancodeFromKey(SDL_Keycode key) => s_SDL_GetScancodeFromKey_SDL_Keycode_t(key);

        private delegate IntPtr SDL_GetScancodeName_SDL_Scancode_t(SDL_Scancode scancode);

        private static SDL_GetScancodeName_SDL_Scancode_t s_SDL_GetScancodeName_SDL_Scancode_t = __LoadFunction<SDL_GetScancodeName_SDL_Scancode_t>("SDL_GetScancodeName");

        public static IntPtr SDL_GetScancodeName(SDL_Scancode scancode) => s_SDL_GetScancodeName_SDL_Scancode_t(scancode);

        private delegate SDL_Scancode SDL_GetScancodeFromName_IntPtr_t(IntPtr name);

        private static SDL_GetScancodeFromName_IntPtr_t s_SDL_GetScancodeFromName_IntPtr_t = __LoadFunction<SDL_GetScancodeFromName_IntPtr_t>("SDL_GetScancodeFromName");

        public static SDL_Scancode SDL_GetScancodeFromName(IntPtr name) => s_SDL_GetScancodeFromName_IntPtr_t(name);

        private delegate IntPtr SDL_GetKeyName_SDL_Keycode_t(SDL_Keycode key);

        private static SDL_GetKeyName_SDL_Keycode_t s_SDL_GetKeyName_SDL_Keycode_t = __LoadFunction<SDL_GetKeyName_SDL_Keycode_t>("SDL_GetKeyName");

        public static IntPtr SDL_GetKeyName(SDL_Keycode key) => s_SDL_GetKeyName_SDL_Keycode_t(key);

        private delegate SDL_Keycode SDL_GetKeyFromName_IntPtr_t(IntPtr name);

        private static SDL_GetKeyFromName_IntPtr_t s_SDL_GetKeyFromName_IntPtr_t = __LoadFunction<SDL_GetKeyFromName_IntPtr_t>("SDL_GetKeyFromName");

        public static SDL_Keycode SDL_GetKeyFromName(IntPtr name) => s_SDL_GetKeyFromName_IntPtr_t(name);

        private delegate void SDL_StartTextInput__t();

        private static SDL_StartTextInput__t s_SDL_StartTextInput__t = __LoadFunction<SDL_StartTextInput__t>("SDL_StartTextInput");

        public static void SDL_StartTextInput() => s_SDL_StartTextInput__t();

        private delegate SDL_bool SDL_IsTextInputActive__t();

        private static SDL_IsTextInputActive__t s_SDL_IsTextInputActive__t = __LoadFunction<SDL_IsTextInputActive__t>("SDL_IsTextInputActive");

        public static SDL_bool SDL_IsTextInputActive() => s_SDL_IsTextInputActive__t();

        private delegate void SDL_StopTextInput__t();

        private static SDL_StopTextInput__t s_SDL_StopTextInput__t = __LoadFunction<SDL_StopTextInput__t>("SDL_StopTextInput");

        public static void SDL_StopTextInput() => s_SDL_StopTextInput__t();

        private delegate void SDL_SetTextInputRect_SDL_Rect_t(ref SDL_Rect rect);

        private static SDL_SetTextInputRect_SDL_Rect_t s_SDL_SetTextInputRect_SDL_Rect_t = __LoadFunction<SDL_SetTextInputRect_SDL_Rect_t>("SDL_SetTextInputRect");

        public static void SDL_SetTextInputRect(ref SDL_Rect rect) => s_SDL_SetTextInputRect_SDL_Rect_t(ref rect);

        private delegate SDL_bool SDL_HasScreenKeyboardSupport__t();

        private static SDL_HasScreenKeyboardSupport__t s_SDL_HasScreenKeyboardSupport__t = __LoadFunction<SDL_HasScreenKeyboardSupport__t>("SDL_HasScreenKeyboardSupport");

        public static SDL_bool SDL_HasScreenKeyboardSupport() => s_SDL_HasScreenKeyboardSupport__t();

        private delegate SDL_bool SDL_IsScreenKeyboardShown_IntPtr_t(IntPtr window);

        private static SDL_IsScreenKeyboardShown_IntPtr_t s_SDL_IsScreenKeyboardShown_IntPtr_t = __LoadFunction<SDL_IsScreenKeyboardShown_IntPtr_t>("SDL_IsScreenKeyboardShown");

        public static SDL_bool SDL_IsScreenKeyboardShown(IntPtr window) => s_SDL_IsScreenKeyboardShown_IntPtr_t(window);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


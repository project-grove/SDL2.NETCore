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

using SDL_Keycode = System.Int32;
using SDL_bool = System.Int32;

namespace SDL2
{
    public static class SDL_keyboard
    {


        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Keysym
        {

            SDL_Scancode scancode;      /**< SDL physical key code - see ::SDL_Scancode for details */
            SDL_Keycode sym;            /**< SDL virtual key code - see ::SDL_Keycode for details */
            UInt16 mod;                 /**< current key modifiers */
            UInt32 unused;

        }

        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetKeyboardFocus();
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetKeyboardState(ref int numkeys);
        [DllImport("libSDL2.so")]
        public static extern SDL_Keymod SDL_GetModState();
        [DllImport("libSDL2.so")]
        public static extern void SDL_SetModState(SDL_Keymod modstate);
        [DllImport("libSDL2.so")]
        public static extern SDL_Keycode SDL_GetKeyFromScancode(SDL_Scancode scancode);
        [DllImport("libSDL2.so")]
        public static extern SDL_Scancode SDL_GetScancodeFromKey(SDL_Keycode key);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetScancodeName(SDL_Scancode scancode);
        [DllImport("libSDL2.so")]
        public static extern SDL_Scancode SDL_GetScancodeFromName(IntPtr name);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetKeyName(SDL_Keycode key);
        [DllImport("libSDL2.so")]
        public static extern SDL_Keycode SDL_GetKeyFromName(IntPtr name);
        [DllImport("libSDL2.so")]
        public static extern void SDL_StartTextInput();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_IsTextInputActive();
        [DllImport("libSDL2.so")]
        public static extern void SDL_StopTextInput();
        [DllImport("libSDL2.so")]
        public static extern void SDL_SetTextInputRect(ref SDL_Rect rect);
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_HasScreenKeyboardSupport();
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_IsScreenKeyboardShown(IntPtr window);

    }
}

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
using static SDL2.SDL_timer;
using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

namespace SDL2
{
public static class SDL_keyboard
{


[StructLayout(LayoutKind.Sequential)]
public struct SDL_Keysym
{

    SDL_Scancode scancode;      /**< SDL physical key code - see ::SDL_Scancode for details */
    SDL_Keycode sym;            /**< SDL virtual key code - see ::SDL_Keycode for details */
    Uint16 mod;                 /**< current key modifiers */
    Uint32 unused;

}

[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetKeyboardFocus();
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetKeyboardState(ref int numkeys);
[DllImport("SDL2.dll")]
public static extern SDL_Keymod SDL_GetModState();
[DllImport("SDL2.dll")]
public static extern void SDL_SetModState(SDL_Keymod modstate);
[DllImport("SDL2.dll")]
public static extern SDL_Keycode SDL_GetKeyFromScancode(SDL_Scancode scancode);
[DllImport("SDL2.dll")]
public static extern SDL_Scancode SDL_GetScancodeFromKey(SDL_Keycode key);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetScancodeName(SDL_Scancode scancode);
[DllImport("SDL2.dll")]
public static extern SDL_Scancode SDL_GetScancodeFromName(IntPtr name);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetKeyName(SDL_Keycode key);
[DllImport("SDL2.dll")]
public static extern SDL_Keycode SDL_GetKeyFromName(IntPtr name);
[DllImport("SDL2.dll")]
public static extern void SDL_StartTextInput();
[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_IsTextInputActive();
[DllImport("SDL2.dll")]
public static extern void SDL_StopTextInput();
[DllImport("SDL2.dll")]
public static extern void SDL_SetTextInputRect(ref SDL_Rect rect);
[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_HasScreenKeyboardSupport();
[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_IsScreenKeyboardShown(ref SDL_Window window);

}
}

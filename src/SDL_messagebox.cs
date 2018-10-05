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
public static class SDL_messagebox
{

public enum SDL_MessageBoxFlags
{

    SDL_MESSAGEBOX_ERROR        = 0x00000010,   /**< error dialog */
    SDL_MESSAGEBOX_WARNING      = 0x00000020,   /**< warning dialog */
    SDL_MESSAGEBOX_INFORMATION  = 0x00000040    /**< informational dialog */

}
public enum SDL_MessageBoxButtonFlags
{

    SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT = 0x00000001,  /**< Marks the default button when return is hit */
    SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT = 0x00000002   /**< Marks the default button when escape is hit */

}
public enum SDL_MessageBoxColorType
{

    SDL_MESSAGEBOX_COLOR_BACKGROUND,
    SDL_MESSAGEBOX_COLOR_TEXT,
    SDL_MESSAGEBOX_COLOR_BUTTON_BORDER,
    SDL_MESSAGEBOX_COLOR_BUTTON_BACKGROUND,
    SDL_MESSAGEBOX_COLOR_BUTTON_SELECTED,
    SDL_MESSAGEBOX_COLOR_MAX

}

[StructLayout(LayoutKind.Sequential)]
public struct SDL_MessageBoxButtonData
{

    Uint32 flags;       /**< ::SDL_MessageBoxButtonFlags */
    int buttonid;       /**< User defined button id (value returned via SDL_ShowMessageBox) */
    const char * text;  /**< The UTF-8 button text */

}
[StructLayout(LayoutKind.Sequential)]
public struct SDL_MessageBoxColor
{

    Uint8 r, g, b;

}
[StructLayout(LayoutKind.Sequential)]
public struct SDL_MessageBoxColorScheme
{

    SDL_MessageBoxColor colors[SDL_MESSAGEBOX_COLOR_MAX];

}
[StructLayout(LayoutKind.Sequential)]
public struct SDL_MessageBoxData
{

    Uint32 flags;                       /**< ::SDL_MessageBoxFlags */
    SDL_Window *window;                 /**< Parent window, can be NULL */
    const char *title;                  /**< UTF-8 title */
    const char *message;                /**< UTF-8 message text */

    int numbuttons;
    const SDL_MessageBoxButtonData *buttons;

    const SDL_MessageBoxColorScheme *colorScheme;   /**< ::SDL_MessageBoxColorScheme, can be NULL to use system settings */

}

[DllImport("SDL2.dll")]
public static extern int SDL_ShowMessageBox(ref SDL_MessageBoxData messageboxdata, ref int buttonid);
[DllImport("SDL2.dll")]
public static extern int SDL_ShowSimpleMessageBox(Uint32 flags, IntPtr title, IntPtr message, ref SDL_Window window);

}
}

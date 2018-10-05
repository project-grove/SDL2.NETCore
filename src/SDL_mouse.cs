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
    public static class SDL_mouse
    {
        public const int SDL_BUTTON_LEFT = 1;
        public const int SDL_BUTTON_MIDDLE = 2;
        public const int SDL_BUTTON_RIGHT = 3;
        public const int SDL_BUTTON_X1 = 4;
        public const int SDL_BUTTON_X2 = 5;

        public enum SDL_SystemCursor
        {

            SDL_SYSTEM_CURSOR_ARROW,     /**< Arrow */
            SDL_SYSTEM_CURSOR_IBEAM,     /**< I-beam */
            SDL_SYSTEM_CURSOR_WAIT,      /**< Wait */
            SDL_SYSTEM_CURSOR_CROSSHAIR, /**< Crosshair */
            SDL_SYSTEM_CURSOR_WAITARROW, /**< Small wait cursor (or Wait if not available) */
            SDL_SYSTEM_CURSOR_SIZENWSE,  /**< Double arrow pointing northwest and southeast */
            SDL_SYSTEM_CURSOR_SIZENESW,  /**< Double arrow pointing northeast and southwest */
            SDL_SYSTEM_CURSOR_SIZEWE,    /**< Double arrow pointing west and east */
            SDL_SYSTEM_CURSOR_SIZENS,    /**< Double arrow pointing north and south */
            SDL_SYSTEM_CURSOR_SIZEALL,   /**< Four pointed arrow pointing north, south, east, and west */
            SDL_SYSTEM_CURSOR_NO,        /**< Slashed circle or crossbones */
            SDL_SYSTEM_CURSOR_HAND,      /**< Hand */
            SDL_NUM_SYSTEM_CURSORS

        }


        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetMouseFocus();
        [DllImport("libSDL2.so")]
        public static extern uint SDL_GetMouseState(ref int x, ref int y);
        [DllImport("libSDL2.so")]
        public static extern uint SDL_GetRelativeMouseState(ref int x, ref int y);
        [DllImport("libSDL2.so")]
        public static extern void SDL_WarpMouseInWindow(IntPtr window, int x, int y);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetRelativeMouseMode(SDL_bool enabled);
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_GetRelativeMouseMode();
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_CreateCursor(ref byte data, ref byte mask, int w, int h, int hot_x, int hot_y);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_CreateColorCursor(ref SDL_Surface surface, int hot_x, int hot_y);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_CreateSystemCursor(SDL_SystemCursor id);
        [DllImport("libSDL2.so")]
        public static extern void SDL_SetCursor(IntPtr cursor);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetCursor();
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetDefaultCursor();
        [DllImport("libSDL2.so")]
        public static extern void SDL_FreeCursor(IntPtr cursor);
        [DllImport("libSDL2.so")]
        public static extern int SDL_ShowCursor(int toggle);

    }
}

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
using NativeLibraryLoader;

namespace SDL2
{
    public static class SDL_mouse
    {
        public const int SDL_BUTTON_LEFT = 1;
        public const int SDL_BUTTON_MIDDLE = 2;
        public const int SDL_BUTTON_RIGHT = 3;
        public const int SDL_BUTTON_X1 = 4;
        public const int SDL_BUTTON_X2 = 5;

        [Flags]
        public enum SDL_MouseButton : uint
        {
            SDL_BUTTON_LEFT = 0x1,
            SDL_BUTTON_MIDDLE = 0x2,
            SDL_BUTTON_RIGHT = 0x4,
            SDL_BUTTON_X1 = 0x8,
            SDL_BUTTON_X2 = 0xF
        }

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

        private delegate IntPtr SDL_GetMouseFocus__t();

        private static SDL_GetMouseFocus__t s_SDL_GetMouseFocus__t = __LoadFunction<SDL_GetMouseFocus__t>("SDL_GetMouseFocus");

        public static IntPtr SDL_GetMouseFocus() => s_SDL_GetMouseFocus__t();

        private delegate uint SDL_GetMouseState_int_int_t(ref int x, ref int y);

        private static SDL_GetMouseState_int_int_t s_SDL_GetMouseState_int_int_t = __LoadFunction<SDL_GetMouseState_int_int_t>("SDL_GetMouseState");

        public static uint SDL_GetMouseState(ref int x, ref int y) => s_SDL_GetMouseState_int_int_t(ref x, ref y);

        private delegate uint SDL_GetRelativeMouseState_int_int_t(ref int x, ref int y);

        private static SDL_GetRelativeMouseState_int_int_t s_SDL_GetRelativeMouseState_int_int_t = __LoadFunction<SDL_GetRelativeMouseState_int_int_t>("SDL_GetRelativeMouseState");

        public static uint SDL_GetRelativeMouseState(ref int x, ref int y) => s_SDL_GetRelativeMouseState_int_int_t(ref x, ref y);

        private delegate void SDL_WarpMouseInWindow_IntPtr_int_int_t(IntPtr window, int x, int y);

        private static SDL_WarpMouseInWindow_IntPtr_int_int_t s_SDL_WarpMouseInWindow_IntPtr_int_int_t = __LoadFunction<SDL_WarpMouseInWindow_IntPtr_int_int_t>("SDL_WarpMouseInWindow");

        public static void SDL_WarpMouseInWindow(IntPtr window, int x, int y) => s_SDL_WarpMouseInWindow_IntPtr_int_int_t(window, x, y);

        private delegate int SDL_SetRelativeMouseMode_SDL_bool_t(SDL_bool enabled);

        private static SDL_SetRelativeMouseMode_SDL_bool_t s_SDL_SetRelativeMouseMode_SDL_bool_t = __LoadFunction<SDL_SetRelativeMouseMode_SDL_bool_t>("SDL_SetRelativeMouseMode");

        public static int SDL_SetRelativeMouseMode(SDL_bool enabled) => s_SDL_SetRelativeMouseMode_SDL_bool_t(enabled);

        private delegate SDL_bool SDL_GetRelativeMouseMode__t();

        private static SDL_GetRelativeMouseMode__t s_SDL_GetRelativeMouseMode__t = __LoadFunction<SDL_GetRelativeMouseMode__t>("SDL_GetRelativeMouseMode");

        public static SDL_bool SDL_GetRelativeMouseMode() => s_SDL_GetRelativeMouseMode__t();

        private delegate IntPtr SDL_CreateCursor_byte_byte_int_int_int_int_t(ref byte data, ref byte mask, int w, int h, int hot_x, int hot_y);

        private static SDL_CreateCursor_byte_byte_int_int_int_int_t s_SDL_CreateCursor_byte_byte_int_int_int_int_t = __LoadFunction<SDL_CreateCursor_byte_byte_int_int_int_int_t>("SDL_CreateCursor");

        public static IntPtr SDL_CreateCursor(ref byte data, ref byte mask, int w, int h, int hot_x, int hot_y) => s_SDL_CreateCursor_byte_byte_int_int_int_int_t(ref data, ref mask, w, h, hot_x, hot_y);

        private delegate IntPtr SDL_CreateColorCursor_SDL_Surface_int_int_t(ref SDL_Surface surface, int hot_x, int hot_y);

        private static SDL_CreateColorCursor_SDL_Surface_int_int_t s_SDL_CreateColorCursor_SDL_Surface_int_int_t = __LoadFunction<SDL_CreateColorCursor_SDL_Surface_int_int_t>("SDL_CreateColorCursor");

        public static IntPtr SDL_CreateColorCursor(ref SDL_Surface surface, int hot_x, int hot_y) => s_SDL_CreateColorCursor_SDL_Surface_int_int_t(ref surface, hot_x, hot_y);

        private delegate IntPtr SDL_CreateSystemCursor_SDL_SystemCursor_t(SDL_SystemCursor id);

        private static SDL_CreateSystemCursor_SDL_SystemCursor_t s_SDL_CreateSystemCursor_SDL_SystemCursor_t = __LoadFunction<SDL_CreateSystemCursor_SDL_SystemCursor_t>("SDL_CreateSystemCursor");

        public static IntPtr SDL_CreateSystemCursor(SDL_SystemCursor id) => s_SDL_CreateSystemCursor_SDL_SystemCursor_t(id);

        private delegate void SDL_SetCursor_IntPtr_t(IntPtr cursor);

        private static SDL_SetCursor_IntPtr_t s_SDL_SetCursor_IntPtr_t = __LoadFunction<SDL_SetCursor_IntPtr_t>("SDL_SetCursor");

        public static void SDL_SetCursor(IntPtr cursor) => s_SDL_SetCursor_IntPtr_t(cursor);

        private delegate IntPtr SDL_GetCursor__t();

        private static SDL_GetCursor__t s_SDL_GetCursor__t = __LoadFunction<SDL_GetCursor__t>("SDL_GetCursor");

        public static IntPtr SDL_GetCursor() => s_SDL_GetCursor__t();

        private delegate IntPtr SDL_GetDefaultCursor__t();

        private static SDL_GetDefaultCursor__t s_SDL_GetDefaultCursor__t = __LoadFunction<SDL_GetDefaultCursor__t>("SDL_GetDefaultCursor");

        public static IntPtr SDL_GetDefaultCursor() => s_SDL_GetDefaultCursor__t();

        private delegate void SDL_FreeCursor_IntPtr_t(IntPtr cursor);

        private static SDL_FreeCursor_IntPtr_t s_SDL_FreeCursor_IntPtr_t = __LoadFunction<SDL_FreeCursor_IntPtr_t>("SDL_FreeCursor");

        public static void SDL_FreeCursor(IntPtr cursor) => s_SDL_FreeCursor_IntPtr_t(cursor);

        private delegate int SDL_ShowCursor_int_t(int toggle);

        private static SDL_ShowCursor_int_t s_SDL_ShowCursor_int_t = __LoadFunction<SDL_ShowCursor_int_t>("SDL_ShowCursor");

        public static int SDL_ShowCursor(int toggle) => s_SDL_ShowCursor_int_t(toggle);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


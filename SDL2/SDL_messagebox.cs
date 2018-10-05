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

using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;
using NativeLibraryLoader;

namespace SDL2
{
    public static class SDL_messagebox
    {

        public enum SDL_MessageBoxFlags
        {

            SDL_MESSAGEBOX_ERROR = 0x00000010,   /**< error dialog */
            SDL_MESSAGEBOX_WARNING = 0x00000020,   /**< warning dialog */
            SDL_MESSAGEBOX_INFORMATION = 0x00000040    /**< informational dialog */

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

            public UInt32 flags;       /**< ::SDL_MessageBoxButtonFlags */
            public int buttonid;       /**< User defined button id (value returned via SDL_ShowMessageBox) */
            public IntPtr text;  /**< The UTF-8 button text */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MessageBoxColor
        {

            public byte r, g, b;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MessageBoxColorScheme
        {
            public unsafe fixed byte colors[15];
            // SDL_MessageBoxColor colors[SDL_MESSAGEBOX_COLOR_MAX];
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MessageBoxData
        {

            public UInt32 flags;                       /**< ::SDL_MessageBoxFlags */
            public IntPtr window;                 /**< Parent window, can be NULL */
            public IntPtr title;                  /**< UTF-8 title */
            public IntPtr message;                /**< UTF-8 message text */

            public int numbuttons;
            public IntPtr buttons;

            public IntPtr colorScheme;   /**< ::SDL_MessageBoxColorScheme, can be NULL to use system settings */

        }

        private delegate int SDL_ShowMessageBox_SDL_MessageBoxData_int_t(ref SDL_MessageBoxData messageboxdata, ref int buttonid);

        private static SDL_ShowMessageBox_SDL_MessageBoxData_int_t s_SDL_ShowMessageBox_SDL_MessageBoxData_int_t = __LoadFunction<SDL_ShowMessageBox_SDL_MessageBoxData_int_t>("SDL_ShowMessageBox");

        public static int SDL_ShowMessageBox(ref SDL_MessageBoxData messageboxdata, ref int buttonid) => s_SDL_ShowMessageBox_SDL_MessageBoxData_int_t(ref messageboxdata, ref buttonid);

        private delegate int SDL_ShowSimpleMessageBox_UInt32_IntPtr_IntPtr_IntPtr_t(UInt32 flags, IntPtr title, IntPtr message, IntPtr window);

        private static SDL_ShowSimpleMessageBox_UInt32_IntPtr_IntPtr_IntPtr_t s_SDL_ShowSimpleMessageBox_UInt32_IntPtr_IntPtr_IntPtr_t = __LoadFunction<SDL_ShowSimpleMessageBox_UInt32_IntPtr_IntPtr_IntPtr_t>("SDL_ShowSimpleMessageBox");

        public static int SDL_ShowSimpleMessageBox(UInt32 flags, IntPtr title, IntPtr message, IntPtr window) => s_SDL_ShowSimpleMessageBox_UInt32_IntPtr_IntPtr_IntPtr_t(flags, title, message, window);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


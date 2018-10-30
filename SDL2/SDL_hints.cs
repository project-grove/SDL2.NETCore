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

using SDL_HintCallback = System.IntPtr;
using SDL_bool = System.Int32;
using NativeLibraryLoader;
using SDL2.Internal;

namespace SDL2
{
    public static class SDL_hints
    {
        public const string SDL_HINT_FRAMEBUFFER_ACCELERATION = "SDL_FRAMEBUFFER_ACCELERATION";
        public const string SDL_HINT_RENDER_DRIVER = "SDL_RENDER_DRIVER";
        public const string SDL_HINT_RENDER_OPENGL_SHADERS = "SDL_RENDER_OPENGL_SHADERS";
        public const string SDL_HINT_RENDER_DIRECT3D_THREADSAFE = "SDL_RENDER_DIRECT3D_THREADSAFE";
        public const string SDL_HINT_RENDER_SCALE_QUALITY = "SDL_RENDER_SCALE_QUALITY";
        public const string SDL_HINT_RENDER_VSYNC = "SDL_RENDER_VSYNC";
        public const string SDL_HINT_VIDEO_ALLOW_SCREENSAVER = "SDL_VIDEO_ALLOW_SCREENSAVER";
        public const string SDL_HINT_VIDEO_X11_XVIDMODE = "SDL_VIDEO_X11_XVIDMODE";
        public const string SDL_HINT_VIDEO_X11_XINERAMA = "SDL_VIDEO_X11_XINERAMA";
        public const string SDL_HINT_VIDEO_X11_XRANDR = "SDL_VIDEO_X11_XRANDR";
        public const string SDL_HINT_GRAB_KEYBOARD = "SDL_GRAB_KEYBOARD";
        public const string SDL_HINT_MOUSE_RELATIVE_MODE_WARP = "SDL_MOUSE_RELATIVE_MODE_WARP";
        public const string SDL_HINT_VIDEO_MINIMIZE_ON_FOCUS_LOSS = "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";
        public const string SDL_HINT_IDLE_TIMER_DISABLED = "SDL_IOS_IDLE_TIMER_DISABLED";
        public const string SDL_HINT_ORIENTATIONS = "SDL_IOS_ORIENTATIONS";
        public const string SDL_HINT_ACCELEROMETER_AS_JOYSTICK = "SDL_ACCELEROMETER_AS_JOYSTICK";
        public const string SDL_HINT_XINPUT_ENABLED = "SDL_XINPUT_ENABLED";
        public const string SDL_HINT_GAMECONTROLLERCONFIG = "SDL_GAMECONTROLLERCONFIG";
        public const string SDL_HINT_JOYSTICK_ALLOW_BACKGROUND_EVENTS = "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";
        public const string SDL_HINT_ALLOW_TOPMOST = "SDL_ALLOW_TOPMOST";
        public const string SDL_HINT_TIMER_RESOLUTION = "SDL_TIMER_RESOLUTION";
        public const string SDL_HINT_VIDEO_HIGHDPI_DISABLED = "SDL_VIDEO_HIGHDPI_DISABLED";
        public const string SDL_HINT_MAC_CTRL_CLICK_EMULATE_RIGHT_CLICK = "SDL_MAC_CTRL_CLICK_EMULATE_RIGHT_CLICK";
        public const string SDL_HINT_VIDEO_WIN_D3DCOMPILER = "SDL_VIDEO_WIN_D3DCOMPILER";
        public const string SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT = "SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";
        public const string SDL_HINT_VIDEO_MAC_FULLSCREEN_SPACES = "SDL_VIDEO_MAC_FULLSCREEN_SPACES";

        public enum SDL_HintPriority
        {

            SDL_HINT_DEFAULT,
            SDL_HINT_NORMAL,
            SDL_HINT_OVERRIDE

        }

        private delegate SDL_bool SDL_SetHintWithPriority_IntPtr_IntPtr_SDL_HintPriority_t(IntPtr name, IntPtr value, SDL_HintPriority priority);

        private static SDL_SetHintWithPriority_IntPtr_IntPtr_SDL_HintPriority_t s_SDL_SetHintWithPriority_IntPtr_IntPtr_SDL_HintPriority_t = __LoadFunction<SDL_SetHintWithPriority_IntPtr_IntPtr_SDL_HintPriority_t>("SDL_SetHintWithPriority");

        private static SDL_bool _SDL_SetHintWithPriority(IntPtr name, IntPtr value, SDL_HintPriority priority) => s_SDL_SetHintWithPriority_IntPtr_IntPtr_SDL_HintPriority_t(name, value, priority);

        public static SDL_bool SDL_SetHintWithPriority(string name, string value, SDL_HintPriority priority)
        {
            var n = Util.StringToHGlobalUTF8(name);
            var v = Util.StringToHGlobalUTF8(value);
            var result = _SDL_SetHintWithPriority(n, v, priority);
            Marshal.FreeHGlobal(n);
            Marshal.FreeHGlobal(v);
            return result;
        }

        private delegate SDL_bool SDL_SetHint_IntPtr_IntPtr_t(IntPtr name, IntPtr value);

        private static SDL_SetHint_IntPtr_IntPtr_t s_SDL_SetHint_IntPtr_IntPtr_t = __LoadFunction<SDL_SetHint_IntPtr_IntPtr_t>("SDL_SetHint");

        private static SDL_bool _SDL_SetHint(IntPtr name, IntPtr value) => s_SDL_SetHint_IntPtr_IntPtr_t(name, value);

        public static SDL_bool SDL_SetHint(string name, string value)
        {
            var n = Util.StringToHGlobalUTF8(name);
            var v = Util.StringToHGlobalUTF8(value);
            var result = _SDL_SetHint(n, v);
            Marshal.FreeHGlobal(n);
            Marshal.FreeHGlobal(v);
            return result;
        }

        private delegate IntPtr SDL_GetHint_IntPtr_t(IntPtr name);

        private static SDL_GetHint_IntPtr_t s_SDL_GetHint_IntPtr_t = __LoadFunction<SDL_GetHint_IntPtr_t>("SDL_GetHint");

        private static IntPtr _SDL_GetHint(IntPtr name) => s_SDL_GetHint_IntPtr_t(name);

        public static unsafe string SDL_GetHint(string name)
        {
            var n = Util.StringToHGlobalUTF8(name);
            try
            {
                var r = _SDL_GetHint(n);
                if (r == IntPtr.Zero) return null;
                return Marshal.PtrToStringAnsi(r);
            }
            finally
            {
                Marshal.FreeHGlobal(n);
            }
        }

        private delegate void SDL_AddHintCallback_IntPtr_SDL_HintCallback_IntPtr_t(IntPtr name, SDL_HintCallback callback, IntPtr userdata);

        private static SDL_AddHintCallback_IntPtr_SDL_HintCallback_IntPtr_t s_SDL_AddHintCallback_IntPtr_SDL_HintCallback_IntPtr_t = __LoadFunction<SDL_AddHintCallback_IntPtr_SDL_HintCallback_IntPtr_t>("SDL_AddHintCallback");

        public static void SDL_AddHintCallback(IntPtr name, SDL_HintCallback callback, IntPtr userdata) => s_SDL_AddHintCallback_IntPtr_SDL_HintCallback_IntPtr_t(name, callback, userdata);

        private delegate void SDL_DelHintCallback_IntPtr_SDL_HintCallback_IntPtr_t(IntPtr name, SDL_HintCallback callback, IntPtr userdata);

        private static SDL_DelHintCallback_IntPtr_SDL_HintCallback_IntPtr_t s_SDL_DelHintCallback_IntPtr_SDL_HintCallback_IntPtr_t = __LoadFunction<SDL_DelHintCallback_IntPtr_SDL_HintCallback_IntPtr_t>("SDL_DelHintCallback");

        public static void SDL_DelHintCallback(IntPtr name, SDL_HintCallback callback, IntPtr userdata) => s_SDL_DelHintCallback_IntPtr_SDL_HintCallback_IntPtr_t(name, callback, userdata);

        private delegate void SDL_ClearHints__t();

        private static SDL_ClearHints__t s_SDL_ClearHints__t = __LoadFunction<SDL_ClearHints__t>("SDL_ClearHints");

        public static void SDL_ClearHints() => s_SDL_ClearHints__t();
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


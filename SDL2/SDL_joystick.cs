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
using SDL_JoystickID = System.Int32;
using NativeLibraryLoader;

namespace SDL2
{
    public static class SDL_joystick
    {
        public const int SDL_HAT_CENTERED = 0x00;
        public const int SDL_HAT_UP = 0x01;
        public const int SDL_HAT_RIGHT = 0x02;
        public const int SDL_HAT_DOWN = 0x04;
        public const int SDL_HAT_LEFT = 0x08;
        public const int SDL_HAT_RIGHTUP = SDL_HAT_RIGHT | SDL_HAT_UP;
        public const int SDL_HAT_RIGHTDOWN = SDL_HAT_RIGHT | SDL_HAT_DOWN;
        public const int SDL_HAT_LEFTUP = SDL_HAT_LEFT | SDL_HAT_UP;
        public const int SDL_HAT_LEFTDOWN = SDL_HAT_LEFT | SDL_HAT_DOWN;


        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoystickGUID
        {
            public unsafe fixed byte guid[16];
        }

        private delegate int SDL_NumJoysticks__t();

        private static SDL_NumJoysticks__t s_SDL_NumJoysticks__t = __LoadFunction<SDL_NumJoysticks__t>("SDL_NumJoysticks");

        public static int SDL_NumJoysticks() => s_SDL_NumJoysticks__t();

        private delegate IntPtr SDL_JoystickNameForIndex_int_t(int device_index);

        private static SDL_JoystickNameForIndex_int_t s_SDL_JoystickNameForIndex_int_t = __LoadFunction<SDL_JoystickNameForIndex_int_t>("SDL_JoystickNameForIndex");

        public static IntPtr SDL_JoystickNameForIndex(int device_index) => s_SDL_JoystickNameForIndex_int_t(device_index);

        private delegate IntPtr SDL_JoystickOpen_int_t(int device_index);

        private static SDL_JoystickOpen_int_t s_SDL_JoystickOpen_int_t = __LoadFunction<SDL_JoystickOpen_int_t>("SDL_JoystickOpen");

        public static IntPtr SDL_JoystickOpen(int device_index) => s_SDL_JoystickOpen_int_t(device_index);

        private delegate IntPtr SDL_JoystickName_IntPtr_t(IntPtr joystick);

        private static SDL_JoystickName_IntPtr_t s_SDL_JoystickName_IntPtr_t = __LoadFunction<SDL_JoystickName_IntPtr_t>("SDL_JoystickName");

        public static IntPtr SDL_JoystickName(IntPtr joystick) => s_SDL_JoystickName_IntPtr_t(joystick);

        private delegate SDL_JoystickGUID SDL_JoystickGetDeviceGUID_int_t(int device_index);

        private static SDL_JoystickGetDeviceGUID_int_t s_SDL_JoystickGetDeviceGUID_int_t = __LoadFunction<SDL_JoystickGetDeviceGUID_int_t>("SDL_JoystickGetDeviceGUID");

        public static SDL_JoystickGUID SDL_JoystickGetDeviceGUID(int device_index) => s_SDL_JoystickGetDeviceGUID_int_t(device_index);

        private delegate SDL_JoystickGUID SDL_JoystickGetGUID_IntPtr_t(IntPtr joystick);

        private static SDL_JoystickGetGUID_IntPtr_t s_SDL_JoystickGetGUID_IntPtr_t = __LoadFunction<SDL_JoystickGetGUID_IntPtr_t>("SDL_JoystickGetGUID");

        public static SDL_JoystickGUID SDL_JoystickGetGUID(IntPtr joystick) => s_SDL_JoystickGetGUID_IntPtr_t(joystick);

        private delegate void SDL_JoystickGetGUIDString_SDL_JoystickGUID_IntPtr_int_t(SDL_JoystickGUID guid, IntPtr pszGUID, int cbGUID);

        private static SDL_JoystickGetGUIDString_SDL_JoystickGUID_IntPtr_int_t s_SDL_JoystickGetGUIDString_SDL_JoystickGUID_IntPtr_int_t = __LoadFunction<SDL_JoystickGetGUIDString_SDL_JoystickGUID_IntPtr_int_t>("SDL_JoystickGetGUIDString");

        public static void SDL_JoystickGetGUIDString(SDL_JoystickGUID guid, IntPtr pszGUID, int cbGUID) => s_SDL_JoystickGetGUIDString_SDL_JoystickGUID_IntPtr_int_t(guid, pszGUID, cbGUID);

        private delegate SDL_JoystickGUID SDL_JoystickGetGUIDFromString_IntPtr_t(IntPtr pchGUID);

        private static SDL_JoystickGetGUIDFromString_IntPtr_t s_SDL_JoystickGetGUIDFromString_IntPtr_t = __LoadFunction<SDL_JoystickGetGUIDFromString_IntPtr_t>("SDL_JoystickGetGUIDFromString");

        public static SDL_JoystickGUID SDL_JoystickGetGUIDFromString(IntPtr pchGUID) => s_SDL_JoystickGetGUIDFromString_IntPtr_t(pchGUID);

        private delegate SDL_bool SDL_JoystickGetAttached_IntPtr_t(IntPtr joystick);

        private static SDL_JoystickGetAttached_IntPtr_t s_SDL_JoystickGetAttached_IntPtr_t = __LoadFunction<SDL_JoystickGetAttached_IntPtr_t>("SDL_JoystickGetAttached");

        public static SDL_bool SDL_JoystickGetAttached(IntPtr joystick) => s_SDL_JoystickGetAttached_IntPtr_t(joystick);

        private delegate SDL_JoystickID SDL_JoystickInstanceID_IntPtr_t(IntPtr joystick);

        private static SDL_JoystickInstanceID_IntPtr_t s_SDL_JoystickInstanceID_IntPtr_t = __LoadFunction<SDL_JoystickInstanceID_IntPtr_t>("SDL_JoystickInstanceID");

        public static SDL_JoystickID SDL_JoystickInstanceID(IntPtr joystick) => s_SDL_JoystickInstanceID_IntPtr_t(joystick);

        private delegate int SDL_JoystickNumAxes_IntPtr_t(IntPtr joystick);

        private static SDL_JoystickNumAxes_IntPtr_t s_SDL_JoystickNumAxes_IntPtr_t = __LoadFunction<SDL_JoystickNumAxes_IntPtr_t>("SDL_JoystickNumAxes");

        public static int SDL_JoystickNumAxes(IntPtr joystick) => s_SDL_JoystickNumAxes_IntPtr_t(joystick);

        private delegate int SDL_JoystickNumBalls_IntPtr_t(IntPtr joystick);

        private static SDL_JoystickNumBalls_IntPtr_t s_SDL_JoystickNumBalls_IntPtr_t = __LoadFunction<SDL_JoystickNumBalls_IntPtr_t>("SDL_JoystickNumBalls");

        public static int SDL_JoystickNumBalls(IntPtr joystick) => s_SDL_JoystickNumBalls_IntPtr_t(joystick);

        private delegate int SDL_JoystickNumHats_IntPtr_t(IntPtr joystick);

        private static SDL_JoystickNumHats_IntPtr_t s_SDL_JoystickNumHats_IntPtr_t = __LoadFunction<SDL_JoystickNumHats_IntPtr_t>("SDL_JoystickNumHats");

        public static int SDL_JoystickNumHats(IntPtr joystick) => s_SDL_JoystickNumHats_IntPtr_t(joystick);

        private delegate int SDL_JoystickNumButtons_IntPtr_t(IntPtr joystick);

        private static SDL_JoystickNumButtons_IntPtr_t s_SDL_JoystickNumButtons_IntPtr_t = __LoadFunction<SDL_JoystickNumButtons_IntPtr_t>("SDL_JoystickNumButtons");

        public static int SDL_JoystickNumButtons(IntPtr joystick) => s_SDL_JoystickNumButtons_IntPtr_t(joystick);

        private delegate void SDL_JoystickUpdate__t();

        private static SDL_JoystickUpdate__t s_SDL_JoystickUpdate__t = __LoadFunction<SDL_JoystickUpdate__t>("SDL_JoystickUpdate");

        public static void SDL_JoystickUpdate() => s_SDL_JoystickUpdate__t();

        private delegate int SDL_JoystickEventState_int_t(int state);

        private static SDL_JoystickEventState_int_t s_SDL_JoystickEventState_int_t = __LoadFunction<SDL_JoystickEventState_int_t>("SDL_JoystickEventState");

        public static int SDL_JoystickEventState(int state) => s_SDL_JoystickEventState_int_t(state);

        private delegate short SDL_JoystickGetAxis_IntPtr_int_t(IntPtr joystick, int axis);

        private static SDL_JoystickGetAxis_IntPtr_int_t s_SDL_JoystickGetAxis_IntPtr_int_t = __LoadFunction<SDL_JoystickGetAxis_IntPtr_int_t>("SDL_JoystickGetAxis");

        public static short SDL_JoystickGetAxis(IntPtr joystick, int axis) => s_SDL_JoystickGetAxis_IntPtr_int_t(joystick, axis);

        private delegate byte SDL_JoystickGetHat_IntPtr_int_t(IntPtr joystick, int hat);

        private static SDL_JoystickGetHat_IntPtr_int_t s_SDL_JoystickGetHat_IntPtr_int_t = __LoadFunction<SDL_JoystickGetHat_IntPtr_int_t>("SDL_JoystickGetHat");

        public static byte SDL_JoystickGetHat(IntPtr joystick, int hat) => s_SDL_JoystickGetHat_IntPtr_int_t(joystick, hat);

        private delegate int SDL_JoystickGetBall_IntPtr_int_int_int_t(IntPtr joystick, int ball, ref int dx, ref int dy);

        private static SDL_JoystickGetBall_IntPtr_int_int_int_t s_SDL_JoystickGetBall_IntPtr_int_int_int_t = __LoadFunction<SDL_JoystickGetBall_IntPtr_int_int_int_t>("SDL_JoystickGetBall");

        public static int SDL_JoystickGetBall(IntPtr joystick, int ball, ref int dx, ref int dy) => s_SDL_JoystickGetBall_IntPtr_int_int_int_t(joystick, ball, ref dx, ref dy);

        private delegate byte SDL_JoystickGetButton_IntPtr_int_t(IntPtr joystick, int button);

        private static SDL_JoystickGetButton_IntPtr_int_t s_SDL_JoystickGetButton_IntPtr_int_t = __LoadFunction<SDL_JoystickGetButton_IntPtr_int_t>("SDL_JoystickGetButton");

        public static byte SDL_JoystickGetButton(IntPtr joystick, int button) => s_SDL_JoystickGetButton_IntPtr_int_t(joystick, button);

        private delegate void SDL_JoystickClose_IntPtr_t(IntPtr joystick);

        private static SDL_JoystickClose_IntPtr_t s_SDL_JoystickClose_IntPtr_t = __LoadFunction<SDL_JoystickClose_IntPtr_t>("SDL_JoystickClose");

        public static void SDL_JoystickClose(IntPtr joystick) => s_SDL_JoystickClose_IntPtr_t(joystick);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


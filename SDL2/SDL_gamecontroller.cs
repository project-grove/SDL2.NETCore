using System;
using System.Runtime.InteropServices;

using SDL2;
using static SDL2.SDL_audio;
using static SDL2.SDL_blendmode;
using static SDL2.SDL_clipboard;
using static SDL2.SDL_cpuinfo;
using static SDL2.SDL_error;
using static SDL2.SDL_events;
using static SDL2.SDL_gesture;
using static SDL2.SDL_haptic;
using static SDL2.SDL_hints;

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

using SDL_RWops = System.IntPtr;
using SDL_Joystick = System.IntPtr;
using SDL_bool = System.Int32;
using NativeLibraryLoader;

namespace SDL2
{
    public static class SDL_gamecontroller
    {

        public enum SDL_GameControllerBindType
        {

            SDL_CONTROLLER_BINDTYPE_NONE = 0,
            SDL_CONTROLLER_BINDTYPE_BUTTON,
            SDL_CONTROLLER_BINDTYPE_AXIS,
            SDL_CONTROLLER_BINDTYPE_HAT

        }
        public enum SDL_GameControllerAxis
        {

            SDL_CONTROLLER_AXIS_INVALID = -1,
            SDL_CONTROLLER_AXIS_LEFTX,
            SDL_CONTROLLER_AXIS_LEFTY,
            SDL_CONTROLLER_AXIS_RIGHTX,
            SDL_CONTROLLER_AXIS_RIGHTY,
            SDL_CONTROLLER_AXIS_TRIGGERLEFT,
            SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
            SDL_CONTROLLER_AXIS_MAX

        }
        public enum SDL_GameControllerButton
        {

            SDL_CONTROLLER_BUTTON_INVALID = -1,
            SDL_CONTROLLER_BUTTON_A,
            SDL_CONTROLLER_BUTTON_B,
            SDL_CONTROLLER_BUTTON_X,
            SDL_CONTROLLER_BUTTON_Y,
            SDL_CONTROLLER_BUTTON_BACK,
            SDL_CONTROLLER_BUTTON_GUIDE,
            SDL_CONTROLLER_BUTTON_START,
            SDL_CONTROLLER_BUTTON_LEFTSTICK,
            SDL_CONTROLLER_BUTTON_RIGHTSTICK,
            SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
            SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
            SDL_CONTROLLER_BUTTON_DPAD_UP,
            SDL_CONTROLLER_BUTTON_DPAD_DOWN,
            SDL_CONTROLLER_BUTTON_DPAD_LEFT,
            SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
            SDL_CONTROLLER_BUTTON_MAX

        }

        [StructLayout(LayoutKind.Explicit)]
        public struct SDL_GameControllerButtonBind
        {
            [FieldOffset(0)]
            public SDL_GameControllerBindType bindType;
            [FieldOffset(4)]
            public int button;
            [FieldOffset(4)]
            public int axis;
            [FieldOffset(4)]
            public int hat;
            [FieldOffset(8)]
            public int hat_mask;

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_GameController
        {
            public SDL_Joystick joystick; // underlying joystick device
            public int ref_count;
            public SDL_JoystickGUID guid;
            public IntPtr name;
            public int num_bindings;
            public IntPtr bindings; // *bindings
            public IntPtr last_match_axis; //**last_match_axis
            public IntPtr last_hat_mask; // Uint8
            public IntPtr next; // * _SDL_GameController *next
        }

        private delegate int SDL_GameControllerAddMappingsFromRW_SDL_RWops_int_t(IntPtr rw, int freerw);

        private static SDL_GameControllerAddMappingsFromRW_SDL_RWops_int_t s_SDL_GameControllerAddMappingsFromRW_SDL_RWops_int_t = __LoadFunction<SDL_GameControllerAddMappingsFromRW_SDL_RWops_int_t>("SDL_GameControllerAddMappingsFromRW");

        public static int SDL_GameControllerAddMappingsFromRW(IntPtr rw, int freerw) => s_SDL_GameControllerAddMappingsFromRW_SDL_RWops_int_t(rw, freerw);

        private delegate int SDL_GameControllerAddMapping_IntPtr_t(IntPtr mappingString);

        private static SDL_GameControllerAddMapping_IntPtr_t s_SDL_GameControllerAddMapping_IntPtr_t = __LoadFunction<SDL_GameControllerAddMapping_IntPtr_t>("SDL_GameControllerAddMapping");

        public static int SDL_GameControllerAddMapping(IntPtr mappingString) => s_SDL_GameControllerAddMapping_IntPtr_t(mappingString);

        private delegate IntPtr SDL_GameControllerMappingForGUID_SDL_JoystickGUID_t(SDL_JoystickGUID guid);

        private static SDL_GameControllerMappingForGUID_SDL_JoystickGUID_t s_SDL_GameControllerMappingForGUID_SDL_JoystickGUID_t = __LoadFunction<SDL_GameControllerMappingForGUID_SDL_JoystickGUID_t>("SDL_GameControllerMappingForGUID");

        public static IntPtr SDL_GameControllerMappingForGUID(SDL_JoystickGUID guid) => s_SDL_GameControllerMappingForGUID_SDL_JoystickGUID_t(guid);

        private delegate IntPtr SDL_GameControllerMapping_SDL_GameController_t(ref SDL_GameController gamecontroller);

        private static SDL_GameControllerMapping_SDL_GameController_t s_SDL_GameControllerMapping_SDL_GameController_t = __LoadFunction<SDL_GameControllerMapping_SDL_GameController_t>("SDL_GameControllerMapping");

        public static IntPtr SDL_GameControllerMapping(ref SDL_GameController gamecontroller) => s_SDL_GameControllerMapping_SDL_GameController_t(ref gamecontroller);

        private delegate SDL_bool SDL_IsGameController_int_t(int joystick_index);

        private static SDL_IsGameController_int_t s_SDL_IsGameController_int_t = __LoadFunction<SDL_IsGameController_int_t>("SDL_IsGameController");

        public static SDL_bool SDL_IsGameController(int joystick_index) => s_SDL_IsGameController_int_t(joystick_index);

        private delegate IntPtr SDL_GameControllerNameForIndex_int_t(int joystick_index);

        private static SDL_GameControllerNameForIndex_int_t s_SDL_GameControllerNameForIndex_int_t = __LoadFunction<SDL_GameControllerNameForIndex_int_t>("SDL_GameControllerNameForIndex");

        public static IntPtr SDL_GameControllerNameForIndex(int joystick_index) => s_SDL_GameControllerNameForIndex_int_t(joystick_index);

        private delegate IntPtr SDL_GameControllerOpen_int_t(int joystick_index);

        private static SDL_GameControllerOpen_int_t s_SDL_GameControllerOpen_int_t = __LoadFunction<SDL_GameControllerOpen_int_t>("SDL_GameControllerOpen");

        public static IntPtr SDL_GameControllerOpen(int joystick_index) => s_SDL_GameControllerOpen_int_t(joystick_index);

        private delegate IntPtr SDL_GameControllerName_SDL_GameController_t(ref SDL_GameController gamecontroller);

        private static SDL_GameControllerName_SDL_GameController_t s_SDL_GameControllerName_SDL_GameController_t = __LoadFunction<SDL_GameControllerName_SDL_GameController_t>("SDL_GameControllerName");

        public static IntPtr SDL_GameControllerName(ref SDL_GameController gamecontroller) => s_SDL_GameControllerName_SDL_GameController_t(ref gamecontroller);

        private delegate SDL_bool SDL_GameControllerGetAttached_SDL_GameController_t(ref SDL_GameController gamecontroller);

        private static SDL_GameControllerGetAttached_SDL_GameController_t s_SDL_GameControllerGetAttached_SDL_GameController_t = __LoadFunction<SDL_GameControllerGetAttached_SDL_GameController_t>("SDL_GameControllerGetAttached");

        public static SDL_bool SDL_GameControllerGetAttached(ref SDL_GameController gamecontroller) => s_SDL_GameControllerGetAttached_SDL_GameController_t(ref gamecontroller);

        private delegate IntPtr SDL_GameControllerGetJoystick_SDL_GameController_t(ref SDL_GameController gamecontroller);

        private static SDL_GameControllerGetJoystick_SDL_GameController_t s_SDL_GameControllerGetJoystick_SDL_GameController_t = __LoadFunction<SDL_GameControllerGetJoystick_SDL_GameController_t>("SDL_GameControllerGetJoystick");

        public static IntPtr SDL_GameControllerGetJoystick(ref SDL_GameController gamecontroller) => s_SDL_GameControllerGetJoystick_SDL_GameController_t(ref gamecontroller);

        private delegate int SDL_GameControllerEventState_int_t(int state);

        private static SDL_GameControllerEventState_int_t s_SDL_GameControllerEventState_int_t = __LoadFunction<SDL_GameControllerEventState_int_t>("SDL_GameControllerEventState");

        public static int SDL_GameControllerEventState(int state) => s_SDL_GameControllerEventState_int_t(state);

        private delegate void SDL_GameControllerUpdate__t();

        private static SDL_GameControllerUpdate__t s_SDL_GameControllerUpdate__t = __LoadFunction<SDL_GameControllerUpdate__t>("SDL_GameControllerUpdate");

        public static void SDL_GameControllerUpdate() => s_SDL_GameControllerUpdate__t();

        private delegate SDL_GameControllerAxis SDL_GameControllerGetAxisFromString_IntPtr_t(IntPtr pchString);

        private static SDL_GameControllerGetAxisFromString_IntPtr_t s_SDL_GameControllerGetAxisFromString_IntPtr_t = __LoadFunction<SDL_GameControllerGetAxisFromString_IntPtr_t>("SDL_GameControllerGetAxisFromString");

        public static SDL_GameControllerAxis SDL_GameControllerGetAxisFromString(IntPtr pchString) => s_SDL_GameControllerGetAxisFromString_IntPtr_t(pchString);

        private delegate IntPtr SDL_GameControllerGetStringForAxis_SDL_GameControllerAxis_t(SDL_GameControllerAxis axis);

        private static SDL_GameControllerGetStringForAxis_SDL_GameControllerAxis_t s_SDL_GameControllerGetStringForAxis_SDL_GameControllerAxis_t = __LoadFunction<SDL_GameControllerGetStringForAxis_SDL_GameControllerAxis_t>("SDL_GameControllerGetStringForAxis");

        public static IntPtr SDL_GameControllerGetStringForAxis(SDL_GameControllerAxis axis) => s_SDL_GameControllerGetStringForAxis_SDL_GameControllerAxis_t(axis);

        private delegate SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis_SDL_GameController_SDL_GameControllerAxis_t(ref SDL_GameController gamecontroller, SDL_GameControllerAxis axis);

        private static SDL_GameControllerGetBindForAxis_SDL_GameController_SDL_GameControllerAxis_t s_SDL_GameControllerGetBindForAxis_SDL_GameController_SDL_GameControllerAxis_t = __LoadFunction<SDL_GameControllerGetBindForAxis_SDL_GameController_SDL_GameControllerAxis_t>("SDL_GameControllerGetBindForAxis");

        public static SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(ref SDL_GameController gamecontroller, SDL_GameControllerAxis axis) => s_SDL_GameControllerGetBindForAxis_SDL_GameController_SDL_GameControllerAxis_t(ref gamecontroller, axis);

        private delegate short SDL_GameControllerGetAxis_SDL_GameController_SDL_GameControllerAxis_t(ref SDL_GameController gamecontroller, SDL_GameControllerAxis axis);

        private static SDL_GameControllerGetAxis_SDL_GameController_SDL_GameControllerAxis_t s_SDL_GameControllerGetAxis_SDL_GameController_SDL_GameControllerAxis_t = __LoadFunction<SDL_GameControllerGetAxis_SDL_GameController_SDL_GameControllerAxis_t>("SDL_GameControllerGetAxis");

        public static short SDL_GameControllerGetAxis(ref SDL_GameController gamecontroller, SDL_GameControllerAxis axis) => s_SDL_GameControllerGetAxis_SDL_GameController_SDL_GameControllerAxis_t(ref gamecontroller, axis);

        private delegate SDL_GameControllerButton SDL_GameControllerGetButtonFromString_IntPtr_t(IntPtr pchString);

        private static SDL_GameControllerGetButtonFromString_IntPtr_t s_SDL_GameControllerGetButtonFromString_IntPtr_t = __LoadFunction<SDL_GameControllerGetButtonFromString_IntPtr_t>("SDL_GameControllerGetButtonFromString");

        public static SDL_GameControllerButton SDL_GameControllerGetButtonFromString(IntPtr pchString) => s_SDL_GameControllerGetButtonFromString_IntPtr_t(pchString);

        private delegate IntPtr SDL_GameControllerGetStringForButton_SDL_GameControllerButton_t(SDL_GameControllerButton button);

        private static SDL_GameControllerGetStringForButton_SDL_GameControllerButton_t s_SDL_GameControllerGetStringForButton_SDL_GameControllerButton_t = __LoadFunction<SDL_GameControllerGetStringForButton_SDL_GameControllerButton_t>("SDL_GameControllerGetStringForButton");

        public static IntPtr SDL_GameControllerGetStringForButton(SDL_GameControllerButton button) => s_SDL_GameControllerGetStringForButton_SDL_GameControllerButton_t(button);

        private delegate SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton_SDL_GameController_SDL_GameControllerButton_t(ref SDL_GameController gamecontroller, SDL_GameControllerButton button);

        private static SDL_GameControllerGetBindForButton_SDL_GameController_SDL_GameControllerButton_t s_SDL_GameControllerGetBindForButton_SDL_GameController_SDL_GameControllerButton_t = __LoadFunction<SDL_GameControllerGetBindForButton_SDL_GameController_SDL_GameControllerButton_t>("SDL_GameControllerGetBindForButton");

        public static SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(ref SDL_GameController gamecontroller, SDL_GameControllerButton button) => s_SDL_GameControllerGetBindForButton_SDL_GameController_SDL_GameControllerButton_t(ref gamecontroller, button);

        private delegate byte SDL_GameControllerGetButton_SDL_GameController_SDL_GameControllerButton_t(ref SDL_GameController gamecontroller, SDL_GameControllerButton button);

        private static SDL_GameControllerGetButton_SDL_GameController_SDL_GameControllerButton_t s_SDL_GameControllerGetButton_SDL_GameController_SDL_GameControllerButton_t = __LoadFunction<SDL_GameControllerGetButton_SDL_GameController_SDL_GameControllerButton_t>("SDL_GameControllerGetButton");

        public static byte SDL_GameControllerGetButton(ref SDL_GameController gamecontroller, SDL_GameControllerButton button) => s_SDL_GameControllerGetButton_SDL_GameController_SDL_GameControllerButton_t(ref gamecontroller, button);

        private delegate void SDL_GameControllerClose_SDL_GameController_t(ref SDL_GameController gamecontroller);

        private static SDL_GameControllerClose_SDL_GameController_t s_SDL_GameControllerClose_SDL_GameController_t = __LoadFunction<SDL_GameControllerClose_SDL_GameController_t>("SDL_GameControllerClose");

        public static void SDL_GameControllerClose(ref SDL_GameController gamecontroller) => s_SDL_GameControllerClose_SDL_GameController_t(ref gamecontroller);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


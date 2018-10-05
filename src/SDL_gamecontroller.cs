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

        [DllImport("libSDL2.so")]
        public static extern int SDL_GameControllerAddMappingsFromRW(ref SDL_RWops rw, int freerw);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GameControllerAddMapping(IntPtr mappingString);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GameControllerMappingForGUID(SDL_JoystickGUID guid);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GameControllerMapping(ref SDL_GameController gamecontroller);
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_IsGameController(int joystick_index);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GameControllerNameForIndex(int joystick_index);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GameControllerOpen(int joystick_index);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GameControllerName(ref SDL_GameController gamecontroller);
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_GameControllerGetAttached(ref SDL_GameController gamecontroller);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GameControllerGetJoystick(ref SDL_GameController gamecontroller);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GameControllerEventState(int state);
        [DllImport("libSDL2.so")]
        public static extern void SDL_GameControllerUpdate();
        [DllImport("libSDL2.so")]
        public static extern SDL_GameControllerAxis SDL_GameControllerGetAxisFromString(IntPtr pchString);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GameControllerGetStringForAxis(SDL_GameControllerAxis axis);
        [DllImport("libSDL2.so")]
        public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(ref SDL_GameController gamecontroller, SDL_GameControllerAxis axis);
        [DllImport("libSDL2.so")]
        public static extern short SDL_GameControllerGetAxis(ref SDL_GameController gamecontroller, SDL_GameControllerAxis axis);
        [DllImport("libSDL2.so")]
        public static extern SDL_GameControllerButton SDL_GameControllerGetButtonFromString(IntPtr pchString);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GameControllerGetStringForButton(SDL_GameControllerButton button);
        [DllImport("libSDL2.so")]
        public static extern SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(ref SDL_GameController gamecontroller, SDL_GameControllerButton button);
        [DllImport("libSDL2.so")]
        public static extern byte SDL_GameControllerGetButton(ref SDL_GameController gamecontroller, SDL_GameControllerButton button);
        [DllImport("libSDL2.so")]
        public static extern void SDL_GameControllerClose(ref SDL_GameController gamecontroller);

    }
}

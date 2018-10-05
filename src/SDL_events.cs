using System;
using System.Runtime.InteropServices;

using SDL2;
using static SDL2.SDL_audio;
using static SDL2.SDL_blendmode;
using static SDL2.SDL_clipboard;
using static SDL2.SDL_cpuinfo;
using static SDL2.SDL_error;
using static SDL2.SDL_gamecontroller;
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
using static SDL2.SDL_timer;
using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

using SDL_bool = System.Int32;
using SDL_JoystickID = System.Int32;
using SDL_TouchID = System.Int64;
using SDL_FingerID = System.Int64;
using SDL_GestureID = System.Int64;
using SDL_EventFilter = System.IntPtr;

namespace SDL2
{
    public static class SDL_events
    {
        public const int SDL_RELEASED = 0;
        public const int SDL_PRESSED = 1;
        public const int SDL_TEXTEDITINGEVENT_TEXT_SIZE = 32;
        public const int SDL_TEXTINPUTEVENT_TEXT_SIZE = 32;
        public const int SDL_QUERY = -1;
        public const int SDL_IGNORE = 0;
        public const int SDL_DISABLE = 0;
        public const int SDL_ENABLE = 1;


        // This struct should be cast depending on the event type
        // The field here is to ensure proper struct size to hold all variations
        [StructLayout(LayoutKind.Explicit, Size=56)]
        public struct SDL_Event
        {
            [FieldOffset(0)]
            public UInt32 type;
            [FieldOffset(4)]
            public unsafe fixed byte data[52];
        }

        public enum SDL_EventType
        {

            SDL_FIRSTEVENT = 0,     /**< Unused (do not remove) */

            /* Application events */
            SDL_QUIT = 0x100, /**< User-requested quit */

            /* These application events have special meaning on iOS, see README-ios.txt for details */
            SDL_APP_TERMINATING,        /**< The application is being terminated by the OS
                                     Called on iOS in applicationWillTerminate()
                                     Called on Android in onDestroy()
                                */
            SDL_APP_LOWMEMORY,          /**< The application is low on memory, free memory if possible.
                                     Called on iOS in applicationDidReceiveMemoryWarning()
                                     Called on Android in onLowMemory()
                                */
            SDL_APP_WILLENTERBACKGROUND, /**< The application is about to enter the background
                                     Called on iOS in applicationWillResignActive()
                                     Called on Android in onPause()
                                */
            SDL_APP_DIDENTERBACKGROUND, /**< The application did enter the background and may not get CPU for some time
                                     Called on iOS in applicationDidEnterBackground()
                                     Called on Android in onPause()
                                */
            SDL_APP_WILLENTERFOREGROUND, /**< The application is about to enter the foreground
                                     Called on iOS in applicationWillEnterForeground()
                                     Called on Android in onResume()
                                */
            SDL_APP_DIDENTERFOREGROUND, /**< The application is now interactive
                                     Called on iOS in applicationDidBecomeActive()
                                     Called on Android in onResume()
                                */

            /* Window events */
            SDL_WINDOWEVENT = 0x200, /**< Window state change */
            SDL_SYSWMEVENT,             /**< System specific event */

            /* Keyboard events */
            SDL_KEYDOWN = 0x300, /**< Key pressed */
            SDL_KEYUP,                  /**< Key released */
            SDL_TEXTEDITING,            /**< Keyboard text editing (composition) */
            SDL_TEXTINPUT,              /**< Keyboard text input */

            /* Mouse events */
            SDL_MOUSEMOTION = 0x400, /**< Mouse moved */
            SDL_MOUSEBUTTONDOWN,        /**< Mouse button pressed */
            SDL_MOUSEBUTTONUP,          /**< Mouse button released */
            SDL_MOUSEWHEEL,             /**< Mouse wheel motion */

            /* Joystick events */
            SDL_JOYAXISMOTION = 0x600, /**< Joystick axis motion */
            SDL_JOYBALLMOTION,          /**< Joystick trackball motion */
            SDL_JOYHATMOTION,           /**< Joystick hat position change */
            SDL_JOYBUTTONDOWN,          /**< Joystick button pressed */
            SDL_JOYBUTTONUP,            /**< Joystick button released */
            SDL_JOYDEVICEADDED,         /**< A new joystick has been inserted into the system */
            SDL_JOYDEVICEREMOVED,       /**< An opened joystick has been removed */

            /* Game controller events */
            SDL_CONTROLLERAXISMOTION = 0x650, /**< Game controller axis motion */
            SDL_CONTROLLERBUTTONDOWN,          /**< Game controller button pressed */
            SDL_CONTROLLERBUTTONUP,            /**< Game controller button released */
            SDL_CONTROLLERDEVICEADDED,         /**< A new Game controller has been inserted into the system */
            SDL_CONTROLLERDEVICEREMOVED,       /**< An opened Game controller has been removed */
            SDL_CONTROLLERDEVICEREMAPPED,      /**< The controller mapping was updated */

            /* Touch events */
            SDL_FINGERDOWN = 0x700,
            SDL_FINGERUP,
            SDL_FINGERMOTION,

            /* Gesture events */
            SDL_DOLLARGESTURE = 0x800,
            SDL_DOLLARRECORD,
            SDL_MULTIGESTURE,

            /* Clipboard events */
            SDL_CLIPBOARDUPDATE = 0x900, /**< The clipboard changed */

            /* Drag and drop events */
            SDL_DROPFILE = 0x1000, /**< The system requests a file open */

            /* Render events */
            SDL_RENDER_TARGETS_RESET = 0x2000, /**< The render targets have been reset */

            /** Events ::SDL_USEREVENT through ::SDL_LASTEVENT are for your use,
             *  and should be allocated with SDL_RegisterEvents()
             */
            SDL_USEREVENT = 0x8000,

            /**
             *  This last event is only for bounding internal arrays
             */
            SDL_LASTEVENT = 0xFFFF

        }
        public enum SDL_eventaction
        {

            SDL_ADDEVENT,
            SDL_PEEKEVENT,
            SDL_GETEVENT

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_CommonEvent
        {

            public UInt32 type;
            public UInt32 timestamp;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_WindowEvent
        {

            public UInt32 type;        /**< ::SDL_WINDOWEVENT */
            public UInt32 timestamp;
            public UInt32 windowID;    /**< The associated window */
            public byte @event;        /**< ::SDL_WindowEventID */
            public byte padding1;
            public byte padding2;
            public byte padding3;
            public Int32 data1;       /**< event dependent data */
            public Int32 data2;       /**< event dependent data */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_KeyboardEvent
        {

            public UInt32 type;        /**< ::SDL_KEYDOWN or ::SDL_KEYUP */
            public UInt32 timestamp;
            public UInt32 windowID;    /**< The window with keyboard focus, if any */
            public byte state;        /**< ::SDL_PRESSED or ::SDL_RELEASED */
            public byte repeat;       /**< Non-zero if this is a key repeat */
            public byte padding2;
            public byte padding3;
            public SDL_Keysym keysym;  /**< The key that was pressed or released */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_TextEditingEvent
        {

            public UInt32 type;                                /**< ::SDL_TEXTEDITING */
            public UInt32 timestamp;
            public UInt32 windowID;                            /**< The window with keyboard focus, if any */
            public unsafe fixed char text[SDL_TEXTEDITINGEVENT_TEXT_SIZE];  /**< The editing text */
            public Int32 start;                               /**< The start cursor of selected editing text */
            public Int32 length;                              /**< The length of selected editing text */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_TextInputEvent
        {

            public UInt32 type;                              /**< ::SDL_TEXTINPUT */
            public UInt32 timestamp;
            public UInt32 windowID;                          /**< The window with keyboard focus, if any */
            public unsafe fixed char text[SDL_TEXTINPUTEVENT_TEXT_SIZE];  /**< The input text */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MouseMotionEvent
        {

            public UInt32 type;        /**< ::SDL_MOUSEMOTION */
            public UInt32 timestamp;
            public UInt32 windowID;    /**< The window with mouse focus, if any */
            public UInt32 which;       /**< The mouse instance id, or SDL_TOUCH_MOUSEID */
            public UInt32 state;       /**< The current button state */
            public Int32 x;           /**< X coordinate, relative to window */
            public Int32 y;           /**< Y coordinate, relative to window */
            public Int32 xrel;        /**< The relative motion in the X direction */
            public Int32 yrel;        /**< The relative motion in the Y direction */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MouseButtonEvent
        {

            public UInt32 type;        /**< ::SDL_MOUSEBUTTONDOWN or ::SDL_MOUSEBUTTONUP */
            public UInt32 timestamp;
            public UInt32 windowID;    /**< The window with mouse focus, if any */
            public UInt32 which;       /**< The mouse instance id, or SDL_TOUCH_MOUSEID */
            public byte button;       /**< The mouse button index */
            public byte state;        /**< ::SDL_PRESSED or ::SDL_RELEASED */
            public byte clicks;       /**< 1 for single-click, 2 for double-click, etc. */
            public byte padding1;
            public Int32 x;           /**< X coordinate, relative to window */
            public Int32 y;           /**< Y coordinate, relative to window */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MouseWheelEvent
        {

            public UInt32 type;        /**< ::SDL_MOUSEWHEEL */
            public UInt32 timestamp;
            public UInt32 windowID;    /**< The window with mouse focus, if any */
            public UInt32 which;       /**< The mouse instance id, or SDL_TOUCH_MOUSEID */
            public Int32 x;           /**< The amount scrolled horizontally, positive to the right and negative to the left */
            public Int32 y;           /**< The amount scrolled vertically, positive away from the user and negative toward the user */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyAxisEvent
        {

            public UInt32 type;        /**< ::SDL_JOYAXISMOTION */
            public UInt32 timestamp;
            public SDL_JoystickID which; /**< The joystick instance id */
            public byte axis;         /**< The joystick axis index */
            public byte padding1;
            public byte padding2;
            public byte padding3;
            public Int16 value;       /**< The axis value (range: -32768 to 32767) */
            public UInt16 padding4;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyBallEvent
        {

            public UInt32 type;        /**< ::SDL_JOYBALLMOTION */
            public UInt32 timestamp;
            public SDL_JoystickID which; /**< The joystick instance id */
            public byte ball;         /**< The joystick trackball index */
            public byte padding1;
            public byte padding2;
            public byte padding3;
            public Int16 xrel;        /**< The relative motion in the X direction */
            public Int16 yrel;        /**< The relative motion in the Y direction */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyHatEvent
        {

            public UInt32 type;        /**< ::SDL_JOYHATMOTION */
            public UInt32 timestamp;
            public SDL_JoystickID which; /**< The joystick instance id */
            public byte hat;          /**< The joystick hat index */
            public byte value;        /**< The hat position value.
                          *   \sa ::SDL_HAT_LEFTUP ::SDL_HAT_UP ::SDL_HAT_RIGHTUP
                          *   \sa ::SDL_HAT_LEFT ::SDL_HAT_CENTERED ::SDL_HAT_RIGHT
                          *   \sa ::SDL_HAT_LEFTDOWN ::SDL_HAT_DOWN ::SDL_HAT_RIGHTDOWN
                          *
                          *   Note that zero means the POV is centered.
                          */
            public byte padding1;
            public byte padding2;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyButtonEvent
        {

            public UInt32 type;        /**< ::SDL_JOYBUTTONDOWN or ::SDL_JOYBUTTONUP */
            public UInt32 timestamp;
            public SDL_JoystickID which; /**< The joystick instance id */
            public byte button;       /**< The joystick button index */
            public byte state;        /**< ::SDL_PRESSED or ::SDL_RELEASED */
            public byte padding1;
            public byte padding2;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_JoyDeviceEvent
        {

            public UInt32 type;        /**< ::SDL_JOYDEVICEADDED or ::SDL_JOYDEVICEREMOVED */
            public UInt32 timestamp;
            public Int32 which;       /**< The joystick device index for the ADDED event, instance id for the REMOVED event */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_ControllerAxisEvent
        {

            public UInt32 type;        /**< ::SDL_CONTROLLERAXISMOTION */
            public UInt32 timestamp;
            public SDL_JoystickID which; /**< The joystick instance id */
            public byte axis;         /**< The controller axis (SDL_GameControllerAxis) */
            public byte padding1;
            public byte padding2;
            public byte padding3;
            public Int16 value;       /**< The axis value (range: -32768 to 32767) */
            public UInt16 padding4;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_ControllerButtonEvent
        {

            public UInt32 type;        /**< ::SDL_CONTROLLERBUTTONDOWN or ::SDL_CONTROLLERBUTTONUP */
            public UInt32 timestamp;
            public SDL_JoystickID which; /**< The joystick instance id */
            public byte button;       /**< The controller button (SDL_GameControllerButton) */
            public byte state;        /**< ::SDL_PRESSED or ::SDL_RELEASED */
            public byte padding1;
            public byte padding2;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_ControllerDeviceEvent
        {

            public UInt32 type;        /**< ::SDL_CONTROLLERDEVICEADDED, ::SDL_CONTROLLERDEVICEREMOVED, or ::SDL_CONTROLLERDEVICEREMAPPED */
            public UInt32 timestamp;
            public Int32 which;       /**< The joystick device index for the ADDED event, instance id for the REMOVED or REMAPPED event */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_TouchFingerEvent
        {

            public UInt32 type;        /**< ::SDL_FINGERMOTION or ::SDL_FINGERDOWN or ::SDL_FINGERUP */
            public UInt32 timestamp;
            public SDL_TouchID touchId; /**< The touch device id */
            public SDL_FingerID fingerId;
            public float x;            /**< Normalized in the range 0...1 */
            public float y;            /**< Normalized in the range 0...1 */
            public float dx;           /**< Normalized in the range 0...1 */
            public float dy;           /**< Normalized in the range 0...1 */
            public float pressure;     /**< Normalized in the range 0...1 */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_MultiGestureEvent
        {

            public UInt32 type;        /**< ::SDL_MULTIGESTURE */
            public UInt32 timestamp;
            public SDL_TouchID touchId; /**< The touch device index */
            public float dTheta;
            public float dDist;
            public float x;
            public float y;
            public UInt16 numFingers;
            public UInt16 padding;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_DollarGestureEvent
        {

            public UInt32 type;        /**< ::SDL_DOLLARGESTURE */
            public UInt32 timestamp;
            public SDL_TouchID touchId; /**< The touch device id */
            public SDL_GestureID gestureId;
            public UInt32 numFingers;
            public float error;
            public float x;            /**< Normalized center of gesture */
            public float y;            /**< Normalized center of gesture */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_DropEvent
        {

            public UInt32 type;        /**< ::SDL_DROPFILE */
            public UInt32 timestamp;
            public IntPtr file;         /**< The file name, which should be freed with SDL_free() */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_QuitEvent
        {

            public UInt32 type;        /**< ::SDL_QUIT */
            public UInt32 timestamp;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_OSEvent
        {

            public UInt32 type;        /**< ::SDL_QUIT */
            public UInt32 timestamp;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_UserEvent
        {

            public UInt32 type;        /**< ::SDL_USEREVENT through ::SDL_LASTEVENT-1 */
            public UInt32 timestamp;
            public UInt32 windowID;    /**< The associated window if any */
            public Int32 code;        /**< User defined event code */
            public IntPtr data1;        /**< User defined data pointer */
            public IntPtr data2;        /**< User defined data pointer */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_SysWMEvent
        {

            public UInt32 type;        /**< ::SDL_SYSWMEVENT */
            public UInt32 timestamp;
            public IntPtr msg;  /**< driver dependent data, defined in SDL_syswm.h */

        }

        [DllImport("SDL2.dll")]
        public static extern void SDL_PumpEvents();
        [DllImport("SDL2.dll")]
        public static extern int SDL_PeepEvents(ref SDL_Event events, int numevents, SDL_eventaction action, UInt32 minType, UInt32 maxType);
        [DllImport("SDL2.dll")]
        public static extern SDL_bool SDL_HasEvent(UInt32 type);
        [DllImport("SDL2.dll")]
        public static extern SDL_bool SDL_HasEvents(UInt32 minType, UInt32 maxType);
        [DllImport("SDL2.dll")]
        public static extern void SDL_FlushEvent(UInt32 type);
        [DllImport("SDL2.dll")]
        public static extern void SDL_FlushEvents(UInt32 minType, UInt32 maxType);
        [DllImport("SDL2.dll")]
        public static extern int SDL_PollEvent(ref SDL_Event @event);
        [DllImport("SDL2.dll")]
        public static extern int SDL_WaitEvent(ref SDL_Event @event);
        [DllImport("SDL2.dll")]
        public static extern int SDL_WaitEventTimeout(ref SDL_Event @event, int timeout);
        [DllImport("SDL2.dll")]
        public static extern int SDL_PushEvent(ref SDL_Event @event);
        [DllImport("SDL2.dll")]
        public static extern void SDL_SetEventFilter(SDL_EventFilter filter, IntPtr userdata);
        [DllImport("SDL2.dll")]
        public static extern SDL_bool SDL_GetEventFilter(ref SDL_EventFilter filter, IntPtr userdata);
        [DllImport("SDL2.dll")]
        public static extern void SDL_AddEventWatch(SDL_EventFilter filter, IntPtr userdata);
        [DllImport("SDL2.dll")]
        public static extern void SDL_DelEventWatch(SDL_EventFilter filter, IntPtr userdata);
        [DllImport("SDL2.dll")]
        public static extern void SDL_FilterEvents(SDL_EventFilter filter, IntPtr userdata);
        [DllImport("SDL2.dll")]
        public static extern byte SDL_EventState(UInt32 type, int state);
        [DllImport("SDL2.dll")]
        public static extern uint SDL_RegisterEvents(int numevents);

    }
}

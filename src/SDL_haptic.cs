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

namespace SDL2
{
    public static class SDL_haptic
    {
        public const int SDL_HAPTIC_CONSTANT = 1 << 0;
        public const int SDL_HAPTIC_SINE = 1 << 1;
        public const int SDL_HAPTIC_LEFTRIGHT = 1 << 2;
        public const int SDL_HAPTIC_SQUARE = 1 << 2;
        public const int SDL_HAPTIC_TRIANGLE = 1 << 3;
        public const int SDL_HAPTIC_SAWTOOTHUP = 1 << 4;
        public const int SDL_HAPTIC_SAWTOOTHDOWN = 1 << 5;
        public const int SDL_HAPTIC_RAMP = 1 << 6;
        public const int SDL_HAPTIC_SPRING = 1 << 7;
        public const int SDL_HAPTIC_DAMPER = 1 << 8;
        public const int SDL_HAPTIC_INERTIA = 1 << 9;
        public const int SDL_HAPTIC_FRICTION = 1 << 10;
        public const int SDL_HAPTIC_CUSTOM = 1 << 11;
        public const int SDL_HAPTIC_GAIN = 1 << 12;
        public const int SDL_HAPTIC_AUTOCENTER = 1 << 13;
        public const int SDL_HAPTIC_STATUS = 1 << 14;
        public const int SDL_HAPTIC_PAUSE = 1 << 15;
        public const int SDL_HAPTIC_POLAR = 0;
        public const int SDL_HAPTIC_CARTESIAN = 1;
        public const int SDL_HAPTIC_SPHERICAL = 2;
        public const uint SDL_HAPTIC_INFINITY = 4294967295U;


        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_HapticDirection
        {

            public byte type;         /**< The type of encoding. */
            public Int32 dir1;      /**< The encoded direction. */
            public Int32 dir2;
            public Int32 dir3;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_HapticConstant
        {

            /* Header */
            public UInt16 type;            /**< ::SDL_HAPTIC_CONSTANT */
            public SDL_HapticDirection direction;  /**< Direction of the effect. */

            /* Replay */
            public UInt32 length;          /**< Duration of the effect. */
            public UInt16 delay;           /**< Delay before starting the effect. */

            /* Trigger */
            public UInt16 button;          /**< Button that triggers the effect. */
            public UInt16 interval;        /**< How soon it can be triggered again after button. */

            /* Constant */
            public Int16 level;           /**< Strength of the constant effect. */

            /* Envelope */
            public UInt16 attack_length;   /**< Duration of the attack. */
            public UInt16 attack_level;    /**< Level at the start of the attack. */
            public UInt16 fade_length;     /**< Duration of the fade. */
            public UInt16 fade_level;      /**< Level at the end of the fade. */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_HapticPeriodic
        {

            /* Header */
            public UInt16 type;        /**< ::SDL_HAPTIC_SINE, ::SDL_HAPTIC_LEFTRIGHT,
                             ::SDL_HAPTIC_TRIANGLE, ::SDL_HAPTIC_SAWTOOTHUP or
                             ::SDL_HAPTIC_SAWTOOTHDOWN */
            public SDL_HapticDirection direction;  /**< Direction of the effect. */

            /* Replay */
            public UInt32 length;      /**< Duration of the effect. */
            public UInt16 delay;       /**< Delay before starting the effect. */

            /* Trigger */
            public UInt16 button;      /**< Button that triggers the effect. */
            public UInt16 interval;    /**< How soon it can be triggered again after button. */

            /* Periodic */
            public UInt16 period;      /**< Period of the wave. */
            public Int16 magnitude;   /**< Peak value. */
            public Int16 offset;      /**< Mean value of the wave. */
            public UInt16 phase;       /**< Horizontal shift given by hundredth of a cycle. */

            /* Envelope */
            public UInt16 attack_length;   /**< Duration of the attack. */
            public UInt16 attack_level;    /**< Level at the start of the attack. */
            public UInt16 fade_length; /**< Duration of the fade. */
            public UInt16 fade_level;  /**< Level at the end of the fade. */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_HapticCondition
        {

            /* Header */
            public UInt16 type;            /**< ::SDL_HAPTIC_SPRING, ::SDL_HAPTIC_DAMPER,
                                 ::SDL_HAPTIC_INERTIA or ::SDL_HAPTIC_FRICTION */
            public SDL_HapticDirection direction;  /**< Direction of the effect - Not used ATM. */

            /* Replay */
            public UInt32 length;          /**< Duration of the effect. */
            public UInt16 delay;           /**< Delay before starting the effect. */

            /* Trigger */
            public UInt16 button;          /**< Button that triggers the effect. */
            public UInt16 interval;        /**< How soon it can be triggered again after button. */

            /* Condition */
            public UInt16 right_sat_1;    /**< Level when joystick is to the positive side. */
            public UInt16 right_sat_2;
            public UInt16 right_sat_3;
            public UInt16 left_sat_1;     /**< Level when joystick is to the negative side. */
            public UInt16 left_sat_2;
            public UInt16 left_sat_3;
            public Int16 right_coeff_1;  /**< How fast to increase the force towards the positive side. */
            public Int16 right_coeff_2;
            public Int16 right_coeff_3;
            public Int16 left_coeff_1;   /**< How fast to increase the force towards the negative side. */
            public Int16 left_coeff_2;
            public Int16 left_coeff_3;
            public UInt16 deadband_1;     /**< Size of the dead zone. */
            public UInt16 deadband_2;
            public UInt16 deadband_3;
            public Int16 center_1;       /**< Position of the dead zone. */
            public Int16 center_2;
            public Int16 center_3;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_HapticRamp
        {

            /* Header */
            public UInt16 type;            /**< ::SDL_HAPTIC_RAMP */
            public SDL_HapticDirection direction;  /**< Direction of the effect. */

            /* Replay */
            public UInt32 length;          /**< Duration of the effect. */
            public UInt16 delay;           /**< Delay before starting the effect. */

            /* Trigger */
            public UInt16 button;          /**< Button that triggers the effect. */
            public UInt16 interval;        /**< How soon it can be triggered again after button. */

            /* Ramp */
            public Int16 start;           /**< Beginning strength level. */
            public Int16 end;             /**< Ending strength level. */

            /* Envelope */
            public UInt16 attack_length;   /**< Duration of the attack. */
            public UInt16 attack_level;    /**< Level at the start of the attack. */
            public UInt16 fade_length;     /**< Duration of the fade. */
            public UInt16 fade_level;      /**< Level at the end of the fade. */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_HapticLeftRight
        {

            /* Header */
            public UInt16 type;            /**< ::SDL_HAPTIC_LEFTRIGHT */

            /* Replay */
            public UInt32 length;          /**< Duration of the effect. */

            /* Rumble */
            public UInt16 large_magnitude; /**< Control of the large controller motor. */
            public UInt16 small_magnitude; /**< Control of the small controller motor. */

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_HapticCustom
        {

            /* Header */
            public UInt16 type;            /**< ::SDL_HAPTIC_CUSTOM */
            public SDL_HapticDirection direction;  /**< Direction of the effect. */

            /* Replay */
            public UInt32 length;          /**< Duration of the effect. */
            public UInt16 delay;           /**< Delay before starting the effect. */

            /* Trigger */
            public UInt16 button;          /**< Button that triggers the effect. */
            public UInt16 interval;        /**< How soon it can be triggered again after button. */

            /* Custom */
            public byte channels;         /**< Axes to use, minimum of one. */
            public UInt16 period;          /**< Sample periods. */
            public UInt16 samples;         /**< Amount of samples. */
            public IntPtr data;           /**< Should contain channels*samples items. */

            /* Envelope */
            public UInt16 attack_length;   /**< Duration of the attack. */
            public UInt16 attack_level;    /**< Level at the start of the attack. */
            public UInt16 fade_length;     /**< Duration of the fade. */
            public UInt16 fade_level;      /**< Level at the end of the fade. */

        }

        [DllImport("libSDL2.so")]
        public static extern int SDL_NumHaptics();
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_HapticName(int device_index);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_HapticOpen(int device_index);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticOpened(int device_index);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticIndex(IntPtr haptic);
        [DllImport("libSDL2.so")]
        public static extern int SDL_MouseIsHaptic();
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_HapticOpenFromMouse();
        [DllImport("libSDL2.so")]
        public static extern int SDL_JoystickIsHaptic(IntPtr joystick);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_HapticOpenFromJoystick(IntPtr joystick);
        [DllImport("libSDL2.so")]
        public static extern void SDL_HapticClose(IntPtr haptic);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticNumEffects(IntPtr haptic);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticNumEffectsPlaying(IntPtr haptic);
        [DllImport("libSDL2.so")]
        public static extern uint SDL_HapticQuery(IntPtr haptic);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticNumAxes(IntPtr haptic);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticEffectSupported(IntPtr haptic, IntPtr effect);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticNewEffect(IntPtr haptic, IntPtr effect);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticUpdateEffect(IntPtr haptic, int effect, IntPtr data);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticRunEffect(IntPtr haptic, int effect, UInt32 iterations);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticStopEffect(IntPtr haptic, int effect);
        [DllImport("libSDL2.so")]
        public static extern void SDL_HapticDestroyEffect(IntPtr haptic, int effect);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticGetEffectStatus(IntPtr haptic, int effect);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticSetGain(IntPtr haptic, int gain);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticSetAutocenter(IntPtr haptic, int autocenter);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticPause(IntPtr haptic);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticUnpause(IntPtr haptic);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticStopAll(IntPtr haptic);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticRumbleSupported(IntPtr haptic);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticRumbleInit(IntPtr haptic);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticRumblePlay(IntPtr haptic, float strength, UInt32 length);
        [DllImport("libSDL2.so")]
        public static extern int SDL_HapticRumbleStop(IntPtr haptic);

    }
}

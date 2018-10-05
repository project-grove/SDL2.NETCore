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
using NativeLibraryLoader;

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

        private delegate int SDL_NumHaptics__t();

        private static SDL_NumHaptics__t s_SDL_NumHaptics__t = __LoadFunction<SDL_NumHaptics__t>("SDL_NumHaptics");

        public static int SDL_NumHaptics() => s_SDL_NumHaptics__t();

        private delegate IntPtr SDL_HapticName_int_t(int device_index);

        private static SDL_HapticName_int_t s_SDL_HapticName_int_t = __LoadFunction<SDL_HapticName_int_t>("SDL_HapticName");

        public static IntPtr SDL_HapticName(int device_index) => s_SDL_HapticName_int_t(device_index);

        private delegate IntPtr SDL_HapticOpen_int_t(int device_index);

        private static SDL_HapticOpen_int_t s_SDL_HapticOpen_int_t = __LoadFunction<SDL_HapticOpen_int_t>("SDL_HapticOpen");

        public static IntPtr SDL_HapticOpen(int device_index) => s_SDL_HapticOpen_int_t(device_index);

        private delegate int SDL_HapticOpened_int_t(int device_index);

        private static SDL_HapticOpened_int_t s_SDL_HapticOpened_int_t = __LoadFunction<SDL_HapticOpened_int_t>("SDL_HapticOpened");

        public static int SDL_HapticOpened(int device_index) => s_SDL_HapticOpened_int_t(device_index);

        private delegate int SDL_HapticIndex_IntPtr_t(IntPtr haptic);

        private static SDL_HapticIndex_IntPtr_t s_SDL_HapticIndex_IntPtr_t = __LoadFunction<SDL_HapticIndex_IntPtr_t>("SDL_HapticIndex");

        public static int SDL_HapticIndex(IntPtr haptic) => s_SDL_HapticIndex_IntPtr_t(haptic);

        private delegate int SDL_MouseIsHaptic__t();

        private static SDL_MouseIsHaptic__t s_SDL_MouseIsHaptic__t = __LoadFunction<SDL_MouseIsHaptic__t>("SDL_MouseIsHaptic");

        public static int SDL_MouseIsHaptic() => s_SDL_MouseIsHaptic__t();

        private delegate IntPtr SDL_HapticOpenFromMouse__t();

        private static SDL_HapticOpenFromMouse__t s_SDL_HapticOpenFromMouse__t = __LoadFunction<SDL_HapticOpenFromMouse__t>("SDL_HapticOpenFromMouse");

        public static IntPtr SDL_HapticOpenFromMouse() => s_SDL_HapticOpenFromMouse__t();

        private delegate int SDL_JoystickIsHaptic_IntPtr_t(IntPtr joystick);

        private static SDL_JoystickIsHaptic_IntPtr_t s_SDL_JoystickIsHaptic_IntPtr_t = __LoadFunction<SDL_JoystickIsHaptic_IntPtr_t>("SDL_JoystickIsHaptic");

        public static int SDL_JoystickIsHaptic(IntPtr joystick) => s_SDL_JoystickIsHaptic_IntPtr_t(joystick);

        private delegate IntPtr SDL_HapticOpenFromJoystick_IntPtr_t(IntPtr joystick);

        private static SDL_HapticOpenFromJoystick_IntPtr_t s_SDL_HapticOpenFromJoystick_IntPtr_t = __LoadFunction<SDL_HapticOpenFromJoystick_IntPtr_t>("SDL_HapticOpenFromJoystick");

        public static IntPtr SDL_HapticOpenFromJoystick(IntPtr joystick) => s_SDL_HapticOpenFromJoystick_IntPtr_t(joystick);

        private delegate void SDL_HapticClose_IntPtr_t(IntPtr haptic);

        private static SDL_HapticClose_IntPtr_t s_SDL_HapticClose_IntPtr_t = __LoadFunction<SDL_HapticClose_IntPtr_t>("SDL_HapticClose");

        public static void SDL_HapticClose(IntPtr haptic) => s_SDL_HapticClose_IntPtr_t(haptic);

        private delegate int SDL_HapticNumEffects_IntPtr_t(IntPtr haptic);

        private static SDL_HapticNumEffects_IntPtr_t s_SDL_HapticNumEffects_IntPtr_t = __LoadFunction<SDL_HapticNumEffects_IntPtr_t>("SDL_HapticNumEffects");

        public static int SDL_HapticNumEffects(IntPtr haptic) => s_SDL_HapticNumEffects_IntPtr_t(haptic);

        private delegate int SDL_HapticNumEffectsPlaying_IntPtr_t(IntPtr haptic);

        private static SDL_HapticNumEffectsPlaying_IntPtr_t s_SDL_HapticNumEffectsPlaying_IntPtr_t = __LoadFunction<SDL_HapticNumEffectsPlaying_IntPtr_t>("SDL_HapticNumEffectsPlaying");

        public static int SDL_HapticNumEffectsPlaying(IntPtr haptic) => s_SDL_HapticNumEffectsPlaying_IntPtr_t(haptic);

        private delegate uint SDL_HapticQuery_IntPtr_t(IntPtr haptic);

        private static SDL_HapticQuery_IntPtr_t s_SDL_HapticQuery_IntPtr_t = __LoadFunction<SDL_HapticQuery_IntPtr_t>("SDL_HapticQuery");

        public static uint SDL_HapticQuery(IntPtr haptic) => s_SDL_HapticQuery_IntPtr_t(haptic);

        private delegate int SDL_HapticNumAxes_IntPtr_t(IntPtr haptic);

        private static SDL_HapticNumAxes_IntPtr_t s_SDL_HapticNumAxes_IntPtr_t = __LoadFunction<SDL_HapticNumAxes_IntPtr_t>("SDL_HapticNumAxes");

        public static int SDL_HapticNumAxes(IntPtr haptic) => s_SDL_HapticNumAxes_IntPtr_t(haptic);

        private delegate int SDL_HapticEffectSupported_IntPtr_IntPtr_t(IntPtr haptic, IntPtr effect);

        private static SDL_HapticEffectSupported_IntPtr_IntPtr_t s_SDL_HapticEffectSupported_IntPtr_IntPtr_t = __LoadFunction<SDL_HapticEffectSupported_IntPtr_IntPtr_t>("SDL_HapticEffectSupported");

        public static int SDL_HapticEffectSupported(IntPtr haptic, IntPtr effect) => s_SDL_HapticEffectSupported_IntPtr_IntPtr_t(haptic, effect);

        private delegate int SDL_HapticNewEffect_IntPtr_IntPtr_t(IntPtr haptic, IntPtr effect);

        private static SDL_HapticNewEffect_IntPtr_IntPtr_t s_SDL_HapticNewEffect_IntPtr_IntPtr_t = __LoadFunction<SDL_HapticNewEffect_IntPtr_IntPtr_t>("SDL_HapticNewEffect");

        public static int SDL_HapticNewEffect(IntPtr haptic, IntPtr effect) => s_SDL_HapticNewEffect_IntPtr_IntPtr_t(haptic, effect);

        private delegate int SDL_HapticUpdateEffect_IntPtr_int_IntPtr_t(IntPtr haptic, int effect, IntPtr data);

        private static SDL_HapticUpdateEffect_IntPtr_int_IntPtr_t s_SDL_HapticUpdateEffect_IntPtr_int_IntPtr_t = __LoadFunction<SDL_HapticUpdateEffect_IntPtr_int_IntPtr_t>("SDL_HapticUpdateEffect");

        public static int SDL_HapticUpdateEffect(IntPtr haptic, int effect, IntPtr data) => s_SDL_HapticUpdateEffect_IntPtr_int_IntPtr_t(haptic, effect, data);

        private delegate int SDL_HapticRunEffect_IntPtr_int_UInt32_t(IntPtr haptic, int effect, UInt32 iterations);

        private static SDL_HapticRunEffect_IntPtr_int_UInt32_t s_SDL_HapticRunEffect_IntPtr_int_UInt32_t = __LoadFunction<SDL_HapticRunEffect_IntPtr_int_UInt32_t>("SDL_HapticRunEffect");

        public static int SDL_HapticRunEffect(IntPtr haptic, int effect, UInt32 iterations) => s_SDL_HapticRunEffect_IntPtr_int_UInt32_t(haptic, effect, iterations);

        private delegate int SDL_HapticStopEffect_IntPtr_int_t(IntPtr haptic, int effect);

        private static SDL_HapticStopEffect_IntPtr_int_t s_SDL_HapticStopEffect_IntPtr_int_t = __LoadFunction<SDL_HapticStopEffect_IntPtr_int_t>("SDL_HapticStopEffect");

        public static int SDL_HapticStopEffect(IntPtr haptic, int effect) => s_SDL_HapticStopEffect_IntPtr_int_t(haptic, effect);

        private delegate void SDL_HapticDestroyEffect_IntPtr_int_t(IntPtr haptic, int effect);

        private static SDL_HapticDestroyEffect_IntPtr_int_t s_SDL_HapticDestroyEffect_IntPtr_int_t = __LoadFunction<SDL_HapticDestroyEffect_IntPtr_int_t>("SDL_HapticDestroyEffect");

        public static void SDL_HapticDestroyEffect(IntPtr haptic, int effect) => s_SDL_HapticDestroyEffect_IntPtr_int_t(haptic, effect);

        private delegate int SDL_HapticGetEffectStatus_IntPtr_int_t(IntPtr haptic, int effect);

        private static SDL_HapticGetEffectStatus_IntPtr_int_t s_SDL_HapticGetEffectStatus_IntPtr_int_t = __LoadFunction<SDL_HapticGetEffectStatus_IntPtr_int_t>("SDL_HapticGetEffectStatus");

        public static int SDL_HapticGetEffectStatus(IntPtr haptic, int effect) => s_SDL_HapticGetEffectStatus_IntPtr_int_t(haptic, effect);

        private delegate int SDL_HapticSetGain_IntPtr_int_t(IntPtr haptic, int gain);

        private static SDL_HapticSetGain_IntPtr_int_t s_SDL_HapticSetGain_IntPtr_int_t = __LoadFunction<SDL_HapticSetGain_IntPtr_int_t>("SDL_HapticSetGain");

        public static int SDL_HapticSetGain(IntPtr haptic, int gain) => s_SDL_HapticSetGain_IntPtr_int_t(haptic, gain);

        private delegate int SDL_HapticSetAutocenter_IntPtr_int_t(IntPtr haptic, int autocenter);

        private static SDL_HapticSetAutocenter_IntPtr_int_t s_SDL_HapticSetAutocenter_IntPtr_int_t = __LoadFunction<SDL_HapticSetAutocenter_IntPtr_int_t>("SDL_HapticSetAutocenter");

        public static int SDL_HapticSetAutocenter(IntPtr haptic, int autocenter) => s_SDL_HapticSetAutocenter_IntPtr_int_t(haptic, autocenter);

        private delegate int SDL_HapticPause_IntPtr_t(IntPtr haptic);

        private static SDL_HapticPause_IntPtr_t s_SDL_HapticPause_IntPtr_t = __LoadFunction<SDL_HapticPause_IntPtr_t>("SDL_HapticPause");

        public static int SDL_HapticPause(IntPtr haptic) => s_SDL_HapticPause_IntPtr_t(haptic);

        private delegate int SDL_HapticUnpause_IntPtr_t(IntPtr haptic);

        private static SDL_HapticUnpause_IntPtr_t s_SDL_HapticUnpause_IntPtr_t = __LoadFunction<SDL_HapticUnpause_IntPtr_t>("SDL_HapticUnpause");

        public static int SDL_HapticUnpause(IntPtr haptic) => s_SDL_HapticUnpause_IntPtr_t(haptic);

        private delegate int SDL_HapticStopAll_IntPtr_t(IntPtr haptic);

        private static SDL_HapticStopAll_IntPtr_t s_SDL_HapticStopAll_IntPtr_t = __LoadFunction<SDL_HapticStopAll_IntPtr_t>("SDL_HapticStopAll");

        public static int SDL_HapticStopAll(IntPtr haptic) => s_SDL_HapticStopAll_IntPtr_t(haptic);

        private delegate int SDL_HapticRumbleSupported_IntPtr_t(IntPtr haptic);

        private static SDL_HapticRumbleSupported_IntPtr_t s_SDL_HapticRumbleSupported_IntPtr_t = __LoadFunction<SDL_HapticRumbleSupported_IntPtr_t>("SDL_HapticRumbleSupported");

        public static int SDL_HapticRumbleSupported(IntPtr haptic) => s_SDL_HapticRumbleSupported_IntPtr_t(haptic);

        private delegate int SDL_HapticRumbleInit_IntPtr_t(IntPtr haptic);

        private static SDL_HapticRumbleInit_IntPtr_t s_SDL_HapticRumbleInit_IntPtr_t = __LoadFunction<SDL_HapticRumbleInit_IntPtr_t>("SDL_HapticRumbleInit");

        public static int SDL_HapticRumbleInit(IntPtr haptic) => s_SDL_HapticRumbleInit_IntPtr_t(haptic);

        private delegate int SDL_HapticRumblePlay_IntPtr_float_UInt32_t(IntPtr haptic, float strength, UInt32 length);

        private static SDL_HapticRumblePlay_IntPtr_float_UInt32_t s_SDL_HapticRumblePlay_IntPtr_float_UInt32_t = __LoadFunction<SDL_HapticRumblePlay_IntPtr_float_UInt32_t>("SDL_HapticRumblePlay");

        public static int SDL_HapticRumblePlay(IntPtr haptic, float strength, UInt32 length) => s_SDL_HapticRumblePlay_IntPtr_float_UInt32_t(haptic, strength, length);

        private delegate int SDL_HapticRumbleStop_IntPtr_t(IntPtr haptic);

        private static SDL_HapticRumbleStop_IntPtr_t s_SDL_HapticRumbleStop_IntPtr_t = __LoadFunction<SDL_HapticRumbleStop_IntPtr_t>("SDL_HapticRumbleStop");

        public static int SDL_HapticRumbleStop(IntPtr haptic) => s_SDL_HapticRumbleStop_IntPtr_t(haptic);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


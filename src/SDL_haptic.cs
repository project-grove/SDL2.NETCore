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
using static SDL2.SDL_timer;
using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

namespace SDL2
{
public static class SDL_haptic
{
public const int SDL_HAPTIC_CONSTANT = 1<<0;
public const int SDL_HAPTIC_SINE = 1<<1;
public const int SDL_HAPTIC_LEFTRIGHT = 1<<2;
public const int SDL_HAPTIC_SQUARE = 1<<2;
public const int SDL_HAPTIC_TRIANGLE = 1<<3;
public const int SDL_HAPTIC_SAWTOOTHUP = 1<<4;
public const int SDL_HAPTIC_SAWTOOTHDOWN = 1<<5;
public const int SDL_HAPTIC_RAMP = 1<<6;
public const int SDL_HAPTIC_SPRING = 1<<7;
public const int SDL_HAPTIC_DAMPER = 1<<8;
public const int SDL_HAPTIC_INERTIA = 1<<9;
public const int SDL_HAPTIC_FRICTION = 1<<10;
public const int SDL_HAPTIC_CUSTOM = 1<<11;
public const int SDL_HAPTIC_GAIN = 1<<12;
public const int SDL_HAPTIC_AUTOCENTER = 1<<13;
public const int SDL_HAPTIC_STATUS = 1<<14;
public const int SDL_HAPTIC_PAUSE = 1<<15;
public const int SDL_HAPTIC_POLAR = 0;
public const int SDL_HAPTIC_CARTESIAN = 1;
public const int SDL_HAPTIC_SPHERICAL = 2;
public const int SDL_HAPTIC_INFINITY = 4294967295U;


[StructLayout(LayoutKind.Sequential)]
public struct SDL_HapticDirection
{

    Uint8 type;         /**< The type of encoding. */
    Sint32 dir[3];      /**< The encoded direction. */

}
[StructLayout(LayoutKind.Sequential)]
public struct SDL_HapticConstant
{

    /* Header */
    Uint16 type;            /**< ::SDL_HAPTIC_CONSTANT */
    SDL_HapticDirection direction;  /**< Direction of the effect. */

    /* Replay */
    Uint32 length;          /**< Duration of the effect. */
    Uint16 delay;           /**< Delay before starting the effect. */

    /* Trigger */
    Uint16 button;          /**< Button that triggers the effect. */
    Uint16 interval;        /**< How soon it can be triggered again after button. */

    /* Constant */
    Sint16 level;           /**< Strength of the constant effect. */

    /* Envelope */
    Uint16 attack_length;   /**< Duration of the attack. */
    Uint16 attack_level;    /**< Level at the start of the attack. */
    Uint16 fade_length;     /**< Duration of the fade. */
    Uint16 fade_level;      /**< Level at the end of the fade. */

}
[StructLayout(LayoutKind.Sequential)]
public struct SDL_HapticPeriodic
{

    /* Header */
    Uint16 type;        /**< ::SDL_HAPTIC_SINE, ::SDL_HAPTIC_LEFTRIGHT,
                             ::SDL_HAPTIC_TRIANGLE, ::SDL_HAPTIC_SAWTOOTHUP or
                             ::SDL_HAPTIC_SAWTOOTHDOWN */
    SDL_HapticDirection direction;  /**< Direction of the effect. */

    /* Replay */
    Uint32 length;      /**< Duration of the effect. */
    Uint16 delay;       /**< Delay before starting the effect. */

    /* Trigger */
    Uint16 button;      /**< Button that triggers the effect. */
    Uint16 interval;    /**< How soon it can be triggered again after button. */

    /* Periodic */
    Uint16 period;      /**< Period of the wave. */
    Sint16 magnitude;   /**< Peak value. */
    Sint16 offset;      /**< Mean value of the wave. */
    Uint16 phase;       /**< Horizontal shift given by hundredth of a cycle. */

    /* Envelope */
    Uint16 attack_length;   /**< Duration of the attack. */
    Uint16 attack_level;    /**< Level at the start of the attack. */
    Uint16 fade_length; /**< Duration of the fade. */
    Uint16 fade_level;  /**< Level at the end of the fade. */

}
[StructLayout(LayoutKind.Sequential)]
public struct SDL_HapticCondition
{

    /* Header */
    Uint16 type;            /**< ::SDL_HAPTIC_SPRING, ::SDL_HAPTIC_DAMPER,
                                 ::SDL_HAPTIC_INERTIA or ::SDL_HAPTIC_FRICTION */
    SDL_HapticDirection direction;  /**< Direction of the effect - Not used ATM. */

    /* Replay */
    Uint32 length;          /**< Duration of the effect. */
    Uint16 delay;           /**< Delay before starting the effect. */

    /* Trigger */
    Uint16 button;          /**< Button that triggers the effect. */
    Uint16 interval;        /**< How soon it can be triggered again after button. */

    /* Condition */
    Uint16 right_sat[3];    /**< Level when joystick is to the positive side. */
    Uint16 left_sat[3];     /**< Level when joystick is to the negative side. */
    Sint16 right_coeff[3];  /**< How fast to increase the force towards the positive side. */
    Sint16 left_coeff[3];   /**< How fast to increase the force towards the negative side. */
    Uint16 deadband[3];     /**< Size of the dead zone. */
    Sint16 center[3];       /**< Position of the dead zone. */

}
[StructLayout(LayoutKind.Sequential)]
public struct SDL_HapticRamp
{

    /* Header */
    Uint16 type;            /**< ::SDL_HAPTIC_RAMP */
    SDL_HapticDirection direction;  /**< Direction of the effect. */

    /* Replay */
    Uint32 length;          /**< Duration of the effect. */
    Uint16 delay;           /**< Delay before starting the effect. */

    /* Trigger */
    Uint16 button;          /**< Button that triggers the effect. */
    Uint16 interval;        /**< How soon it can be triggered again after button. */

    /* Ramp */
    Sint16 start;           /**< Beginning strength level. */
    Sint16 end;             /**< Ending strength level. */

    /* Envelope */
    Uint16 attack_length;   /**< Duration of the attack. */
    Uint16 attack_level;    /**< Level at the start of the attack. */
    Uint16 fade_length;     /**< Duration of the fade. */
    Uint16 fade_level;      /**< Level at the end of the fade. */

}
[StructLayout(LayoutKind.Sequential)]
public struct SDL_HapticLeftRight
{

    /* Header */
    Uint16 type;            /**< ::SDL_HAPTIC_LEFTRIGHT */

    /* Replay */
    Uint32 length;          /**< Duration of the effect. */

    /* Rumble */
    Uint16 large_magnitude; /**< Control of the large controller motor. */
    Uint16 small_magnitude; /**< Control of the small controller motor. */

}
[StructLayout(LayoutKind.Sequential)]
public struct SDL_HapticCustom
{

    /* Header */
    Uint16 type;            /**< ::SDL_HAPTIC_CUSTOM */
    SDL_HapticDirection direction;  /**< Direction of the effect. */

    /* Replay */
    Uint32 length;          /**< Duration of the effect. */
    Uint16 delay;           /**< Delay before starting the effect. */

    /* Trigger */
    Uint16 button;          /**< Button that triggers the effect. */
    Uint16 interval;        /**< How soon it can be triggered again after button. */

    /* Custom */
    Uint8 channels;         /**< Axes to use, minimum of one. */
    Uint16 period;          /**< Sample periods. */
    Uint16 samples;         /**< Amount of samples. */
    Uint16 *data;           /**< Should contain channels*samples items. */

    /* Envelope */
    Uint16 attack_length;   /**< Duration of the attack. */
    Uint16 attack_level;    /**< Level at the start of the attack. */
    Uint16 fade_length;     /**< Duration of the fade. */
    Uint16 fade_level;      /**< Level at the end of the fade. */

}

[DllImport("SDL2.dll")]
public static extern int SDL_NumHaptics();
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_HapticName(int device_index);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_HapticOpen(int device_index);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticOpened(int device_index);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticIndex(ref SDL_Haptic haptic);
[DllImport("SDL2.dll")]
public static extern int SDL_MouseIsHaptic();
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_HapticOpenFromMouse();
[DllImport("SDL2.dll")]
public static extern int SDL_JoystickIsHaptic(ref SDL_Joystick joystick);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_HapticOpenFromJoystick(ref SDL_Joystick joystick);
[DllImport("SDL2.dll")]
public static extern void SDL_HapticClose(ref SDL_Haptic haptic);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticNumEffects(ref SDL_Haptic haptic);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticNumEffectsPlaying(ref SDL_Haptic haptic);
[DllImport("SDL2.dll")]
public static extern unsigned int SDL_HapticQuery(ref SDL_Haptic haptic);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticNumAxes(ref SDL_Haptic haptic);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticEffectSupported(ref SDL_Haptic haptic, ref SDL_HapticEffect effect);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticNewEffect(ref SDL_Haptic haptic, ref SDL_HapticEffect effect);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticUpdateEffect(ref SDL_Haptic haptic, int effect, ref SDL_HapticEffect data);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticRunEffect(ref SDL_Haptic haptic, int effect, Uint32 iterations);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticStopEffect(ref SDL_Haptic haptic, int effect);
[DllImport("SDL2.dll")]
public static extern void SDL_HapticDestroyEffect(ref SDL_Haptic haptic, int effect);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticGetEffectStatus(ref SDL_Haptic haptic, int effect);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticSetGain(ref SDL_Haptic haptic, int gain);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticSetAutocenter(ref SDL_Haptic haptic, int autocenter);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticPause(ref SDL_Haptic haptic);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticUnpause(ref SDL_Haptic haptic);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticStopAll(ref SDL_Haptic haptic);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticRumbleSupported(ref SDL_Haptic haptic);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticRumbleInit(ref SDL_Haptic haptic);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticRumblePlay(ref SDL_Haptic haptic, float strength, Uint32 length);
[DllImport("SDL2.dll")]
public static extern int SDL_HapticRumbleStop(ref SDL_Haptic haptic);

}
}

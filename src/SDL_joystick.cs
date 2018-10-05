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
using static SDL2.SDL_timer;
using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

namespace SDL2
{
public static class SDL_joystick
{
public const int SDL_HAT_CENTERED = 0x00;
public const int SDL_HAT_UP = 0x01;
public const int SDL_HAT_RIGHT = 0x02;
public const int SDL_HAT_DOWN = 0x04;
public const int SDL_HAT_LEFT = 0x08;
public const int SDL_HAT_RIGHTUP = SDL_HAT_RIGHT|SDL_HAT_UP;
public const int SDL_HAT_RIGHTDOWN = SDL_HAT_RIGHT|SDL_HAT_DOWN;
public const int SDL_HAT_LEFTUP = SDL_HAT_LEFT|SDL_HAT_UP;
public const int SDL_HAT_LEFTDOWN = SDL_HAT_LEFT|SDL_HAT_DOWN;


[StructLayout(LayoutKind.Sequential)]
public struct SDL_JoystickGUID
{

    Uint8 data[16];

}

[DllImport("SDL2.dll")]
public static extern int SDL_NumJoysticks();
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_JoystickNameForIndex(int device_index);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_JoystickOpen(int device_index);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_JoystickName(ref SDL_Joystick joystick);
[DllImport("SDL2.dll")]
public static extern SDL_JoystickGUID SDL_JoystickGetDeviceGUID(int device_index);
[DllImport("SDL2.dll")]
public static extern SDL_JoystickGUID SDL_JoystickGetGUID(ref SDL_Joystick joystick);
[DllImport("SDL2.dll")]
public static extern void SDL_JoystickGetGUIDString(SDL_JoystickGUID guid, IntPtr pszGUID, int cbGUID);
[DllImport("SDL2.dll")]
public static extern SDL_JoystickGUID SDL_JoystickGetGUIDFromString(IntPtr pchGUID);
[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_JoystickGetAttached(ref SDL_Joystick joystick);
[DllImport("SDL2.dll")]
public static extern SDL_JoystickID SDL_JoystickInstanceID(ref SDL_Joystick joystick);
[DllImport("SDL2.dll")]
public static extern int SDL_JoystickNumAxes(ref SDL_Joystick joystick);
[DllImport("SDL2.dll")]
public static extern int SDL_JoystickNumBalls(ref SDL_Joystick joystick);
[DllImport("SDL2.dll")]
public static extern int SDL_JoystickNumHats(ref SDL_Joystick joystick);
[DllImport("SDL2.dll")]
public static extern int SDL_JoystickNumButtons(ref SDL_Joystick joystick);
[DllImport("SDL2.dll")]
public static extern void SDL_JoystickUpdate();
[DllImport("SDL2.dll")]
public static extern int SDL_JoystickEventState(int state);
[DllImport("SDL2.dll")]
public static extern short SDL_JoystickGetAxis(ref SDL_Joystick joystick, int axis);
[DllImport("SDL2.dll")]
public static extern byte SDL_JoystickGetHat(ref SDL_Joystick joystick, int hat);
[DllImport("SDL2.dll")]
public static extern int SDL_JoystickGetBall(ref SDL_Joystick joystick, int ball, ref int dx, ref int dy);
[DllImport("SDL2.dll")]
public static extern byte SDL_JoystickGetButton(ref SDL_Joystick joystick, int button);
[DllImport("SDL2.dll")]
public static extern void SDL_JoystickClose(ref SDL_Joystick joystick);

}
}

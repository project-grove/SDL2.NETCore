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
using static SDL2.SDL_timer;
using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

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


[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_SetHintWithPriority(IntPtr name, IntPtr value, SDL_HintPriority priority);
[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_SetHint(IntPtr name, IntPtr value);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetHint(IntPtr name);
[DllImport("SDL2.dll")]
public static extern void SDL_AddHintCallback(IntPtr name, SDL_HintCallback callback, ref void userdata);
[DllImport("SDL2.dll")]
public static extern void SDL_DelHintCallback(IntPtr name, SDL_HintCallback callback, ref void userdata);
[DllImport("SDL2.dll")]
public static extern void SDL_ClearHints();

}
}

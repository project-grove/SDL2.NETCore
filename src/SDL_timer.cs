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
public static class SDL_timer
{



[DllImport("SDL2.dll")]
public static extern uint SDL_GetTicks();
[DllImport("SDL2.dll")]
public static extern ulong SDL_GetPerformanceCounter();
[DllImport("SDL2.dll")]
public static extern ulong SDL_GetPerformanceFrequency();
[DllImport("SDL2.dll")]
public static extern void SDL_Delay(Uint32 ms);
[DllImport("SDL2.dll")]
public static extern SDL_TimerID SDL_AddTimer(Uint32 interval, SDL_TimerCallback callback, ref void param);
[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_RemoveTimer(SDL_TimerID id);

}
}

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
    public static class SDL_keycode
    {
        public const int SDLK_SCANCODE_MASK = 1 << 30;
        public const int KMOD_CTRL = (int)SDL_Keymod.KMOD_LCTRL | (int)SDL_Keymod.KMOD_RCTRL;
        public const int KMOD_SHIFT = (int)SDL_Keymod.KMOD_LSHIFT | (int)SDL_Keymod.KMOD_RSHIFT;
        public const int KMOD_ALT = (int)SDL_Keymod.KMOD_LALT | (int)SDL_Keymod.KMOD_RALT;
        public const int KMOD_GUI = (int)SDL_Keymod.KMOD_LGUI | (int)SDL_Keymod.KMOD_RGUI;

        public enum SDL_Keymod
        {

            KMOD_NONE = 0x0000,
            KMOD_LSHIFT = 0x0001,
            KMOD_RSHIFT = 0x0002,
            KMOD_LCTRL = 0x0040,
            KMOD_RCTRL = 0x0080,
            KMOD_LALT = 0x0100,
            KMOD_RALT = 0x0200,
            KMOD_LGUI = 0x0400,
            KMOD_RGUI = 0x0800,
            KMOD_NUM = 0x1000,
            KMOD_CAPS = 0x2000,
            KMOD_MODE = 0x4000,
            KMOD_RESERVED = 0x8000

        }

        public static int SDL_scancode_to_keycode(int scancode)
        {
            return scancode | SDLK_SCANCODE_MASK;
        }

    }
}


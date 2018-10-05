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
using static SDL2.SDL_power;
using static SDL2.SDL_rect;
using static SDL2.SDL_render;
using static SDL2.SDL_scancode;
using static SDL2.SDL_surface;

using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

using SDL_bool = System.Int32;

namespace SDL2
{
    public static class SDL_pixels
    {
        public const int SDL_ALPHA_OPAQUE = 255;
        public const int SDL_ALPHA_TRANSPARENT = 0;


        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Color
        {

            public byte r;
            public byte g;
            public byte b;
            public byte a;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Palette
        {

            public int ncolors;
            public IntPtr colors;
            public UInt32 version;
            public int refcount;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_PixelFormat
        {

            public UInt32 format;
            public IntPtr palette;
            public byte BitsPerPixel;
            public byte BytesPerPixel;
            public byte padding_1;
            public byte padding_2;
            public UInt32 Rmask;
            public UInt32 Gmask;
            public UInt32 Bmask;
            public UInt32 Amask;
            public byte Rloss;
            public byte Gloss;
            public byte Bloss;
            public byte Aloss;
            public byte Rshift;
            public byte Gshift;
            public byte Bshift;
            public byte Ashift;
            public int refcount;
            public IntPtr next;

        }

        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetPixelFormatName(UInt32 format);
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_PixelFormatEnumToMasks(UInt32 format, ref int bpp, ref uint Rmask, ref uint Gmask, ref uint Bmask, ref uint Amask);
        [DllImport("libSDL2.so")]
        public static extern uint SDL_MasksToPixelFormatEnum(int bpp, UInt32 Rmask, UInt32 Gmask, UInt32 Bmask, UInt32 Amask);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_AllocFormat(UInt32 pixel_format);
        [DllImport("libSDL2.so")]
        public static extern void SDL_FreeFormat(ref SDL_PixelFormat format);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_AllocPalette(int ncolors);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetPixelFormatPalette(ref SDL_PixelFormat format, ref SDL_Palette palette);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetPaletteColors(ref SDL_Palette palette, ref SDL_Color colors, int firstcolor, int ncolors);
        [DllImport("libSDL2.so")]
        public static extern void SDL_FreePalette(ref SDL_Palette palette);
        [DllImport("libSDL2.so")]
        public static extern uint SDL_MapRGB(ref SDL_PixelFormat format, byte r, byte g, byte b);
        [DllImport("libSDL2.so")]
        public static extern uint SDL_MapRGBA(ref SDL_PixelFormat format, byte r, byte g, byte b, byte a);
        [DllImport("libSDL2.so")]
        public static extern void SDL_GetRGB(UInt32 pixel, ref SDL_PixelFormat format, ref byte r, ref byte g, ref byte b);
        [DllImport("libSDL2.so")]
        public static extern void SDL_GetRGBA(UInt32 pixel, ref SDL_PixelFormat format, ref byte r, ref byte g, ref byte b, ref byte a);
        [DllImport("libSDL2.so")]
        public static extern void SDL_CalculateGammaRamp(float gamma, ref ushort ramp);

    }
}

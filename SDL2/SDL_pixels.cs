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
using NativeLibraryLoader;

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

        private delegate IntPtr SDL_GetPixelFormatName_UInt32_t(UInt32 format);

        private static SDL_GetPixelFormatName_UInt32_t s_SDL_GetPixelFormatName_UInt32_t = __LoadFunction<SDL_GetPixelFormatName_UInt32_t>("SDL_GetPixelFormatName");

        public static IntPtr SDL_GetPixelFormatName(UInt32 format) => s_SDL_GetPixelFormatName_UInt32_t(format);

        private delegate SDL_bool SDL_PixelFormatEnumToMasks_UInt32_int_uint_uint_uint_uint_t(UInt32 format, ref int bpp, ref uint Rmask, ref uint Gmask, ref uint Bmask, ref uint Amask);

        private static SDL_PixelFormatEnumToMasks_UInt32_int_uint_uint_uint_uint_t s_SDL_PixelFormatEnumToMasks_UInt32_int_uint_uint_uint_uint_t = __LoadFunction<SDL_PixelFormatEnumToMasks_UInt32_int_uint_uint_uint_uint_t>("SDL_PixelFormatEnumToMasks");

        public static SDL_bool SDL_PixelFormatEnumToMasks(UInt32 format, ref int bpp, ref uint Rmask, ref uint Gmask, ref uint Bmask, ref uint Amask) => s_SDL_PixelFormatEnumToMasks_UInt32_int_uint_uint_uint_uint_t(format, ref bpp, ref Rmask, ref Gmask, ref Bmask, ref Amask);

        private delegate uint SDL_MasksToPixelFormatEnum_int_UInt32_UInt32_UInt32_UInt32_t(int bpp, UInt32 Rmask, UInt32 Gmask, UInt32 Bmask, UInt32 Amask);

        private static SDL_MasksToPixelFormatEnum_int_UInt32_UInt32_UInt32_UInt32_t s_SDL_MasksToPixelFormatEnum_int_UInt32_UInt32_UInt32_UInt32_t = __LoadFunction<SDL_MasksToPixelFormatEnum_int_UInt32_UInt32_UInt32_UInt32_t>("SDL_MasksToPixelFormatEnum");

        public static uint SDL_MasksToPixelFormatEnum(int bpp, UInt32 Rmask, UInt32 Gmask, UInt32 Bmask, UInt32 Amask) => s_SDL_MasksToPixelFormatEnum_int_UInt32_UInt32_UInt32_UInt32_t(bpp, Rmask, Gmask, Bmask, Amask);

        private delegate IntPtr SDL_AllocFormat_UInt32_t(UInt32 pixel_format);

        private static SDL_AllocFormat_UInt32_t s_SDL_AllocFormat_UInt32_t = __LoadFunction<SDL_AllocFormat_UInt32_t>("SDL_AllocFormat");

        public static IntPtr SDL_AllocFormat(UInt32 pixel_format) => s_SDL_AllocFormat_UInt32_t(pixel_format);

        private delegate void SDL_FreeFormat_SDL_PixelFormat_t(ref SDL_PixelFormat format);

        private static SDL_FreeFormat_SDL_PixelFormat_t s_SDL_FreeFormat_SDL_PixelFormat_t = __LoadFunction<SDL_FreeFormat_SDL_PixelFormat_t>("SDL_FreeFormat");

        public static void SDL_FreeFormat(ref SDL_PixelFormat format) => s_SDL_FreeFormat_SDL_PixelFormat_t(ref format);

        private delegate IntPtr SDL_AllocPalette_int_t(int ncolors);

        private static SDL_AllocPalette_int_t s_SDL_AllocPalette_int_t = __LoadFunction<SDL_AllocPalette_int_t>("SDL_AllocPalette");

        public static IntPtr SDL_AllocPalette(int ncolors) => s_SDL_AllocPalette_int_t(ncolors);

        private delegate int SDL_SetPixelFormatPalette_SDL_PixelFormat_SDL_Palette_t(ref SDL_PixelFormat format, ref SDL_Palette palette);

        private static SDL_SetPixelFormatPalette_SDL_PixelFormat_SDL_Palette_t s_SDL_SetPixelFormatPalette_SDL_PixelFormat_SDL_Palette_t = __LoadFunction<SDL_SetPixelFormatPalette_SDL_PixelFormat_SDL_Palette_t>("SDL_SetPixelFormatPalette");

        public static int SDL_SetPixelFormatPalette(ref SDL_PixelFormat format, ref SDL_Palette palette) => s_SDL_SetPixelFormatPalette_SDL_PixelFormat_SDL_Palette_t(ref format, ref palette);

        private delegate int SDL_SetPaletteColors_SDL_Palette_SDL_Color_int_int_t(ref SDL_Palette palette, ref SDL_Color colors, int firstcolor, int ncolors);

        private static SDL_SetPaletteColors_SDL_Palette_SDL_Color_int_int_t s_SDL_SetPaletteColors_SDL_Palette_SDL_Color_int_int_t = __LoadFunction<SDL_SetPaletteColors_SDL_Palette_SDL_Color_int_int_t>("SDL_SetPaletteColors");

        public static int SDL_SetPaletteColors(ref SDL_Palette palette, ref SDL_Color colors, int firstcolor, int ncolors) => s_SDL_SetPaletteColors_SDL_Palette_SDL_Color_int_int_t(ref palette, ref colors, firstcolor, ncolors);

        private delegate void SDL_FreePalette_SDL_Palette_t(ref SDL_Palette palette);

        private static SDL_FreePalette_SDL_Palette_t s_SDL_FreePalette_SDL_Palette_t = __LoadFunction<SDL_FreePalette_SDL_Palette_t>("SDL_FreePalette");

        public static void SDL_FreePalette(ref SDL_Palette palette) => s_SDL_FreePalette_SDL_Palette_t(ref palette);

        private delegate uint SDL_MapRGB_SDL_PixelFormat_byte_byte_byte_t(ref SDL_PixelFormat format, byte r, byte g, byte b);

        private static SDL_MapRGB_SDL_PixelFormat_byte_byte_byte_t s_SDL_MapRGB_SDL_PixelFormat_byte_byte_byte_t = __LoadFunction<SDL_MapRGB_SDL_PixelFormat_byte_byte_byte_t>("SDL_MapRGB");

        public static uint SDL_MapRGB(ref SDL_PixelFormat format, byte r, byte g, byte b) => s_SDL_MapRGB_SDL_PixelFormat_byte_byte_byte_t(ref format, r, g, b);

        private delegate uint SDL_MapRGBA_SDL_PixelFormat_byte_byte_byte_byte_t(ref SDL_PixelFormat format, byte r, byte g, byte b, byte a);

        private static SDL_MapRGBA_SDL_PixelFormat_byte_byte_byte_byte_t s_SDL_MapRGBA_SDL_PixelFormat_byte_byte_byte_byte_t = __LoadFunction<SDL_MapRGBA_SDL_PixelFormat_byte_byte_byte_byte_t>("SDL_MapRGBA");

        public static uint SDL_MapRGBA(ref SDL_PixelFormat format, byte r, byte g, byte b, byte a) => s_SDL_MapRGBA_SDL_PixelFormat_byte_byte_byte_byte_t(ref format, r, g, b, a);

        private delegate void SDL_GetRGB_UInt32_SDL_PixelFormat_byte_byte_byte_t(UInt32 pixel, ref SDL_PixelFormat format, ref byte r, ref byte g, ref byte b);

        private static SDL_GetRGB_UInt32_SDL_PixelFormat_byte_byte_byte_t s_SDL_GetRGB_UInt32_SDL_PixelFormat_byte_byte_byte_t = __LoadFunction<SDL_GetRGB_UInt32_SDL_PixelFormat_byte_byte_byte_t>("SDL_GetRGB");

        public static void SDL_GetRGB(UInt32 pixel, ref SDL_PixelFormat format, ref byte r, ref byte g, ref byte b) => s_SDL_GetRGB_UInt32_SDL_PixelFormat_byte_byte_byte_t(pixel, ref format, ref r, ref g, ref b);

        private delegate void SDL_GetRGBA_UInt32_SDL_PixelFormat_byte_byte_byte_byte_t(UInt32 pixel, ref SDL_PixelFormat format, ref byte r, ref byte g, ref byte b, ref byte a);

        private static SDL_GetRGBA_UInt32_SDL_PixelFormat_byte_byte_byte_byte_t s_SDL_GetRGBA_UInt32_SDL_PixelFormat_byte_byte_byte_byte_t = __LoadFunction<SDL_GetRGBA_UInt32_SDL_PixelFormat_byte_byte_byte_byte_t>("SDL_GetRGBA");

        public static void SDL_GetRGBA(UInt32 pixel, ref SDL_PixelFormat format, ref byte r, ref byte g, ref byte b, ref byte a) => s_SDL_GetRGBA_UInt32_SDL_PixelFormat_byte_byte_byte_byte_t(pixel, ref format, ref r, ref g, ref b, ref a);

        private delegate void SDL_CalculateGammaRamp_float_ushort_t(float gamma, ref ushort ramp);

        private static SDL_CalculateGammaRamp_float_ushort_t s_SDL_CalculateGammaRamp_float_ushort_t = __LoadFunction<SDL_CalculateGammaRamp_float_ushort_t>("SDL_CalculateGammaRamp");

        public static void SDL_CalculateGammaRamp(float gamma, ref ushort ramp) => s_SDL_CalculateGammaRamp_float_ushort_t(gamma, ref ramp);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


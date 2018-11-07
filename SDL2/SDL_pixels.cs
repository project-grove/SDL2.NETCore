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


        /** Pixel formats */
        public const uint SDL_PIXELFORMAT_UNKNOWN = 0x0;
        public const uint SDL_PIXELFORMAT_INDEX1LSB = 0x11100100;
        public const uint SDL_PIXELFORMAT_INDEX1MSB = 0x11200100;
        public const uint SDL_PIXELFORMAT_INDEX4LSB = 0x12100400;
        public const uint SDL_PIXELFORMAT_INDEX4MSB = 0x12200400;
        public const uint SDL_PIXELFORMAT_INDEX8 = 0x13000801;
        public const uint SDL_PIXELFORMAT_RGB332 = 0x14110801;
        public const uint SDL_PIXELFORMAT_RGB444 = 0x15120c02;
        public const uint SDL_PIXELFORMAT_RGB555 = 0x15130f02;
        public const uint SDL_PIXELFORMAT_BGR555 = 0x15530f02;
        public const uint SDL_PIXELFORMAT_ARGB4444 = 0x15321002;
        public const uint SDL_PIXELFORMAT_RGBA4444 = 0x15421002;
        public const uint SDL_PIXELFORMAT_ABGR4444 = 0x15721002;
        public const uint SDL_PIXELFORMAT_BGRA4444 = 0x15821002;
        public const uint SDL_PIXELFORMAT_ARGB1555 = 0x15331002;
        public const uint SDL_PIXELFORMAT_RGBA5551 = 0x15441002;
        public const uint SDL_PIXELFORMAT_ABGR1555 = 0x15731002;
        public const uint SDL_PIXELFORMAT_BGRA5551 = 0x15841002;
        public const uint SDL_PIXELFORMAT_RGB565 = 0x15151002;
        public const uint SDL_PIXELFORMAT_BGR565 = 0x15551002;
        public const uint SDL_PIXELFORMAT_RGB24 = 0x17101803;
        public const uint SDL_PIXELFORMAT_BGR24 = 0x17401803;
        public const uint SDL_PIXELFORMAT_RGB888 = 0x16161804;
        public const uint SDL_PIXELFORMAT_RGBX8888 = 0x16261804;
        public const uint SDL_PIXELFORMAT_BGR888 = 0x16561804;
        public const uint SDL_PIXELFORMAT_BGRX8888 = 0x16661804;
        public const uint SDL_PIXELFORMAT_ARGB8888 = 0x16362004;
        public const uint SDL_PIXELFORMAT_RGBA8888 = 0x16462004;
        public const uint SDL_PIXELFORMAT_ABGR8888 = 0x16762004;
        public const uint SDL_PIXELFORMAT_BGRA8888 = 0x16862004;
        public const uint SDL_PIXELFORMAT_ARGB2101010 = 0x16372004;
        public const uint SDL_PIXELFORMAT_YV12 = 0x32315659;
        public const uint SDL_PIXELFORMAT_IYUV = 0x56555949;
        public const uint SDL_PIXELFORMAT_YUY2 = 0x32595559;
        public const uint SDL_PIXELFORMAT_UYVY = 0x59565955;
        public const uint SDL_PIXELFORMAT_YVYU = 0x55595659;

        /** Pixel type. */
        public enum SDL_PixelType
        {
            SDL_PIXELTYPE_UNKNOWN,
            SDL_PIXELTYPE_INDEX1,
            SDL_PIXELTYPE_INDEX4,
            SDL_PIXELTYPE_INDEX8,
            SDL_PIXELTYPE_PACKED8,
            SDL_PIXELTYPE_PACKED16,
            SDL_PIXELTYPE_PACKED32,
            SDL_PIXELTYPE_ARRAYU8,
            SDL_PIXELTYPE_ARRAYU16,
            SDL_PIXELTYPE_ARRAYU32,
            SDL_PIXELTYPE_ARRAYF16,
            SDL_PIXELTYPE_ARRAYF32
        };

        /** Bitmap pixel order, high bit -> low bit. */
        public enum SDL_BitmapOrder
        {
            SDL_BITMAPORDER_NONE,
            SDL_BITMAPORDER_4321,
            SDL_BITMAPORDER_1234
        };

        /** Packed component order, high bit -> low bit. */
        public enum SDL_PackedOrder
        {
            SDL_PACKEDORDER_NONE,
            SDL_PACKEDORDER_XRGB,
            SDL_PACKEDORDER_RGBX,
            SDL_PACKEDORDER_ARGB,
            SDL_PACKEDORDER_RGBA,
            SDL_PACKEDORDER_XBGR,
            SDL_PACKEDORDER_BGRX,
            SDL_PACKEDORDER_ABGR,
            SDL_PACKEDORDER_BGRA
        };

        /** Array component order, low byte -> high byte. */
        public enum SDL_ArrayOrder
        {
            SDL_ARRAYORDER_NONE,
            SDL_ARRAYORDER_RGB,
            SDL_ARRAYORDER_RGBA,
            SDL_ARRAYORDER_ARGB,
            SDL_ARRAYORDER_BGR,
            SDL_ARRAYORDER_BGRA,
            SDL_ARRAYORDER_ABGR
        };

        /** Packed component layout. */
        public enum SDL_PackedLayout
        {
            SDL_PACKEDLAYOUT_NONE,
            SDL_PACKEDLAYOUT_332,
            SDL_PACKEDLAYOUT_4444,
            SDL_PACKEDLAYOUT_1555,
            SDL_PACKEDLAYOUT_5551,
            SDL_PACKEDLAYOUT_565,
            SDL_PACKEDLAYOUT_8888,
            SDL_PACKEDLAYOUT_2101010,
            SDL_PACKEDLAYOUT_1010102
        };


        public static uint SDL_PIXELFLAG(uint format) => ((format >> 28) & 0x0F);
        public static SDL_PixelType SDL_PIXELTYPE(uint format) => (SDL_PixelType)((format >> 24) & 0x0F);
        // SDL_BitmapOrder, SDL_PackedOrder or SDL_ArrayOrder
        public static int SDL_PIXELORDER(uint format) => (int)((format >> 20) & 0x0F);
        public static SDL_PackedLayout SDL_PIXELLAYOUT(uint format) => (SDL_PackedLayout)((format >> 16) & 0x0F);
        public static int SDL_BITSPERPIXEL(uint format) => (int)((format >> 8) & 0xFF);
        public static int SDL_BYTESPERPIXEL(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format))
            {
                switch (format)
                {
                    case SDL_PIXELFORMAT_YUY2:
                    case SDL_PIXELFORMAT_UYVY:
                    case SDL_PIXELFORMAT_YVYU:
                        return 2;
                    default:
                        return 1;
                }
            }
            return (int)(format & 0xFF);
        }
        public static bool SDL_ISPIXELFORMAT_FOURCC(uint format) => ((format) & (SDL_PIXELFLAG(format) != 1 ? 1U : 0U)) > 0;
        public static bool SDL_ISPIXELFORMAT_ALPHA(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format)) return false;
            if (SDL_ISPIXELFORMAT_PACKED(format))
            {
                switch ((SDL_PackedOrder)SDL_PIXELORDER(format))
                {
                    case SDL_PackedOrder.SDL_PACKEDORDER_ARGB:
                    case SDL_PackedOrder.SDL_PACKEDORDER_ABGR:
                    case SDL_PackedOrder.SDL_PACKEDORDER_BGRA:
                    case SDL_PackedOrder.SDL_PACKEDORDER_RGBA:
                        return true;
                    default:
                        return false;
                }
            }
            else if (SDL_ISPIXELFORMAT_ARRAY(format))
            {
                switch ((SDL_ArrayOrder)SDL_PIXELORDER(format))
                {
                    case SDL_ArrayOrder.SDL_ARRAYORDER_ABGR:
                    case SDL_ArrayOrder.SDL_ARRAYORDER_ARGB:
                    case SDL_ArrayOrder.SDL_ARRAYORDER_BGRA:
                    case SDL_ArrayOrder.SDL_ARRAYORDER_RGBA:
                        return true;
                    default:
                        return false;
                }
            }
            return false;
        }

        public static bool SDL_ISPIXELFORMAT_INDEXED(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format)) return false;
            switch (SDL_PIXELTYPE(format))
            {
                case SDL_PixelType.SDL_PIXELTYPE_INDEX1:
                case SDL_PixelType.SDL_PIXELTYPE_INDEX4:
                case SDL_PixelType.SDL_PIXELTYPE_INDEX8:
                    return true;
                default:
                    return false;
            }
        }

        public static bool SDL_ISPIXELFORMAT_PACKED(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format)) return false;
            switch (SDL_PIXELTYPE(format))
            {
                case SDL_PixelType.SDL_PIXELTYPE_PACKED8:
                case SDL_PixelType.SDL_PIXELTYPE_PACKED16:
                case SDL_PixelType.SDL_PIXELTYPE_PACKED32:
                    return true;
                default:
                    return false;
            }
        }

        public static bool SDL_ISPIXELFORMAT_ARRAY(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format)) return false;
            switch (SDL_PIXELTYPE(format))
            {
                case SDL_PixelType.SDL_PIXELTYPE_ARRAYU8:
                case SDL_PixelType.SDL_PIXELTYPE_ARRAYU16:
                case SDL_PixelType.SDL_PIXELTYPE_ARRAYU32:
                case SDL_PixelType.SDL_PIXELTYPE_ARRAYF16:
                case SDL_PixelType.SDL_PIXELTYPE_ARRAYF32:
                    return true;
                default:
                    return false;
            }
        }

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

        private delegate void SDL_FreeFormat_SDL_PixelFormat_t(IntPtr format);

        private static SDL_FreeFormat_SDL_PixelFormat_t s_SDL_FreeFormat_SDL_PixelFormat_t = __LoadFunction<SDL_FreeFormat_SDL_PixelFormat_t>("SDL_FreeFormat");

        public static void SDL_FreeFormat(IntPtr format) => s_SDL_FreeFormat_SDL_PixelFormat_t(format);

        private delegate IntPtr SDL_AllocPalette_int_t(int ncolors);

        private static SDL_AllocPalette_int_t s_SDL_AllocPalette_int_t = __LoadFunction<SDL_AllocPalette_int_t>("SDL_AllocPalette");

        public static IntPtr SDL_AllocPalette(int ncolors) => s_SDL_AllocPalette_int_t(ncolors);

        private delegate int SDL_SetPixelFormatPalette_SDL_PixelFormat_SDL_Palette_t(IntPtr format, IntPtr palette);

        private static SDL_SetPixelFormatPalette_SDL_PixelFormat_SDL_Palette_t s_SDL_SetPixelFormatPalette_SDL_PixelFormat_SDL_Palette_t = __LoadFunction<SDL_SetPixelFormatPalette_SDL_PixelFormat_SDL_Palette_t>("SDL_SetPixelFormatPalette");

        public static int SDL_SetPixelFormatPalette(IntPtr format, IntPtr palette) => s_SDL_SetPixelFormatPalette_SDL_PixelFormat_SDL_Palette_t(format, palette);

        private delegate int SDL_SetPaletteColors_SDL_Palette_SDL_Color_int_int_t(IntPtr palette, IntPtr colors, int firstcolor, int ncolors);

        private static SDL_SetPaletteColors_SDL_Palette_SDL_Color_int_int_t s_SDL_SetPaletteColors_SDL_Palette_SDL_Color_int_int_t = __LoadFunction<SDL_SetPaletteColors_SDL_Palette_SDL_Color_int_int_t>("SDL_SetPaletteColors");

        public static int SDL_SetPaletteColors(IntPtr palette, IntPtr colors, int firstcolor, int ncolors) => s_SDL_SetPaletteColors_SDL_Palette_SDL_Color_int_int_t(palette, colors, firstcolor, ncolors);

        private delegate void SDL_FreePalette_SDL_Palette_t(IntPtr palette);

        private static SDL_FreePalette_SDL_Palette_t s_SDL_FreePalette_SDL_Palette_t = __LoadFunction<SDL_FreePalette_SDL_Palette_t>("SDL_FreePalette");

        public static void SDL_FreePalette(IntPtr palette) => s_SDL_FreePalette_SDL_Palette_t(palette);

        private delegate uint SDL_MapRGB_SDL_PixelFormat_byte_byte_byte_t(IntPtr format, byte r, byte g, byte b);

        private static SDL_MapRGB_SDL_PixelFormat_byte_byte_byte_t s_SDL_MapRGB_SDL_PixelFormat_byte_byte_byte_t = __LoadFunction<SDL_MapRGB_SDL_PixelFormat_byte_byte_byte_t>("SDL_MapRGB");

        public static uint SDL_MapRGB(IntPtr format, byte r, byte g, byte b) => s_SDL_MapRGB_SDL_PixelFormat_byte_byte_byte_t(format, r, g, b);

        private delegate uint SDL_MapRGBA_SDL_PixelFormat_byte_byte_byte_byte_t(IntPtr format, byte r, byte g, byte b, byte a);

        private static SDL_MapRGBA_SDL_PixelFormat_byte_byte_byte_byte_t s_SDL_MapRGBA_SDL_PixelFormat_byte_byte_byte_byte_t = __LoadFunction<SDL_MapRGBA_SDL_PixelFormat_byte_byte_byte_byte_t>("SDL_MapRGBA");

        public static uint SDL_MapRGBA(IntPtr format, byte r, byte g, byte b, byte a) => s_SDL_MapRGBA_SDL_PixelFormat_byte_byte_byte_byte_t(format, r, g, b, a);

        private delegate void SDL_GetRGB_UInt32_SDL_PixelFormat_byte_byte_byte_t(UInt32 pixel, IntPtr format, ref byte r, ref byte g, ref byte b);

        private static SDL_GetRGB_UInt32_SDL_PixelFormat_byte_byte_byte_t s_SDL_GetRGB_UInt32_SDL_PixelFormat_byte_byte_byte_t = __LoadFunction<SDL_GetRGB_UInt32_SDL_PixelFormat_byte_byte_byte_t>("SDL_GetRGB");

        public static void SDL_GetRGB(UInt32 pixel, IntPtr format, ref byte r, ref byte g, ref byte b) => s_SDL_GetRGB_UInt32_SDL_PixelFormat_byte_byte_byte_t(pixel, format, ref r, ref g, ref b);

        private delegate void SDL_GetRGBA_UInt32_SDL_PixelFormat_byte_byte_byte_byte_t(UInt32 pixel, IntPtr format, ref byte r, ref byte g, ref byte b, ref byte a);

        private static SDL_GetRGBA_UInt32_SDL_PixelFormat_byte_byte_byte_byte_t s_SDL_GetRGBA_UInt32_SDL_PixelFormat_byte_byte_byte_byte_t = __LoadFunction<SDL_GetRGBA_UInt32_SDL_PixelFormat_byte_byte_byte_byte_t>("SDL_GetRGBA");

        public static void SDL_GetRGBA(UInt32 pixel, IntPtr format, ref byte r, ref byte g, ref byte b, ref byte a) => s_SDL_GetRGBA_UInt32_SDL_PixelFormat_byte_byte_byte_byte_t(pixel, format, ref r, ref g, ref b, ref a);

        private delegate void SDL_CalculateGammaRamp_float_ushort_t(float gamma, ref ushort ramp);

        private static SDL_CalculateGammaRamp_float_ushort_t s_SDL_CalculateGammaRamp_float_ushort_t = __LoadFunction<SDL_CalculateGammaRamp_float_ushort_t>("SDL_CalculateGammaRamp");

        public static void SDL_CalculateGammaRamp(float gamma, ref ushort ramp) => s_SDL_CalculateGammaRamp_float_ushort_t(gamma, ref ramp);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


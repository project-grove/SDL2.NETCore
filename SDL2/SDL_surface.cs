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

using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

using SDL_RWops = System.IntPtr;
using SDL_bool = System.Int32;
using NativeLibraryLoader;

namespace SDL2
{
    public static class SDL_surface
    {
        public const int SDL_SWSURFACE = 0;
        public const int SDL_PREALLOC = 0x00000001;
        public const int SDL_RLEACCEL = 0x00000002;
        public const int SDL_DONTFREE = 0x00000004;
        public static bool SDL_MUSTLOCK(SDL_Surface S) =>
            ((S.flags & SDL_RLEACCEL) != 0);

        [StructLayout(LayoutKind.Sequential)]
        unsafe struct SDL_BlitInfo
        {
            byte* src;
            int src_w, src_h;
            int src_pitch;
            int src_skip;
            byte* dst;
            int dst_w, dst_h;
            int dst_pitch;
            int dst_skip;
            SDL_PixelFormat* src_fmt;
            SDL_PixelFormat* dst_fmt;
            byte* table;
            int flags;
            UInt32 colorkey;
            byte r, g, b, a;
        }

        [StructLayout(LayoutKind.Sequential)]
        unsafe struct SDL_BlitMap
        {
            SDL_Surface* dst;
            int identity;
            IntPtr blit;
            void* data;
            SDL_BlitInfo info;

            /* the version count matches the destination; mismatch indicates
               an invalid mapping */
            UInt32 dst_palette_version;
            UInt32 src_palette_version;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_Surface
        {

            public UInt32 flags;               /**< Read-only */
            public IntPtr format;    /**< Read-only */
            public int w, h;                   /**< Read-only */
            public int pitch;                  /**< Read-only */
            public IntPtr pixels;               /**< Read-write */

            /** Application data associated with the surface */
            public IntPtr userdata;             /**< Read-write */

            /** information needed for surfaces requiring locks */
            public int locked;                 /**< Read-only */
            public IntPtr lock_data;            /**< Read-only */

            /** clipping information */
            public SDL_Rect clip_rect;         /**< Read-only */

            /** info for fast blit mapping to other surfaces */
            // struct SDL_BlitMap map;    /**< Private */
            SDL_BlitMap map;

            /** Reference count -- used when freeing surface */
            int refcount;               /**< Read-mostly */

        }

        private delegate IntPtr SDL_CreateRGBSurface_uint_int_int_int_uint_uint_uint_uint_t(uint flags, int width, int height, int depth, uint rmask, uint gmask, uint bmask, uint amask);

        private static SDL_CreateRGBSurface_uint_int_int_int_uint_uint_uint_uint_t s_SDL_CreateRGBSurface_uint_int_int_int_uint_uint_uint_uint_t = __LoadFunction<SDL_CreateRGBSurface_uint_int_int_int_uint_uint_uint_uint_t>("SDL_CreateRGBSurface");

        public static IntPtr SDL_CreateRGBSurface(uint flags, int width, int height, int depth, uint rmask, uint gmask, uint bmask, uint amask) => s_SDL_CreateRGBSurface_uint_int_int_int_uint_uint_uint_uint_t(flags, width, height, depth, rmask, gmask, bmask, amask);

        private delegate IntPtr SDL_CreateRGBSurfaceFrom_IntPtr_int_int_int_int_UInt32_UInt32_UInt32_UInt32_t(IntPtr pixels, int width, int height, int depth, int pitch, UInt32 Rmask, UInt32 Gmask, UInt32 Bmask, UInt32 Amask);

        private static SDL_CreateRGBSurfaceFrom_IntPtr_int_int_int_int_UInt32_UInt32_UInt32_UInt32_t s_SDL_CreateRGBSurfaceFrom_IntPtr_int_int_int_int_UInt32_UInt32_UInt32_UInt32_t = __LoadFunction<SDL_CreateRGBSurfaceFrom_IntPtr_int_int_int_int_UInt32_UInt32_UInt32_UInt32_t>("SDL_CreateRGBSurfaceFrom");

        public static IntPtr SDL_CreateRGBSurfaceFrom(IntPtr pixels, int width, int height, int depth, int pitch, UInt32 Rmask, UInt32 Gmask, UInt32 Bmask, UInt32 Amask) => s_SDL_CreateRGBSurfaceFrom_IntPtr_int_int_int_int_UInt32_UInt32_UInt32_UInt32_t(pixels, width, height, depth, pitch, Rmask, Gmask, Bmask, Amask);

        private delegate void SDL_FreeSurface_SDL_Surface_t(IntPtr surface);

        private static SDL_FreeSurface_SDL_Surface_t s_SDL_FreeSurface_SDL_Surface_t = __LoadFunction<SDL_FreeSurface_SDL_Surface_t>("SDL_FreeSurface");

        public static void SDL_FreeSurface(IntPtr surface) => s_SDL_FreeSurface_SDL_Surface_t(surface);

        private delegate int SDL_SetSurfacePalette_SDL_Surface_SDL_Palette_t(IntPtr surface, ref SDL_Palette palette);

        private static SDL_SetSurfacePalette_SDL_Surface_SDL_Palette_t s_SDL_SetSurfacePalette_SDL_Surface_SDL_Palette_t = __LoadFunction<SDL_SetSurfacePalette_SDL_Surface_SDL_Palette_t>("SDL_SetSurfacePalette");

        public static int SDL_SetSurfacePalette(IntPtr surface, ref SDL_Palette palette) => s_SDL_SetSurfacePalette_SDL_Surface_SDL_Palette_t(surface, ref palette);

        private delegate int SDL_LockSurface_SDL_Surface_t(IntPtr surface);

        private static SDL_LockSurface_SDL_Surface_t s_SDL_LockSurface_SDL_Surface_t = __LoadFunction<SDL_LockSurface_SDL_Surface_t>("SDL_LockSurface");

        public static int SDL_LockSurface(IntPtr surface) => s_SDL_LockSurface_SDL_Surface_t(surface);

        private delegate void SDL_UnlockSurface_SDL_Surface_t(IntPtr surface);

        private static SDL_UnlockSurface_SDL_Surface_t s_SDL_UnlockSurface_SDL_Surface_t = __LoadFunction<SDL_UnlockSurface_SDL_Surface_t>("SDL_UnlockSurface");

        public static void SDL_UnlockSurface(IntPtr surface) => s_SDL_UnlockSurface_SDL_Surface_t(surface);

        private delegate IntPtr SDL_LoadBMP_RW_SDL_RWops_int_t(IntPtr src, int freesrc);

        private static SDL_LoadBMP_RW_SDL_RWops_int_t s_SDL_LoadBMP_RW_SDL_RWops_int_t = __LoadFunction<SDL_LoadBMP_RW_SDL_RWops_int_t>("SDL_LoadBMP_RW");

        public static IntPtr SDL_LoadBMP_RW(IntPtr src, int freesrc) => s_SDL_LoadBMP_RW_SDL_RWops_int_t(src, freesrc);

        private delegate int SDL_SetSurfaceRLE_SDL_Surface_int_t(IntPtr surface, int flag);

        private static SDL_SetSurfaceRLE_SDL_Surface_int_t s_SDL_SetSurfaceRLE_SDL_Surface_int_t = __LoadFunction<SDL_SetSurfaceRLE_SDL_Surface_int_t>("SDL_SetSurfaceRLE");

        public static int SDL_SetSurfaceRLE(IntPtr surface, int flag) => s_SDL_SetSurfaceRLE_SDL_Surface_int_t(surface, flag);

        private delegate int SDL_SetColorKey_SDL_Surface_int_UInt32_t(IntPtr surface, int flag, UInt32 key);

        private static SDL_SetColorKey_SDL_Surface_int_UInt32_t s_SDL_SetColorKey_SDL_Surface_int_UInt32_t = __LoadFunction<SDL_SetColorKey_SDL_Surface_int_UInt32_t>("SDL_SetColorKey");

        public static int SDL_SetColorKey(IntPtr surface, int flag, UInt32 key) => s_SDL_SetColorKey_SDL_Surface_int_UInt32_t(surface, flag, key);

        private delegate int SDL_GetColorKey_SDL_Surface_uint_t(IntPtr surface, ref uint key);

        private static SDL_GetColorKey_SDL_Surface_uint_t s_SDL_GetColorKey_SDL_Surface_uint_t = __LoadFunction<SDL_GetColorKey_SDL_Surface_uint_t>("SDL_GetColorKey");

        public static int SDL_GetColorKey(IntPtr surface, ref uint key) => s_SDL_GetColorKey_SDL_Surface_uint_t(surface, ref key);

        private delegate int SDL_SetSurfaceColorMod_SDL_Surface_byte_byte_byte_t(IntPtr surface, byte r, byte g, byte b);

        private static SDL_SetSurfaceColorMod_SDL_Surface_byte_byte_byte_t s_SDL_SetSurfaceColorMod_SDL_Surface_byte_byte_byte_t = __LoadFunction<SDL_SetSurfaceColorMod_SDL_Surface_byte_byte_byte_t>("SDL_SetSurfaceColorMod");

        public static int SDL_SetSurfaceColorMod(IntPtr surface, byte r, byte g, byte b) => s_SDL_SetSurfaceColorMod_SDL_Surface_byte_byte_byte_t(surface, r, g, b);

        private delegate int SDL_GetSurfaceColorMod_SDL_Surface_byte_byte_byte_t(IntPtr surface, ref byte r, ref byte g, ref byte b);

        private static SDL_GetSurfaceColorMod_SDL_Surface_byte_byte_byte_t s_SDL_GetSurfaceColorMod_SDL_Surface_byte_byte_byte_t = __LoadFunction<SDL_GetSurfaceColorMod_SDL_Surface_byte_byte_byte_t>("SDL_GetSurfaceColorMod");

        public static int SDL_GetSurfaceColorMod(IntPtr surface, ref byte r, ref byte g, ref byte b) => s_SDL_GetSurfaceColorMod_SDL_Surface_byte_byte_byte_t(surface, ref r, ref g, ref b);

        private delegate int SDL_SetSurfaceAlphaMod_SDL_Surface_byte_t(IntPtr surface, byte alpha);

        private static SDL_SetSurfaceAlphaMod_SDL_Surface_byte_t s_SDL_SetSurfaceAlphaMod_SDL_Surface_byte_t = __LoadFunction<SDL_SetSurfaceAlphaMod_SDL_Surface_byte_t>("SDL_SetSurfaceAlphaMod");

        public static int SDL_SetSurfaceAlphaMod(IntPtr surface, byte alpha) => s_SDL_SetSurfaceAlphaMod_SDL_Surface_byte_t(surface, alpha);

        private delegate int SDL_GetSurfaceAlphaMod_SDL_Surface_byte_t(IntPtr surface, ref byte alpha);

        private static SDL_GetSurfaceAlphaMod_SDL_Surface_byte_t s_SDL_GetSurfaceAlphaMod_SDL_Surface_byte_t = __LoadFunction<SDL_GetSurfaceAlphaMod_SDL_Surface_byte_t>("SDL_GetSurfaceAlphaMod");

        public static int SDL_GetSurfaceAlphaMod(IntPtr surface, ref byte alpha) => s_SDL_GetSurfaceAlphaMod_SDL_Surface_byte_t(surface, ref alpha);

        private delegate int SDL_SetSurfaceBlendMode_SDL_Surface_SDL_BlendMode_t(IntPtr surface, SDL_BlendMode blendMode);

        private static SDL_SetSurfaceBlendMode_SDL_Surface_SDL_BlendMode_t s_SDL_SetSurfaceBlendMode_SDL_Surface_SDL_BlendMode_t = __LoadFunction<SDL_SetSurfaceBlendMode_SDL_Surface_SDL_BlendMode_t>("SDL_SetSurfaceBlendMode");

        public static int SDL_SetSurfaceBlendMode(IntPtr surface, SDL_BlendMode blendMode) => s_SDL_SetSurfaceBlendMode_SDL_Surface_SDL_BlendMode_t(surface, blendMode);

        private delegate int SDL_GetSurfaceBlendMode_SDL_Surface_SDL_BlendMode_t(IntPtr surface, ref SDL_BlendMode blendMode);

        private static SDL_GetSurfaceBlendMode_SDL_Surface_SDL_BlendMode_t s_SDL_GetSurfaceBlendMode_SDL_Surface_SDL_BlendMode_t = __LoadFunction<SDL_GetSurfaceBlendMode_SDL_Surface_SDL_BlendMode_t>("SDL_GetSurfaceBlendMode");

        public static int SDL_GetSurfaceBlendMode(IntPtr surface, ref SDL_BlendMode blendMode) => s_SDL_GetSurfaceBlendMode_SDL_Surface_SDL_BlendMode_t(surface, ref blendMode);

        private unsafe delegate SDL_bool SDL_SetClipRect_SDL_Surface_SDL_Rect_t(IntPtr surface, SDL_Rect* rect);

        private static SDL_SetClipRect_SDL_Surface_SDL_Rect_t s_SDL_SetClipRect_SDL_Surface_SDL_Rect_t = __LoadFunction<SDL_SetClipRect_SDL_Surface_SDL_Rect_t>("SDL_SetClipRect");

        public static unsafe SDL_bool SDL_SetClipRect(IntPtr surface, SDL_Rect* rect) => s_SDL_SetClipRect_SDL_Surface_SDL_Rect_t(surface, rect);

        private unsafe delegate void SDL_GetClipRect_SDL_Surface_SDL_Rect_t(IntPtr surface, SDL_Rect* rect);

        private static SDL_GetClipRect_SDL_Surface_SDL_Rect_t s_SDL_GetClipRect_SDL_Surface_SDL_Rect_t = __LoadFunction<SDL_GetClipRect_SDL_Surface_SDL_Rect_t>("SDL_GetClipRect");

        public unsafe static void SDL_GetClipRect(IntPtr surface, SDL_Rect* rect) => s_SDL_GetClipRect_SDL_Surface_SDL_Rect_t(surface, rect);

        private delegate int SDL_ConvertPixels_int_int_UInt32_IntPtr_int_UInt32_IntPtr_int_t(int width, int height, UInt32 src_format, IntPtr src, int src_pitch, UInt32 dst_format, IntPtr dst, int dst_pitch);

        private static SDL_ConvertPixels_int_int_UInt32_IntPtr_int_UInt32_IntPtr_int_t s_SDL_ConvertPixels_int_int_UInt32_IntPtr_int_UInt32_IntPtr_int_t = __LoadFunction<SDL_ConvertPixels_int_int_UInt32_IntPtr_int_UInt32_IntPtr_int_t>("SDL_ConvertPixels");

        public static int SDL_ConvertPixels(int width, int height, UInt32 src_format, IntPtr src, int src_pitch, UInt32 dst_format, IntPtr dst, int dst_pitch) => s_SDL_ConvertPixels_int_int_UInt32_IntPtr_int_UInt32_IntPtr_int_t(width, height, src_format, src, src_pitch, dst_format, dst, dst_pitch);

        private unsafe delegate int SDL_SoftStretch_SDL_Surface_SDL_Rect_SDL_Surface_SDL_Rect_t(IntPtr src, SDL_Rect* srcrect, IntPtr dst, SDL_Rect* dstrect);

        private unsafe delegate int SDL_BlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t(IntPtr src, SDL_Rect* srcrect, IntPtr dst, SDL_Rect* dstrect);

        private static SDL_BlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t s_SDL_BlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t;

        public unsafe static int SDL_BlitScaled(IntPtr src, SDL_Rect* srcrect, IntPtr dst, SDL_Rect* dstrect) => s_SDL_BlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t(src, srcrect, dst, dstrect);

        private unsafe delegate int SDL_LowerBlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t(IntPtr src, SDL_Rect* srcrect, IntPtr dst, SDL_Rect* dstrect);

        private static SDL_LowerBlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t s_SDL_LowerBlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t = __LoadFunction<SDL_LowerBlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t>("SDL_LowerBlitScaled");

        public unsafe static int SDL_LowerBlitScaled(IntPtr src, SDL_Rect* srcrect, IntPtr dst, SDL_Rect* dstrect) => s_SDL_LowerBlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t(src, srcrect, dst, dstrect);

        private unsafe delegate int SDL_FillRect_IntPtr_SDL_Rect_UInt32_t(IntPtr dst, SDL_Rect* rect, UInt32 color);

        private static SDL_FillRect_IntPtr_SDL_Rect_UInt32_t s_SDL_FillRect_IntPtr_SDL_Rect_UInt32_t = __LoadFunction<SDL_FillRect_IntPtr_SDL_Rect_UInt32_t>("SDL_FillRect");

        public unsafe static int SDL_FillRect(IntPtr dst, SDL_Rect* rect, UInt32 color) => s_SDL_FillRect_IntPtr_SDL_Rect_UInt32_t(dst, rect, color);

        private delegate int SDL_FillRects_IntPtr_IntPtr_int_UInt32_t(IntPtr dst, IntPtr rects, int count, UInt32 color);

        private static SDL_FillRects_IntPtr_IntPtr_int_UInt32_t s_SDL_FillRects_IntPtr_IntPtr_int_UInt32_t = __LoadFunction<SDL_FillRects_IntPtr_IntPtr_int_UInt32_t>("SDL_FillRects");

        public static int SDL_FillRects(IntPtr dst, IntPtr rects, int count, UInt32 color) => s_SDL_FillRects_IntPtr_IntPtr_int_UInt32_t(dst, rects, count, color);

        private static SDL_SoftStretch_SDL_Surface_SDL_Rect_SDL_Surface_SDL_Rect_t s_SDL_SoftStretch_SDL_Surface_SDL_Rect_SDL_Surface_SDL_Rect_t = __LoadFunction<SDL_SoftStretch_SDL_Surface_SDL_Rect_SDL_Surface_SDL_Rect_t>("SDL_SoftStretch");

        public unsafe static int SDL_SoftStretch(IntPtr src, SDL_Rect* srcrect, IntPtr dst, SDL_Rect* dstrect) => s_SDL_SoftStretch_SDL_Surface_SDL_Rect_SDL_Surface_SDL_Rect_t(src, srcrect, dst, dstrect);

        private delegate IntPtr SDL_ConvertSurface_IntPtr_IntPtr_UInt32_t(IntPtr src, IntPtr fmt, UInt32 flags);

        private static SDL_ConvertSurface_IntPtr_IntPtr_UInt32_t s_SDL_ConvertSurface_IntPtr_IntPtr_UInt32_t = __LoadFunction<SDL_ConvertSurface_IntPtr_IntPtr_UInt32_t>("SDL_ConvertSurface");

        public static IntPtr SDL_ConvertSurface(IntPtr src, IntPtr fmt, UInt32 flags) => s_SDL_ConvertSurface_IntPtr_IntPtr_UInt32_t(src, fmt, flags);

        private delegate IntPtr SDL_ConvertSurfaceFormat_IntPtr_UInt32_UInt32_t(IntPtr src, UInt32 fmt, UInt32 flags);

        private static SDL_ConvertSurfaceFormat_IntPtr_UInt32_UInt32_t s_SDL_ConvertSurfaceFormat_IntPtr_UInt32_UInt32_t = __LoadFunction<SDL_ConvertSurfaceFormat_IntPtr_UInt32_UInt32_t>("SDL_ConvertSurfaceFormat");

        public static IntPtr SDL_ConvertSurfaceFormat(IntPtr src, UInt32 fmt, UInt32 flags) => s_SDL_ConvertSurfaceFormat_IntPtr_UInt32_UInt32_t(src, fmt, flags);

        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }

#pragma warning disable
        static SDL_surface()
        {
            var blitScaled = new[] { "SDL_BlitScaled", "SDL_UpperBlitScaled" };
            foreach (var name in blitScaled)
            {
                try
                {
                    s_SDL_BlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t =
                        __LoadFunction<SDL_BlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t>(name);
                    break;
                }
                catch (Exception ex) { }
            }
            if (s_SDL_BlitScaled_IntPtr_SDL_Rect_IntPtr_SDL_Rect_t == null)
                throw new EntryPointNotFoundException("Could not find SDL_BlitScaled function");
        }
#pragma warning enable
    }
}


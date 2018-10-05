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

namespace SDL2
{
    public static class SDL_surface
    {
        public const int SDL_SWSURFACE = 0;
        public const int SDL_PREALLOC = 0x00000001;
        public const int SDL_RLEACCEL = 0x00000002;
        public const int SDL_DONTFREE = 0x00000004;

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

        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_CreateRGBSurfaceFrom(IntPtr pixels, int width, int height, int depth, int pitch, UInt32 Rmask, UInt32 Gmask, UInt32 Bmask, UInt32 Amask);
        [DllImport("libSDL2.so")]
        public static extern void SDL_FreeSurface(ref SDL_Surface surface);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetSurfacePalette(ref SDL_Surface surface, ref SDL_Palette palette);
        [DllImport("libSDL2.so")]
        public static extern int SDL_LockSurface(ref SDL_Surface surface);
        [DllImport("libSDL2.so")]
        public static extern void SDL_UnlockSurface(ref SDL_Surface surface);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_LoadBMP_RW(ref SDL_RWops src, int freesrc);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetSurfaceRLE(ref SDL_Surface surface, int flag);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetColorKey(ref SDL_Surface surface, int flag, UInt32 key);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetColorKey(ref SDL_Surface surface, ref uint key);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetSurfaceColorMod(ref SDL_Surface surface, byte r, byte g, byte b);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetSurfaceColorMod(ref SDL_Surface surface, ref byte r, ref byte g, ref byte b);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetSurfaceAlphaMod(ref SDL_Surface surface, byte alpha);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetSurfaceAlphaMod(ref SDL_Surface surface, ref byte alpha);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetSurfaceBlendMode(ref SDL_Surface surface, SDL_BlendMode blendMode);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetSurfaceBlendMode(ref SDL_Surface surface, ref SDL_BlendMode blendMode);
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_SetClipRect(ref SDL_Surface surface, ref SDL_Rect rect);
        [DllImport("libSDL2.so")]
        public static extern void SDL_GetClipRect(ref SDL_Surface surface, ref SDL_Rect rect);
        [DllImport("libSDL2.so")]
        public static extern int SDL_ConvertPixels(int width, int height, UInt32 src_format, IntPtr src, int src_pitch, UInt32 dst_format, IntPtr dst, int dst_pitch);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SoftStretch(ref SDL_Surface src, ref SDL_Rect srcrect, ref SDL_Surface dst, ref SDL_Rect dstrect);

    }
}

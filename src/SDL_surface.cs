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
using static SDL2.SDL_timer;
using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

namespace SDL2
{
public static class SDL_surface
{
public const int SDL_SWSURFACE = 0;
public const int SDL_PREALLOC = 0x00000001;
public const int SDL_RLEACCEL = 0x00000002;
public const int SDL_DONTFREE = 0x00000004;
public const int SDL_BlitSurface = SDL_UpperBlit;
public const int SDL_BlitScaled = SDL_UpperBlitScaled;


[StructLayout(LayoutKind.Sequential)]
public struct SDL_Surface
{

    Uint32 flags;               /**< Read-only */
    SDL_PixelFormat *format;    /**< Read-only */
    int w, h;                   /**< Read-only */
    int pitch;                  /**< Read-only */
    void *pixels;               /**< Read-write */

    /** Application data associated with the surface */
    void *userdata;             /**< Read-write */

    /** information needed for surfaces requiring locks */
    int locked;                 /**< Read-only */
    void *lock_data;            /**< Read-only */

    /** clipping information */
    SDL_Rect clip_rect;         /**< Read-only */

    /** info for fast blit mapping to other surfaces */
    struct SDL_BlitMap *map;    /**< Private */

    /** Reference count -- used when freeing surface */
    int refcount;               /**< Read-mostly */

}

[DllImport("SDL2.dll")]
public static extern IntPtr SDL_CreateRGBSurfaceFrom(ref void pixels, int width, int height, int depth, int pitch, Uint32 Rmask, Uint32 Gmask, Uint32 Bmask, Uint32 Amask);
[DllImport("SDL2.dll")]
public static extern void SDL_FreeSurface(ref SDL_Surface surface);
[DllImport("SDL2.dll")]
public static extern int SDL_SetSurfacePalette(ref SDL_Surface surface, ref SDL_Palette palette);
[DllImport("SDL2.dll")]
public static extern int SDL_LockSurface(ref SDL_Surface surface);
[DllImport("SDL2.dll")]
public static extern void SDL_UnlockSurface(ref SDL_Surface surface);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_LoadBMP_RW(ref SDL_RWops src, int freesrc);
[DllImport("SDL2.dll")]
public static extern int SDL_SetSurfaceRLE(ref SDL_Surface surface, int flag);
[DllImport("SDL2.dll")]
public static extern int SDL_SetColorKey(ref SDL_Surface surface, int flag, Uint32 key);
[DllImport("SDL2.dll")]
public static extern int SDL_GetColorKey(ref SDL_Surface surface, ref uint key);
[DllImport("SDL2.dll")]
public static extern int SDL_SetSurfaceColorMod(ref SDL_Surface surface, Uint8 r, Uint8 g, Uint8 b);
[DllImport("SDL2.dll")]
public static extern int SDL_GetSurfaceColorMod(ref SDL_Surface surface, ref byte r, ref byte g, ref byte b);
[DllImport("SDL2.dll")]
public static extern int SDL_SetSurfaceAlphaMod(ref SDL_Surface surface, Uint8 alpha);
[DllImport("SDL2.dll")]
public static extern int SDL_GetSurfaceAlphaMod(ref SDL_Surface surface, ref byte alpha);
[DllImport("SDL2.dll")]
public static extern int SDL_SetSurfaceBlendMode(ref SDL_Surface surface, SDL_BlendMode blendMode);
[DllImport("SDL2.dll")]
public static extern int SDL_GetSurfaceBlendMode(ref SDL_Surface surface, ref SDL_BlendMode blendMode);
[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_SetClipRect(ref SDL_Surface surface, ref SDL_Rect rect);
[DllImport("SDL2.dll")]
public static extern void SDL_GetClipRect(ref SDL_Surface surface, ref SDL_Rect rect);
[DllImport("SDL2.dll")]
public static extern int SDL_ConvertPixels(int width, int height, Uint32 src_format, ref void src, int src_pitch, Uint32 dst_format, ref void dst, int dst_pitch);
[DllImport("SDL2.dll")]
public static extern int SDL_SoftStretch(ref SDL_Surface src, ref SDL_Rect srcrect, ref SDL_Surface dst, ref SDL_Rect dstrect);

}
}

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
using static SDL2.SDL_scancode;
using static SDL2.SDL_surface;
using static SDL2.SDL_timer;
using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

namespace SDL2
{
public static class SDL_render
{

public enum SDL_RendererFlags
{

    SDL_RENDERER_SOFTWARE = 0x00000001,         /**< The renderer is a software fallback */
    SDL_RENDERER_ACCELERATED = 0x00000002,      /**< The renderer uses hardware
                                                     acceleration */
    SDL_RENDERER_PRESENTVSYNC = 0x00000004,     /**< Present is synchronized
                                                     with the refresh rate */
    SDL_RENDERER_TARGETTEXTURE = 0x00000008     /**< The renderer supports
                                                     rendering to texture */

}
public enum SDL_TextureAccess
{

    SDL_TEXTUREACCESS_STATIC,    /**< Changes rarely, not lockable */
    SDL_TEXTUREACCESS_STREAMING, /**< Changes frequently, lockable */
    SDL_TEXTUREACCESS_TARGET     /**< Texture can be used as a render target */

}
public enum SDL_TextureModulate
{

    SDL_TEXTUREMODULATE_NONE = 0x00000000,     /**< No modulation */
    SDL_TEXTUREMODULATE_COLOR = 0x00000001,    /**< srcC = srcC * color */
    SDL_TEXTUREMODULATE_ALPHA = 0x00000002     /**< srcA = srcA * alpha */

}
public enum SDL_RendererFlip
{

    SDL_FLIP_NONE = 0x00000000,     /**< Do not flip */
    SDL_FLIP_HORIZONTAL = 0x00000001,    /**< flip horizontally */
    SDL_FLIP_VERTICAL = 0x00000002     /**< flip vertically */

}

[StructLayout(LayoutKind.Sequential)]
public struct SDL_RendererInfo
{

    const char *name;           /**< The name of the renderer */
    Uint32 flags;               /**< Supported ::SDL_RendererFlags */
    Uint32 num_texture_formats; /**< The number of available texture formats */
    Uint32 texture_formats[16]; /**< The available texture formats */
    int max_texture_width;      /**< The maximimum texture width */
    int max_texture_height;     /**< The maximimum texture height */

}

[DllImport("SDL2.dll")]
public static extern int SDL_GetNumRenderDrivers();
[DllImport("SDL2.dll")]
public static extern int SDL_GetRenderDriverInfo(int index, ref SDL_RendererInfo info);
[DllImport("SDL2.dll")]
public static extern int SDL_CreateWindowAndRenderer(int width, int height, Uint32 window_flags, ref SDL_Window , ref SDL_Renderer );
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_CreateRenderer(ref SDL_Window window, int index, Uint32 flags);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_CreateSoftwareRenderer(ref SDL_Surface surface);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetRenderer(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern int SDL_GetRendererInfo(ref SDL_Renderer renderer, ref SDL_RendererInfo info);
[DllImport("SDL2.dll")]
public static extern int SDL_GetRendererOutputSize(ref SDL_Renderer renderer, ref int w, ref int h);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_CreateTexture(ref SDL_Renderer renderer, Uint32 format, int access, int w, int h);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_CreateTextureFromSurface(ref SDL_Renderer renderer, ref SDL_Surface surface);
[DllImport("SDL2.dll")]
public static extern int SDL_QueryTexture(ref SDL_Texture texture, ref uint format, ref int access, ref int w, ref int h);
[DllImport("SDL2.dll")]
public static extern int SDL_SetTextureColorMod(ref SDL_Texture texture, Uint8 r, Uint8 g, Uint8 b);
[DllImport("SDL2.dll")]
public static extern int SDL_GetTextureColorMod(ref SDL_Texture texture, ref byte r, ref byte g, ref byte b);
[DllImport("SDL2.dll")]
public static extern int SDL_SetTextureAlphaMod(ref SDL_Texture texture, Uint8 alpha);
[DllImport("SDL2.dll")]
public static extern int SDL_GetTextureAlphaMod(ref SDL_Texture texture, ref byte alpha);
[DllImport("SDL2.dll")]
public static extern int SDL_SetTextureBlendMode(ref SDL_Texture texture, SDL_BlendMode blendMode);
[DllImport("SDL2.dll")]
public static extern int SDL_GetTextureBlendMode(ref SDL_Texture texture, ref SDL_BlendMode blendMode);
[DllImport("SDL2.dll")]
public static extern int SDL_UpdateTexture(ref SDL_Texture texture, ref SDL_Rect rect, ref void pixels, int pitch);
[DllImport("SDL2.dll")]
public static extern int SDL_UpdateYUVTexture(ref SDL_Texture texture, ref SDL_Rect rect, ref byte Yplane, int Ypitch, ref byte Uplane, int Upitch, ref byte Vplane, int Vpitch);
[DllImport("SDL2.dll")]
public static extern int SDL_LockTexture(ref SDL_Texture texture, ref SDL_Rect rect, ref void , ref int pitch);
[DllImport("SDL2.dll")]
public static extern void SDL_UnlockTexture(ref SDL_Texture texture);
[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_RenderTargetSupported(ref SDL_Renderer renderer);
[DllImport("SDL2.dll")]
public static extern int SDL_SetRenderTarget(ref SDL_Renderer renderer, ref SDL_Texture texture);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetRenderTarget(ref SDL_Renderer renderer);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderSetLogicalSize(ref SDL_Renderer renderer, int w, int h);
[DllImport("SDL2.dll")]
public static extern void SDL_RenderGetLogicalSize(ref SDL_Renderer renderer, ref int w, ref int h);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderSetViewport(ref SDL_Renderer renderer, ref SDL_Rect rect);
[DllImport("SDL2.dll")]
public static extern void SDL_RenderGetViewport(ref SDL_Renderer renderer, ref SDL_Rect rect);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderSetClipRect(ref SDL_Renderer renderer, ref SDL_Rect rect);
[DllImport("SDL2.dll")]
public static extern void SDL_RenderGetClipRect(ref SDL_Renderer renderer, ref SDL_Rect rect);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderSetScale(ref SDL_Renderer renderer, float scaleX, float scaleY);
[DllImport("SDL2.dll")]
public static extern void SDL_RenderGetScale(ref SDL_Renderer renderer, ref float scaleX, ref float scaleY);
[DllImport("SDL2.dll")]
public static extern int SDL_SetRenderDrawColor(ref SDL_Renderer renderer, Uint8 r, Uint8 g, Uint8 b, Uint8 a);
[DllImport("SDL2.dll")]
public static extern int SDL_GetRenderDrawColor(ref SDL_Renderer renderer, ref byte r, ref byte g, ref byte b, ref byte a);
[DllImport("SDL2.dll")]
public static extern int SDL_SetRenderDrawBlendMode(ref SDL_Renderer renderer, SDL_BlendMode blendMode);
[DllImport("SDL2.dll")]
public static extern int SDL_GetRenderDrawBlendMode(ref SDL_Renderer renderer, ref SDL_BlendMode blendMode);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderClear(ref SDL_Renderer renderer);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderDrawPoint(ref SDL_Renderer renderer, int x, int y);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderDrawPoints(ref SDL_Renderer renderer, ref SDL_Point points, int count);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderDrawLine(ref SDL_Renderer renderer, int x1, int y1, int x2, int y2);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderDrawLines(ref SDL_Renderer renderer, ref SDL_Point points, int count);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderDrawRect(ref SDL_Renderer renderer, ref SDL_Rect rect);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderDrawRects(ref SDL_Renderer renderer, ref SDL_Rect rects, int count);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderFillRect(ref SDL_Renderer renderer, ref SDL_Rect rect);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderFillRects(ref SDL_Renderer renderer, ref SDL_Rect rects, int count);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderCopy(ref SDL_Renderer renderer, ref SDL_Texture texture, ref SDL_Rect srcrect, ref SDL_Rect dstrect);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderCopyEx(ref SDL_Renderer renderer, ref SDL_Texture texture, ref SDL_Rect srcrect, ref SDL_Rect dstrect, double angle, ref SDL_Point center, SDL_RendererFlip flip);
[DllImport("SDL2.dll")]
public static extern int SDL_RenderReadPixels(ref SDL_Renderer renderer, ref SDL_Rect rect, Uint32 format, ref void pixels, int pitch);
[DllImport("SDL2.dll")]
public static extern void SDL_RenderPresent(ref SDL_Renderer renderer);
[DllImport("SDL2.dll")]
public static extern void SDL_DestroyTexture(ref SDL_Texture texture);
[DllImport("SDL2.dll")]
public static extern void SDL_DestroyRenderer(ref SDL_Renderer renderer);
[DllImport("SDL2.dll")]
public static extern int SDL_GL_BindTexture(ref SDL_Texture texture, ref float texw, ref float texh);
[DllImport("SDL2.dll")]
public static extern int SDL_GL_UnbindTexture(ref SDL_Texture texture);

}
}

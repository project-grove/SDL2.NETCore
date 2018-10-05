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

using static SDL2.SDL_touch;
using static SDL2.SDL_version;
using static SDL2.SDL_video;

using SDL_bool = System.Int32;

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

            public IntPtr name;           /**< The name of the renderer */
            public UInt32 flags;               /**< Supported ::SDL_RendererFlags */
            public UInt32 num_texture_formats; /**< The number of available texture formats */
            public unsafe fixed UInt32 texture_formats[16]; /**< The available texture formats */
            public int max_texture_width;      /**< The maximimum texture width */
            public int max_texture_height;     /**< The maximimum texture height */

        }

        [DllImport("libSDL2.so")]
        public static extern int SDL_GetNumRenderDrivers();
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetRenderDriverInfo(int index, IntPtr info);
        [DllImport("libSDL2.so")]
        public static extern int SDL_CreateWindowAndRenderer(int width, int height, UInt32 window_flags, out IntPtr window, out IntPtr renderer);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_CreateRenderer(IntPtr window, int index, UInt32 flags);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_CreateSoftwareRenderer(ref SDL_Surface surface);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetRenderer(IntPtr window);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetRendererInfo(IntPtr renderer, IntPtr info);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetRendererOutputSize(IntPtr renderer, ref int w, ref int h);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_CreateTexture(IntPtr renderer, UInt32 format, int access, int w, int h);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_CreateTextureFromSurface(IntPtr renderer, ref SDL_Surface surface);
        [DllImport("libSDL2.so")]
        public static extern int SDL_QueryTexture(IntPtr texture, ref uint format, ref int access, ref int w, ref int h);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetTextureColorMod(IntPtr texture, byte r, byte g, byte b);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetTextureColorMod(IntPtr texture, ref byte r, ref byte g, ref byte b);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetTextureAlphaMod(IntPtr texture, byte alpha);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetTextureAlphaMod(IntPtr texture, ref byte alpha);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetTextureBlendMode(IntPtr texture, SDL_BlendMode blendMode);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetTextureBlendMode(IntPtr texture, ref SDL_BlendMode blendMode);
        [DllImport("libSDL2.so")]
        public static extern int SDL_UpdateTexture(IntPtr texture, ref SDL_Rect rect, IntPtr pixels, int pitch);
        [DllImport("libSDL2.so")]
        public static extern int SDL_UpdateYUVTexture(IntPtr texture, ref SDL_Rect rect, ref byte Yplane, int Ypitch, ref byte Uplane, int Upitch, ref byte Vplane, int Vpitch);
        [DllImport("libSDL2.so")]
        public static extern int SDL_LockTexture(IntPtr texture, ref SDL_Rect rect, out IntPtr pixels, ref int pitch);
        [DllImport("libSDL2.so")]
        public static extern void SDL_UnlockTexture(IntPtr texture);
        [DllImport("libSDL2.so")]
        public static extern SDL_bool SDL_RenderTargetSupported(IntPtr renderer);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetRenderTarget(IntPtr renderer, IntPtr texture);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetRenderTarget(IntPtr renderer);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderSetLogicalSize(IntPtr renderer, int w, int h);
        [DllImport("libSDL2.so")]
        public static extern void SDL_RenderGetLogicalSize(IntPtr renderer, ref int w, ref int h);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderSetViewport(IntPtr renderer, ref SDL_Rect rect);
        [DllImport("libSDL2.so")]
        public static extern void SDL_RenderGetViewport(IntPtr renderer, ref SDL_Rect rect);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderSetClipRect(IntPtr renderer, ref SDL_Rect rect);
        [DllImport("libSDL2.so")]
        public static extern void SDL_RenderGetClipRect(IntPtr renderer, ref SDL_Rect rect);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderSetScale(IntPtr renderer, float scaleX, float scaleY);
        [DllImport("libSDL2.so")]
        public static extern void SDL_RenderGetScale(IntPtr renderer, ref float scaleX, ref float scaleY);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetRenderDrawColor(IntPtr renderer, ref byte r, ref byte g, ref byte b, ref byte a);
        [DllImport("libSDL2.so")]
        public static extern int SDL_SetRenderDrawBlendMode(IntPtr renderer, SDL_BlendMode blendMode);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetRenderDrawBlendMode(IntPtr renderer, ref SDL_BlendMode blendMode);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderClear(IntPtr renderer);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderDrawPoint(IntPtr renderer, int x, int y);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderDrawPoints(IntPtr renderer, ref SDL_Point points, int count);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderDrawLine(IntPtr renderer, int x1, int y1, int x2, int y2);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderDrawLines(IntPtr renderer, ref SDL_Point points, int count);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderDrawRect(IntPtr renderer, ref SDL_Rect rect);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderDrawRects(IntPtr renderer, ref SDL_Rect rects, int count);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderFillRect(IntPtr renderer, ref SDL_Rect rect);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderFillRects(IntPtr renderer, ref SDL_Rect rects, int count);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderCopy(IntPtr renderer, IntPtr texture, ref SDL_Rect srcrect, ref SDL_Rect dstrect);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, ref SDL_Rect srcrect, ref SDL_Rect dstrect, double angle, ref SDL_Point center, SDL_RendererFlip flip);
        [DllImport("libSDL2.so")]
        public static extern int SDL_RenderReadPixels(IntPtr renderer, ref SDL_Rect rect, UInt32 format, out IntPtr pixels, int pitch);
        [DllImport("libSDL2.so")]
        public static extern void SDL_RenderPresent(IntPtr renderer);
        [DllImport("libSDL2.so")]
        public static extern void SDL_DestroyTexture(IntPtr texture);
        [DllImport("libSDL2.so")]
        public static extern void SDL_DestroyRenderer(IntPtr renderer);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GL_BindTexture(IntPtr texture, ref float texw, ref float texh);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GL_UnbindTexture(IntPtr texture);

    }
}

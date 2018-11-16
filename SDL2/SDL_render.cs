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
using NativeLibraryLoader;

namespace SDL2
{
    public static class SDL_render
    {
        [Flags]
        public enum SDL_RendererFlags : UInt32
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
            public SDL_RendererFlags flags;               /**< Supported ::SDL_RendererFlags */
            public UInt32 num_texture_formats; /**< The number of available texture formats */
            public unsafe fixed UInt32 texture_formats[16]; /**< The available texture formats */
            public int max_texture_width;      /**< The maximimum texture width */
            public int max_texture_height;     /**< The maximimum texture height */

        }

        private delegate int SDL_GetNumRenderDrivers__t();

        private static SDL_GetNumRenderDrivers__t s_SDL_GetNumRenderDrivers__t = __LoadFunction<SDL_GetNumRenderDrivers__t>("SDL_GetNumRenderDrivers");

        public static int SDL_GetNumRenderDrivers() => s_SDL_GetNumRenderDrivers__t();

        private delegate int SDL_GetRenderDriverInfo_int_IntPtr_t(int index, out SDL_RendererInfo info);

        private static SDL_GetRenderDriverInfo_int_IntPtr_t s_SDL_GetRenderDriverInfo_int_IntPtr_t = __LoadFunction<SDL_GetRenderDriverInfo_int_IntPtr_t>("SDL_GetRenderDriverInfo");

        public static int SDL_GetRenderDriverInfo(int index, out SDL_RendererInfo info) => s_SDL_GetRenderDriverInfo_int_IntPtr_t(index, out info);

        private delegate int SDL_CreateWindowAndRenderer_int_int_UInt32_IntPtr_IntPtr_t(int width, int height, UInt32 window_flags, out IntPtr window, out IntPtr renderer);

        private static SDL_CreateWindowAndRenderer_int_int_UInt32_IntPtr_IntPtr_t s_SDL_CreateWindowAndRenderer_int_int_UInt32_IntPtr_IntPtr_t = __LoadFunction<SDL_CreateWindowAndRenderer_int_int_UInt32_IntPtr_IntPtr_t>("SDL_CreateWindowAndRenderer");

        public static int SDL_CreateWindowAndRenderer(int width, int height, UInt32 window_flags, out IntPtr window, out IntPtr renderer) => s_SDL_CreateWindowAndRenderer_int_int_UInt32_IntPtr_IntPtr_t(width, height, window_flags, out window, out renderer);

        private delegate IntPtr SDL_CreateRenderer_IntPtr_int_UInt32_t(IntPtr window, int index, UInt32 flags);

        private static SDL_CreateRenderer_IntPtr_int_UInt32_t s_SDL_CreateRenderer_IntPtr_int_UInt32_t = __LoadFunction<SDL_CreateRenderer_IntPtr_int_UInt32_t>("SDL_CreateRenderer");

        public static IntPtr SDL_CreateRenderer(IntPtr window, int index, UInt32 flags) => s_SDL_CreateRenderer_IntPtr_int_UInt32_t(window, index, flags);

        private delegate IntPtr SDL_CreateSoftwareRenderer_SDL_Surface_t(ref SDL_Surface surface);

        private static SDL_CreateSoftwareRenderer_SDL_Surface_t s_SDL_CreateSoftwareRenderer_SDL_Surface_t = __LoadFunction<SDL_CreateSoftwareRenderer_SDL_Surface_t>("SDL_CreateSoftwareRenderer");

        public static IntPtr SDL_CreateSoftwareRenderer(ref SDL_Surface surface) => s_SDL_CreateSoftwareRenderer_SDL_Surface_t(ref surface);

        private delegate IntPtr SDL_GetRenderer_IntPtr_t(IntPtr window);

        private static SDL_GetRenderer_IntPtr_t s_SDL_GetRenderer_IntPtr_t = __LoadFunction<SDL_GetRenderer_IntPtr_t>("SDL_GetRenderer");

        public static IntPtr SDL_GetRenderer(IntPtr window) => s_SDL_GetRenderer_IntPtr_t(window);

        private delegate int SDL_GetRendererInfo_IntPtr_IntPtr_t(IntPtr renderer, ref SDL_RendererInfo info);

        private static SDL_GetRendererInfo_IntPtr_IntPtr_t s_SDL_GetRendererInfo_IntPtr_IntPtr_t = __LoadFunction<SDL_GetRendererInfo_IntPtr_IntPtr_t>("SDL_GetRendererInfo");

        public static int SDL_GetRendererInfo(IntPtr renderer, ref SDL_RendererInfo info) => s_SDL_GetRendererInfo_IntPtr_IntPtr_t(renderer, ref info);

        private delegate int SDL_GetRendererOutputSize_IntPtr_int_int_t(IntPtr renderer, out int w, out int h);

        private static SDL_GetRendererOutputSize_IntPtr_int_int_t s_SDL_GetRendererOutputSize_IntPtr_int_int_t = __LoadFunction<SDL_GetRendererOutputSize_IntPtr_int_int_t>("SDL_GetRendererOutputSize");

        public static int SDL_GetRendererOutputSize(IntPtr renderer, out int w, out int h) => s_SDL_GetRendererOutputSize_IntPtr_int_int_t(renderer, out w, out h);

        private delegate IntPtr SDL_CreateTexture_IntPtr_UInt32_int_int_int_t(IntPtr renderer, UInt32 format, int access, int w, int h);

        private static SDL_CreateTexture_IntPtr_UInt32_int_int_int_t s_SDL_CreateTexture_IntPtr_UInt32_int_int_int_t = __LoadFunction<SDL_CreateTexture_IntPtr_UInt32_int_int_int_t>("SDL_CreateTexture");

        public static IntPtr SDL_CreateTexture(IntPtr renderer, UInt32 format, int access, int w, int h) => s_SDL_CreateTexture_IntPtr_UInt32_int_int_int_t(renderer, format, access, w, h);

        private delegate IntPtr SDL_CreateTextureFromSurface_IntPtr_SDL_Surface_t(IntPtr renderer, IntPtr surface);

        private static SDL_CreateTextureFromSurface_IntPtr_SDL_Surface_t s_SDL_CreateTextureFromSurface_IntPtr_SDL_Surface_t = __LoadFunction<SDL_CreateTextureFromSurface_IntPtr_SDL_Surface_t>("SDL_CreateTextureFromSurface");

        public static IntPtr SDL_CreateTextureFromSurface(IntPtr renderer, IntPtr surface) => s_SDL_CreateTextureFromSurface_IntPtr_SDL_Surface_t(renderer, surface);

        private delegate int SDL_QueryTexture_IntPtr_uint_int_int_int_t(IntPtr texture, ref uint format, ref int access, ref int w, ref int h);

        private static SDL_QueryTexture_IntPtr_uint_int_int_int_t s_SDL_QueryTexture_IntPtr_uint_int_int_int_t = __LoadFunction<SDL_QueryTexture_IntPtr_uint_int_int_int_t>("SDL_QueryTexture");

        public static int SDL_QueryTexture(IntPtr texture, ref uint format, ref int access, ref int w, ref int h) => s_SDL_QueryTexture_IntPtr_uint_int_int_int_t(texture, ref format, ref access, ref w, ref h);

        private delegate int SDL_SetTextureColorMod_IntPtr_byte_byte_byte_t(IntPtr texture, byte r, byte g, byte b);

        private static SDL_SetTextureColorMod_IntPtr_byte_byte_byte_t s_SDL_SetTextureColorMod_IntPtr_byte_byte_byte_t = __LoadFunction<SDL_SetTextureColorMod_IntPtr_byte_byte_byte_t>("SDL_SetTextureColorMod");

        public static int SDL_SetTextureColorMod(IntPtr texture, byte r, byte g, byte b) => s_SDL_SetTextureColorMod_IntPtr_byte_byte_byte_t(texture, r, g, b);

        private delegate int SDL_GetTextureColorMod_IntPtr_byte_byte_byte_t(IntPtr texture, ref byte r, ref byte g, ref byte b);

        private static SDL_GetTextureColorMod_IntPtr_byte_byte_byte_t s_SDL_GetTextureColorMod_IntPtr_byte_byte_byte_t = __LoadFunction<SDL_GetTextureColorMod_IntPtr_byte_byte_byte_t>("SDL_GetTextureColorMod");

        public static int SDL_GetTextureColorMod(IntPtr texture, ref byte r, ref byte g, ref byte b) => s_SDL_GetTextureColorMod_IntPtr_byte_byte_byte_t(texture, ref r, ref g, ref b);

        private delegate int SDL_SetTextureAlphaMod_IntPtr_byte_t(IntPtr texture, byte alpha);

        private static SDL_SetTextureAlphaMod_IntPtr_byte_t s_SDL_SetTextureAlphaMod_IntPtr_byte_t = __LoadFunction<SDL_SetTextureAlphaMod_IntPtr_byte_t>("SDL_SetTextureAlphaMod");

        public static int SDL_SetTextureAlphaMod(IntPtr texture, byte alpha) => s_SDL_SetTextureAlphaMod_IntPtr_byte_t(texture, alpha);

        private delegate int SDL_GetTextureAlphaMod_IntPtr_byte_t(IntPtr texture, ref byte alpha);

        private static SDL_GetTextureAlphaMod_IntPtr_byte_t s_SDL_GetTextureAlphaMod_IntPtr_byte_t = __LoadFunction<SDL_GetTextureAlphaMod_IntPtr_byte_t>("SDL_GetTextureAlphaMod");

        public static int SDL_GetTextureAlphaMod(IntPtr texture, ref byte alpha) => s_SDL_GetTextureAlphaMod_IntPtr_byte_t(texture, ref alpha);

        private delegate int SDL_SetTextureBlendMode_IntPtr_SDL_BlendMode_t(IntPtr texture, SDL_BlendMode blendMode);

        private static SDL_SetTextureBlendMode_IntPtr_SDL_BlendMode_t s_SDL_SetTextureBlendMode_IntPtr_SDL_BlendMode_t = __LoadFunction<SDL_SetTextureBlendMode_IntPtr_SDL_BlendMode_t>("SDL_SetTextureBlendMode");

        public static int SDL_SetTextureBlendMode(IntPtr texture, SDL_BlendMode blendMode) => s_SDL_SetTextureBlendMode_IntPtr_SDL_BlendMode_t(texture, blendMode);

        private delegate int SDL_GetTextureBlendMode_IntPtr_SDL_BlendMode_t(IntPtr texture, ref SDL_BlendMode blendMode);

        private static SDL_GetTextureBlendMode_IntPtr_SDL_BlendMode_t s_SDL_GetTextureBlendMode_IntPtr_SDL_BlendMode_t = __LoadFunction<SDL_GetTextureBlendMode_IntPtr_SDL_BlendMode_t>("SDL_GetTextureBlendMode");

        public static int SDL_GetTextureBlendMode(IntPtr texture, ref SDL_BlendMode blendMode) => s_SDL_GetTextureBlendMode_IntPtr_SDL_BlendMode_t(texture, ref blendMode);

        private delegate int SDL_UpdateTexture_IntPtr_SDL_Rect_IntPtr_int_t(IntPtr texture, IntPtr rect, IntPtr pixels, int pitch);

        private static SDL_UpdateTexture_IntPtr_SDL_Rect_IntPtr_int_t s_SDL_UpdateTexture_IntPtr_SDL_Rect_IntPtr_int_t = __LoadFunction<SDL_UpdateTexture_IntPtr_SDL_Rect_IntPtr_int_t>("SDL_UpdateTexture");

        public static int SDL_UpdateTexture(IntPtr texture, IntPtr rect, IntPtr pixels, int pitch) => s_SDL_UpdateTexture_IntPtr_SDL_Rect_IntPtr_int_t(texture, rect, pixels, pitch);

        private unsafe delegate int SDL_UpdateYUVTexture_IntPtr_SDL_Rect_byte_int_byte_int_byte_int_t(IntPtr texture, SDL_Rect* rect, ref byte Yplane, int Ypitch, ref byte Uplane, int Upitch, ref byte Vplane, int Vpitch);

        private static SDL_UpdateYUVTexture_IntPtr_SDL_Rect_byte_int_byte_int_byte_int_t s_SDL_UpdateYUVTexture_IntPtr_SDL_Rect_byte_int_byte_int_byte_int_t = __LoadFunction<SDL_UpdateYUVTexture_IntPtr_SDL_Rect_byte_int_byte_int_byte_int_t>("SDL_UpdateYUVTexture");

        public unsafe static int SDL_UpdateYUVTexture(IntPtr texture, SDL_Rect* rect, ref byte Yplane, int Ypitch, ref byte Uplane, int Upitch, ref byte Vplane, int Vpitch) => s_SDL_UpdateYUVTexture_IntPtr_SDL_Rect_byte_int_byte_int_byte_int_t(texture, rect, ref Yplane, Ypitch, ref Uplane, Upitch, ref Vplane, Vpitch);

        private unsafe delegate int SDL_LockTexture_IntPtr_SDL_Rect_IntPtr_int_t(IntPtr texture, IntPtr rect, out IntPtr pixels, ref int pitch);

        private static SDL_LockTexture_IntPtr_SDL_Rect_IntPtr_int_t s_SDL_LockTexture_IntPtr_SDL_Rect_IntPtr_int_t = __LoadFunction<SDL_LockTexture_IntPtr_SDL_Rect_IntPtr_int_t>("SDL_LockTexture");

        public unsafe static int SDL_LockTexture(IntPtr texture, IntPtr rect, out IntPtr pixels, ref int pitch) => s_SDL_LockTexture_IntPtr_SDL_Rect_IntPtr_int_t(texture, rect, out pixels, ref pitch);

        private delegate void SDL_UnlockTexture_IntPtr_t(IntPtr texture);

        private static SDL_UnlockTexture_IntPtr_t s_SDL_UnlockTexture_IntPtr_t = __LoadFunction<SDL_UnlockTexture_IntPtr_t>("SDL_UnlockTexture");

        public static void SDL_UnlockTexture(IntPtr texture) => s_SDL_UnlockTexture_IntPtr_t(texture);

        private delegate SDL_bool SDL_RenderTargetSupported_IntPtr_t(IntPtr renderer);

        private static SDL_RenderTargetSupported_IntPtr_t s_SDL_RenderTargetSupported_IntPtr_t = __LoadFunction<SDL_RenderTargetSupported_IntPtr_t>("SDL_RenderTargetSupported");

        public static SDL_bool SDL_RenderTargetSupported(IntPtr renderer) => s_SDL_RenderTargetSupported_IntPtr_t(renderer);

        private delegate int SDL_SetRenderTarget_IntPtr_IntPtr_t(IntPtr renderer, IntPtr texture);

        private static SDL_SetRenderTarget_IntPtr_IntPtr_t s_SDL_SetRenderTarget_IntPtr_IntPtr_t = __LoadFunction<SDL_SetRenderTarget_IntPtr_IntPtr_t>("SDL_SetRenderTarget");

        public static int SDL_SetRenderTarget(IntPtr renderer, IntPtr texture) => s_SDL_SetRenderTarget_IntPtr_IntPtr_t(renderer, texture);

        private delegate IntPtr SDL_GetRenderTarget_IntPtr_t(IntPtr renderer);

        private static SDL_GetRenderTarget_IntPtr_t s_SDL_GetRenderTarget_IntPtr_t = __LoadFunction<SDL_GetRenderTarget_IntPtr_t>("SDL_GetRenderTarget");

        public static IntPtr SDL_GetRenderTarget(IntPtr renderer) => s_SDL_GetRenderTarget_IntPtr_t(renderer);

        private delegate int SDL_RenderSetLogicalSize_IntPtr_int_int_t(IntPtr renderer, int w, int h);

        private static SDL_RenderSetLogicalSize_IntPtr_int_int_t s_SDL_RenderSetLogicalSize_IntPtr_int_int_t = __LoadFunction<SDL_RenderSetLogicalSize_IntPtr_int_int_t>("SDL_RenderSetLogicalSize");

        public static int SDL_RenderSetLogicalSize(IntPtr renderer, int w, int h) => s_SDL_RenderSetLogicalSize_IntPtr_int_int_t(renderer, w, h);

        private delegate void SDL_RenderGetLogicalSize_IntPtr_int_int_t(IntPtr renderer, ref int w, ref int h);

        private static SDL_RenderGetLogicalSize_IntPtr_int_int_t s_SDL_RenderGetLogicalSize_IntPtr_int_int_t = __LoadFunction<SDL_RenderGetLogicalSize_IntPtr_int_int_t>("SDL_RenderGetLogicalSize");

        public static void SDL_RenderGetLogicalSize(IntPtr renderer, ref int w, ref int h) => s_SDL_RenderGetLogicalSize_IntPtr_int_int_t(renderer, ref w, ref h);

        private unsafe delegate int SDL_RenderSetViewport_IntPtr_SDL_Rect_t(IntPtr renderer, SDL_Rect* rect);

        private static SDL_RenderSetViewport_IntPtr_SDL_Rect_t s_SDL_RenderSetViewport_IntPtr_SDL_Rect_t = __LoadFunction<SDL_RenderSetViewport_IntPtr_SDL_Rect_t>("SDL_RenderSetViewport");

        public unsafe static int SDL_RenderSetViewport(IntPtr renderer, SDL_Rect* rect) => s_SDL_RenderSetViewport_IntPtr_SDL_Rect_t(renderer, rect);

        private unsafe delegate void SDL_RenderGetViewport_IntPtr_SDL_Rect_t(IntPtr renderer, SDL_Rect* rect);

        private static SDL_RenderGetViewport_IntPtr_SDL_Rect_t s_SDL_RenderGetViewport_IntPtr_SDL_Rect_t = __LoadFunction<SDL_RenderGetViewport_IntPtr_SDL_Rect_t>("SDL_RenderGetViewport");

        public unsafe static void SDL_RenderGetViewport(IntPtr renderer, SDL_Rect* rect) => s_SDL_RenderGetViewport_IntPtr_SDL_Rect_t(renderer, rect);

        private unsafe delegate int SDL_RenderSetClipRect_IntPtr_SDL_Rect_t(IntPtr renderer, SDL_Rect* rect);

        private static SDL_RenderSetClipRect_IntPtr_SDL_Rect_t s_SDL_RenderSetClipRect_IntPtr_SDL_Rect_t = __LoadFunction<SDL_RenderSetClipRect_IntPtr_SDL_Rect_t>("SDL_RenderSetClipRect");

        public unsafe static int SDL_RenderSetClipRect(IntPtr renderer, SDL_Rect* rect) => s_SDL_RenderSetClipRect_IntPtr_SDL_Rect_t(renderer, rect);

        private unsafe delegate void SDL_RenderGetClipRect_IntPtr_SDL_Rect_t(IntPtr renderer, SDL_Rect* rect);

        private static SDL_RenderGetClipRect_IntPtr_SDL_Rect_t s_SDL_RenderGetClipRect_IntPtr_SDL_Rect_t = __LoadFunction<SDL_RenderGetClipRect_IntPtr_SDL_Rect_t>("SDL_RenderGetClipRect");

        public unsafe static void SDL_RenderGetClipRect(IntPtr renderer, SDL_Rect* rect) => s_SDL_RenderGetClipRect_IntPtr_SDL_Rect_t(renderer, rect);

        private delegate int SDL_RenderSetScale_IntPtr_float_float_t(IntPtr renderer, float scaleX, float scaleY);

        private static SDL_RenderSetScale_IntPtr_float_float_t s_SDL_RenderSetScale_IntPtr_float_float_t = __LoadFunction<SDL_RenderSetScale_IntPtr_float_float_t>("SDL_RenderSetScale");

        public static int SDL_RenderSetScale(IntPtr renderer, float scaleX, float scaleY) => s_SDL_RenderSetScale_IntPtr_float_float_t(renderer, scaleX, scaleY);

        private delegate void SDL_RenderGetScale_IntPtr_float_float_t(IntPtr renderer, ref float scaleX, ref float scaleY);

        private static SDL_RenderGetScale_IntPtr_float_float_t s_SDL_RenderGetScale_IntPtr_float_float_t = __LoadFunction<SDL_RenderGetScale_IntPtr_float_float_t>("SDL_RenderGetScale");

        public static void SDL_RenderGetScale(IntPtr renderer, ref float scaleX, ref float scaleY) => s_SDL_RenderGetScale_IntPtr_float_float_t(renderer, ref scaleX, ref scaleY);

        private delegate int SDL_SetRenderDrawColor_IntPtr_byte_byte_byte_byte_t(IntPtr renderer, byte r, byte g, byte b, byte a);

        private static SDL_SetRenderDrawColor_IntPtr_byte_byte_byte_byte_t s_SDL_SetRenderDrawColor_IntPtr_byte_byte_byte_byte_t = __LoadFunction<SDL_SetRenderDrawColor_IntPtr_byte_byte_byte_byte_t>("SDL_SetRenderDrawColor");

        public static int SDL_SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a) => s_SDL_SetRenderDrawColor_IntPtr_byte_byte_byte_byte_t(renderer, r, g, b, a);

        private delegate int SDL_GetRenderDrawColor_IntPtr_byte_byte_byte_byte_t(IntPtr renderer, ref byte r, ref byte g, ref byte b, ref byte a);

        private static SDL_GetRenderDrawColor_IntPtr_byte_byte_byte_byte_t s_SDL_GetRenderDrawColor_IntPtr_byte_byte_byte_byte_t = __LoadFunction<SDL_GetRenderDrawColor_IntPtr_byte_byte_byte_byte_t>("SDL_GetRenderDrawColor");

        public static int SDL_GetRenderDrawColor(IntPtr renderer, ref byte r, ref byte g, ref byte b, ref byte a) => s_SDL_GetRenderDrawColor_IntPtr_byte_byte_byte_byte_t(renderer, ref r, ref g, ref b, ref a);

        private delegate int SDL_SetRenderDrawBlendMode_IntPtr_SDL_BlendMode_t(IntPtr renderer, SDL_BlendMode blendMode);

        private static SDL_SetRenderDrawBlendMode_IntPtr_SDL_BlendMode_t s_SDL_SetRenderDrawBlendMode_IntPtr_SDL_BlendMode_t = __LoadFunction<SDL_SetRenderDrawBlendMode_IntPtr_SDL_BlendMode_t>("SDL_SetRenderDrawBlendMode");

        public static int SDL_SetRenderDrawBlendMode(IntPtr renderer, SDL_BlendMode blendMode) => s_SDL_SetRenderDrawBlendMode_IntPtr_SDL_BlendMode_t(renderer, blendMode);

        private delegate int SDL_GetRenderDrawBlendMode_IntPtr_SDL_BlendMode_t(IntPtr renderer, ref SDL_BlendMode blendMode);

        private static SDL_GetRenderDrawBlendMode_IntPtr_SDL_BlendMode_t s_SDL_GetRenderDrawBlendMode_IntPtr_SDL_BlendMode_t = __LoadFunction<SDL_GetRenderDrawBlendMode_IntPtr_SDL_BlendMode_t>("SDL_GetRenderDrawBlendMode");

        public static int SDL_GetRenderDrawBlendMode(IntPtr renderer, ref SDL_BlendMode blendMode) => s_SDL_GetRenderDrawBlendMode_IntPtr_SDL_BlendMode_t(renderer, ref blendMode);

        private delegate int SDL_RenderClear_IntPtr_t(IntPtr renderer);

        private static SDL_RenderClear_IntPtr_t s_SDL_RenderClear_IntPtr_t = __LoadFunction<SDL_RenderClear_IntPtr_t>("SDL_RenderClear");

        public static int SDL_RenderClear(IntPtr renderer) => s_SDL_RenderClear_IntPtr_t(renderer);

        private delegate int SDL_RenderDrawPoint_IntPtr_int_int_t(IntPtr renderer, int x, int y);

        private static SDL_RenderDrawPoint_IntPtr_int_int_t s_SDL_RenderDrawPoint_IntPtr_int_int_t = __LoadFunction<SDL_RenderDrawPoint_IntPtr_int_int_t>("SDL_RenderDrawPoint");

        public static int SDL_RenderDrawPoint(IntPtr renderer, int x, int y) => s_SDL_RenderDrawPoint_IntPtr_int_int_t(renderer, x, y);

        private unsafe delegate int SDL_RenderDrawPoints_IntPtr_SDL_Point_int_t(IntPtr renderer, SDL_Point* points, int count);

        private static SDL_RenderDrawPoints_IntPtr_SDL_Point_int_t s_SDL_RenderDrawPoints_IntPtr_SDL_Point_int_t = __LoadFunction<SDL_RenderDrawPoints_IntPtr_SDL_Point_int_t>("SDL_RenderDrawPoints");

        public unsafe static int SDL_RenderDrawPoints(IntPtr renderer, SDL_Point* points, int count) => s_SDL_RenderDrawPoints_IntPtr_SDL_Point_int_t(renderer, points, count);

        private delegate int SDL_RenderDrawLine_IntPtr_int_int_int_int_t(IntPtr renderer, int x1, int y1, int x2, int y2);

        private static SDL_RenderDrawLine_IntPtr_int_int_int_int_t s_SDL_RenderDrawLine_IntPtr_int_int_int_int_t = __LoadFunction<SDL_RenderDrawLine_IntPtr_int_int_int_int_t>("SDL_RenderDrawLine");

        public static int SDL_RenderDrawLine(IntPtr renderer, int x1, int y1, int x2, int y2) => s_SDL_RenderDrawLine_IntPtr_int_int_int_int_t(renderer, x1, y1, x2, y2);

        private unsafe delegate int SDL_RenderDrawLines_IntPtr_SDL_Point_int_t(IntPtr renderer, SDL_Point* points, int count);

        private static SDL_RenderDrawLines_IntPtr_SDL_Point_int_t s_SDL_RenderDrawLines_IntPtr_SDL_Point_int_t = __LoadFunction<SDL_RenderDrawLines_IntPtr_SDL_Point_int_t>("SDL_RenderDrawLines");

        public unsafe static int SDL_RenderDrawLines(IntPtr renderer, SDL_Point* points, int count) => s_SDL_RenderDrawLines_IntPtr_SDL_Point_int_t(renderer, points, count);

        private unsafe delegate int SDL_RenderDrawRect_IntPtr_SDL_Rect_t(IntPtr renderer, SDL_Rect* rect);

        private static SDL_RenderDrawRect_IntPtr_SDL_Rect_t s_SDL_RenderDrawRect_IntPtr_SDL_Rect_t = __LoadFunction<SDL_RenderDrawRect_IntPtr_SDL_Rect_t>("SDL_RenderDrawRect");

        public unsafe static int SDL_RenderDrawRect(IntPtr renderer, SDL_Rect* rect) => s_SDL_RenderDrawRect_IntPtr_SDL_Rect_t(renderer, rect);

        private unsafe delegate int SDL_RenderDrawRects_IntPtr_SDL_Rect_int_t(IntPtr renderer, SDL_Rect* rects, int count);

        private static SDL_RenderDrawRects_IntPtr_SDL_Rect_int_t s_SDL_RenderDrawRects_IntPtr_SDL_Rect_int_t = __LoadFunction<SDL_RenderDrawRects_IntPtr_SDL_Rect_int_t>("SDL_RenderDrawRects");

        public unsafe static int SDL_RenderDrawRects(IntPtr renderer, SDL_Rect* rects, int count) => s_SDL_RenderDrawRects_IntPtr_SDL_Rect_int_t(renderer, rects, count);

        private unsafe delegate int SDL_RenderFillRect_IntPtr_SDL_Rect_t(IntPtr renderer, SDL_Rect* rect);

        private static SDL_RenderFillRect_IntPtr_SDL_Rect_t s_SDL_RenderFillRect_IntPtr_SDL_Rect_t = __LoadFunction<SDL_RenderFillRect_IntPtr_SDL_Rect_t>("SDL_RenderFillRect");

        public unsafe static int SDL_RenderFillRect(IntPtr renderer, SDL_Rect* rect) => s_SDL_RenderFillRect_IntPtr_SDL_Rect_t(renderer, rect);

        private unsafe delegate int SDL_RenderFillRects_IntPtr_SDL_Rect_int_t(IntPtr renderer, SDL_Rect* rects, int count);

        private static SDL_RenderFillRects_IntPtr_SDL_Rect_int_t s_SDL_RenderFillRects_IntPtr_SDL_Rect_int_t = __LoadFunction<SDL_RenderFillRects_IntPtr_SDL_Rect_int_t>("SDL_RenderFillRects");

        public unsafe static int SDL_RenderFillRects(IntPtr renderer, SDL_Rect* rects, int count) => s_SDL_RenderFillRects_IntPtr_SDL_Rect_int_t(renderer, rects, count);

        private unsafe delegate int SDL_RenderCopy_IntPtr_IntPtr_SDL_Rect_SDL_Rect_t(IntPtr renderer, IntPtr texture, SDL_Rect* srcrect, SDL_Rect* dstrect);

        private static SDL_RenderCopy_IntPtr_IntPtr_SDL_Rect_SDL_Rect_t s_SDL_RenderCopy_IntPtr_IntPtr_SDL_Rect_SDL_Rect_t = __LoadFunction<SDL_RenderCopy_IntPtr_IntPtr_SDL_Rect_SDL_Rect_t>("SDL_RenderCopy");

        public unsafe static int SDL_RenderCopy(IntPtr renderer, IntPtr texture, SDL_Rect* srcrect, SDL_Rect* dstrect) => s_SDL_RenderCopy_IntPtr_IntPtr_SDL_Rect_SDL_Rect_t(renderer, texture, srcrect, dstrect);

        private unsafe delegate int SDL_RenderCopyEx_IntPtr_IntPtr_SDL_Rect_SDL_Rect_double_SDL_Point_SDL_RendererFlip_t(IntPtr renderer, IntPtr texture, SDL_Rect* srcrect, SDL_Rect* dstrect, double angle, SDL_Point* center, SDL_RendererFlip flip);

        private static SDL_RenderCopyEx_IntPtr_IntPtr_SDL_Rect_SDL_Rect_double_SDL_Point_SDL_RendererFlip_t s_SDL_RenderCopyEx_IntPtr_IntPtr_SDL_Rect_SDL_Rect_double_SDL_Point_SDL_RendererFlip_t = __LoadFunction<SDL_RenderCopyEx_IntPtr_IntPtr_SDL_Rect_SDL_Rect_double_SDL_Point_SDL_RendererFlip_t>("SDL_RenderCopyEx");

        public unsafe static int SDL_RenderCopyEx(IntPtr renderer, IntPtr texture, SDL_Rect* srcrect, SDL_Rect* dstrect, double angle, SDL_Point* center, SDL_RendererFlip flip) => s_SDL_RenderCopyEx_IntPtr_IntPtr_SDL_Rect_SDL_Rect_double_SDL_Point_SDL_RendererFlip_t(renderer, texture, srcrect, dstrect, angle, center, flip);

        private unsafe delegate int SDL_RenderReadPixels_IntPtr_SDL_Rect_UInt32_IntPtr_int_t(IntPtr renderer, IntPtr rect, UInt32 format, IntPtr pixels, int pitch);

        private static SDL_RenderReadPixels_IntPtr_SDL_Rect_UInt32_IntPtr_int_t s_SDL_RenderReadPixels_IntPtr_SDL_Rect_UInt32_IntPtr_int_t = __LoadFunction<SDL_RenderReadPixels_IntPtr_SDL_Rect_UInt32_IntPtr_int_t>("SDL_RenderReadPixels");

        public unsafe static int SDL_RenderReadPixels(IntPtr renderer, IntPtr rect, UInt32 format, IntPtr pixels, int pitch) => s_SDL_RenderReadPixels_IntPtr_SDL_Rect_UInt32_IntPtr_int_t(renderer, rect, format, pixels, pitch);

        private delegate void SDL_RenderPresent_IntPtr_t(IntPtr renderer);

        private static SDL_RenderPresent_IntPtr_t s_SDL_RenderPresent_IntPtr_t = __LoadFunction<SDL_RenderPresent_IntPtr_t>("SDL_RenderPresent");

        public static void SDL_RenderPresent(IntPtr renderer) => s_SDL_RenderPresent_IntPtr_t(renderer);

        private delegate void SDL_DestroyTexture_IntPtr_t(IntPtr texture);

        private static SDL_DestroyTexture_IntPtr_t s_SDL_DestroyTexture_IntPtr_t = __LoadFunction<SDL_DestroyTexture_IntPtr_t>("SDL_DestroyTexture");

        public static void SDL_DestroyTexture(IntPtr texture) => s_SDL_DestroyTexture_IntPtr_t(texture);

        private delegate void SDL_DestroyRenderer_IntPtr_t(IntPtr renderer);

        private static SDL_DestroyRenderer_IntPtr_t s_SDL_DestroyRenderer_IntPtr_t = __LoadFunction<SDL_DestroyRenderer_IntPtr_t>("SDL_DestroyRenderer");

        public static void SDL_DestroyRenderer(IntPtr renderer) => s_SDL_DestroyRenderer_IntPtr_t(renderer);

        private delegate int SDL_GL_BindTexture_IntPtr_float_float_t(IntPtr texture, ref float texw, ref float texh);

        private static SDL_GL_BindTexture_IntPtr_float_float_t s_SDL_GL_BindTexture_IntPtr_float_float_t = __LoadFunction<SDL_GL_BindTexture_IntPtr_float_float_t>("SDL_GL_BindTexture");

        public static int SDL_GL_BindTexture(IntPtr texture, ref float texw, ref float texh) => s_SDL_GL_BindTexture_IntPtr_float_float_t(texture, ref texw, ref texh);

        private delegate int SDL_GL_UnbindTexture_IntPtr_t(IntPtr texture);

        private static SDL_GL_UnbindTexture_IntPtr_t s_SDL_GL_UnbindTexture_IntPtr_t = __LoadFunction<SDL_GL_UnbindTexture_IntPtr_t>("SDL_GL_UnbindTexture");

        public static int SDL_GL_UnbindTexture(IntPtr texture) => s_SDL_GL_UnbindTexture_IntPtr_t(texture);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


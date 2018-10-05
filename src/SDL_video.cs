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
using static SDL2.SDL_surface;
using static SDL2.SDL_timer;
using static SDL2.SDL_touch;
using static SDL2.SDL_version;

namespace SDL2
{
public static class SDL_video
{
public const int SDL_WINDOWPOS_UNDEFINED_MASK = 0x1FFF0000;
public const int SDL_WINDOWPOS_CENTERED_MASK = 0x2FFF0000;

public enum SDL_WindowFlags
{

    SDL_WINDOW_FULLSCREEN = 0x00000001,         /**< fullscreen window */
    SDL_WINDOW_OPENGL = 0x00000002,             /**< window usable with OpenGL context */
    SDL_WINDOW_SHOWN = 0x00000004,              /**< window is visible */
    SDL_WINDOW_HIDDEN = 0x00000008,             /**< window is not visible */
    SDL_WINDOW_BORDERLESS = 0x00000010,         /**< no window decoration */
    SDL_WINDOW_RESIZABLE = 0x00000020,          /**< window can be resized */
    SDL_WINDOW_MINIMIZED = 0x00000040,          /**< window is minimized */
    SDL_WINDOW_MAXIMIZED = 0x00000080,          /**< window is maximized */
    SDL_WINDOW_INPUT_GRABBED = 0x00000100,      /**< window has grabbed input focus */
    SDL_WINDOW_INPUT_FOCUS = 0x00000200,        /**< window has input focus */
    SDL_WINDOW_MOUSE_FOCUS = 0x00000400,        /**< window has mouse focus */
    SDL_WINDOW_FULLSCREEN_DESKTOP = ( SDL_WINDOW_FULLSCREEN | 0x00001000 ),
    SDL_WINDOW_FOREIGN = 0x00000800,            /**< window not created by SDL */
    SDL_WINDOW_ALLOW_HIGHDPI = 0x00002000       /**< window should be created in high-DPI mode if supported */

}
public enum SDL_WindowEventID
{

    SDL_WINDOWEVENT_NONE,           /**< Never used */
    SDL_WINDOWEVENT_SHOWN,          /**< Window has been shown */
    SDL_WINDOWEVENT_HIDDEN,         /**< Window has been hidden */
    SDL_WINDOWEVENT_EXPOSED,        /**< Window has been exposed and should be
                                         redrawn */
    SDL_WINDOWEVENT_MOVED,          /**< Window has been moved to data1, data2
                                     */
    SDL_WINDOWEVENT_RESIZED,        /**< Window has been resized to data1xdata2 */
    SDL_WINDOWEVENT_SIZE_CHANGED,   /**< The window size has changed, either as a result of an API call or through the system or user changing the window size. */
    SDL_WINDOWEVENT_MINIMIZED,      /**< Window has been minimized */
    SDL_WINDOWEVENT_MAXIMIZED,      /**< Window has been maximized */
    SDL_WINDOWEVENT_RESTORED,       /**< Window has been restored to normal size
                                         and position */
    SDL_WINDOWEVENT_ENTER,          /**< Window has gained mouse focus */
    SDL_WINDOWEVENT_LEAVE,          /**< Window has lost mouse focus */
    SDL_WINDOWEVENT_FOCUS_GAINED,   /**< Window has gained keyboard focus */
    SDL_WINDOWEVENT_FOCUS_LOST,     /**< Window has lost keyboard focus */
    SDL_WINDOWEVENT_CLOSE           /**< The window manager requests that the
                                         window be closed */

}
public enum SDL_GLattr
{

    SDL_GL_RED_SIZE,
    SDL_GL_GREEN_SIZE,
    SDL_GL_BLUE_SIZE,
    SDL_GL_ALPHA_SIZE,
    SDL_GL_BUFFER_SIZE,
    SDL_GL_DOUBLEBUFFER,
    SDL_GL_DEPTH_SIZE,
    SDL_GL_STENCIL_SIZE,
    SDL_GL_ACCUM_RED_SIZE,
    SDL_GL_ACCUM_GREEN_SIZE,
    SDL_GL_ACCUM_BLUE_SIZE,
    SDL_GL_ACCUM_ALPHA_SIZE,
    SDL_GL_STEREO,
    SDL_GL_MULTISAMPLEBUFFERS,
    SDL_GL_MULTISAMPLESAMPLES,
    SDL_GL_ACCELERATED_VISUAL,
    SDL_GL_RETAINED_BACKING,
    SDL_GL_CONTEXT_MAJOR_VERSION,
    SDL_GL_CONTEXT_MINOR_VERSION,
    SDL_GL_CONTEXT_EGL,
    SDL_GL_CONTEXT_FLAGS,
    SDL_GL_CONTEXT_PROFILE_MASK,
    SDL_GL_SHARE_WITH_CURRENT_CONTEXT,
    SDL_GL_FRAMEBUFFER_SRGB_CAPABLE

}
public enum SDL_GLprofile
{

    SDL_GL_CONTEXT_PROFILE_CORE           = 0x0001,
    SDL_GL_CONTEXT_PROFILE_COMPATIBILITY  = 0x0002,
    SDL_GL_CONTEXT_PROFILE_ES             = 0x0004 /* GLX_CONTEXT_ES2_PROFILE_BIT_EXT */

}
public enum SDL_GLcontextFlag
{

    SDL_GL_CONTEXT_DEBUG_FLAG              = 0x0001,
    SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG = 0x0002,
    SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG      = 0x0004,
    SDL_GL_CONTEXT_RESET_ISOLATION_FLAG    = 0x0008

}

[StructLayout(LayoutKind.Sequential)]
public struct SDL_DisplayMode
{

    Uint32 format;              /**< pixel format */
    int w;                      /**< width */
    int h;                      /**< height */
    int refresh_rate;           /**< refresh rate (or zero for unspecified) */
    void *driverdata;           /**< driver-specific data, initialize to 0 */

}

[DllImport("SDL2.dll")]
public static extern int SDL_GetNumVideoDrivers();
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetVideoDriver(int index);
[DllImport("SDL2.dll")]
public static extern int SDL_VideoInit(IntPtr driver_name);
[DllImport("SDL2.dll")]
public static extern void SDL_VideoQuit();
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetCurrentVideoDriver();
[DllImport("SDL2.dll")]
public static extern int SDL_GetNumVideoDisplays();
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetDisplayName(int displayIndex);
[DllImport("SDL2.dll")]
public static extern int SDL_GetDisplayBounds(int displayIndex, ref SDL_Rect rect);
[DllImport("SDL2.dll")]
public static extern int SDL_GetNumDisplayModes(int displayIndex);
[DllImport("SDL2.dll")]
public static extern int SDL_GetDisplayMode(int displayIndex, int modeIndex, ref SDL_DisplayMode mode);
[DllImport("SDL2.dll")]
public static extern int SDL_GetDesktopDisplayMode(int displayIndex, ref SDL_DisplayMode mode);
[DllImport("SDL2.dll")]
public static extern int SDL_GetCurrentDisplayMode(int displayIndex, ref SDL_DisplayMode mode);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetClosestDisplayMode(int displayIndex, ref SDL_DisplayMode mode, ref SDL_DisplayMode closest);
[DllImport("SDL2.dll")]
public static extern int SDL_GetWindowDisplayIndex(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern int SDL_SetWindowDisplayMode(ref SDL_Window window, ref SDL_DisplayMode mode);
[DllImport("SDL2.dll")]
public static extern int SDL_GetWindowDisplayMode(ref SDL_Window window, ref SDL_DisplayMode mode);
[DllImport("SDL2.dll")]
public static extern uint SDL_GetWindowPixelFormat(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_CreateWindow(IntPtr title, int x, int y, int w, int h, Uint32 flags);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_CreateWindowFrom(ref void data);
[DllImport("SDL2.dll")]
public static extern uint SDL_GetWindowID(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetWindowFromID(Uint32 id);
[DllImport("SDL2.dll")]
public static extern uint SDL_GetWindowFlags(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern void SDL_SetWindowTitle(ref SDL_Window window, IntPtr title);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetWindowTitle(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern void SDL_SetWindowIcon(ref SDL_Window window, ref SDL_Surface icon);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_SetWindowData(ref SDL_Window window, IntPtr name, ref void userdata);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetWindowData(ref SDL_Window window, IntPtr name);
[DllImport("SDL2.dll")]
public static extern void SDL_SetWindowPosition(ref SDL_Window window, int x, int y);
[DllImport("SDL2.dll")]
public static extern void SDL_GetWindowPosition(ref SDL_Window window, ref int x, ref int y);
[DllImport("SDL2.dll")]
public static extern void SDL_SetWindowSize(ref SDL_Window window, int w, int h);
[DllImport("SDL2.dll")]
public static extern void SDL_GetWindowSize(ref SDL_Window window, ref int w, ref int h);
[DllImport("SDL2.dll")]
public static extern void SDL_SetWindowMinimumSize(ref SDL_Window window, int min_w, int min_h);
[DllImport("SDL2.dll")]
public static extern void SDL_GetWindowMinimumSize(ref SDL_Window window, ref int w, ref int h);
[DllImport("SDL2.dll")]
public static extern void SDL_SetWindowMaximumSize(ref SDL_Window window, int max_w, int max_h);
[DllImport("SDL2.dll")]
public static extern void SDL_GetWindowMaximumSize(ref SDL_Window window, ref int w, ref int h);
[DllImport("SDL2.dll")]
public static extern void SDL_SetWindowBordered(ref SDL_Window window, SDL_bool bordered);
[DllImport("SDL2.dll")]
public static extern void SDL_ShowWindow(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern void SDL_HideWindow(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern void SDL_RaiseWindow(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern void SDL_MaximizeWindow(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern void SDL_MinimizeWindow(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern void SDL_RestoreWindow(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern int SDL_SetWindowFullscreen(ref SDL_Window window, Uint32 flags);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GetWindowSurface(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern int SDL_UpdateWindowSurface(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern int SDL_UpdateWindowSurfaceRects(ref SDL_Window window, ref SDL_Rect rects, int numrects);
[DllImport("SDL2.dll")]
public static extern void SDL_SetWindowGrab(ref SDL_Window window, SDL_bool grabbed);
[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_GetWindowGrab(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern int SDL_SetWindowBrightness(ref SDL_Window window, float brightness);
[DllImport("SDL2.dll")]
public static extern float SDL_GetWindowBrightness(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern int SDL_SetWindowGammaRamp(ref SDL_Window window, ref ushort red, ref ushort green, ref ushort blue);
[DllImport("SDL2.dll")]
public static extern int SDL_GetWindowGammaRamp(ref SDL_Window window, ref ushort red, ref ushort green, ref ushort blue);
[DllImport("SDL2.dll")]
public static extern void SDL_DestroyWindow(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_IsScreenSaverEnabled();
[DllImport("SDL2.dll")]
public static extern void SDL_EnableScreenSaver();
[DllImport("SDL2.dll")]
public static extern void SDL_DisableScreenSaver();
[DllImport("SDL2.dll")]
public static extern int SDL_GL_LoadLibrary(IntPtr path);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GL_GetProcAddress(IntPtr proc);
[DllImport("SDL2.dll")]
public static extern void SDL_GL_UnloadLibrary();
[DllImport("SDL2.dll")]
public static extern SDL_bool SDL_GL_ExtensionSupported(IntPtr extension);
[DllImport("SDL2.dll")]
public static extern void SDL_GL_ResetAttributes();
[DllImport("SDL2.dll")]
public static extern int SDL_GL_SetAttribute(SDL_GLattr attr, int value);
[DllImport("SDL2.dll")]
public static extern int SDL_GL_GetAttribute(SDL_GLattr attr, ref int value);
[DllImport("SDL2.dll")]
public static extern SDL_GLContext SDL_GL_CreateContext(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern int SDL_GL_MakeCurrent(ref SDL_Window window, SDL_GLContext context);
[DllImport("SDL2.dll")]
public static extern IntPtr SDL_GL_GetCurrentWindow();
[DllImport("SDL2.dll")]
public static extern SDL_GLContext SDL_GL_GetCurrentContext();
[DllImport("SDL2.dll")]
public static extern void SDL_GL_GetDrawableSize(ref SDL_Window window, ref int w, ref int h);
[DllImport("SDL2.dll")]
public static extern int SDL_GL_SetSwapInterval(int interval);
[DllImport("SDL2.dll")]
public static extern int SDL_GL_GetSwapInterval();
[DllImport("SDL2.dll")]
public static extern void SDL_GL_SwapWindow(ref SDL_Window window);
[DllImport("SDL2.dll")]
public static extern void SDL_GL_DeleteContext(SDL_GLContext context);

}
}

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

using static SDL2.SDL_touch;
using static SDL2.SDL_version;

using SDL_bool = System.Int32;
using SDL_GLContext = System.IntPtr;
using NativeLibraryLoader;
using SDL2.Internal;

namespace SDL2
{
    public static class SDL_video
    {
        public const int SDL_WINDOWPOS_UNDEFINED_MASK = 0x1FFF0000;
        public const int SDL_WINDOWPOS_CENTERED_MASK = 0x2FFF0000;
        public static int SDL_WINDOWPOS_UNDEFINED_DISPLAY(int displayIndex) =>
            SDL_WINDOWPOS_UNDEFINED_MASK | displayIndex;
        public static int SDL_WINDOWPOS_CENTERED_DISPLAY(int displayIndex) =>
            SDL_WINDOWPOS_CENTERED_MASK | displayIndex;


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
            SDL_WINDOW_FULLSCREEN_DESKTOP = (SDL_WINDOW_FULLSCREEN | 0x00001000),
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

            SDL_GL_CONTEXT_PROFILE_CORE = 0x0001,
            SDL_GL_CONTEXT_PROFILE_COMPATIBILITY = 0x0002,
            SDL_GL_CONTEXT_PROFILE_ES = 0x0004 /* GLX_CONTEXT_ES2_PROFILE_BIT_EXT */

        }
        public enum SDL_GLcontextFlag
        {

            SDL_GL_CONTEXT_DEBUG_FLAG = 0x0001,
            SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG = 0x0002,
            SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG = 0x0004,
            SDL_GL_CONTEXT_RESET_ISOLATION_FLAG = 0x0008

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_DisplayMode
        {

            public UInt32 format;              /**< pixel format */
            public int w;                      /**< width */
            public int h;                      /**< height */
            public int refresh_rate;           /**< refresh rate (or zero for unspecified) */
            public IntPtr driverdata;           /**< driver-specific data, initialize to 0 */

            public override string ToString() => $"{w}x{h} - {refresh_rate} Hz";

            public override bool Equals(object obj) => obj is SDL_DisplayMode && this == (SDL_DisplayMode)obj;
            public override int GetHashCode()
            {
                var hash = 17;
                hash = hash * 23 + format.GetHashCode();
                hash = hash * 23 + w.GetHashCode();
                hash = hash * 23 + h.GetHashCode();
                hash = hash * 23 + refresh_rate.GetHashCode();
                return hash;
            }
            public static bool operator ==(SDL_DisplayMode one, SDL_DisplayMode two) =>
                one.format == two.format &&
                    one.w == two.w &&
                    one.h == two.h &&
                    one.refresh_rate == two.refresh_rate;
            public static bool operator !=(SDL_DisplayMode one, SDL_DisplayMode two) => !(one == two);
        }

        private delegate int SDL_GetNumVideoDrivers__t();

        private static SDL_GetNumVideoDrivers__t s_SDL_GetNumVideoDrivers__t = __LoadFunction<SDL_GetNumVideoDrivers__t>("SDL_GetNumVideoDrivers");

        public static int SDL_GetNumVideoDrivers() => s_SDL_GetNumVideoDrivers__t();

        private delegate IntPtr SDL_GetVideoDriver_int_t(int index);

        private static SDL_GetVideoDriver_int_t s_SDL_GetVideoDriver_int_t = __LoadFunction<SDL_GetVideoDriver_int_t>("SDL_GetVideoDriver");

        public static IntPtr SDL_GetVideoDriver(int index) => s_SDL_GetVideoDriver_int_t(index);

        private delegate int SDL_VideoInit_IntPtr_t(IntPtr driver_name);

        private static SDL_VideoInit_IntPtr_t s_SDL_VideoInit_IntPtr_t = __LoadFunction<SDL_VideoInit_IntPtr_t>("SDL_VideoInit");

        public static int SDL_VideoInit(IntPtr driver_name) => s_SDL_VideoInit_IntPtr_t(driver_name);

        private delegate void SDL_VideoQuit__t();

        private static SDL_VideoQuit__t s_SDL_VideoQuit__t = __LoadFunction<SDL_VideoQuit__t>("SDL_VideoQuit");

        public static void SDL_VideoQuit() => s_SDL_VideoQuit__t();

        private delegate IntPtr SDL_GetCurrentVideoDriver__t();

        private static SDL_GetCurrentVideoDriver__t s_SDL_GetCurrentVideoDriver__t = __LoadFunction<SDL_GetCurrentVideoDriver__t>("SDL_GetCurrentVideoDriver");

        public static IntPtr SDL_GetCurrentVideoDriver() => s_SDL_GetCurrentVideoDriver__t();

        private delegate int SDL_GetNumVideoDisplays__t();

        private static SDL_GetNumVideoDisplays__t s_SDL_GetNumVideoDisplays__t = __LoadFunction<SDL_GetNumVideoDisplays__t>("SDL_GetNumVideoDisplays");

        public static int SDL_GetNumVideoDisplays() => s_SDL_GetNumVideoDisplays__t();

        private delegate IntPtr SDL_GetDisplayName_int_t(int displayIndex);

        private static SDL_GetDisplayName_int_t s_SDL_GetDisplayName_int_t = __LoadFunction<SDL_GetDisplayName_int_t>("SDL_GetDisplayName");

        private static IntPtr _SDL_GetDisplayName(int displayIndex) => s_SDL_GetDisplayName_int_t(displayIndex);
        public static string SDL_GetDisplayName(int displayIndex) => Util.PtrToStringUTF8(_SDL_GetDisplayName(displayIndex));

        private delegate int SDL_GetDisplayBounds_int_SDL_Rect_t(int displayIndex, ref SDL_Rect rect);

        private static SDL_GetDisplayBounds_int_SDL_Rect_t s_SDL_GetDisplayBounds_int_SDL_Rect_t = __LoadFunction<SDL_GetDisplayBounds_int_SDL_Rect_t>("SDL_GetDisplayBounds");

        public static int SDL_GetDisplayBounds(int displayIndex, ref SDL_Rect rect) => s_SDL_GetDisplayBounds_int_SDL_Rect_t(displayIndex, ref rect);

        private delegate int SDL_GetNumDisplayModes_int_t(int displayIndex);

        private static SDL_GetNumDisplayModes_int_t s_SDL_GetNumDisplayModes_int_t = __LoadFunction<SDL_GetNumDisplayModes_int_t>("SDL_GetNumDisplayModes");

        public static int SDL_GetNumDisplayModes(int displayIndex) => s_SDL_GetNumDisplayModes_int_t(displayIndex);

        private delegate int SDL_GetDisplayMode_int_int_SDL_DisplayMode_t(int displayIndex, int modeIndex, ref SDL_DisplayMode mode);

        private static SDL_GetDisplayMode_int_int_SDL_DisplayMode_t s_SDL_GetDisplayMode_int_int_SDL_DisplayMode_t = __LoadFunction<SDL_GetDisplayMode_int_int_SDL_DisplayMode_t>("SDL_GetDisplayMode");

        public static int SDL_GetDisplayMode(int displayIndex, int modeIndex, ref SDL_DisplayMode mode) => s_SDL_GetDisplayMode_int_int_SDL_DisplayMode_t(displayIndex, modeIndex, ref mode);

        private delegate int SDL_GetDesktopDisplayMode_int_SDL_DisplayMode_t(int displayIndex, ref SDL_DisplayMode mode);

        private static SDL_GetDesktopDisplayMode_int_SDL_DisplayMode_t s_SDL_GetDesktopDisplayMode_int_SDL_DisplayMode_t = __LoadFunction<SDL_GetDesktopDisplayMode_int_SDL_DisplayMode_t>("SDL_GetDesktopDisplayMode");

        public static int SDL_GetDesktopDisplayMode(int displayIndex, ref SDL_DisplayMode mode) => s_SDL_GetDesktopDisplayMode_int_SDL_DisplayMode_t(displayIndex, ref mode);

        private delegate int SDL_GetCurrentDisplayMode_int_SDL_DisplayMode_t(int displayIndex, ref SDL_DisplayMode mode);

        private static SDL_GetCurrentDisplayMode_int_SDL_DisplayMode_t s_SDL_GetCurrentDisplayMode_int_SDL_DisplayMode_t = __LoadFunction<SDL_GetCurrentDisplayMode_int_SDL_DisplayMode_t>("SDL_GetCurrentDisplayMode");

        public static int SDL_GetCurrentDisplayMode(int displayIndex, ref SDL_DisplayMode mode) => s_SDL_GetCurrentDisplayMode_int_SDL_DisplayMode_t(displayIndex, ref mode);

        private delegate IntPtr SDL_GetClosestDisplayMode_int_SDL_DisplayMode_SDL_DisplayMode_t(int displayIndex, ref SDL_DisplayMode mode, ref SDL_DisplayMode closest);

        private static SDL_GetClosestDisplayMode_int_SDL_DisplayMode_SDL_DisplayMode_t s_SDL_GetClosestDisplayMode_int_SDL_DisplayMode_SDL_DisplayMode_t = __LoadFunction<SDL_GetClosestDisplayMode_int_SDL_DisplayMode_SDL_DisplayMode_t>("SDL_GetClosestDisplayMode");

        public static IntPtr SDL_GetClosestDisplayMode(int displayIndex, ref SDL_DisplayMode mode, ref SDL_DisplayMode closest) => s_SDL_GetClosestDisplayMode_int_SDL_DisplayMode_SDL_DisplayMode_t(displayIndex, ref mode, ref closest);

        private delegate int SDL_GetWindowDisplayIndex_IntPtr_t(IntPtr window);

        private static SDL_GetWindowDisplayIndex_IntPtr_t s_SDL_GetWindowDisplayIndex_IntPtr_t = __LoadFunction<SDL_GetWindowDisplayIndex_IntPtr_t>("SDL_GetWindowDisplayIndex");

        public static int SDL_GetWindowDisplayIndex(IntPtr window) => s_SDL_GetWindowDisplayIndex_IntPtr_t(window);

        private delegate int SDL_SetWindowDisplayMode_IntPtr_SDL_DisplayMode_t(IntPtr window, ref SDL_DisplayMode mode);

        private static SDL_SetWindowDisplayMode_IntPtr_SDL_DisplayMode_t s_SDL_SetWindowDisplayMode_IntPtr_SDL_DisplayMode_t = __LoadFunction<SDL_SetWindowDisplayMode_IntPtr_SDL_DisplayMode_t>("SDL_SetWindowDisplayMode");

        public static int SDL_SetWindowDisplayMode(IntPtr window, ref SDL_DisplayMode mode) => s_SDL_SetWindowDisplayMode_IntPtr_SDL_DisplayMode_t(window, ref mode);

        private delegate int SDL_GetWindowDisplayMode_IntPtr_SDL_DisplayMode_t(IntPtr window, ref SDL_DisplayMode mode);

        private static SDL_GetWindowDisplayMode_IntPtr_SDL_DisplayMode_t s_SDL_GetWindowDisplayMode_IntPtr_SDL_DisplayMode_t = __LoadFunction<SDL_GetWindowDisplayMode_IntPtr_SDL_DisplayMode_t>("SDL_GetWindowDisplayMode");

        public static int SDL_GetWindowDisplayMode(IntPtr window, ref SDL_DisplayMode mode) => s_SDL_GetWindowDisplayMode_IntPtr_SDL_DisplayMode_t(window, ref mode);

        private delegate uint SDL_GetWindowPixelFormat_IntPtr_t(IntPtr window);

        private static SDL_GetWindowPixelFormat_IntPtr_t s_SDL_GetWindowPixelFormat_IntPtr_t = __LoadFunction<SDL_GetWindowPixelFormat_IntPtr_t>("SDL_GetWindowPixelFormat");

        public static uint SDL_GetWindowPixelFormat(IntPtr window) => s_SDL_GetWindowPixelFormat_IntPtr_t(window);

        private delegate IntPtr SDL_CreateWindow_IntPtr_int_int_int_int_UInt32_t(IntPtr title, int x, int y, int w, int h, UInt32 flags);

        private static SDL_CreateWindow_IntPtr_int_int_int_int_UInt32_t s_SDL_CreateWindow_IntPtr_int_int_int_int_UInt32_t = __LoadFunction<SDL_CreateWindow_IntPtr_int_int_int_int_UInt32_t>("SDL_CreateWindow");

        public static IntPtr SDL_CreateWindow(string title, int x, int y, int w, int h, UInt32 flags) => s_SDL_CreateWindow_IntPtr_int_int_int_int_UInt32_t(Util.StringToHGlobalUTF8(title), x, y, w, h, flags);

        private delegate IntPtr SDL_CreateWindowFrom_IntPtr_t(IntPtr data);

        private static SDL_CreateWindowFrom_IntPtr_t s_SDL_CreateWindowFrom_IntPtr_t = __LoadFunction<SDL_CreateWindowFrom_IntPtr_t>("SDL_CreateWindowFrom");

        public static IntPtr SDL_CreateWindowFrom(IntPtr data) => s_SDL_CreateWindowFrom_IntPtr_t(data);

        private delegate uint SDL_GetWindowID_IntPtr_t(IntPtr window);

        private static SDL_GetWindowID_IntPtr_t s_SDL_GetWindowID_IntPtr_t = __LoadFunction<SDL_GetWindowID_IntPtr_t>("SDL_GetWindowID");

        public static uint SDL_GetWindowID(IntPtr window) => s_SDL_GetWindowID_IntPtr_t(window);

        private delegate IntPtr SDL_GetWindowFromID_UInt32_t(UInt32 id);

        private static SDL_GetWindowFromID_UInt32_t s_SDL_GetWindowFromID_UInt32_t = __LoadFunction<SDL_GetWindowFromID_UInt32_t>("SDL_GetWindowFromID");

        public static IntPtr SDL_GetWindowFromID(UInt32 id) => s_SDL_GetWindowFromID_UInt32_t(id);

        private delegate uint SDL_GetWindowFlags_IntPtr_t(IntPtr window);

        private static SDL_GetWindowFlags_IntPtr_t s_SDL_GetWindowFlags_IntPtr_t = __LoadFunction<SDL_GetWindowFlags_IntPtr_t>("SDL_GetWindowFlags");

        public static uint SDL_GetWindowFlags(IntPtr window) => s_SDL_GetWindowFlags_IntPtr_t(window);

        private delegate void SDL_SetWindowTitle_IntPtr_IntPtr_t(IntPtr window, IntPtr title);

        private static SDL_SetWindowTitle_IntPtr_IntPtr_t s_SDL_SetWindowTitle_IntPtr_IntPtr_t = __LoadFunction<SDL_SetWindowTitle_IntPtr_IntPtr_t>("SDL_SetWindowTitle");

        private static void _SDL_SetWindowTitle(IntPtr window, IntPtr title) => s_SDL_SetWindowTitle_IntPtr_IntPtr_t(window, title);
        public static void SDL_SetWindowTitle(IntPtr window, string title) => _SDL_SetWindowTitle(window, Util.StringToHGlobalUTF8(title));

        private delegate IntPtr SDL_GetWindowTitle_IntPtr_t(IntPtr window);

        private static SDL_GetWindowTitle_IntPtr_t s_SDL_GetWindowTitle_IntPtr_t = __LoadFunction<SDL_GetWindowTitle_IntPtr_t>("SDL_GetWindowTitle");

        private static IntPtr _SDL_GetWindowTitle(IntPtr window) => s_SDL_GetWindowTitle_IntPtr_t(window);
        public static string SDL_GetWindowTitle(IntPtr window) => Util.PtrToStringUTF8(_SDL_GetWindowTitle(window));

        private delegate void SDL_SetWindowIcon_IntPtr_SDL_Surface_t(IntPtr window, ref SDL_Surface icon);

        private static SDL_SetWindowIcon_IntPtr_SDL_Surface_t s_SDL_SetWindowIcon_IntPtr_SDL_Surface_t = __LoadFunction<SDL_SetWindowIcon_IntPtr_SDL_Surface_t>("SDL_SetWindowIcon");

        public static void SDL_SetWindowIcon(IntPtr window, ref SDL_Surface icon) => s_SDL_SetWindowIcon_IntPtr_SDL_Surface_t(window, ref icon);

        private delegate IntPtr SDL_SetWindowData_IntPtr_IntPtr_IntPtr_t(IntPtr window, IntPtr name, IntPtr userdata);

        private static SDL_SetWindowData_IntPtr_IntPtr_IntPtr_t s_SDL_SetWindowData_IntPtr_IntPtr_IntPtr_t = __LoadFunction<SDL_SetWindowData_IntPtr_IntPtr_IntPtr_t>("SDL_SetWindowData");

        public static IntPtr SDL_SetWindowData(IntPtr window, IntPtr name, IntPtr userdata) => s_SDL_SetWindowData_IntPtr_IntPtr_IntPtr_t(window, name, userdata);

        private delegate IntPtr SDL_GetWindowData_IntPtr_IntPtr_t(IntPtr window, IntPtr name);

        private static SDL_GetWindowData_IntPtr_IntPtr_t s_SDL_GetWindowData_IntPtr_IntPtr_t = __LoadFunction<SDL_GetWindowData_IntPtr_IntPtr_t>("SDL_GetWindowData");

        public static IntPtr SDL_GetWindowData(IntPtr window, IntPtr name) => s_SDL_GetWindowData_IntPtr_IntPtr_t(window, name);

        private delegate void SDL_SetWindowPosition_IntPtr_int_int_t(IntPtr window, int x, int y);

        private static SDL_SetWindowPosition_IntPtr_int_int_t s_SDL_SetWindowPosition_IntPtr_int_int_t = __LoadFunction<SDL_SetWindowPosition_IntPtr_int_int_t>("SDL_SetWindowPosition");

        public static void SDL_SetWindowPosition(IntPtr window, int x, int y) => s_SDL_SetWindowPosition_IntPtr_int_int_t(window, x, y);

        private delegate void SDL_GetWindowPosition_IntPtr_int_int_t(IntPtr window, out int x, out int y);

        private static SDL_GetWindowPosition_IntPtr_int_int_t s_SDL_GetWindowPosition_IntPtr_int_int_t = __LoadFunction<SDL_GetWindowPosition_IntPtr_int_int_t>("SDL_GetWindowPosition");

        public static void SDL_GetWindowPosition(IntPtr window, out int x, out int y) => s_SDL_GetWindowPosition_IntPtr_int_int_t(window, out x, out y);

        private delegate void SDL_SetWindowSize_IntPtr_int_int_t(IntPtr window, int w, int h);

        private static SDL_SetWindowSize_IntPtr_int_int_t s_SDL_SetWindowSize_IntPtr_int_int_t = __LoadFunction<SDL_SetWindowSize_IntPtr_int_int_t>("SDL_SetWindowSize");

        public static void SDL_SetWindowSize(IntPtr window, int w, int h) => s_SDL_SetWindowSize_IntPtr_int_int_t(window, w, h);

        private delegate void SDL_GetWindowSize_IntPtr_int_int_t(IntPtr window, out int w, out int h);

        private static SDL_GetWindowSize_IntPtr_int_int_t s_SDL_GetWindowSize_IntPtr_int_int_t = __LoadFunction<SDL_GetWindowSize_IntPtr_int_int_t>("SDL_GetWindowSize");

        public static void SDL_GetWindowSize(IntPtr window, out int w, out int h) => s_SDL_GetWindowSize_IntPtr_int_int_t(window, out w, out h);

        private delegate void SDL_SetWindowMinimumSize_IntPtr_int_int_t(IntPtr window, int min_w, int min_h);

        private static SDL_SetWindowMinimumSize_IntPtr_int_int_t s_SDL_SetWindowMinimumSize_IntPtr_int_int_t = __LoadFunction<SDL_SetWindowMinimumSize_IntPtr_int_int_t>("SDL_SetWindowMinimumSize");

        public static void SDL_SetWindowMinimumSize(IntPtr window, int min_w, int min_h) => s_SDL_SetWindowMinimumSize_IntPtr_int_int_t(window, min_w, min_h);

        private delegate void SDL_GetWindowMinimumSize_IntPtr_int_int_t(IntPtr window, out int w, out int h);

        private static SDL_GetWindowMinimumSize_IntPtr_int_int_t s_SDL_GetWindowMinimumSize_IntPtr_int_int_t = __LoadFunction<SDL_GetWindowMinimumSize_IntPtr_int_int_t>("SDL_GetWindowMinimumSize");

        public static void SDL_GetWindowMinimumSize(IntPtr window, out int w, out int h) => s_SDL_GetWindowMinimumSize_IntPtr_int_int_t(window, out w, out h);

        private delegate void SDL_SetWindowMaximumSize_IntPtr_int_int_t(IntPtr window, int max_w, int max_h);

        private static SDL_SetWindowMaximumSize_IntPtr_int_int_t s_SDL_SetWindowMaximumSize_IntPtr_int_int_t = __LoadFunction<SDL_SetWindowMaximumSize_IntPtr_int_int_t>("SDL_SetWindowMaximumSize");

        public static void SDL_SetWindowMaximumSize(IntPtr window, int max_w, int max_h) => s_SDL_SetWindowMaximumSize_IntPtr_int_int_t(window, max_w, max_h);

        private delegate void SDL_GetWindowMaximumSize_IntPtr_int_int_t(IntPtr window, out int w, out int h);

        private static SDL_GetWindowMaximumSize_IntPtr_int_int_t s_SDL_GetWindowMaximumSize_IntPtr_int_int_t = __LoadFunction<SDL_GetWindowMaximumSize_IntPtr_int_int_t>("SDL_GetWindowMaximumSize");

        public static void SDL_GetWindowMaximumSize(IntPtr window, out int w, out int h) => s_SDL_GetWindowMaximumSize_IntPtr_int_int_t(window, out w, out h);

        private delegate void SDL_SetWindowBordered_IntPtr_SDL_bool_t(IntPtr window, SDL_bool bordered);

        private static SDL_SetWindowBordered_IntPtr_SDL_bool_t s_SDL_SetWindowBordered_IntPtr_SDL_bool_t = __LoadFunction<SDL_SetWindowBordered_IntPtr_SDL_bool_t>("SDL_SetWindowBordered");

        public static void SDL_SetWindowBordered(IntPtr window, SDL_bool bordered) => s_SDL_SetWindowBordered_IntPtr_SDL_bool_t(window, bordered);

        private delegate void SDL_ShowWindow_IntPtr_t(IntPtr window);

        private static SDL_ShowWindow_IntPtr_t s_SDL_ShowWindow_IntPtr_t = __LoadFunction<SDL_ShowWindow_IntPtr_t>("SDL_ShowWindow");

        public static void SDL_ShowWindow(IntPtr window) => s_SDL_ShowWindow_IntPtr_t(window);

        private delegate void SDL_HideWindow_IntPtr_t(IntPtr window);

        private static SDL_HideWindow_IntPtr_t s_SDL_HideWindow_IntPtr_t = __LoadFunction<SDL_HideWindow_IntPtr_t>("SDL_HideWindow");

        public static void SDL_HideWindow(IntPtr window) => s_SDL_HideWindow_IntPtr_t(window);

        private delegate void SDL_RaiseWindow_IntPtr_t(IntPtr window);

        private static SDL_RaiseWindow_IntPtr_t s_SDL_RaiseWindow_IntPtr_t = __LoadFunction<SDL_RaiseWindow_IntPtr_t>("SDL_RaiseWindow");

        public static void SDL_RaiseWindow(IntPtr window) => s_SDL_RaiseWindow_IntPtr_t(window);

        private delegate void SDL_MaximizeWindow_IntPtr_t(IntPtr window);

        private static SDL_MaximizeWindow_IntPtr_t s_SDL_MaximizeWindow_IntPtr_t = __LoadFunction<SDL_MaximizeWindow_IntPtr_t>("SDL_MaximizeWindow");

        public static void SDL_MaximizeWindow(IntPtr window) => s_SDL_MaximizeWindow_IntPtr_t(window);

        private delegate void SDL_MinimizeWindow_IntPtr_t(IntPtr window);

        private static SDL_MinimizeWindow_IntPtr_t s_SDL_MinimizeWindow_IntPtr_t = __LoadFunction<SDL_MinimizeWindow_IntPtr_t>("SDL_MinimizeWindow");

        public static void SDL_MinimizeWindow(IntPtr window) => s_SDL_MinimizeWindow_IntPtr_t(window);

        private delegate void SDL_RestoreWindow_IntPtr_t(IntPtr window);

        private static SDL_RestoreWindow_IntPtr_t s_SDL_RestoreWindow_IntPtr_t = __LoadFunction<SDL_RestoreWindow_IntPtr_t>("SDL_RestoreWindow");

        public static void SDL_RestoreWindow(IntPtr window) => s_SDL_RestoreWindow_IntPtr_t(window);

        private delegate int SDL_SetWindowFullscreen_IntPtr_UInt32_t(IntPtr window, UInt32 flags);

        private static SDL_SetWindowFullscreen_IntPtr_UInt32_t s_SDL_SetWindowFullscreen_IntPtr_UInt32_t = __LoadFunction<SDL_SetWindowFullscreen_IntPtr_UInt32_t>("SDL_SetWindowFullscreen");

        public static int SDL_SetWindowFullscreen(IntPtr window, UInt32 flags) => s_SDL_SetWindowFullscreen_IntPtr_UInt32_t(window, flags);

        private delegate IntPtr SDL_GetWindowSurface_IntPtr_t(IntPtr window);

        private static SDL_GetWindowSurface_IntPtr_t s_SDL_GetWindowSurface_IntPtr_t = __LoadFunction<SDL_GetWindowSurface_IntPtr_t>("SDL_GetWindowSurface");

        public static IntPtr SDL_GetWindowSurface(IntPtr window) => s_SDL_GetWindowSurface_IntPtr_t(window);

        private delegate int SDL_UpdateWindowSurface_IntPtr_t(IntPtr window);

        private static SDL_UpdateWindowSurface_IntPtr_t s_SDL_UpdateWindowSurface_IntPtr_t = __LoadFunction<SDL_UpdateWindowSurface_IntPtr_t>("SDL_UpdateWindowSurface");

        public static int SDL_UpdateWindowSurface(IntPtr window) => s_SDL_UpdateWindowSurface_IntPtr_t(window);

        private delegate int SDL_UpdateWindowSurfaceRects_IntPtr_SDL_Rect_int_t(IntPtr window, ref SDL_Rect rects, int numrects);

        private static SDL_UpdateWindowSurfaceRects_IntPtr_SDL_Rect_int_t s_SDL_UpdateWindowSurfaceRects_IntPtr_SDL_Rect_int_t = __LoadFunction<SDL_UpdateWindowSurfaceRects_IntPtr_SDL_Rect_int_t>("SDL_UpdateWindowSurfaceRects");

        public static int SDL_UpdateWindowSurfaceRects(IntPtr window, ref SDL_Rect rects, int numrects) => s_SDL_UpdateWindowSurfaceRects_IntPtr_SDL_Rect_int_t(window, ref rects, numrects);

        private delegate void SDL_SetWindowGrab_IntPtr_SDL_bool_t(IntPtr window, SDL_bool grabbed);

        private static SDL_SetWindowGrab_IntPtr_SDL_bool_t s_SDL_SetWindowGrab_IntPtr_SDL_bool_t = __LoadFunction<SDL_SetWindowGrab_IntPtr_SDL_bool_t>("SDL_SetWindowGrab");

        public static void SDL_SetWindowGrab(IntPtr window, SDL_bool grabbed) => s_SDL_SetWindowGrab_IntPtr_SDL_bool_t(window, grabbed);

        private delegate SDL_bool SDL_GetWindowGrab_IntPtr_t(IntPtr window);

        private static SDL_GetWindowGrab_IntPtr_t s_SDL_GetWindowGrab_IntPtr_t = __LoadFunction<SDL_GetWindowGrab_IntPtr_t>("SDL_GetWindowGrab");

        public static SDL_bool SDL_GetWindowGrab(IntPtr window) => s_SDL_GetWindowGrab_IntPtr_t(window);

        private delegate int SDL_SetWindowBrightness_IntPtr_float_t(IntPtr window, float brightness);

        private static SDL_SetWindowBrightness_IntPtr_float_t s_SDL_SetWindowBrightness_IntPtr_float_t = __LoadFunction<SDL_SetWindowBrightness_IntPtr_float_t>("SDL_SetWindowBrightness");

        public static int SDL_SetWindowBrightness(IntPtr window, float brightness) => s_SDL_SetWindowBrightness_IntPtr_float_t(window, brightness);

        private delegate float SDL_GetWindowBrightness_IntPtr_t(IntPtr window);

        private static SDL_GetWindowBrightness_IntPtr_t s_SDL_GetWindowBrightness_IntPtr_t = __LoadFunction<SDL_GetWindowBrightness_IntPtr_t>("SDL_GetWindowBrightness");

        public static float SDL_GetWindowBrightness(IntPtr window) => s_SDL_GetWindowBrightness_IntPtr_t(window);

        private delegate int SDL_SetWindowGammaRamp_IntPtr_ushort_ushort_ushort_t(IntPtr window, ref ushort red, ref ushort green, ref ushort blue);

        private static SDL_SetWindowGammaRamp_IntPtr_ushort_ushort_ushort_t s_SDL_SetWindowGammaRamp_IntPtr_ushort_ushort_ushort_t = __LoadFunction<SDL_SetWindowGammaRamp_IntPtr_ushort_ushort_ushort_t>("SDL_SetWindowGammaRamp");

        public static int SDL_SetWindowGammaRamp(IntPtr window, ref ushort red, ref ushort green, ref ushort blue) => s_SDL_SetWindowGammaRamp_IntPtr_ushort_ushort_ushort_t(window, ref red, ref green, ref blue);

        private delegate int SDL_GetWindowGammaRamp_IntPtr_ushort_ushort_ushort_t(IntPtr window, ref ushort red, ref ushort green, ref ushort blue);

        private static SDL_GetWindowGammaRamp_IntPtr_ushort_ushort_ushort_t s_SDL_GetWindowGammaRamp_IntPtr_ushort_ushort_ushort_t = __LoadFunction<SDL_GetWindowGammaRamp_IntPtr_ushort_ushort_ushort_t>("SDL_GetWindowGammaRamp");

        public static int SDL_GetWindowGammaRamp(IntPtr window, ref ushort red, ref ushort green, ref ushort blue) => s_SDL_GetWindowGammaRamp_IntPtr_ushort_ushort_ushort_t(window, ref red, ref green, ref blue);

        private delegate void SDL_DestroyWindow_IntPtr_t(IntPtr window);

        private static SDL_DestroyWindow_IntPtr_t s_SDL_DestroyWindow_IntPtr_t = __LoadFunction<SDL_DestroyWindow_IntPtr_t>("SDL_DestroyWindow");

        public static void SDL_DestroyWindow(IntPtr window) => s_SDL_DestroyWindow_IntPtr_t(window);

        private delegate SDL_bool SDL_IsScreenSaverEnabled__t();

        private static SDL_IsScreenSaverEnabled__t s_SDL_IsScreenSaverEnabled__t = __LoadFunction<SDL_IsScreenSaverEnabled__t>("SDL_IsScreenSaverEnabled");

        public static SDL_bool SDL_IsScreenSaverEnabled() => s_SDL_IsScreenSaverEnabled__t();

        private delegate void SDL_EnableScreenSaver__t();

        private static SDL_EnableScreenSaver__t s_SDL_EnableScreenSaver__t = __LoadFunction<SDL_EnableScreenSaver__t>("SDL_EnableScreenSaver");

        public static void SDL_EnableScreenSaver() => s_SDL_EnableScreenSaver__t();

        private delegate void SDL_DisableScreenSaver__t();

        private static SDL_DisableScreenSaver__t s_SDL_DisableScreenSaver__t = __LoadFunction<SDL_DisableScreenSaver__t>("SDL_DisableScreenSaver");

        public static void SDL_DisableScreenSaver() => s_SDL_DisableScreenSaver__t();

        private delegate int SDL_GL_LoadLibrary_IntPtr_t(IntPtr path);

        private static SDL_GL_LoadLibrary_IntPtr_t s_SDL_GL_LoadLibrary_IntPtr_t = __LoadFunction<SDL_GL_LoadLibrary_IntPtr_t>("SDL_GL_LoadLibrary");

        public static int SDL_GL_LoadLibrary(IntPtr path) => s_SDL_GL_LoadLibrary_IntPtr_t(path);

        private delegate IntPtr SDL_GL_GetProcAddress_IntPtr_t(IntPtr proc);

        private static SDL_GL_GetProcAddress_IntPtr_t s_SDL_GL_GetProcAddress_IntPtr_t = __LoadFunction<SDL_GL_GetProcAddress_IntPtr_t>("SDL_GL_GetProcAddress");

        public static IntPtr SDL_GL_GetProcAddress(IntPtr proc) => s_SDL_GL_GetProcAddress_IntPtr_t(proc);

        private delegate void SDL_GL_UnloadLibrary__t();

        private static SDL_GL_UnloadLibrary__t s_SDL_GL_UnloadLibrary__t = __LoadFunction<SDL_GL_UnloadLibrary__t>("SDL_GL_UnloadLibrary");

        public static void SDL_GL_UnloadLibrary() => s_SDL_GL_UnloadLibrary__t();

        private delegate SDL_bool SDL_GL_ExtensionSupported_IntPtr_t(IntPtr extension);

        private static SDL_GL_ExtensionSupported_IntPtr_t s_SDL_GL_ExtensionSupported_IntPtr_t = __LoadFunction<SDL_GL_ExtensionSupported_IntPtr_t>("SDL_GL_ExtensionSupported");

        public static SDL_bool SDL_GL_ExtensionSupported(IntPtr extension) => s_SDL_GL_ExtensionSupported_IntPtr_t(extension);

        private delegate void SDL_GL_ResetAttributes__t();

        private static SDL_GL_ResetAttributes__t s_SDL_GL_ResetAttributes__t = __LoadFunction<SDL_GL_ResetAttributes__t>("SDL_GL_ResetAttributes");

        public static void SDL_GL_ResetAttributes() => s_SDL_GL_ResetAttributes__t();

        private delegate int SDL_GL_SetAttribute_SDL_GLattr_int_t(SDL_GLattr attr, int value);

        private static SDL_GL_SetAttribute_SDL_GLattr_int_t s_SDL_GL_SetAttribute_SDL_GLattr_int_t = __LoadFunction<SDL_GL_SetAttribute_SDL_GLattr_int_t>("SDL_GL_SetAttribute");

        public static int SDL_GL_SetAttribute(SDL_GLattr attr, int value) => s_SDL_GL_SetAttribute_SDL_GLattr_int_t(attr, value);

        private delegate int SDL_GL_GetAttribute_SDL_GLattr_int_t(SDL_GLattr attr, out int value);

        private static SDL_GL_GetAttribute_SDL_GLattr_int_t s_SDL_GL_GetAttribute_SDL_GLattr_int_t = __LoadFunction<SDL_GL_GetAttribute_SDL_GLattr_int_t>("SDL_GL_GetAttribute");

        public static int SDL_GL_GetAttribute(SDL_GLattr attr, out int value) => s_SDL_GL_GetAttribute_SDL_GLattr_int_t(attr, out value);

        private delegate SDL_GLContext SDL_GL_CreateContext_IntPtr_t(IntPtr window);

        private static SDL_GL_CreateContext_IntPtr_t s_SDL_GL_CreateContext_IntPtr_t = __LoadFunction<SDL_GL_CreateContext_IntPtr_t>("SDL_GL_CreateContext");

        public static SDL_GLContext SDL_GL_CreateContext(IntPtr window) => s_SDL_GL_CreateContext_IntPtr_t(window);

        private delegate int SDL_GL_MakeCurrent_IntPtr_SDL_GLContext_t(IntPtr window, SDL_GLContext context);

        private static SDL_GL_MakeCurrent_IntPtr_SDL_GLContext_t s_SDL_GL_MakeCurrent_IntPtr_SDL_GLContext_t = __LoadFunction<SDL_GL_MakeCurrent_IntPtr_SDL_GLContext_t>("SDL_GL_MakeCurrent");

        public static int SDL_GL_MakeCurrent(IntPtr window, SDL_GLContext context) => s_SDL_GL_MakeCurrent_IntPtr_SDL_GLContext_t(window, context);

        private delegate IntPtr SDL_GL_GetCurrentWindow__t();

        private static SDL_GL_GetCurrentWindow__t s_SDL_GL_GetCurrentWindow__t = __LoadFunction<SDL_GL_GetCurrentWindow__t>("SDL_GL_GetCurrentWindow");

        public static IntPtr SDL_GL_GetCurrentWindow() => s_SDL_GL_GetCurrentWindow__t();

        private delegate SDL_GLContext SDL_GL_GetCurrentContext__t();

        private static SDL_GL_GetCurrentContext__t s_SDL_GL_GetCurrentContext__t = __LoadFunction<SDL_GL_GetCurrentContext__t>("SDL_GL_GetCurrentContext");

        public static SDL_GLContext SDL_GL_GetCurrentContext() => s_SDL_GL_GetCurrentContext__t();

        private delegate void SDL_GL_GetDrawableSize_IntPtr_int_int_t(IntPtr window, out int w, out int h);

        private static SDL_GL_GetDrawableSize_IntPtr_int_int_t s_SDL_GL_GetDrawableSize_IntPtr_int_int_t = __LoadFunction<SDL_GL_GetDrawableSize_IntPtr_int_int_t>("SDL_GL_GetDrawableSize");

        public static void SDL_GL_GetDrawableSize(IntPtr window, out int w, out int h) => s_SDL_GL_GetDrawableSize_IntPtr_int_int_t(window, out w, out h);

        private delegate int SDL_GL_SetSwapInterval_int_t(int interval);

        private static SDL_GL_SetSwapInterval_int_t s_SDL_GL_SetSwapInterval_int_t = __LoadFunction<SDL_GL_SetSwapInterval_int_t>("SDL_GL_SetSwapInterval");

        public static int SDL_GL_SetSwapInterval(int interval) => s_SDL_GL_SetSwapInterval_int_t(interval);

        private delegate int SDL_GL_GetSwapInterval__t();

        private static SDL_GL_GetSwapInterval__t s_SDL_GL_GetSwapInterval__t = __LoadFunction<SDL_GL_GetSwapInterval__t>("SDL_GL_GetSwapInterval");

        public static int SDL_GL_GetSwapInterval() => s_SDL_GL_GetSwapInterval__t();

        private delegate void SDL_GL_SwapWindow_IntPtr_t(IntPtr window);

        private static SDL_GL_SwapWindow_IntPtr_t s_SDL_GL_SwapWindow_IntPtr_t = __LoadFunction<SDL_GL_SwapWindow_IntPtr_t>("SDL_GL_SwapWindow");

        public static void SDL_GL_SwapWindow(IntPtr window) => s_SDL_GL_SwapWindow_IntPtr_t(window);

        private delegate void SDL_GL_DeleteContext_SDL_GLContext_t(SDL_GLContext context);

        private static SDL_GL_DeleteContext_SDL_GLContext_t s_SDL_GL_DeleteContext_SDL_GLContext_t = __LoadFunction<SDL_GL_DeleteContext_SDL_GLContext_t>("SDL_GL_DeleteContext");

        public static void SDL_GL_DeleteContext(SDL_GLContext context) => s_SDL_GL_DeleteContext_SDL_GLContext_t(context);

        /* X11 ONLY */
        private delegate int SDL_SetWindowInputFocus_IntPtr_t(IntPtr window);
        private static SDL_SetWindowInputFocus_IntPtr_t s_SDL_SetWindowInputFocus_IntPtr_t;
        public static int SDL_SetWindowInputFocus(IntPtr window) => s_SDL_SetWindowInputFocus_IntPtr_t(window);

        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }

#pragma warning disable
        static SDL_video()
        {
            try
            {
                s_SDL_SetWindowInputFocus_IntPtr_t = __LoadFunction<SDL_SetWindowInputFocus_IntPtr_t>("SDL_SetWindowInputFocus");
            }
            catch (Exception ex)
            {
                s_SDL_SetWindowInputFocus_IntPtr_t = p => { return 0; };
            }
        }
#pragma warning enable
    }
}


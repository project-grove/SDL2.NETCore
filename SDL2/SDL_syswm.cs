using System;
using SDL_bool = System.Int32;

namespace SDL2
{
    public static class SDL_syswm
    {
        public enum SDL_SYSWM_TYPE
        {
            SDL_SYSWM_UNKNOWN,
            SDL_SYSWM_WINDOWS,
            SDL_SYSWM_X11,
            SDL_SYSWM_DIRECTFB,
            SDL_SYSWM_COCOA,
            SDL_SYSWM_UIKIT,
            SDL_SYSWM_WAYLAND,
            SDL_SYSWM_MIR,
            SDL_SYSWM_WINRT,
            SDL_SYSWM_ANDROID,
            SDL_SYSWM_VIVANTE
        }

        private delegate SDL_bool SDL_GetWindowWMInfo_IntPtr_IntPtr_t(IntPtr window, IntPtr info);

        private static SDL_GetWindowWMInfo_IntPtr_IntPtr_t s_SDL_GetWindowWMInfo_IntPtr_IntPtr_t = __LoadFunction<SDL_GetWindowWMInfo_IntPtr_IntPtr_t>("SDL_GetWindowWMInfo");

        public static SDL_bool SDL_GetWindowWMInfo(IntPtr window, IntPtr info) => s_SDL_GetWindowWMInfo_IntPtr_IntPtr_t(window, info);

        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}
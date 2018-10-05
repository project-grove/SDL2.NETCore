using System;
using NativeLibraryLoader;

namespace SDL2
{
    public static class SDL
    {
        public const int SDL_INIT_TIMER = 0x00000001;
        public const int SDL_INIT_AUDIO = 0x00000010;
        public const int SDL_INIT_VIDEO = 0x00000020;  /**< SDL_INIT_VIDEO implies SDL_INIT_EVENTS */
        public const int SDL_INIT_JOYSTICK = 0x00000200;  /**< SDL_INIT_JOYSTICK implies SDL_INIT_EVENTS */
        public const int SDL_INIT_HAPTIC = 0x00001000;
        public const int SDL_INIT_GAMECONTROLLER = 0x00002000;  /**< SDL_INIT_GAMECONTROLLER implies SDL_INIT_JOYSTICK */
        public const int SDL_INIT_EVENTS = 0x00004000;
        public const int SDL_INIT_NOPARACHUTE = 0x00100000;  /**< Don't catch fatal signals */
        public const int SDL_INIT_EVERYTHING = (
                        SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO | SDL_INIT_EVENTS |
                        SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC | SDL_INIT_GAMECONTROLLER
                    );

        private delegate int SDL_Init_UInt32_t(UInt32 flags);

        private static SDL_Init_UInt32_t s_SDL_Init_UInt32_t = __LoadFunction<SDL_Init_UInt32_t>("SDL_Init");

        public static int SDL_Init(UInt32 flags) => s_SDL_Init_UInt32_t(flags);

        private delegate int SDL_InitSubSystem_UInt32_t(UInt32 flags);

        private static SDL_InitSubSystem_UInt32_t s_SDL_InitSubSystem_UInt32_t = __LoadFunction<SDL_InitSubSystem_UInt32_t>("SDL_InitSubSystem");

        public static int SDL_InitSubSystem(UInt32 flags) => s_SDL_InitSubSystem_UInt32_t(flags);

        private delegate void SDL_QuitSubSystem_UInt32_t(UInt32 flags);

        private static SDL_QuitSubSystem_UInt32_t s_SDL_QuitSubSystem_UInt32_t = __LoadFunction<SDL_QuitSubSystem_UInt32_t>("SDL_QuitSubSystem");

        public static void SDL_QuitSubSystem(UInt32 flags) => s_SDL_QuitSubSystem_UInt32_t(flags);

        private delegate UInt32 SDL_WasInit_UInt32_t(UInt32 flags);

        private static SDL_WasInit_UInt32_t s_SDL_WasInit_UInt32_t = __LoadFunction<SDL_WasInit_UInt32_t>("SDL_WasInit");

        public static UInt32 SDL_WasInit(UInt32 flags) => s_SDL_WasInit_UInt32_t(flags);

        private delegate void SDL_Quit__t();

        private static SDL_Quit__t s_SDL_Quit__t = __LoadFunction<SDL_Quit__t>("SDL_Quit");

        public static void SDL_Quit() => s_SDL_Quit__t();
        private static T __LoadFunction<T>(string name)
        {
            return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name);
        }
    }
}

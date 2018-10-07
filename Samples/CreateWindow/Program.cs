using System;
using SDL2;
using static System.Console;
using static SDL2.SDL;
using static SDL2.SDL_render;
using static SDL2.SDL_video;
using static SDL2.SDL_error;
using static SDL2.SDL_version;
using System.Runtime.InteropServices;

namespace CreateWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = 640;
            var height = 480;

            if (SDL_Init(SDL_INIT_VIDEO) != 0)
                throw new Exception($"Could not init SDL: {SDL_GetError()}");
            var result = SDL_CreateWindowAndRenderer(width, height,
                (uint)(SDL_WindowFlags.SDL_WINDOW_SHOWN |
                    SDL_WindowFlags.SDL_WINDOW_OPENGL),
                out IntPtr window,
                out IntPtr renderer);

            if (result != 0)
                throw new Exception($"Could not initialize window: {SDL_GetError()}");

            SDL_GetVersion(out SDL_Version version);
            WriteLine($"Using SDL {version.major}.{version.minor}.{version.patch}");

            var displayCount = SDL_GetNumVideoDisplays();
            for (int display = 0; display < displayCount; display++)
            {
                var numModes = SDL_GetNumDisplayModes(display);
                WriteLine($"Display {display} - {numModes} modes:");
                for (int mode = 0; mode < numModes; mode++)
                {
                    var modeInfo = new SDL_DisplayMode();
                    if (SDL_GetDisplayMode(display, mode, ref modeInfo) != 0)
                        throw new Exception($"Could not get display mode info: {SDL_GetError()}");
                    WriteLine("\t" + modeInfo);
                }
            }
            SDL_Quit();
        }
    }
}

using System;
using SDL2;
using static SDL2.SDL;
using static SDL2.SDL_render;
using static SDL2.SDL_video;
using static SDL2.SDL_error;
using System.Runtime.InteropServices;

namespace CreateWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = 640;
            var height = 480;

            if (SDL_Init(SDL_INIT_VIDEO) == 0)
                throw new Exception($"Could not init SDL: {SDL_GetError()}");
            var result = SDL_CreateWindowAndRenderer(width, height,
                (uint)(SDL_WindowFlags.SDL_WINDOW_SHOWN |
                    SDL_WindowFlags.SDL_WINDOW_OPENGL) |
                    SDL_WINDOWPOS_UNDEFINED_MASK,
                out IntPtr window,
                out IntPtr renderer);

            if (result == 0)
                throw new Exception($"Could not initialize window: {SDL_GetError()}");
            SDL_Quit();
        }
    }
}

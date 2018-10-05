using System;
using SDL2;
using static SDL2.SDL;
using static SDL2.SDL_render;
using static SDL2.SDL_video;

namespace CreateWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 640;
            int height = 480;
            SDL_CreateWindowAndRenderer(width, height,
                (uint)(SDL_WindowFlags.SDL_WINDOW_SHOWN) | SDL_WINDOWPOS_UNDEFINED_MASK,
                out IntPtr window,
                out IntPtr renderer);
            SDL_Quit();
        }
    }
}

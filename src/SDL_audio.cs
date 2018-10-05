using System;
using System.Runtime.InteropServices;

using SDL2;
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
using static SDL2.SDL_video;

using SDL_AudioFormat = System.UInt32;
using SDL_AudioCallback = System.IntPtr;
using SDL_AudioFilter = System.IntPtr;
using SDL_AudioDeviceID = System.UInt32;
using SDL_RWops = System.IntPtr;

namespace SDL2
{
    public static class SDL_audio
    {
        public const int SDL_AUDIO_MASK_BITSIZE = 0xFF;
        public const int SDL_AUDIO_MASK_DATATYPE = 1 << 8;
        public const int SDL_AUDIO_MASK_ENDIAN = 1 << 12;
        public const int SDL_AUDIO_MASK_SIGNED = 1 << 15;
        public const int AUDIO_U8 = 0x0008;
        public const int AUDIO_S8 = 0x8008;
        public const int AUDIO_U16LSB = 0x0010;
        public const int AUDIO_S16LSB = 0x8010;
        public const int AUDIO_U16MSB = 0x1010;
        public const int AUDIO_S16MSB = 0x9010;
        public const int AUDIO_U16 = AUDIO_U16LSB;
        public const int AUDIO_S16 = AUDIO_S16LSB;
        public const int AUDIO_S32LSB = 0x8020;
        public const int AUDIO_S32MSB = 0x9020;
        public const int AUDIO_S32 = AUDIO_S32LSB;
        public const int AUDIO_F32LSB = 0x8120;
        public const int AUDIO_F32MSB = 0x9120;
        public const int AUDIO_F32 = AUDIO_F32LSB;
        public const int AUDIO_U16SYS = AUDIO_U16LSB;
        public const int AUDIO_S16SYS = AUDIO_S16LSB;
        public const int AUDIO_S32SYS = AUDIO_S32LSB;
        public const int AUDIO_F32SYS = AUDIO_F32LSB;
        public const int SDL_AUDIO_ALLOW_FREQUENCY_CHANGE = 0x00000001;
        public const int SDL_AUDIO_ALLOW_FORMAT_CHANGE = 0x00000002;
        public const int SDL_AUDIO_ALLOW_CHANNELS_CHANGE = 0x00000004;
        public const int SDL_AUDIO_ALLOW_ANY_CHANGE = SDL_AUDIO_ALLOW_FREQUENCY_CHANGE | SDL_AUDIO_ALLOW_FORMAT_CHANGE | SDL_AUDIO_ALLOW_CHANNELS_CHANGE;
        public const int SDL_MIX_MAXVOLUME = 128;

        public enum SDL_AudioStatus
        {

            SDL_AUDIO_STOPPED = 0,
            SDL_AUDIO_PLAYING,
            SDL_AUDIO_PAUSED

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_AudioSpec
        {

            public int freq;                   /**< DSP frequency -- samples per second */
            public SDL_AudioFormat format;     /**< Audio data format */
            public byte channels;             /**< Number of channels: 1 mono, 2 stereo */
            public byte silence;              /**< Audio buffer silence value (calculated) */
            public UInt16 samples;             /**< Audio buffer size in samples (power of 2) */
            public UInt16 padding;             /**< Necessary for some compile environments */
            public UInt32 size;                /**< Audio buffer size in bytes (calculated) */
            public SDL_AudioCallback callback;
            public IntPtr userdata;

        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SDL_AudioCVT
        {

            public int needed;                 /**< Set to 1 if conversion possible */
            public SDL_AudioFormat src_format; /**< Source audio format */
            public SDL_AudioFormat dst_format; /**< Target audio format */
            public double rate_incr;           /**< Rate conversion increment */
            public IntPtr buf;                 /**< Buffer to hold entire audio data */
            public int len;                    /**< Length of original audio buffer */
            public int len_cvt;                /**< Length of converted audio buffer */
            public int len_mult;               /**< buffer must be len*len_mult big */
            public double len_ratio;           /**< Given len, final size is len*len_ratio */
            /* UNSUPPORTED due to C# limitations */
            // public unsafe fixed SDL_AudioFilter filters[10];        /**< Filter list */
            // public int filter_index;           /**< Current audio conversion function */

        }

        [DllImport("libSDL2.so")]
        public static extern int SDL_GetNumAudioDrivers();
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetAudioDriver(int index);
        [DllImport("libSDL2.so")]
        public static extern int SDL_AudioInit(IntPtr driver_name);
        [DllImport("libSDL2.so")]
        public static extern void SDL_AudioQuit();
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetCurrentAudioDriver();
        [DllImport("libSDL2.so")]
        public static extern int SDL_OpenAudio(ref SDL_AudioSpec desired, ref SDL_AudioSpec obtained);
        [DllImport("libSDL2.so")]
        public static extern int SDL_GetNumAudioDevices(int iscapture);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_GetAudioDeviceName(int index, int iscapture);
        [DllImport("libSDL2.so")]
        public static extern SDL_AudioDeviceID SDL_OpenAudioDevice(IntPtr device, int iscapture, ref 
                                                                      SDL_AudioSpec desired, ref SDL_AudioSpec obtained, int
                                                                      allowed_changes);
        [DllImport("libSDL2.so")]
        public static extern SDL_AudioStatus SDL_GetAudioStatus();
        [DllImport("libSDL2.so")]
        public static extern SDL_AudioStatus SDL_GetAudioDeviceStatus(SDL_AudioDeviceID dev);
        [DllImport("libSDL2.so")]
        public static extern void SDL_PauseAudio(int pause_on);
        [DllImport("libSDL2.so")]
        public static extern void SDL_PauseAudioDevice(SDL_AudioDeviceID dev, int pause_on);
        [DllImport("libSDL2.so")]
        public static extern IntPtr SDL_LoadWAV_RW(ref SDL_RWops src, int freesrc, ref SDL_AudioSpec spec, IntPtr audio_buf, ref uint audio_len);
        [DllImport("libSDL2.so")]
        public static extern void SDL_FreeWAV(ref byte audio_buf);
        [DllImport("libSDL2.so")]
        public static extern int SDL_BuildAudioCVT(ref SDL_AudioCVT cvt, SDL_AudioFormat src_format, byte src_channels, int src_rate, SDL_AudioFormat dst_format, byte dst_channels, int dst_rate);
        [DllImport("libSDL2.so")]
        public static extern int SDL_ConvertAudio(ref SDL_AudioCVT cvt);
        [DllImport("libSDL2.so")]
        public static extern void SDL_MixAudio(ref byte dst, ref byte src, UInt32 len, int volume);
        [DllImport("libSDL2.so")]
        public static extern void SDL_MixAudioFormat(ref byte dst, ref byte src, SDL_AudioFormat format, UInt32 len, int volume);
        [DllImport("libSDL2.so")]
        public static extern void SDL_LockAudio();
        [DllImport("libSDL2.so")]
        public static extern void SDL_LockAudioDevice(SDL_AudioDeviceID dev);
        [DllImport("libSDL2.so")]
        public static extern void SDL_UnlockAudio();
        [DllImport("libSDL2.so")]
        public static extern void SDL_UnlockAudioDevice(SDL_AudioDeviceID dev);
        [DllImport("libSDL2.so")]
        public static extern void SDL_CloseAudio();
        [DllImport("libSDL2.so")]
        public static extern void SDL_CloseAudioDevice(SDL_AudioDeviceID dev);

    }
}

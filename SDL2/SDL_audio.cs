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
using NativeLibraryLoader;

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
            // public unsafe fixed IntPtr filters[10];        /**< Filter list */
            public IntPtr filter_1;
            public IntPtr filter_2;
            public IntPtr filter_3;
            public IntPtr filter_4;
            public IntPtr filter_5;
            public IntPtr filter_6;
            public IntPtr filter_7;
            public IntPtr filter_8;
            public IntPtr filter_9;
            public IntPtr filter_10;
            public int filter_index;           /**< Current audio conversion function */

        }

        private delegate int SDL_GetNumAudioDrivers__t();

        private static SDL_GetNumAudioDrivers__t s_SDL_GetNumAudioDrivers__t = __LoadFunction<SDL_GetNumAudioDrivers__t>("SDL_GetNumAudioDrivers");

        public static int SDL_GetNumAudioDrivers() => s_SDL_GetNumAudioDrivers__t();

        private delegate IntPtr SDL_GetAudioDriver_int_t(int index);

        private static SDL_GetAudioDriver_int_t s_SDL_GetAudioDriver_int_t = __LoadFunction<SDL_GetAudioDriver_int_t>("SDL_GetAudioDriver");

        private static IntPtr _SDL_GetAudioDriver(int index) => s_SDL_GetAudioDriver_int_t(index);
        public static string SDL_GetAudioDriver(int index) =>
            Marshal.PtrToStringAnsi(_SDL_GetAudioDriver(index));

        private delegate int SDL_AudioInit_IntPtr_t(IntPtr driver_name);

        private static SDL_AudioInit_IntPtr_t s_SDL_AudioInit_IntPtr_t = __LoadFunction<SDL_AudioInit_IntPtr_t>("SDL_AudioInit");

        public static int SDL_AudioInit(IntPtr driver_name) => s_SDL_AudioInit_IntPtr_t(driver_name);

        private delegate void SDL_AudioQuit__t();

        private static SDL_AudioQuit__t s_SDL_AudioQuit__t = __LoadFunction<SDL_AudioQuit__t>("SDL_AudioQuit");

        public static void SDL_AudioQuit() => s_SDL_AudioQuit__t();

        private delegate IntPtr SDL_GetCurrentAudioDriver__t();

        private static SDL_GetCurrentAudioDriver__t s_SDL_GetCurrentAudioDriver__t = __LoadFunction<SDL_GetCurrentAudioDriver__t>("SDL_GetCurrentAudioDriver");

        private static IntPtr _SDL_GetCurrentAudioDriver() => s_SDL_GetCurrentAudioDriver__t();
        public static string SDL_GetCurrentAudioDriver() => Marshal.PtrToStringAnsi(_SDL_GetCurrentAudioDriver());

        private delegate int SDL_OpenAudio_SDL_AudioSpec_SDL_AudioSpec_t(ref SDL_AudioSpec desired, ref SDL_AudioSpec obtained);

        private static SDL_OpenAudio_SDL_AudioSpec_SDL_AudioSpec_t s_SDL_OpenAudio_SDL_AudioSpec_SDL_AudioSpec_t = __LoadFunction<SDL_OpenAudio_SDL_AudioSpec_SDL_AudioSpec_t>("SDL_OpenAudio");

        public static int SDL_OpenAudio(ref SDL_AudioSpec desired, ref SDL_AudioSpec obtained) => s_SDL_OpenAudio_SDL_AudioSpec_SDL_AudioSpec_t(ref desired, ref obtained);

        private delegate int SDL_GetNumAudioDevices_int_t(int iscapture);

        private static SDL_GetNumAudioDevices_int_t s_SDL_GetNumAudioDevices_int_t = __LoadFunction<SDL_GetNumAudioDevices_int_t>("SDL_GetNumAudioDevices");

        public static int SDL_GetNumAudioDevices(int iscapture) => s_SDL_GetNumAudioDevices_int_t(iscapture);

        private delegate IntPtr SDL_GetAudioDeviceName_int_int_t(int index, int iscapture);

        private static SDL_GetAudioDeviceName_int_int_t s_SDL_GetAudioDeviceName_int_int_t = __LoadFunction<SDL_GetAudioDeviceName_int_int_t>("SDL_GetAudioDeviceName");

        public static IntPtr SDL_GetAudioDeviceName(int index, int iscapture) => s_SDL_GetAudioDeviceName_int_int_t(index, iscapture);

        private delegate SDL_AudioDeviceID SDL_OpenAudioDevice_IntPtr_int_SDL_AudioSpec_SDL_AudioSpec_int_t(IntPtr device, int iscapture, ref
SDL_AudioSpec desired, ref SDL_AudioSpec obtained, int
allowed_changes);

        private static SDL_OpenAudioDevice_IntPtr_int_SDL_AudioSpec_SDL_AudioSpec_int_t s_SDL_OpenAudioDevice_IntPtr_int_SDL_AudioSpec_SDL_AudioSpec_int_t = __LoadFunction<SDL_OpenAudioDevice_IntPtr_int_SDL_AudioSpec_SDL_AudioSpec_int_t>("SDL_OpenAudioDevice");

        public static SDL_AudioDeviceID SDL_OpenAudioDevice(IntPtr device, int iscapture, ref
SDL_AudioSpec desired, ref SDL_AudioSpec obtained, int
allowed_changes) => s_SDL_OpenAudioDevice_IntPtr_int_SDL_AudioSpec_SDL_AudioSpec_int_t(device, iscapture, ref desired, ref obtained, allowed_changes);

        private delegate SDL_AudioStatus SDL_GetAudioStatus__t();

        private static SDL_GetAudioStatus__t s_SDL_GetAudioStatus__t = __LoadFunction<SDL_GetAudioStatus__t>("SDL_GetAudioStatus");

        public static SDL_AudioStatus SDL_GetAudioStatus() => s_SDL_GetAudioStatus__t();

        private delegate SDL_AudioStatus SDL_GetAudioDeviceStatus_SDL_AudioDeviceID_t(SDL_AudioDeviceID dev);

        private static SDL_GetAudioDeviceStatus_SDL_AudioDeviceID_t s_SDL_GetAudioDeviceStatus_SDL_AudioDeviceID_t = __LoadFunction<SDL_GetAudioDeviceStatus_SDL_AudioDeviceID_t>("SDL_GetAudioDeviceStatus");

        public static SDL_AudioStatus SDL_GetAudioDeviceStatus(SDL_AudioDeviceID dev) => s_SDL_GetAudioDeviceStatus_SDL_AudioDeviceID_t(dev);

        private delegate void SDL_PauseAudio_int_t(int pause_on);

        private static SDL_PauseAudio_int_t s_SDL_PauseAudio_int_t = __LoadFunction<SDL_PauseAudio_int_t>("SDL_PauseAudio");

        public static void SDL_PauseAudio(int pause_on) => s_SDL_PauseAudio_int_t(pause_on);

        private delegate void SDL_PauseAudioDevice_SDL_AudioDeviceID_int_t(SDL_AudioDeviceID dev, int pause_on);

        private static SDL_PauseAudioDevice_SDL_AudioDeviceID_int_t s_SDL_PauseAudioDevice_SDL_AudioDeviceID_int_t = __LoadFunction<SDL_PauseAudioDevice_SDL_AudioDeviceID_int_t>("SDL_PauseAudioDevice");

        public static void SDL_PauseAudioDevice(SDL_AudioDeviceID dev, int pause_on) => s_SDL_PauseAudioDevice_SDL_AudioDeviceID_int_t(dev, pause_on);

        private delegate IntPtr SDL_LoadWAV_RW_SDL_RWops_int_SDL_AudioSpec_IntPtr_uint_t(IntPtr src, int freesrc, ref SDL_AudioSpec spec, IntPtr audio_buf, ref uint audio_len);

        private static SDL_LoadWAV_RW_SDL_RWops_int_SDL_AudioSpec_IntPtr_uint_t s_SDL_LoadWAV_RW_SDL_RWops_int_SDL_AudioSpec_IntPtr_uint_t = __LoadFunction<SDL_LoadWAV_RW_SDL_RWops_int_SDL_AudioSpec_IntPtr_uint_t>("SDL_LoadWAV_RW");

        public static IntPtr SDL_LoadWAV_RW(IntPtr src, int freesrc, ref SDL_AudioSpec spec, IntPtr audio_buf, ref uint audio_len) => s_SDL_LoadWAV_RW_SDL_RWops_int_SDL_AudioSpec_IntPtr_uint_t(src, freesrc, ref spec, audio_buf, ref audio_len);

        private delegate void SDL_FreeWAV_byte_t(ref byte audio_buf);

        private static SDL_FreeWAV_byte_t s_SDL_FreeWAV_byte_t = __LoadFunction<SDL_FreeWAV_byte_t>("SDL_FreeWAV");

        public static void SDL_FreeWAV(ref byte audio_buf) => s_SDL_FreeWAV_byte_t(ref audio_buf);

        private delegate int SDL_BuildAudioCVT_SDL_AudioCVT_SDL_AudioFormat_byte_int_SDL_AudioFormat_byte_int_t(ref SDL_AudioCVT cvt, SDL_AudioFormat src_format, byte src_channels, int src_rate, SDL_AudioFormat dst_format, byte dst_channels, int dst_rate);

        private static SDL_BuildAudioCVT_SDL_AudioCVT_SDL_AudioFormat_byte_int_SDL_AudioFormat_byte_int_t s_SDL_BuildAudioCVT_SDL_AudioCVT_SDL_AudioFormat_byte_int_SDL_AudioFormat_byte_int_t = __LoadFunction<SDL_BuildAudioCVT_SDL_AudioCVT_SDL_AudioFormat_byte_int_SDL_AudioFormat_byte_int_t>("SDL_BuildAudioCVT");

        public static int SDL_BuildAudioCVT(ref SDL_AudioCVT cvt, SDL_AudioFormat src_format, byte src_channels, int src_rate, SDL_AudioFormat dst_format, byte dst_channels, int dst_rate) => s_SDL_BuildAudioCVT_SDL_AudioCVT_SDL_AudioFormat_byte_int_SDL_AudioFormat_byte_int_t(ref cvt, src_format, src_channels, src_rate, dst_format, dst_channels, dst_rate);

        private delegate int SDL_ConvertAudio_SDL_AudioCVT_t(ref SDL_AudioCVT cvt);

        private static SDL_ConvertAudio_SDL_AudioCVT_t s_SDL_ConvertAudio_SDL_AudioCVT_t = __LoadFunction<SDL_ConvertAudio_SDL_AudioCVT_t>("SDL_ConvertAudio");

        public static int SDL_ConvertAudio(ref SDL_AudioCVT cvt) => s_SDL_ConvertAudio_SDL_AudioCVT_t(ref cvt);

        private delegate void SDL_MixAudio_byte_byte_UInt32_int_t(ref byte dst, ref byte src, UInt32 len, int volume);

        private static SDL_MixAudio_byte_byte_UInt32_int_t s_SDL_MixAudio_byte_byte_UInt32_int_t = __LoadFunction<SDL_MixAudio_byte_byte_UInt32_int_t>("SDL_MixAudio");

        public static void SDL_MixAudio(ref byte dst, ref byte src, UInt32 len, int volume) => s_SDL_MixAudio_byte_byte_UInt32_int_t(ref dst, ref src, len, volume);

        private delegate void SDL_MixAudioFormat_byte_byte_SDL_AudioFormat_UInt32_int_t(ref byte dst, ref byte src, SDL_AudioFormat format, UInt32 len, int volume);

        private static SDL_MixAudioFormat_byte_byte_SDL_AudioFormat_UInt32_int_t s_SDL_MixAudioFormat_byte_byte_SDL_AudioFormat_UInt32_int_t = __LoadFunction<SDL_MixAudioFormat_byte_byte_SDL_AudioFormat_UInt32_int_t>("SDL_MixAudioFormat");

        public static void SDL_MixAudioFormat(ref byte dst, ref byte src, SDL_AudioFormat format, UInt32 len, int volume) => s_SDL_MixAudioFormat_byte_byte_SDL_AudioFormat_UInt32_int_t(ref dst, ref src, format, len, volume);

        private delegate void SDL_LockAudio__t();

        private static SDL_LockAudio__t s_SDL_LockAudio__t = __LoadFunction<SDL_LockAudio__t>("SDL_LockAudio");

        public static void SDL_LockAudio() => s_SDL_LockAudio__t();

        private delegate void SDL_LockAudioDevice_SDL_AudioDeviceID_t(SDL_AudioDeviceID dev);

        private static SDL_LockAudioDevice_SDL_AudioDeviceID_t s_SDL_LockAudioDevice_SDL_AudioDeviceID_t = __LoadFunction<SDL_LockAudioDevice_SDL_AudioDeviceID_t>("SDL_LockAudioDevice");

        public static void SDL_LockAudioDevice(SDL_AudioDeviceID dev) => s_SDL_LockAudioDevice_SDL_AudioDeviceID_t(dev);

        private delegate void SDL_UnlockAudio__t();

        private static SDL_UnlockAudio__t s_SDL_UnlockAudio__t = __LoadFunction<SDL_UnlockAudio__t>("SDL_UnlockAudio");

        public static void SDL_UnlockAudio() => s_SDL_UnlockAudio__t();

        private delegate void SDL_UnlockAudioDevice_SDL_AudioDeviceID_t(SDL_AudioDeviceID dev);

        private static SDL_UnlockAudioDevice_SDL_AudioDeviceID_t s_SDL_UnlockAudioDevice_SDL_AudioDeviceID_t = __LoadFunction<SDL_UnlockAudioDevice_SDL_AudioDeviceID_t>("SDL_UnlockAudioDevice");

        public static void SDL_UnlockAudioDevice(SDL_AudioDeviceID dev) => s_SDL_UnlockAudioDevice_SDL_AudioDeviceID_t(dev);

        private delegate void SDL_CloseAudio__t();

        private static SDL_CloseAudio__t s_SDL_CloseAudio__t = __LoadFunction<SDL_CloseAudio__t>("SDL_CloseAudio");

        public static void SDL_CloseAudio() => s_SDL_CloseAudio__t();

        private delegate void SDL_CloseAudioDevice_SDL_AudioDeviceID_t(SDL_AudioDeviceID dev);

        private static SDL_CloseAudioDevice_SDL_AudioDeviceID_t s_SDL_CloseAudioDevice_SDL_AudioDeviceID_t = __LoadFunction<SDL_CloseAudioDevice_SDL_AudioDeviceID_t>("SDL_CloseAudioDevice");

        public static void SDL_CloseAudioDevice(SDL_AudioDeviceID dev) => s_SDL_CloseAudioDevice_SDL_AudioDeviceID_t(dev);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


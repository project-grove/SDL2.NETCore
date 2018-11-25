using System;
using System.Runtime.InteropServices;
using static SDL2.SDL_audio;

using SDL_RWops = System.IntPtr;
using Mix_EffectFunc_t = System.IntPtr;
using Mix_EffectDone_t = System.IntPtr;
using NativeLibraryLoader;
using SDL2.Internal;

namespace SDL2
{
    public static class SDL_mixer
    {
        public static bool IsSDLMixerLoaded => Loader_SDL2.SdlMixer != null;
        public const int MIX_CHANNELS = 8;
        public const int MIX_DEFAULT_FREQUENCY = 22050;
        public const int MIX_DEFAULT_FORMAT = AUDIO_S16LSB;
        public const int MIX_DEFAULT_CHANNELS = 2;
        public const int MIX_MAX_VOLUME = 128;
        public const int MIX_CHANNEL_POST = -2;
        public const string MIX_EFFECTSMAXSPEED = "MIX_EFFECTSMAXSPEED";

        public enum MIX_InitFlags
        {

            MIX_INIT_FLAC = 0x00000001,
            MIX_INIT_MOD = 0x00000002,
            MIX_INIT_MODPLUG = 0x00000004,
            MIX_INIT_MP3 = 0x00000008,
            MIX_INIT_OGG = 0x00000010,
            MIX_INIT_FLUIDSYNTH = 0x00000020

        }
        public enum Mix_Fading
        {

            MIX_NO_FADING,
            MIX_FADING_OUT,
            MIX_FADING_IN

        }
        public enum Mix_MusicType
        {

            MUS_NONE,
            MUS_CMD,
            MUS_WAV,
            MUS_MOD,
            MUS_MID,
            MUS_OGG,
            MUS_MP3,
            MUS_MP3_MAD,
            MUS_FLAC,
            MUS_MODPLUG

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Mix_Chunk
        {

            int allocated;
            IntPtr abuf;
            UInt32 alen;
            byte volume;       /* Per-sample volume, 0-128 */

        }

        private delegate IntPtr Mix_Linked_Version__t();

        private static Mix_Linked_Version__t s_Mix_Linked_Version__t = __LoadFunction<Mix_Linked_Version__t>("Mix_Linked_Version");

        public static IntPtr Mix_Linked_Version() => s_Mix_Linked_Version__t();

        private delegate int Mix_Init_int_t(int flags);

        private static Mix_Init_int_t s_Mix_Init_int_t = __LoadFunction<Mix_Init_int_t>("Mix_Init");

        public static int Mix_Init(int flags) => s_Mix_Init_int_t(flags);

        private delegate void Mix_Quit__t();

        private static Mix_Quit__t s_Mix_Quit__t = __LoadFunction<Mix_Quit__t>("Mix_Quit");

        public static void Mix_Quit() => s_Mix_Quit__t();

        private delegate int Mix_OpenAudio_int_UInt16_int_int_t(int frequency, UInt16 format, int channels, int chunksize);

        private static Mix_OpenAudio_int_UInt16_int_int_t s_Mix_OpenAudio_int_UInt16_int_int_t = __LoadFunction<Mix_OpenAudio_int_UInt16_int_int_t>("Mix_OpenAudio");

        public static int Mix_OpenAudio(int frequency, UInt16 format, int channels, int chunksize) => s_Mix_OpenAudio_int_UInt16_int_int_t(frequency, format, channels, chunksize);

        private delegate int Mix_AllocateChannels_int_t(int numchans);

        private static Mix_AllocateChannels_int_t s_Mix_AllocateChannels_int_t = __LoadFunction<Mix_AllocateChannels_int_t>("Mix_AllocateChannels");

        public static int Mix_AllocateChannels(int numchans) => s_Mix_AllocateChannels_int_t(numchans);

        private delegate int Mix_QuerySpec_int_ushort_int_t(ref int frequency, ref ushort format, ref int channels);

        private static Mix_QuerySpec_int_ushort_int_t s_Mix_QuerySpec_int_ushort_int_t = __LoadFunction<Mix_QuerySpec_int_ushort_int_t>("Mix_QuerySpec");

        public static int Mix_QuerySpec(ref int frequency, ref ushort format, ref int channels) => s_Mix_QuerySpec_int_ushort_int_t(ref frequency, ref format, ref channels);

        private delegate IntPtr Mix_LoadWAV_RW_SDL_RWops_int_t(IntPtr src, int freesrc);

        private static Mix_LoadWAV_RW_SDL_RWops_int_t s_Mix_LoadWAV_RW_SDL_RWops_int_t = __LoadFunction<Mix_LoadWAV_RW_SDL_RWops_int_t>("Mix_LoadWAV_RW");

        public static IntPtr Mix_LoadWAV_RW(IntPtr src, int freesrc) => s_Mix_LoadWAV_RW_SDL_RWops_int_t(src, freesrc);

        private delegate IntPtr Mix_LoadMUS_IntPtr_t(IntPtr file);

        private static Mix_LoadMUS_IntPtr_t s_Mix_LoadMUS_IntPtr_t = __LoadFunction<Mix_LoadMUS_IntPtr_t>("Mix_LoadMUS");

        public static IntPtr Mix_LoadMUS(IntPtr file) => s_Mix_LoadMUS_IntPtr_t(file);

        private delegate IntPtr Mix_LoadMUS_RW_SDL_RWops_int_t(IntPtr src, int freesrc);

        private static Mix_LoadMUS_RW_SDL_RWops_int_t s_Mix_LoadMUS_RW_SDL_RWops_int_t = __LoadFunction<Mix_LoadMUS_RW_SDL_RWops_int_t>("Mix_LoadMUS_RW");

        public static IntPtr Mix_LoadMUS_RW(IntPtr src, int freesrc) => s_Mix_LoadMUS_RW_SDL_RWops_int_t(src, freesrc);

        private delegate IntPtr Mix_LoadMUSType_RW_SDL_RWops_Mix_MusicType_int_t(IntPtr src, Mix_MusicType type, int freesrc);

        private static Mix_LoadMUSType_RW_SDL_RWops_Mix_MusicType_int_t s_Mix_LoadMUSType_RW_SDL_RWops_Mix_MusicType_int_t = __LoadFunction<Mix_LoadMUSType_RW_SDL_RWops_Mix_MusicType_int_t>("Mix_LoadMUSType_RW");

        public static IntPtr Mix_LoadMUSType_RW(IntPtr src, Mix_MusicType type, int freesrc) => s_Mix_LoadMUSType_RW_SDL_RWops_Mix_MusicType_int_t(src, type, freesrc);

        private delegate IntPtr Mix_QuickLoad_WAV_byte_t(IntPtr mem);

        private static Mix_QuickLoad_WAV_byte_t s_Mix_QuickLoad_WAV_byte_t = __LoadFunction<Mix_QuickLoad_WAV_byte_t>("Mix_QuickLoad_WAV");

        public static IntPtr Mix_QuickLoad_WAV(IntPtr mem) => s_Mix_QuickLoad_WAV_byte_t(mem);

        private delegate IntPtr Mix_QuickLoad_RAW_byte_UInt32_t(IntPtr mem, UInt32 len);

        private static Mix_QuickLoad_RAW_byte_UInt32_t s_Mix_QuickLoad_RAW_byte_UInt32_t = __LoadFunction<Mix_QuickLoad_RAW_byte_UInt32_t>("Mix_QuickLoad_RAW");

        public static IntPtr Mix_QuickLoad_RAW(IntPtr mem, UInt32 len) => s_Mix_QuickLoad_RAW_byte_UInt32_t(mem, len);

        private delegate void Mix_FreeChunk_Mix_Chunk_t(IntPtr chunk);

        private static Mix_FreeChunk_Mix_Chunk_t s_Mix_FreeChunk_Mix_Chunk_t = __LoadFunction<Mix_FreeChunk_Mix_Chunk_t>("Mix_FreeChunk");

        public static void Mix_FreeChunk(IntPtr chunk) => s_Mix_FreeChunk_Mix_Chunk_t(chunk);

        private delegate void Mix_FreeMusic_IntPtr_t(IntPtr music);

        private static Mix_FreeMusic_IntPtr_t s_Mix_FreeMusic_IntPtr_t = __LoadFunction<Mix_FreeMusic_IntPtr_t>("Mix_FreeMusic");

        public static void Mix_FreeMusic(IntPtr music) => s_Mix_FreeMusic_IntPtr_t(music);

        private delegate int Mix_GetNumChunkDecoders__t();

        private static Mix_GetNumChunkDecoders__t s_Mix_GetNumChunkDecoders__t = __LoadFunction<Mix_GetNumChunkDecoders__t>("Mix_GetNumChunkDecoders");

        public static int Mix_GetNumChunkDecoders() => s_Mix_GetNumChunkDecoders__t();

        private delegate IntPtr Mix_GetChunkDecoder_int_t(int index);

        private static Mix_GetChunkDecoder_int_t s_Mix_GetChunkDecoder_int_t = __LoadFunction<Mix_GetChunkDecoder_int_t>("Mix_GetChunkDecoder");

        public static IntPtr Mix_GetChunkDecoder(int index) => s_Mix_GetChunkDecoder_int_t(index);

        private delegate int Mix_GetNumMusicDecoders__t();

        private static Mix_GetNumMusicDecoders__t s_Mix_GetNumMusicDecoders__t = __LoadFunction<Mix_GetNumMusicDecoders__t>("Mix_GetNumMusicDecoders");

        public static int Mix_GetNumMusicDecoders() => s_Mix_GetNumMusicDecoders__t();

        private delegate IntPtr Mix_GetMusicDecoder_int_t(int index);

        private static Mix_GetMusicDecoder_int_t s_Mix_GetMusicDecoder_int_t = __LoadFunction<Mix_GetMusicDecoder_int_t>("Mix_GetMusicDecoder");

        public static IntPtr Mix_GetMusicDecoder(int index) => s_Mix_GetMusicDecoder_int_t(index);

        private delegate Mix_MusicType Mix_GetMusicType_IntPtr_t(IntPtr music);

        private static Mix_GetMusicType_IntPtr_t s_Mix_GetMusicType_IntPtr_t = __LoadFunction<Mix_GetMusicType_IntPtr_t>("Mix_GetMusicType");

        public static Mix_MusicType Mix_GetMusicType(IntPtr music) => s_Mix_GetMusicType_IntPtr_t(music);

        private delegate IntPtr Mix_GetMusicHookData__t();

        private static Mix_GetMusicHookData__t s_Mix_GetMusicHookData__t = __LoadFunction<Mix_GetMusicHookData__t>("Mix_GetMusicHookData");

        public static IntPtr Mix_GetMusicHookData() => s_Mix_GetMusicHookData__t();

        private delegate int Mix_RegisterEffect_int_Mix_EffectFunc_t_Mix_EffectDone_t_IntPtr_t(int chan, Mix_EffectFunc_t f, Mix_EffectDone_t d, IntPtr arg);

        private static Mix_RegisterEffect_int_Mix_EffectFunc_t_Mix_EffectDone_t_IntPtr_t s_Mix_RegisterEffect_int_Mix_EffectFunc_t_Mix_EffectDone_t_IntPtr_t = __LoadFunction<Mix_RegisterEffect_int_Mix_EffectFunc_t_Mix_EffectDone_t_IntPtr_t>("Mix_RegisterEffect");

        public static int Mix_RegisterEffect(int chan, Mix_EffectFunc_t f, Mix_EffectDone_t d, IntPtr arg) => s_Mix_RegisterEffect_int_Mix_EffectFunc_t_Mix_EffectDone_t_IntPtr_t(chan, f, d, arg);

        private delegate int Mix_UnregisterEffect_int_Mix_EffectFunc_t_t(int channel, Mix_EffectFunc_t f);

        private static Mix_UnregisterEffect_int_Mix_EffectFunc_t_t s_Mix_UnregisterEffect_int_Mix_EffectFunc_t_t = __LoadFunction<Mix_UnregisterEffect_int_Mix_EffectFunc_t_t>("Mix_UnregisterEffect");

        public static int Mix_UnregisterEffect(int channel, Mix_EffectFunc_t f) => s_Mix_UnregisterEffect_int_Mix_EffectFunc_t_t(channel, f);

        private delegate int Mix_UnregisterAllEffects_int_t(int channel);

        private static Mix_UnregisterAllEffects_int_t s_Mix_UnregisterAllEffects_int_t = __LoadFunction<Mix_UnregisterAllEffects_int_t>("Mix_UnregisterAllEffects");

        public static int Mix_UnregisterAllEffects(int channel) => s_Mix_UnregisterAllEffects_int_t(channel);

        private delegate int Mix_SetPanning_int_byte_byte_t(int channel, byte left, byte right);

        private static Mix_SetPanning_int_byte_byte_t s_Mix_SetPanning_int_byte_byte_t = __LoadFunction<Mix_SetPanning_int_byte_byte_t>("Mix_SetPanning");

        public static int Mix_SetPanning(int channel, byte left, byte right) => s_Mix_SetPanning_int_byte_byte_t(channel, left, right);

        private delegate int Mix_SetPosition_int_Int16_byte_t(int channel, Int16 angle, byte distance);

        private static Mix_SetPosition_int_Int16_byte_t s_Mix_SetPosition_int_Int16_byte_t = __LoadFunction<Mix_SetPosition_int_Int16_byte_t>("Mix_SetPosition");

        public static int Mix_SetPosition(int channel, Int16 angle, byte distance) => s_Mix_SetPosition_int_Int16_byte_t(channel, angle, distance);

        private delegate int Mix_SetDistance_int_byte_t(int channel, byte distance);

        private static Mix_SetDistance_int_byte_t s_Mix_SetDistance_int_byte_t = __LoadFunction<Mix_SetDistance_int_byte_t>("Mix_SetDistance");

        public static int Mix_SetDistance(int channel, byte distance) => s_Mix_SetDistance_int_byte_t(channel, distance);

        private delegate int Mix_SetReverseStereo_int_int_t(int channel, int flip);

        private static Mix_SetReverseStereo_int_int_t s_Mix_SetReverseStereo_int_int_t = __LoadFunction<Mix_SetReverseStereo_int_int_t>("Mix_SetReverseStereo");

        public static int Mix_SetReverseStereo(int channel, int flip) => s_Mix_SetReverseStereo_int_int_t(channel, flip);

        private delegate int Mix_ReserveChannels_int_t(int num);

        private static Mix_ReserveChannels_int_t s_Mix_ReserveChannels_int_t = __LoadFunction<Mix_ReserveChannels_int_t>("Mix_ReserveChannels");

        public static int Mix_ReserveChannels(int num) => s_Mix_ReserveChannels_int_t(num);

        private delegate int Mix_GroupChannel_int_int_t(int which, int tag);

        private static Mix_GroupChannel_int_int_t s_Mix_GroupChannel_int_int_t = __LoadFunction<Mix_GroupChannel_int_int_t>("Mix_GroupChannel");

        public static int Mix_GroupChannel(int which, int tag) => s_Mix_GroupChannel_int_int_t(which, tag);

        private delegate int Mix_GroupChannels_int_int_int_t(int from, int to, int tag);

        private static Mix_GroupChannels_int_int_int_t s_Mix_GroupChannels_int_int_int_t = __LoadFunction<Mix_GroupChannels_int_int_int_t>("Mix_GroupChannels");

        public static int Mix_GroupChannels(int from, int to, int tag) => s_Mix_GroupChannels_int_int_int_t(from, to, tag);

        private delegate int Mix_GroupAvailable_int_t(int tag);

        private static Mix_GroupAvailable_int_t s_Mix_GroupAvailable_int_t = __LoadFunction<Mix_GroupAvailable_int_t>("Mix_GroupAvailable");

        public static int Mix_GroupAvailable(int tag) => s_Mix_GroupAvailable_int_t(tag);

        private delegate int Mix_GroupCount_int_t(int tag);

        private static Mix_GroupCount_int_t s_Mix_GroupCount_int_t = __LoadFunction<Mix_GroupCount_int_t>("Mix_GroupCount");

        public static int Mix_GroupCount(int tag) => s_Mix_GroupCount_int_t(tag);

        private delegate int Mix_GroupOldest_int_t(int tag);

        private static Mix_GroupOldest_int_t s_Mix_GroupOldest_int_t = __LoadFunction<Mix_GroupOldest_int_t>("Mix_GroupOldest");

        public static int Mix_GroupOldest(int tag) => s_Mix_GroupOldest_int_t(tag);

        private delegate int Mix_GroupNewer_int_t(int tag);

        private static Mix_GroupNewer_int_t s_Mix_GroupNewer_int_t = __LoadFunction<Mix_GroupNewer_int_t>("Mix_GroupNewer");

        public static int Mix_GroupNewer(int tag) => s_Mix_GroupNewer_int_t(tag);

        private delegate int Mix_PlayChannelTimed_int_Mix_Chunk_int_int_t(int channel, IntPtr chunk, int loops, int ticks);

        private static Mix_PlayChannelTimed_int_Mix_Chunk_int_int_t s_Mix_PlayChannelTimed_int_Mix_Chunk_int_int_t = __LoadFunction<Mix_PlayChannelTimed_int_Mix_Chunk_int_int_t>("Mix_PlayChannelTimed");

        public static int Mix_PlayChannelTimed(int channel, IntPtr chunk, int loops, int ticks) => s_Mix_PlayChannelTimed_int_Mix_Chunk_int_int_t(channel, chunk, loops, ticks);

        private delegate int Mix_PlayMusic_IntPtr_int_t(IntPtr music, int loops);

        private static Mix_PlayMusic_IntPtr_int_t s_Mix_PlayMusic_IntPtr_int_t = __LoadFunction<Mix_PlayMusic_IntPtr_int_t>("Mix_PlayMusic");

        public static int Mix_PlayMusic(IntPtr music, int loops) => s_Mix_PlayMusic_IntPtr_int_t(music, loops);

        private delegate int Mix_FadeInMusic_IntPtr_int_int_t(IntPtr music, int loops, int ms);

        private static Mix_FadeInMusic_IntPtr_int_int_t s_Mix_FadeInMusic_IntPtr_int_int_t = __LoadFunction<Mix_FadeInMusic_IntPtr_int_int_t>("Mix_FadeInMusic");

        public static int Mix_FadeInMusic(IntPtr music, int loops, int ms) => s_Mix_FadeInMusic_IntPtr_int_int_t(music, loops, ms);

        private delegate int Mix_FadeInMusicPos_IntPtr_int_int_double_t(IntPtr music, int loops, int ms, double position);

        private static Mix_FadeInMusicPos_IntPtr_int_int_double_t s_Mix_FadeInMusicPos_IntPtr_int_int_double_t = __LoadFunction<Mix_FadeInMusicPos_IntPtr_int_int_double_t>("Mix_FadeInMusicPos");

        public static int Mix_FadeInMusicPos(IntPtr music, int loops, int ms, double position) => s_Mix_FadeInMusicPos_IntPtr_int_int_double_t(music, loops, ms, position);

        private delegate int Mix_FadeInChannelTimed_int_Mix_Chunk_int_int_int_t(int channel, IntPtr chunk, int loops, int ms, int ticks);

        private static Mix_FadeInChannelTimed_int_Mix_Chunk_int_int_int_t s_Mix_FadeInChannelTimed_int_Mix_Chunk_int_int_int_t = __LoadFunction<Mix_FadeInChannelTimed_int_Mix_Chunk_int_int_int_t>("Mix_FadeInChannelTimed");

        public static int Mix_FadeInChannelTimed(int channel, IntPtr chunk, int loops, int ms, int ticks) => s_Mix_FadeInChannelTimed_int_Mix_Chunk_int_int_int_t(channel, chunk, loops, ms, ticks);

        private delegate int Mix_Volume_int_int_t(int channel, int volume);

        private static Mix_Volume_int_int_t s_Mix_Volume_int_int_t = __LoadFunction<Mix_Volume_int_int_t>("Mix_Volume");

        public static int Mix_Volume(int channel, int volume) => s_Mix_Volume_int_int_t(channel, volume);

        private delegate int Mix_VolumeChunk_Mix_Chunk_int_t(IntPtr chunk, int volume);

        private static Mix_VolumeChunk_Mix_Chunk_int_t s_Mix_VolumeChunk_Mix_Chunk_int_t = __LoadFunction<Mix_VolumeChunk_Mix_Chunk_int_t>("Mix_VolumeChunk");

        public static int Mix_VolumeChunk(IntPtr chunk, int volume) => s_Mix_VolumeChunk_Mix_Chunk_int_t(chunk, volume);

        private delegate int Mix_VolumeMusic_int_t(int volume);

        private static Mix_VolumeMusic_int_t s_Mix_VolumeMusic_int_t = __LoadFunction<Mix_VolumeMusic_int_t>("Mix_VolumeMusic");

        public static int Mix_VolumeMusic(int volume) => s_Mix_VolumeMusic_int_t(volume);

        private delegate int Mix_HaltChannel_int_t(int channel);

        private static Mix_HaltChannel_int_t s_Mix_HaltChannel_int_t = __LoadFunction<Mix_HaltChannel_int_t>("Mix_HaltChannel");

        public static int Mix_HaltChannel(int channel) => s_Mix_HaltChannel_int_t(channel);

        private delegate int Mix_HaltGroup_int_t(int tag);

        private static Mix_HaltGroup_int_t s_Mix_HaltGroup_int_t = __LoadFunction<Mix_HaltGroup_int_t>("Mix_HaltGroup");

        public static int Mix_HaltGroup(int tag) => s_Mix_HaltGroup_int_t(tag);

        private delegate int Mix_HaltMusic__t();

        private static Mix_HaltMusic__t s_Mix_HaltMusic__t = __LoadFunction<Mix_HaltMusic__t>("Mix_HaltMusic");

        public static int Mix_HaltMusic() => s_Mix_HaltMusic__t();

        private delegate int Mix_ExpireChannel_int_int_t(int channel, int ticks);

        private static Mix_ExpireChannel_int_int_t s_Mix_ExpireChannel_int_int_t = __LoadFunction<Mix_ExpireChannel_int_int_t>("Mix_ExpireChannel");

        public static int Mix_ExpireChannel(int channel, int ticks) => s_Mix_ExpireChannel_int_int_t(channel, ticks);

        private delegate int Mix_FadeOutChannel_int_int_t(int which, int ms);

        private static Mix_FadeOutChannel_int_int_t s_Mix_FadeOutChannel_int_int_t = __LoadFunction<Mix_FadeOutChannel_int_int_t>("Mix_FadeOutChannel");

        public static int Mix_FadeOutChannel(int which, int ms) => s_Mix_FadeOutChannel_int_int_t(which, ms);

        private delegate int Mix_FadeOutGroup_int_int_t(int tag, int ms);

        private static Mix_FadeOutGroup_int_int_t s_Mix_FadeOutGroup_int_int_t = __LoadFunction<Mix_FadeOutGroup_int_int_t>("Mix_FadeOutGroup");

        public static int Mix_FadeOutGroup(int tag, int ms) => s_Mix_FadeOutGroup_int_int_t(tag, ms);

        private delegate int Mix_FadeOutMusic_int_t(int ms);

        private static Mix_FadeOutMusic_int_t s_Mix_FadeOutMusic_int_t = __LoadFunction<Mix_FadeOutMusic_int_t>("Mix_FadeOutMusic");

        public static int Mix_FadeOutMusic(int ms) => s_Mix_FadeOutMusic_int_t(ms);

        private delegate Mix_Fading Mix_FadingMusic__t();

        private static Mix_FadingMusic__t s_Mix_FadingMusic__t = __LoadFunction<Mix_FadingMusic__t>("Mix_FadingMusic");

        public static Mix_Fading Mix_FadingMusic() => s_Mix_FadingMusic__t();

        private delegate Mix_Fading Mix_FadingChannel_int_t(int which);

        private static Mix_FadingChannel_int_t s_Mix_FadingChannel_int_t = __LoadFunction<Mix_FadingChannel_int_t>("Mix_FadingChannel");

        public static Mix_Fading Mix_FadingChannel(int which) => s_Mix_FadingChannel_int_t(which);

        private delegate void Mix_Pause_int_t(int channel);

        private static Mix_Pause_int_t s_Mix_Pause_int_t = __LoadFunction<Mix_Pause_int_t>("Mix_Pause");

        public static void Mix_Pause(int channel) => s_Mix_Pause_int_t(channel);

        private delegate void Mix_Resume_int_t(int channel);

        private static Mix_Resume_int_t s_Mix_Resume_int_t = __LoadFunction<Mix_Resume_int_t>("Mix_Resume");

        public static void Mix_Resume(int channel) => s_Mix_Resume_int_t(channel);

        private delegate int Mix_Paused_int_t(int channel);

        private static Mix_Paused_int_t s_Mix_Paused_int_t = __LoadFunction<Mix_Paused_int_t>("Mix_Paused");

        public static int Mix_Paused(int channel) => s_Mix_Paused_int_t(channel);

        private delegate void Mix_PauseMusic__t();

        private static Mix_PauseMusic__t s_Mix_PauseMusic__t = __LoadFunction<Mix_PauseMusic__t>("Mix_PauseMusic");

        public static void Mix_PauseMusic() => s_Mix_PauseMusic__t();

        private delegate void Mix_ResumeMusic__t();

        private static Mix_ResumeMusic__t s_Mix_ResumeMusic__t = __LoadFunction<Mix_ResumeMusic__t>("Mix_ResumeMusic");

        public static void Mix_ResumeMusic() => s_Mix_ResumeMusic__t();

        private delegate void Mix_RewindMusic__t();

        private static Mix_RewindMusic__t s_Mix_RewindMusic__t = __LoadFunction<Mix_RewindMusic__t>("Mix_RewindMusic");

        public static void Mix_RewindMusic() => s_Mix_RewindMusic__t();

        private delegate int Mix_PausedMusic__t();

        private static Mix_PausedMusic__t s_Mix_PausedMusic__t = __LoadFunction<Mix_PausedMusic__t>("Mix_PausedMusic");

        public static int Mix_PausedMusic() => s_Mix_PausedMusic__t();

        private delegate int Mix_SetMusicPosition_double_t(double position);

        private static Mix_SetMusicPosition_double_t s_Mix_SetMusicPosition_double_t = __LoadFunction<Mix_SetMusicPosition_double_t>("Mix_SetMusicPosition");

        public static int Mix_SetMusicPosition(double position) => s_Mix_SetMusicPosition_double_t(position);

        private delegate int Mix_Playing_int_t(int channel);

        private static Mix_Playing_int_t s_Mix_Playing_int_t = __LoadFunction<Mix_Playing_int_t>("Mix_Playing");

        public static int Mix_Playing(int channel) => s_Mix_Playing_int_t(channel);

        private delegate int Mix_PlayingMusic__t();

        private static Mix_PlayingMusic__t s_Mix_PlayingMusic__t = __LoadFunction<Mix_PlayingMusic__t>("Mix_PlayingMusic");

        public static int Mix_PlayingMusic() => s_Mix_PlayingMusic__t();

        private delegate int Mix_SetMusicCMD_IntPtr_t(IntPtr command);

        private static Mix_SetMusicCMD_IntPtr_t s_Mix_SetMusicCMD_IntPtr_t = __LoadFunction<Mix_SetMusicCMD_IntPtr_t>("Mix_SetMusicCMD");

        public static int Mix_SetMusicCMD(IntPtr command) => s_Mix_SetMusicCMD_IntPtr_t(command);

        private delegate int Mix_SetSynchroValue_int_t(int value);

        private static Mix_SetSynchroValue_int_t s_Mix_SetSynchroValue_int_t = __LoadFunction<Mix_SetSynchroValue_int_t>("Mix_SetSynchroValue");

        public static int Mix_SetSynchroValue(int value) => s_Mix_SetSynchroValue_int_t(value);

        private delegate int Mix_GetSynchroValue__t();

        private static Mix_GetSynchroValue__t s_Mix_GetSynchroValue__t = __LoadFunction<Mix_GetSynchroValue__t>("Mix_GetSynchroValue");

        public static int Mix_GetSynchroValue() => s_Mix_GetSynchroValue__t();

        private delegate int Mix_SetSoundFonts_IntPtr_t(IntPtr paths);

        private static Mix_SetSoundFonts_IntPtr_t s_Mix_SetSoundFonts_IntPtr_t = __LoadFunction<Mix_SetSoundFonts_IntPtr_t>("Mix_SetSoundFonts");

        public static int Mix_SetSoundFonts(IntPtr paths) => s_Mix_SetSoundFonts_IntPtr_t(paths);

        private delegate IntPtr Mix_GetSoundFonts__t();

        private static Mix_GetSoundFonts__t s_Mix_GetSoundFonts__t = __LoadFunction<Mix_GetSoundFonts__t>("Mix_GetSoundFonts");

        public static IntPtr Mix_GetSoundFonts() => s_Mix_GetSoundFonts__t();

        private delegate IntPtr Mix_GetChunk_int_t(int channel);

        private static Mix_GetChunk_int_t s_Mix_GetChunk_int_t = __LoadFunction<Mix_GetChunk_int_t>("Mix_GetChunk");

        public static IntPtr Mix_GetChunk(int channel) => s_Mix_GetChunk_int_t(channel);

        private delegate void Mix_CloseAudio__t();

        private static Mix_CloseAudio__t s_Mix_CloseAudio__t = __LoadFunction<Mix_CloseAudio__t>("Mix_CloseAudio");

        public static void Mix_CloseAudio() => s_Mix_CloseAudio__t();
        private static T __LoadFunction<T>(string name)
            where T : class
        {
            if (Loader_SDL2.SdlMixer == null) return null;
            try
            {
                return Loader_SDL2.SdlMixer.LoadFunction<T>(name);
            }
#pragma warning disable
            catch (Exception ex)
            {
                return null;
            }
#pragma warning enable
        }
    }
}


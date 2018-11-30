using System;
using System.Runtime.InteropServices;

using SDL2;
using NativeLibraryLoader;

using SDL_bool = System.Int32;
using size_t = System.IntPtr;

namespace SDL2
{
    public static class SDL_rwops
    {
        public const int SDL_RWOPS_UNKNOWN = 0;
        public const int SDL_RWOPS_WINFILE = 1;
        public const int SDL_RWOPS_STDFILE = 2;
        public const int SDL_RWOPS_JNIFILE = 3;
        public const int SDL_RWOPS_MEMORY = 4;
        public const int SDL_RWOPS_MEMORY_RO = 5;
        public const int RW_SEEK_SET = 0;
        public const int RW_SEEK_CUR = 1;
        public const int RW_SEEK_END = 2;

        private delegate IntPtr SDL_RWFromFile_IntPtr_IntPtr_t(IntPtr file, IntPtr mode);

        private static SDL_RWFromFile_IntPtr_IntPtr_t s_SDL_RWFromFile_IntPtr_IntPtr_t = __LoadFunction<SDL_RWFromFile_IntPtr_IntPtr_t>("SDL_RWFromFile");

        public static IntPtr SDL_RWFromFile(IntPtr file, IntPtr mode) => s_SDL_RWFromFile_IntPtr_IntPtr_t(file, mode);

        private delegate IntPtr SDL_RWFromFP_FILE_SDL_bool_t(IntPtr fp, SDL_bool autoclose);

        private static SDL_RWFromFP_FILE_SDL_bool_t s_SDL_RWFromFP_FILE_SDL_bool_t = __LoadFunction<SDL_RWFromFP_FILE_SDL_bool_t>("SDL_RWFromFP");

        public static IntPtr SDL_RWFromFP(IntPtr fp, SDL_bool autoclose) => s_SDL_RWFromFP_FILE_SDL_bool_t(fp, autoclose);


        private delegate IntPtr SDL_RWFromMem_void_int_t(IntPtr mem, int size);

        private static SDL_RWFromMem_void_int_t s_SDL_RWFromMem_void_int_t = __LoadFunction<SDL_RWFromMem_void_int_t>("SDL_RWFromMem");

        public static IntPtr SDL_RWFromMem(IntPtr mem, int size) => s_SDL_RWFromMem_void_int_t(mem, size);

        private delegate IntPtr SDL_RWFromConstMem_void_int_t(IntPtr mem, int size);

        private static SDL_RWFromConstMem_void_int_t s_SDL_RWFromConstMem_void_int_t = __LoadFunction<SDL_RWFromConstMem_void_int_t>("SDL_RWFromConstMem");

        public static IntPtr SDL_RWFromConstMem(IntPtr mem, int size) => s_SDL_RWFromConstMem_void_int_t(mem, size);

        private delegate IntPtr SDL_AllocRW__t();

        private static SDL_AllocRW__t s_SDL_AllocRW__t = __LoadFunction<SDL_AllocRW__t>("SDL_AllocRW");

        public static IntPtr SDL_AllocRW() => s_SDL_AllocRW__t();

        private delegate void SDL_FreeRW_SDL_RWops_t(IntPtr area);

        private static SDL_FreeRW_SDL_RWops_t s_SDL_FreeRW_SDL_RWops_t = __LoadFunction<SDL_FreeRW_SDL_RWops_t>("SDL_FreeRW");

        public static void SDL_FreeRW(IntPtr area) => s_SDL_FreeRW_SDL_RWops_t(area);

        private delegate byte SDL_ReadU8_SDL_RWops_t(IntPtr src);

        private static SDL_ReadU8_SDL_RWops_t s_SDL_ReadU8_SDL_RWops_t = __LoadFunction<SDL_ReadU8_SDL_RWops_t>("SDL_ReadU8");

        public static byte SDL_ReadU8(IntPtr src) => s_SDL_ReadU8_SDL_RWops_t(src);

        private delegate ushort SDL_ReadLE16_SDL_RWops_t(IntPtr src);

        private static SDL_ReadLE16_SDL_RWops_t s_SDL_ReadLE16_SDL_RWops_t = __LoadFunction<SDL_ReadLE16_SDL_RWops_t>("SDL_ReadLE16");

        public static ushort SDL_ReadLE16(IntPtr src) => s_SDL_ReadLE16_SDL_RWops_t(src);

        private delegate ushort SDL_ReadBE16_SDL_RWops_t(IntPtr src);

        private static SDL_ReadBE16_SDL_RWops_t s_SDL_ReadBE16_SDL_RWops_t = __LoadFunction<SDL_ReadBE16_SDL_RWops_t>("SDL_ReadBE16");

        public static ushort SDL_ReadBE16(IntPtr src) => s_SDL_ReadBE16_SDL_RWops_t(src);

        private delegate uint SDL_ReadLE32_SDL_RWops_t(IntPtr src);

        private static SDL_ReadLE32_SDL_RWops_t s_SDL_ReadLE32_SDL_RWops_t = __LoadFunction<SDL_ReadLE32_SDL_RWops_t>("SDL_ReadLE32");

        public static uint SDL_ReadLE32(IntPtr src) => s_SDL_ReadLE32_SDL_RWops_t(src);

        private delegate uint SDL_ReadBE32_SDL_RWops_t(IntPtr src);

        private static SDL_ReadBE32_SDL_RWops_t s_SDL_ReadBE32_SDL_RWops_t = __LoadFunction<SDL_ReadBE32_SDL_RWops_t>("SDL_ReadBE32");

        public static uint SDL_ReadBE32(IntPtr src) => s_SDL_ReadBE32_SDL_RWops_t(src);

        private delegate ulong SDL_ReadLE64_SDL_RWops_t(IntPtr src);

        private static SDL_ReadLE64_SDL_RWops_t s_SDL_ReadLE64_SDL_RWops_t = __LoadFunction<SDL_ReadLE64_SDL_RWops_t>("SDL_ReadLE64");

        public static ulong SDL_ReadLE64(IntPtr src) => s_SDL_ReadLE64_SDL_RWops_t(src);

        private delegate ulong SDL_ReadBE64_SDL_RWops_t(IntPtr src);

        private static SDL_ReadBE64_SDL_RWops_t s_SDL_ReadBE64_SDL_RWops_t = __LoadFunction<SDL_ReadBE64_SDL_RWops_t>("SDL_ReadBE64");

        public static ulong SDL_ReadBE64(IntPtr src) => s_SDL_ReadBE64_SDL_RWops_t(src);

        private delegate size_t SDL_WriteU8_SDL_RWops_byte_t(IntPtr dst, byte value);

        private static SDL_WriteU8_SDL_RWops_byte_t s_SDL_WriteU8_SDL_RWops_byte_t = __LoadFunction<SDL_WriteU8_SDL_RWops_byte_t>("SDL_WriteU8");

        public static size_t SDL_WriteU8(IntPtr dst, byte value) => s_SDL_WriteU8_SDL_RWops_byte_t(dst, value);

        private delegate size_t SDL_WriteLE16_SDL_RWops_UInt16_t(IntPtr dst, UInt16 value);

        private static SDL_WriteLE16_SDL_RWops_UInt16_t s_SDL_WriteLE16_SDL_RWops_UInt16_t = __LoadFunction<SDL_WriteLE16_SDL_RWops_UInt16_t>("SDL_WriteLE16");

        public static size_t SDL_WriteLE16(IntPtr dst, UInt16 value) => s_SDL_WriteLE16_SDL_RWops_UInt16_t(dst, value);

        private delegate size_t SDL_WriteBE16_SDL_RWops_UInt16_t(IntPtr dst, UInt16 value);

        private static SDL_WriteBE16_SDL_RWops_UInt16_t s_SDL_WriteBE16_SDL_RWops_UInt16_t = __LoadFunction<SDL_WriteBE16_SDL_RWops_UInt16_t>("SDL_WriteBE16");

        public static size_t SDL_WriteBE16(IntPtr dst, UInt16 value) => s_SDL_WriteBE16_SDL_RWops_UInt16_t(dst, value);

        private delegate size_t SDL_WriteLE32_SDL_RWops_UInt32_t(IntPtr dst, UInt32 value);

        private static SDL_WriteLE32_SDL_RWops_UInt32_t s_SDL_WriteLE32_SDL_RWops_UInt32_t = __LoadFunction<SDL_WriteLE32_SDL_RWops_UInt32_t>("SDL_WriteLE32");

        public static size_t SDL_WriteLE32(IntPtr dst, UInt32 value) => s_SDL_WriteLE32_SDL_RWops_UInt32_t(dst, value);

        private delegate size_t SDL_WriteBE32_SDL_RWops_UInt32_t(IntPtr dst, UInt32 value);

        private static SDL_WriteBE32_SDL_RWops_UInt32_t s_SDL_WriteBE32_SDL_RWops_UInt32_t = __LoadFunction<SDL_WriteBE32_SDL_RWops_UInt32_t>("SDL_WriteBE32");

        public static size_t SDL_WriteBE32(IntPtr dst, UInt32 value) => s_SDL_WriteBE32_SDL_RWops_UInt32_t(dst, value);

        private delegate size_t SDL_WriteLE64_SDL_RWops_UInt64_t(IntPtr dst, UInt64 value);

        private static SDL_WriteLE64_SDL_RWops_UInt64_t s_SDL_WriteLE64_SDL_RWops_UInt64_t = __LoadFunction<SDL_WriteLE64_SDL_RWops_UInt64_t>("SDL_WriteLE64");

        public static size_t SDL_WriteLE64(IntPtr dst, UInt64 value) => s_SDL_WriteLE64_SDL_RWops_UInt64_t(dst, value);

        private delegate size_t SDL_WriteBE64_SDL_RWops_UInt64_t(IntPtr dst, UInt64 value);

        private static SDL_WriteBE64_SDL_RWops_UInt64_t s_SDL_WriteBE64_SDL_RWops_UInt64_t = __LoadFunction<SDL_WriteBE64_SDL_RWops_UInt64_t>("SDL_WriteBE64");

        public static size_t SDL_WriteBE64(IntPtr dst, UInt64 value) => s_SDL_WriteBE64_SDL_RWops_UInt64_t(dst, value);
        private static T __LoadFunction<T>(string name) { return SDL2.Internal.Loader_SDL2.LoadFunction<T>(name); }
    }
}


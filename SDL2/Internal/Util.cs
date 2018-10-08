using System;
using System.Text;

namespace SDL2.Internal
{
    internal static class Util
    {
        public unsafe static int strlen(byte* str)
        {
            int result = 0;
            while (*str != 0) {
                result++;
                str++;
            }
            return result;
        }   

        public unsafe static string PtrToStringUTF8(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero) return null;
            var p = (byte*)ptr;
            var length = strlen(p);
            return Encoding.UTF8.GetString(p, length);
        }
    }
}
using System;
using System.Runtime.InteropServices;
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

        public unsafe static IntPtr StringToHGlobalUTF8(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var ptr = Marshal.AllocHGlobal(bytes.Length + 1);
            Marshal.Copy(bytes, 0, ptr, bytes.Length);
            *((byte*)ptr + bytes.Length) = 0;
            return ptr;
        }
    }
}
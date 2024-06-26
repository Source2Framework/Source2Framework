﻿namespace Source2Framework.Extensions
{
    public static partial class IntPtrExtensions
    {
        public static IntPtr AddOffset(this IntPtr ptr, int offset)
        {
            return ptr + offset;
        }

        public static unsafe IntPtr ToAbsolute(this IntPtr ptr, int preOffset, int postOffset)
        {
            if (ptr != IntPtr.Zero)
            {
                ptr.AddOffset(preOffset);
                ptr = ptr + sizeof(int) + *(int*)(ptr);
                ptr.AddOffset(postOffset);
            }

            return ptr;
        }

        public static string ToHexStr(this IntPtr ptr)
        {
            return $"0x{ptr:X}";
        }
    }
}

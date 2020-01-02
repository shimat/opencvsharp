using System;

namespace OpenCvSharp
{
    internal static class PlatformUtil
    {
        public static long AlignSize(long sz, int n)
        {
            return (sz + n - 1) & -n;
        }

        public static long TruncateForX86(long value)
        {
            if (IntPtr.Size == 4)
                return (int)value;
            return value;
        }
    }
}

using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Util
{
    internal static class StringHelper
    {
        public static unsafe string? PtrToStringAnsi(sbyte* p)
        {
#if DOTNET_FRAMEWORK
            return new string(p);
#else
            // memo: https://github.com/dotnet/standard/blob/master/netstandard/ref/mscorlib.cs#L2970
            return Marshal.PtrToStringAnsi(new IntPtr(p));
#endif
        }

        public static string? PtrToStringAnsi(IntPtr p)
        {
#if DOTNET_FRAMEWORK
            unsafe 
            { 
                return new string((sbyte*)p);
            }
#else
            // memo: https://github.com/dotnet/standard/blob/master/netstandard/ref/mscorlib.cs#L2970
            return Marshal.PtrToStringAnsi(p);
#endif
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class MarshalHelper
    {
        public static int SizeOf<T>()
        {
#if net20 || net40
            if (typeof(T).IsValueType)
            {
                return Marshal.SizeOf(typeof(T));
            }
            else
            {
                return IntPtr.Size;
            }
#else
            if (typeof(T).GetTypeInfo().IsValueType)
            {
#if uwp
                return Marshal.SizeOf(typeof(T));
#else
                return Marshal.SizeOf<T>();
#endif
            }
            else
            {
                return IntPtr.Size;
            }
#endif
            }

        public static T PtrToStructure<T>(IntPtr p)
            where T : struct 
        {
#if net20 || net40 || uwp
            return (T)Marshal.PtrToStructure(p, typeof(T));
#else
            return Marshal.PtrToStructure<T>(p);
#endif
        }
    }
}

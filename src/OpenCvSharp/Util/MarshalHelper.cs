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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
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
                return Marshal.SizeOf<T>();
            }
            else
            {
                return IntPtr.Size;
            }
#endif
        }
    }
}

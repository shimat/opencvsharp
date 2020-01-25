using System;
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
            if (typeof(T).GetTypeInfo().IsValueType)
            {
                return Marshal.SizeOf<T>();
            }
            return IntPtr.Size;
        }
    }
}

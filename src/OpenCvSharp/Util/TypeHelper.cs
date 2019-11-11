using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class TypeHelper
    {
#if LANG_JP
/// <summary>
/// ポインタから構造体にキャストを試みる
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="ptr"></param>
/// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ptr"></param>
        /// <returns></returns>
#endif
        public static T ToObject<T>(IntPtr ptr) where T : struct
        {
            var t = typeof(T);
            // IntPtrはそのまま返す
            if (t == typeof(IntPtr))
            {
                return (T) (object) ptr;
            }

#if NET20 || NET40
            return (T)Marshal.PtrToStructure(ptr, typeof(T));
#else
            return Marshal.PtrToStructure<T>(ptr);
#endif
        }
    }
}

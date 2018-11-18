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
            Type t = typeof(T);
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

#if LANG_JP
/// <summary>
/// testとtargetが同じ型かどうかチェック
/// </summary>
/// <param name="test">source type</param>
/// <param name="target">generic type</param>
/// <returns></returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="test"></param>
        /// <param name="target"></param>
        /// <returns></returns>
#endif
        private static bool CheckType(Type test, Type target)
        {
#if NET20 || NET40
            while (test != typeof(object))
            {
                if (test.IsGenericType)
                {
                    Type g = test.GetGenericTypeDefinition();
                    if (target == g)
                    {
                        return true;
                    }
                }
                test = test.BaseType;
            }
#else
            while (test != typeof(object))
            {
                if (test.GetTypeInfo().IsGenericType)
                {
                    Type g = test.GetGenericTypeDefinition();
                    if (target == g)
                    {
                        return true;
                    }
                }
                test = test.GetTypeInfo().BaseType;
            }
#endif
            return false;
        }
    }
}

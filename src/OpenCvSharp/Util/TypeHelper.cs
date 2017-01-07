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
/// void*からT型のオブジェクトに変換を試みる.
/// TがOpenCVのオブジェクトの場合は、IntPtrを取るコンストラクタ呼び出しを試みる.
/// </summary>
/// <typeparam name="T">オブジェクトの型. プリミティブ型か、OpenCVのオブジェクト(ICvObject).</typeparam>
/// <param name="p">変換するポインタ</param>
/// <returns>T型に変換した結果</returns>
#else
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p"></param>
        /// <returns></returns>
#endif
        public static T Cast<T>(IntPtr p)
        {
            Type t = typeof(T);

#if net20 || net40
// OpenCVのオブジェクトであることを期待してポインタからのオブジェクト生成を試みる.
            ConstructorInfo info = t.GetConstructor(new Type[] { typeof(IntPtr), typeof(bool) });
            if (info != null)
            {
                return (T)info.Invoke(new object[] { p, false });
            }
            else
            {
                info = t.GetConstructor(new Type[] { typeof(IntPtr) });
                if (info == null)
                {
                    throw new OpenCvSharpException("{0} is invalid type for this method. Value type or OpenCV's class are valid.", t.Name);
                }
                return (T)info.Invoke(new object[] { p });
            }   
#else
            // OpenCVのオブジェクトであることを期待してポインタからのオブジェクト生成を試みる.
            ConstructorInfo info = t.GetTypeInfo().GetConstructor(new Type[] {typeof(IntPtr), typeof(bool)});
            if (info != null)
            {
                return (T) info.Invoke(new object[] {p, false});
            }
            else
            {
                info = t.GetTypeInfo().GetConstructor(new Type[] {typeof(IntPtr)});
                if (info == null)
                {
                    throw new OpenCvSharpException(
                        "{0} is invalid type for this method. Value type or OpenCV's class are valid.", t.Name);
                }
                return (T) info.Invoke(new object[] {p});
            }
#endif
        }

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

#if net20 || net40
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
#if net20 || net40
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

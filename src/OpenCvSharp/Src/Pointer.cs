/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
#if LANG_JP 
    /// <summary>
    /// 構造体のポインタ (t*) 
    /// </summary>
    /// <typeparam name="T"></typeparam>
#else
    /// <summary>
    /// Structure which represents t*
    /// </summary>
    /// <typeparam name="T"></typeparam>
#endif
    [StructLayout(LayoutKind.Sequential)]
    public struct Pointer<T> where T : struct
    {
        /// <summary>
        /// IntPtr
        /// </summary>
        private IntPtr address;


        /// <summary>
        /// Null pointer
        /// </summary>
        public static readonly Pointer<T> Zero = new Pointer<T>(IntPtr.Zero);


#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="address"></param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="address"></param>
#endif
        public Pointer(IntPtr address)
        {
            this.address = address;
        }


#if LANG_JP
        /// <summary>
        /// アドレス
        /// </summary>
#else
        /// <summary>
        /// Address
        /// </summary>
#endif
        public IntPtr Address
        {
            get { return address; }
            set { address = value; }
        }


#if LANG_JP
        /// <summary>
        /// ポインタの実体 (*t)
        /// </summary>
#else
        /// <summary>
        /// entity of the pointer (*t)
        /// </summary>
#endif
        public T Entity
        {
            get 
            {
                return Util.ToObject<T>(address); 
            }
        }


#if LANG_JP
        /// <summary>
        /// IntPtrへの暗黙のキャスト
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// implicit cast to IntPtr
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#endif
        public static implicit operator IntPtr(Pointer<T> self)
        {
            return self.address;
        }

#if LANG_JP
        /// <summary>
        /// Tへの明示的なキャスト
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#else
        /// <summary>
        /// explicit cast to t
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
#endif
        public static explicit operator T(Pointer<T> self)
        {
            return self.Entity;
        }
    }
}

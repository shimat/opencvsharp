/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// cvSeqSort, cvSeqSearch等のメソッドで指定する, 比較関数をあらわすデリゲート.
	/// aがbより小さければ負の値を, aとbが等しければ0を, aがbより大きければ正の値を返す.
	/// </summary>
	/// <param name="a"></param>
    /// <param name="b"></param>
	/// <returns>aがbより小さければ負の値を, aとbが等しければ0を, aがbより大きければ正の値を返す.</returns>
#else
    /// <summary>
    /// The comparison function that returns negative, zero or positive value depending on the elements relation
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CvCmpFunc(
        IntPtr a,
        IntPtr b//,
        //IntPtr userdata
    );

#if LANG_JP
    /// <summary>
    /// cvSeqSort, cvSeqSearch等のメソッドで指定する, 比較関数をあらわすデリゲート.
    /// aがbより小さければ負の値を, aとbが等しければ0を, aがbより大きければ正の値を返す.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns>aがbより小さければ負の値を, aとbが等しければ0を, aがbより大きければ正の値を返す.</returns>
#else
    /// <summary>
    /// The comparison function that returns negative, zero or positive value depending on the elements relation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
#endif
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int CvCmpFunc<T>(
        T a,
        T b//,
        //IntPtr userdata
    ) 
    //where T : struct
    ;
}

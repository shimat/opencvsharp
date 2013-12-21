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
    /// cvCalcEMD2で用いる, ユーザ定義距離関数．2点の座標を与えると，その点間の距離を返す． 
    /// </summary>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <returns></returns>
#else
    /// <summary>
    /// The user-defined distance function for cvCalcEMD2. It takes coordinates of two points and returns the distance between the points. 
    /// </summary>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <returns></returns>
#endif
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate Int32 CvDistanceFunction(
		float[] f1, 
		float[] f2//,
		//IntPtr userdata
	); 
}

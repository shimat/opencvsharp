/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
	/// <summary>
	/// CvCaptureのキャプチャタイプ(カメラorファイル)
	/// </summary>
#else
    /// <summary>
    /// Capture type of CvCapture (Camera or AVI file)
    /// </summary>
#endif
    public enum CaptureType
    {
#if LANG_JP
		/// <summary>
		/// AVIファイルからのキャプチャ
		/// </summary>
#else
        /// <summary>
        /// Captures from an AVI file
        /// </summary>
#endif
        File,


#if LANG_JP
		/// <summary>
		/// カメラからのキャプチャ
		/// </summary>
#else
        /// <summary>
        /// Captures from digital camera
        /// </summary>
#endif
        Camera
    }
}

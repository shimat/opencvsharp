using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// IplImageの原点
	/// </summary>
#else
    /// <summary>
    /// Origin of IplImage
    /// </summary>
#endif
	public enum ImageOrigin : int
	{
#if LANG_JP
		/// <summary>
		/// 左上原点 [IPL_ORIGIN_TL (0)]
		/// </summary>
#else
        /// <summary>
        /// top-left origin [IPL_ORIGIN_TL (0)]
        /// </summary>
#endif
		TopLeft = CvConst.IPL_ORIGIN_TL,


#if LANG_JP
		/// <summary>
		/// 左下原点 (Windowsのビットマップ形式) [IPL_ORIGIN_BL (1)]
		/// </summary>
#else
        /// <summary>
        /// bottom-left origin (Windows bitmaps style) [IPL_ORIGIN_BL (1)]
        /// </summary>
#endif
		BottomLeft = CvConst.IPL_ORIGIN_BL,
	};
}

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
	/// カメラキャプチャの初期化に用いるカメラのデバイス
	/// </summary>
#else
    /// <summary>
    /// Camera device types
    /// </summary>
#endif
    public enum CaptureDevice : int
    {
#if LANG_JP
		/// <summary>
		/// autodetect
        /// [CV_CAP_ANY]
		/// </summary>
#else
        /// <summary>
        /// autodetect
        /// [CV_CAP_ANY]
        /// </summary>
#endif
        Any = CvConst.CV_CAP_ANY,



#if LANG_JP
		/// <summary>
		/// MIL proprietary drivers
        /// [CV_CAP_MIL]
		/// </summary>
#else
        /// <summary>
        /// MIL proprietary drivers
        /// [CV_CAP_MIL]
        /// </summary>
#endif
        MIL = CvConst.CV_CAP_MIL,



#if LANG_JP
		/// <summary>
		/// platform native
        /// [CV_CAP_VFW]
		/// </summary>
#else
        /// <summary>
        /// platform native
        /// [CV_CAP_VFW]
        /// </summary>
#endif
        VFW = CvConst.CV_CAP_VFW,
#if LANG_JP
		/// <summary>
		/// platform native
        /// [CV_CAP_V4L]
		/// </summary>
#else
        /// <summary>
        /// platform native
        /// [CV_CAP_V4L]
        /// </summary>
#endif
        V4L = CvConst.CV_CAP_V4L,
#if LANG_JP
		/// <summary>
		/// platform native
        /// [CV_CAP_V4L2]
		/// </summary>
#else
        /// <summary>
        /// platform native
        /// [CV_CAP_V4L2]
        /// </summary>
#endif
        V4L2 = CvConst.CV_CAP_V4L2,



#if LANG_JP
		/// <summary>
		/// IEEE 1394 drivers
        /// [CV_CAP_FIREWIRE]
		/// </summary>
#else
        /// <summary>
        /// IEEE 1394 drivers
        /// [CV_CAP_FIREWIRE]
        /// </summary>
#endif
        Firewire = CvConst.CV_CAP_FIREWIRE,
#if LANG_JP
		/// <summary>
		/// IEEE 1394 drivers
        /// [CV_CAP_IEEE1394]
		/// </summary>
#else
        /// <summary>
        /// IEEE 1394 drivers
        /// [CV_CAP_IEEE1394]
        /// </summary>
#endif
        IEEE1394 = CvConst.CV_CAP_IEEE1394,
#if LANG_JP
		/// <summary>
		/// IEEE 1394 drivers
        /// [CV_CAP_FIREWARE]
		/// </summary>
#else
        /// <summary>
        /// IEEE 1394 drivers
        /// [CV_CAP_FIREWARE]
        /// </summary>
#endif
        Fireware = CvConst.CV_CAP_FIREWARE,
#if LANG_JP
		/// <summary>
		/// IEEE 1394 drivers
        /// [CV_CAP_DC1394]
		/// </summary>
#else
        /// <summary>
        /// IEEE 1394 drivers
        /// [CV_CAP_DC1394]
        /// </summary>
#endif
        DC1394 = CvConst.CV_CAP_DC1394,
#if LANG_JP
		/// <summary>
		/// IEEE 1394 drivers
        /// [CV_CAP_CMU1394]
		/// </summary>
#else
        /// <summary>
        /// IEEE 1394 drivers
        /// [CV_CAP_CMU1394]
        /// </summary>
#endif
        CMU1394 = CvConst.CV_CAP_CMU1394,



#if LANG_JP
		/// <summary>
		/// TYZX proprietary drivers
        /// [CV_CAP_STEREO]
		/// </summary>
#else
        /// <summary>
        /// TYZX proprietary drivers
        /// [CV_CAP_STEREO]
        /// </summary>
#endif
        Stereo = CvConst.CV_CAP_STEREO,
#if LANG_JP
		/// <summary>
		/// TYZX proprietary drivers
        /// [CV_CAP_TYZX]
		/// </summary>
#else
        /// <summary>
        /// TYZX proprietary drivers
        /// [CV_CAP_TYZX]
        /// </summary>
#endif
        TYZX = CvConst.CV_CAP_TYZX,
#if LANG_JP
		/// <summary>
		/// TYZX proprietary drivers
        /// [CV_TYZX_LEFT]
		/// </summary>
#else
        /// <summary>
        /// TYZX proprietary drivers
        /// [CV_TYZX_LEFT]
        /// </summary>
#endif
        TYZX_Left = CvConst.CV_TYZX_LEFT,
#if LANG_JP
		/// <summary>
		/// TYZX proprietary drivers
        /// [CV_TYZX_RIGHT]
		/// </summary>
#else
        /// <summary>
        /// TYZX proprietary drivers
        /// [CV_TYZX_RIGHT]
        /// </summary>
#endif
        TYZX_Right = CvConst.CV_TYZX_RIGHT,
#if LANG_JP
		/// <summary>
		/// TYZX proprietary drivers
        /// [CV_TYZX_COLOR]
		/// </summary>
#else
        /// <summary>
        /// TYZX proprietary drivers
        /// [CV_TYZX_COLOR]
        /// </summary>
#endif
        TYZX_Color = CvConst.CV_TYZX_COLOR,
#if LANG_JP
		/// <summary>
		/// TYZX proprietary drivers
        /// [CV_TYZX_Z]
		/// </summary>
#else
        /// <summary>
        /// TYZX proprietary drivers
        /// [CV_TYZX_Z]
        /// </summary>
#endif
        TYZX_Z = CvConst.CV_TYZX_Z,



#if LANG_JP
		/// <summary>
		/// QuickTime
        /// [CV_CAP_QT]
		/// </summary>
#else
        /// <summary>
        /// QuickTime
        /// [CV_CAP_QT]
        /// </summary>
#endif
        QuickTime = CvConst.CV_CAP_QT,



#if LANG_JP
		/// <summary>
		/// Unicap drivers
        /// [CV_CAP_UNICAP]
		/// </summary>
#else
        /// <summary>
        /// Unicap drivers
        /// [CV_CAP_UNICAP]
        /// </summary>
#endif
        Unicap = CvConst.CV_CAP_UNICAP,



#if LANG_JP
		/// <summary>
		/// DirectShow (via videoInput)
        /// [CV_CAP_DSHOW]
		/// </summary>
#else
        /// <summary>
        /// DirectShow (via videoInput)
        /// [CV_CAP_DSHOW]
        /// </summary>
#endif
        DShow = CvConst.CV_CAP_DSHOW,



#if LANG_JP
		/// <summary>
		/// PvAPI, Prosilica GigE SDK
        /// [CV_CAP_PVAPI]
		/// </summary>
#else
        /// <summary>
        /// PvAPI, Prosilica GigE SDK
        /// [CV_CAP_PVAPI]
        /// </summary>
#endif
        PvAPI = CvConst.CV_CAP_PVAPI,



#if LANG_JP
		/// <summary>
		/// OpenNI (for Kinect)
        /// [CV_CAP_OPENNI]
		/// </summary>
#else
        /// <summary>
        /// OpenNI (for Kinect)
        /// [CV_CAP_OPENNI]
        /// </summary>
#endif
        OpenNI = CvConst.CV_CAP_OPENNI,



#if LANG_JP
		/// <summary>
		/// Android
        /// [CV_CAP_ANDROID]
		/// </summary>
#else
        /// <summary>
        /// Android
        /// [CV_CAP_ANDROID]
        /// </summary>
#endif
        Android = CvConst.CV_CAP_ANDROID,  



#if LANG_JP
		/// <summary>
		/// XIMEA Camera API
        /// [CV_CAP_XIAPI]
		/// </summary>
#else
        /// <summary>
        /// XIMEA Camera API
        /// [CV_CAP_XIAPI]
        /// </summary>
#endif
        XIAPI = CvConst.CV_CAP_XIAPI, 
    }
}

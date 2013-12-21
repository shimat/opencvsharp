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
	/// マルチヘッドカメラから取得する画像のチャネル
	/// </summary>
#else
    /// <summary>
    /// channel indices for multi-head camera live streams
    /// </summary>
#endif
    public enum CameraChannels : int
    {
#if LANG_JP
		/// <summary>
		/// 0
		/// </summary>
#else
        /// <summary>
        /// 0
        /// </summary>
#endif
        Zero = 0,

        #region OpenNI
        // Data given from depth generator.

#if LANG_JP
		/// <summary>
		/// Depth values in mm (CV_16UC1)
        /// [CV_CAP_OPENNI_DEPTH_MAP]
		/// </summary>
#else
        /// <summary>
        /// Depth values in mm (CV_16UC1)
        /// [CV_CAP_OPENNI_DEPTH_MAP]
        /// </summary>
#endif
        OpenNI_DepthMap = CvConst.CV_CAP_OPENNI_DEPTH_MAP, 
#if LANG_JP
		/// <summary>
		/// XYZ in meters (CV_32FC3)
        /// [CV_CAP_OPENNI_POINT_CLOUD_MAP]
		/// </summary>
#else
        /// <summary>
        /// XYZ in meters (CV_32FC3)
        /// [CV_CAP_OPENNI_POINT_CLOUD_MAP]
        /// </summary>
#endif
        OpenNI_PointCloudMap = CvConst.CV_CAP_OPENNI_POINT_CLOUD_MAP, 
#if LANG_JP
		/// <summary>
		/// Disparity in pixels (CV_8UC1)
        /// [CV_CAP_OPENNI_DISPARITY_MAP]
		/// </summary>
#else
        /// <summary>
        /// Disparity in pixels (CV_8UC1)
        /// [CV_CAP_OPENNI_DISPARITY_MAP]
        /// </summary>
#endif
        OpenNI_DisparityMap = CvConst.CV_CAP_OPENNI_DISPARITY_MAP, 
#if LANG_JP
		/// <summary>
		/// Disparity in pixels (CV_32FC1)
        /// [CV_CAP_OPENNI_DISPARITY_MAP_32F]
		/// </summary>
#else
        /// <summary>
        /// Disparity in pixels (CV_32FC1)
        /// [CV_CAP_OPENNI_DISPARITY_MAP_32F]
        /// </summary>
#endif
        OpenNI_DisparityMap32F = CvConst.CV_CAP_OPENNI_DISPARITY_MAP_32F, 
#if LANG_JP
		/// <summary>
		/// CV_8UC1
        /// [CV_CAP_OPENNI_VALID_DEPTH_MASK]
		/// </summary>
#else
        /// <summary>
        /// CV_8UC1
        /// [CV_CAP_OPENNI_VALID_DEPTH_MASK]
        /// </summary>
#endif
        OpenNI_ValidDepthMask = CvConst.CV_CAP_OPENNI_VALID_DEPTH_MASK, 
        
        // Data given from RGB image generator.
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_OPENNI_BGR_IMAGE]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_OPENNI_BGR_IMAGE]
        /// </summary>
#endif
        OpenNI_BGRImage = CvConst.CV_CAP_OPENNI_BGR_IMAGE,
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_OPENNI_GRAY_IMAGE]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_OPENNI_GRAY_IMAGE]
        /// </summary>
#endif
        OpenNI_GrayImage = CvConst.CV_CAP_OPENNI_GRAY_IMAGE,
        
        // Supported output modes of OpenNI image generator
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_OPENNI_VGA_30HZ]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_OPENNI_VGA_30HZ]
        /// </summary>
#endif
        OpenNI_VGA30Hz = CvConst.CV_CAP_OPENNI_VGA_30HZ,
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_OPENNI_SXGA_15HZ]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_OPENNI_SXGA_15HZ]
        /// </summary>
#endif
        OpenNI_SXGA15Hz = CvConst.CV_CAP_OPENNI_SXGA_15HZ,
        #endregion

        #region Android
        // supported by Android camera output formats

#if LANG_JP
		/// <summary>
		/// BGR
        /// [CV_CAP_ANDROID_COLOR_FRAME_BGR]
		/// </summary>
#else
        /// <summary>
        /// BGR
        /// [CV_CAP_ANDROID_COLOR_FRAME_BGR]
        /// </summary>
#endif
        Android_ColorFrameBGR = CvConst.CV_CAP_ANDROID_COLOR_FRAME_BGR, 
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_ANDROID_COLOR_FRAME]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_ANDROID_COLOR_FRAME]
        /// </summary>
#endif
        Android_ColorFrame = CvConst.CV_CAP_ANDROID_COLOR_FRAME,
#if LANG_JP
		/// <summary>
		/// Y
        /// [CV_CAP_ANDROID_GREY_FRAME]
		/// </summary>
#else
        /// <summary>
        /// Y
        /// [CV_CAP_ANDROID_GREY_FRAME]
        /// </summary>
#endif
        Android_GreyFrame = CvConst.CV_CAP_ANDROID_GREY_FRAME,  
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_ANDROID_COLOR_FRAME_RGB]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_ANDROID_COLOR_FRAME_RGB]
        /// </summary>
#endif
        Android_ColorFrameRGB = CvConst.CV_CAP_ANDROID_COLOR_FRAME_RGB,
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_ANDROID_COLOR_FRAME_BGRA]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_ANDROID_COLOR_FRAME_BGRA]
        /// </summary>
#endif
        Android_ColorFrameBGRA = CvConst.CV_CAP_ANDROID_COLOR_FRAME_BGRA,
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_ANDROID_COLOR_FRAME_RGBA]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_ANDROID_COLOR_FRAME_RGBA]
        /// </summary>
#endif
        Android_ColorFrameRGBA = CvConst.CV_CAP_ANDROID_COLOR_FRAME_RGBA,
        #endregion
    }
}

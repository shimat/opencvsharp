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
	/// CvCaptureのプロパティID
	/// </summary>
#else
    /// <summary>
    /// Property identifiers for CvCapture
    /// </summary>
#endif
    public enum CaptureProperty : int
    {
        #region Basic
#if LANG_JP
		/// <summary>
		/// ファイル中の現在の位置（ミリ秒単位），あるいはビデオキャプチャのタイムスタンプ値
        /// [CV_CAP_PROP_POS_MSEC]
		/// </summary>
#else
        /// <summary>
        /// Position in milliseconds from the file beginning
        /// [CV_CAP_PROP_POS_MSEC]
        /// </summary>
#endif
        PosMsec = CvConst.CV_CAP_PROP_POS_MSEC,


#if LANG_JP
		/// <summary>
		/// 次にデコード/キャプチャされるフレームのインデックス．0 から始まる
        /// [CV_CAP_PROP_POS_FRAMES]
		/// </summary>
#else
        /// <summary>
        /// Position in frames (only for video files)
        /// [CV_CAP_PROP_POS_FRAMES]
        /// </summary>
#endif
        PosFrames = CvConst.CV_CAP_PROP_POS_FRAMES,


#if LANG_JP
		/// <summary>
		/// ビデオファイル内の相対的な位置 (0 - ファイルの最初，1 - ファイルの最後）
        /// [CV_CAP_PROP_POS_AVI_RATIO]
		/// </summary>
#else
        /// <summary>
        /// Position in relative units (0 - start of the file, 1 - end of the file)
        /// [CV_CAP_PROP_POS_AVI_RATIO]
        /// </summary>
#endif
        PosAviRatio = CvConst.CV_CAP_PROP_POS_AVI_RATIO,


#if LANG_JP
		/// <summary>
		/// ビデオストリーム中のフレームの幅
        /// [CV_CAP_PROP_FRAME_WIDTH]
		/// </summary>
#else
        /// <summary>
        /// Width of frames in the video stream (only for cameras)
        /// [CV_CAP_PROP_FRAME_WIDTH]
        /// </summary>
#endif
        FrameWidth = CvConst.CV_CAP_PROP_FRAME_WIDTH,


#if LANG_JP
		/// <summary>
		/// ビデオストリーム中のフレームの高さ
        /// [CV_CAP_PROP_FRAME_HEIGHT]
		/// </summary>
#else
        /// <summary>
        /// Height of frames in the video stream (only for cameras)
        /// [CV_CAP_PROP_FRAME_HEIGHT]
        /// </summary>
#endif
        FrameHeight = CvConst.CV_CAP_PROP_FRAME_HEIGHT,


#if LANG_JP
		/// <summary>
		/// フレームレート
        /// [CV_CAP_PROP_FPS]
		/// </summary>
#else
        /// <summary>
        /// Frame rate (only for cameras)
        /// [CV_CAP_PROP_FPS]
        /// </summary>
#endif
        Fps = CvConst.CV_CAP_PROP_FPS,


#if LANG_JP
		/// <summary>
		/// コーデックを表す 4 文字
        /// [CV_CAP_PROP_FOURCC]
		/// </summary>
#else
        /// <summary>
        /// 4-character code of codec (only for cameras). 
        /// [CV_CAP_PROP_FOURCC]
        /// </summary>
#endif
        FourCC = CvConst.CV_CAP_PROP_FOURCC,


#if LANG_JP
		/// <summary>
		/// ビデオファイル中のフレーム数 
        /// [CV_CAP_PROP_FRAME_COUNT]
		/// </summary>
#else
        /// <summary>
        /// Number of frames in the video stream
        /// [CV_CAP_PROP_FRAME_COUNT]
        /// </summary>
#endif
        FrameCount = CvConst.CV_CAP_PROP_FRAME_COUNT,


#if LANG_JP
		/// <summary>
		/// retrieve() によって返されるMat オブジェクトのフォーマット．
        /// [CV_CAP_PROP_FORMAT]
		/// </summary>
#else
        /// <summary>
        /// The format of the Mat objects returned by retrieve()
        /// [CV_CAP_PROP_FORMAT]
        /// </summary>
#endif
        Format = CvConst.CV_CAP_PROP_FORMAT,


#if LANG_JP
		/// <summary>
		/// 現在のキャプチャモードを表す，バックエンド固有の値．
        /// [CV_CAP_PROP_MODE]
		/// </summary>
#else
        /// <summary>
        /// A backend-specific value indicating the current capture mode
        /// [CV_CAP_PROP_MODE]
        /// </summary>
#endif
        Mode = CvConst.CV_CAP_PROP_MODE,


#if LANG_JP
		/// <summary>
		/// 明度
        /// [CV_CAP_PROP_BRIGHTNESS]
		/// </summary>
#else
        /// <summary>
        /// Brightness of image (only for cameras) 
        /// [CV_CAP_PROP_BRIGHTNESS]
        /// </summary>
#endif
        Brightness = CvConst.CV_CAP_PROP_BRIGHTNESS,


#if LANG_JP
		/// <summary>
		/// コントラスト
        /// [CV_CAP_PROP_CONTRAST]
		/// </summary>
#else
        /// <summary>
        /// contrast of image (only for cameras) 
        /// [CV_CAP_PROP_CONTRAST]
        /// </summary>
#endif
        Contrast = CvConst.CV_CAP_PROP_CONTRAST,


#if LANG_JP
		/// <summary>
		/// 彩度
        /// [CV_CAP_PROP_SATURATION]
		/// </summary>
#else
        /// <summary>
        /// Saturation of image (only for cameras) 
        /// [CV_CAP_PROP_SATURATION]
        /// </summary>
#endif
        Saturation = CvConst.CV_CAP_PROP_SATURATION,


#if LANG_JP
		/// <summary>
		/// 色相
        /// [CV_CAP_PROP_HUE]
		/// </summary>
#else
        /// <summary>
        /// hue of image (only for cameras) 
        /// [CV_CAP_PROP_HUE]
        /// </summary>
#endif
        Hue = CvConst.CV_CAP_PROP_HUE,


#if LANG_JP
		/// <summary>
		/// 画像のゲイン（カメラの場合のみ）．
        /// [CV_CAP_PROP_GAIN]
		/// </summary>
#else
        /// <summary>
        /// Gain of the image (only for cameras)
        /// [CV_CAP_PROP_GAIN]
        /// </summary>
#endif
        Gain = CvConst.CV_CAP_PROP_GAIN,


#if LANG_JP
		/// <summary>
		/// 露出（カメラの場合のみ）．
        /// [CV_CAP_PROP_EXPOSURE]
		/// </summary>
#else
        /// <summary>
        /// Exposure (only for cameras)
        /// [CV_CAP_PROP_EXPOSURE]
        /// </summary>
#endif
        Exposure = CvConst.CV_CAP_PROP_EXPOSURE,


#if LANG_JP
		/// <summary>
		/// 画像がRGBに変換されるか否かを表す，ブール値のフラグ．
        /// [CV_CAP_PROP_CONVERT_RGB]
		/// </summary>
#else
        /// <summary>
        /// Boolean flags indicating whether images should be converted to RGB
        /// [CV_CAP_PROP_CONVERT_RGB]
        /// </summary>
#endif
        ConvertRgb = CvConst.CV_CAP_PROP_CONVERT_RGB,


#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_PROP_WHITE_BALANCE]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_WHITE_BALANCE]
        /// </summary>
#endif
        WhiteBalance = CvConst.CV_CAP_PROP_WHITE_BALANCE,


#if LANG_JP
		/// <summary>
		/// TOWRITE（注意：現在のところ，DC1394 v 2.x バックエンドでのみサポートされます）．
        /// [CV_CAP_PROP_RECTIFICATION]
		/// </summary>
#else
        /// <summary>
        /// TOWRITE (note: only supported by DC1394 v 2.x backend currently)
        /// [CV_CAP_PROP_RECTIFICATION]
        /// </summary>
#endif
        Rectification = CvConst.CV_CAP_PROP_RECTIFICATION,


#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_PROP_MONOCROME]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_MONOCROME]
        /// </summary>
#endif
        Monocrome = CvConst.CV_CAP_PROP_MONOCROME,
        #endregion

        #region Added for 2.3
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_PROP_SHARPNESS]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_SHARPNESS]
        /// </summary>
#endif
        Sharpness = CvConst.CV_CAP_PROP_SHARPNESS,
#if LANG_JP
		/// <summary>
		/// exposure control done by camera,
        /// user can adjust refernce level using this feature
        /// [CV_CAP_PROP_AUTO_EXPOSURE]
		/// </summary>
#else
        /// <summary>
        /// exposure control done by camera,
        /// user can adjust refernce level using this feature
        /// [CV_CAP_PROP_AUTO_EXPOSURE]
        /// </summary>
#endif
        AutoExposure = CvConst.CV_CAP_PROP_AUTO_EXPOSURE, 
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_PROP_GAMMA]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_GAMMA]
        /// </summary>
#endif
        Gamma = CvConst.CV_CAP_PROP_GAMMA,
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_PROP_TEMPERATURE]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_TEMPERATURE]
        /// </summary>
#endif
        Temperature = CvConst.CV_CAP_PROP_TEMPERATURE,
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_PROP_TRIGGER]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_TRIGGER]
        /// </summary>
#endif
        Trigger = CvConst.CV_CAP_PROP_TRIGGER,
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_PROP_TRIGGER_DELAY]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_TRIGGER_DELAY]
        /// </summary>
#endif
        TriggerDelay = CvConst.CV_CAP_PROP_TRIGGER_DELAY,
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_PROP_WHITE_BALANCE_RED_V]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_WHITE_BALANCE_RED_V]
        /// </summary>
#endif
        WhiteBalanceRedV = CvConst.CV_CAP_PROP_WHITE_BALANCE_RED_V,
#if LANG_JP
		/// <summary>
		/// 
        /// [CV_CAP_PROP_MAX_DC1394]
		/// </summary>
#else
        /// <summary>
        /// 
        /// [CV_CAP_PROP_MAX_DC1394]
        /// </summary>
#endif
        MaxDC1394 = CvConst.CV_CAP_PROP_MAX_DC1394,
#if LANG_JP
		/// <summary>
		/// property for highgui class CvCapture_Android only
        /// [CV_CAP_PROP_AUTOGRAB]
		/// </summary>
#else
        /// <summary>
        /// property for highgui class CvCapture_Android only
        /// [CV_CAP_PROP_AUTOGRAB]
        /// </summary>
#endif
        AutoGrab = CvConst.CV_CAP_PROP_AUTOGRAB, 
#if LANG_JP
		/// <summary>
		/// readonly, tricky property, returns cpnst char* indeed
        /// [CV_CAP_PROP_SUPPORTED_PREVIEW_SIZES_STRING]
		/// </summary>
#else
        /// <summary>
        /// readonly, tricky property, returns cpnst char* indeed
        /// [CV_CAP_PROP_SUPPORTED_PREVIEW_SIZES_STRING]
        /// </summary>
#endif
        SupportedPreviewSizesString = CvConst.CV_CAP_PROP_SUPPORTED_PREVIEW_SIZES_STRING, 
#if LANG_JP
		/// <summary>
		/// readonly, tricky property, returns cpnst char* indeed
        /// [CV_CAP_PROP_PREVIEW_FORMAT]
		/// </summary>
#else
        /// <summary>
        /// readonly, tricky property, returns cpnst char* indeed
        /// [CV_CAP_PROP_PREVIEW_FORMAT]
        /// </summary>
#endif
        PreviewFormat = CvConst.CV_CAP_PROP_PREVIEW_FORMAT,
        #endregion

        #region OpenNI
        // Properties of cameras available through OpenNI interfaces

        /// <summary>
        /// 
        /// </summary>
        OpenNI_OutputMode = CvConst.CV_CAP_PROP_OPENNI_OUTPUT_MODE,
        /// <summary>
        /// 
        /// </summary>
        OpenNI_FrameMaxDepth = CvConst.CV_CAP_PROP_OPENNI_FRAME_MAX_DEPTH, // in mm
        /// <summary>
        /// 
        /// </summary>
        OpenNI_Baseline = CvConst.CV_CAP_PROP_OPENNI_BASELINE, // in mm
        /// <summary>
        /// 
        /// </summary>
        OpenNI_FocalLength = CvConst.CV_CAP_PROP_OPENNI_FOCAL_LENGTH, // in pixels
        /// <summary>
        /// 
        /// </summary>
        OpenNI_RegistrationON = CvConst.CV_CAP_PROP_OPENNI_REGISTRATION_ON, // flag
        /// <summary>
        /// flag that synchronizes the remapping depth map to image map
        /// by changing depth generator's view point (if the flag is "on") or
        /// sets this view point to its normal one (if the flag is "off").
        /// </summary>
        OpenNI_Registratiob = CvConst.CV_CAP_PROP_OPENNI_REGISTRATION, 
        /// <summary>
        /// 
        /// </summary>
        OpenNI_ImageGeneratorOutputMode = CvConst.CV_CAP_OPENNI_IMAGE_GENERATOR_OUTPUT_MODE,
        /// <summary>
        /// 
        /// </summary>
        OpenNI_DepthGeneratorBaseline = CvConst.CV_CAP_OPENNI_DEPTH_GENERATOR_BASELINE,
        /// <summary>
        /// 
        /// </summary>
        OpenNI_DepthGeneratorFocalLength = CvConst.CV_CAP_OPENNI_DEPTH_GENERATOR_FOCAL_LENGTH,
        /// <summary>
        /// 
        /// </summary>
        OpenNI_DepthGeneratorRegistrationON = CvConst.CV_CAP_OPENNI_DEPTH_GENERATOR_REGISTRATION_ON,
        #endregion

        #region GStreamer
        // Properties of cameras available through GStreamer interface

        /// <summary>
        /// default is 1
        /// </summary>
        GStreamerQueueLength = CvConst.CV_CAP_GSTREAMER_QUEUE_LENGTH, 
        /// <summary>
        /// ip for anable multicast master mode. 0 for disable multicast
        /// </summary>
        PvAPIMulticastIP = CvConst.CV_CAP_PROP_PVAPI_MULTICASTIP, 
        #endregion

        #region XI
        // Properties of cameras available through XIMEA SDK interface
        
        /// <summary>
        /// Change image resolution by binning or skipping. 
        /// </summary>
        XI_Downsampling = CvConst.CV_CAP_PROP_XI_DOWNSAMPLING,      
        /// <summary>
        /// Output data format.
        /// </summary>
        XI_DataFormat = CvConst.CV_CAP_PROP_XI_DATA_FORMAT,       
        /// <summary>
        /// Horizontal offset from the origin to the area of interest (in pixels).
        /// </summary>        
        XI_OffsetX = CvConst.CV_CAP_PROP_XI_OFFSET_X,      
        /// <summary>
        /// Vertical offset from the origin to the area of interest (in pixels).
        /// </summary>
        XI_OffsetY = CvConst.CV_CAP_PROP_XI_OFFSET_Y,      
        /// <summary>
        /// Defines source of trigger.
        /// </summary>
        XI_TrgSource = CvConst.CV_CAP_PROP_XI_TRG_SOURCE,     
        /// <summary>
        /// Generates an internal trigger. PRM_TRG_SOURCE must be set to TRG_SOFTWARE.
        /// </summary>
        XI_TrgSoftware = CvConst.CV_CAP_PROP_XI_TRG_SOFTWARE,      
        /// <summary>
        /// Selects general purpose input 
        /// </summary>
        XI_GpiSelector = CvConst.CV_CAP_PROP_XI_GPI_SELECTOR,     
        /// <summary>
        /// Set general purpose input mode
        /// </summary>
        XI_GpiMode = CvConst.CV_CAP_PROP_XI_GPI_MODE,     
        /// <summary>
        /// Get general purpose level
        /// </summary>
        XI_GpiLevel = CvConst.CV_CAP_PROP_XI_GPI_LEVEL,     
        /// <summary>
        /// Selects general purpose output 
        /// </summary>
        XI_GpoSelector = CvConst.CV_CAP_PROP_XI_GPO_SELECTOR,     
        /// <summary>
        /// Set general purpose output mode
        /// </summary>
        XI_GpoMode = CvConst.CV_CAP_PROP_XI_GPO_MODE,     
        /// <summary>
        /// Selects camera signalling LED 
        /// </summary>
        XI_LedSelector = CvConst.CV_CAP_PROP_XI_LED_SELECTOR,     
        /// <summary>
        /// Define camera signalling LED functionality
        /// </summary>
        XI_LedMode = CvConst.CV_CAP_PROP_XI_LED_MODE,     
        /// <summary>
        /// Calculates White Balance(must be called during acquisition)
        /// </summary>
        XI_ManualWB = CvConst.CV_CAP_PROP_XI_MANUAL_WB,     
        /// <summary>
        /// Automatic white balance
        /// </summary>
        XI_AutoWB = CvConst.CV_CAP_PROP_XI_AUTO_WB,     
        /// <summary>
        /// Automatic exposure/gain
        /// </summary>
        XI_AEAG = CvConst.CV_CAP_PROP_XI_AEAG,      
        /// <summary>
        /// Exposure priority (0.5 - exposure 50%, gain 50%).
        /// </summary>
        XI_ExpPriority = CvConst.CV_CAP_PROP_XI_EXP_PRIORITY,     
        /// <summary>
        /// Maximum limit of exposure in AEAG procedure
        /// </summary>
        XI_AEMaxLimit = CvConst.CV_CAP_PROP_XI_AE_MAX_LIMIT,     
        /// <summary>
        /// Maximum limit of gain in AEAG procedure
        /// </summary>
        XI_AGMaxLimit = CvConst.CV_CAP_PROP_XI_AG_MAX_LIMIT,     
        /// <summary>
        /// Average intensity of output signal AEAG should achieve(in %)
        /// </summary>
        XI_AEAGLevel = CvConst.CV_CAP_PROP_XI_AEAG_LEVEL,      
        /// <summary>
        /// Image capture timeout in milliseconds
        /// </summary>
        XI_Timeout = CvConst.CV_CAP_PROP_XI_TIMEOUT       
        #endregion
    }
}

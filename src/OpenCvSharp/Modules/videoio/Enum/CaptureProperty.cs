namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// CvCaptureのプロパティID
    /// </summary>
#else
    /// <summary>
    /// Property identifiers for CvCapture
    /// </summary>
#endif
    public enum CaptureProperty
    {
        #region Basic

#if LANG_JP
    /// <summary>
    /// ファイル中の現在の位置（ミリ秒単位），あるいはビデオキャプチャのタイムスタンプ値
    /// </summary>
#else
        /// <summary>
        /// Position in milliseconds from the file beginning
        /// </summary>
#endif
        PosMsec = 0,


#if LANG_JP
    /// <summary>
    /// 次にデコード/キャプチャされるフレームのインデックス．0 から始まる
    /// </summary>
#else
        /// <summary>
        /// Position in frames (only for video files)
        /// </summary>
#endif
        PosFrames = 1,

#if LANG_JP
    /// <summary>
    /// ビデオファイル内の相対的な位置 (0 - ファイルの最初，1 - ファイルの最後）
    /// </summary>
#else
        /// <summary>
        /// Position in relative units (0 - start of the file, 1 - end of the file)
        /// </summary>
#endif
        PosAviRatio = 2,

#if LANG_JP
    /// <summary>
    /// ビデオストリーム中のフレームの幅
    /// </summary>
#else
        /// <summary>
        /// Width of frames in the video stream (only for cameras)
        /// </summary>
#endif
        FrameWidth = 3,

#if LANG_JP
    /// <summary>
    /// ビデオストリーム中のフレームの高さ
    /// </summary>
#else
        /// <summary>
        /// Height of frames in the video stream (only for cameras)
        /// </summary>
#endif
        FrameHeight = 4,

#if LANG_JP
    /// <summary>
    /// フレームレート
    /// </summary>
#else
        /// <summary>
        /// Frame rate (only for cameras)
        /// </summary>
#endif
        Fps = 5,

#if LANG_JP
    /// <summary>
    /// コーデックを表す 4 文字
    /// </summary>
#else
        /// <summary>
        /// 4-character code of codec (only for cameras). 
        /// </summary>
#endif
        // ReSharper disable once InconsistentNaming
        FourCC = 6,

#if LANG_JP
    /// <summary>
    /// ビデオファイル中のフレーム数 
    /// </summary>
#else
        /// <summary>
        /// Number of frames in the video stream
        /// </summary>
#endif
        FrameCount = 7,

#if LANG_JP
    /// <summary>
    /// retrieve() によって返されるMat オブジェクトのフォーマット．
    /// </summary>
#else
        /// <summary>
        /// The format of the Mat objects returned by retrieve()
        /// </summary>
#endif
        Format = 8,

#if LANG_JP
    /// <summary>
    /// 現在のキャプチャモードを表す，バックエンド固有の値．
    /// </summary>
#else
        /// <summary>
        /// A backend-specific value indicating the current capture mode
        /// </summary>
#endif
        Mode = 9,

#if LANG_JP
    /// <summary>
    /// 明度
    /// </summary>
#else
        /// <summary>
        /// Brightness of image (only for cameras) 
        /// </summary>
#endif
        Brightness = 10,


#if LANG_JP
    /// <summary>
    /// コントラスト
    /// </summary>
#else
        /// <summary>
        /// contrast of image (only for cameras) 
        /// </summary>
#endif
        Contrast = 11,

#if LANG_JP
    /// <summary>
    /// 彩度
    /// </summary>
#else
        /// <summary>
        /// Saturation of image (only for cameras) 
        /// </summary>
#endif
        Saturation = 12,


#if LANG_JP
    /// <summary>
    /// 色相
    /// </summary>
#else
        /// <summary>
        /// hue of image (only for cameras) 
        /// </summary>
#endif
        Hue = 13,


#if LANG_JP
    /// <summary>
    /// 画像のゲイン（カメラの場合のみ）．
    /// </summary>
#else
        /// <summary>
        /// Gain of the image (only for cameras)
        /// </summary>
#endif
        Gain = 14,


#if LANG_JP
    /// <summary>
    /// 露出（カメラの場合のみ）．
    /// </summary>
#else
        /// <summary>
        /// Exposure (only for cameras)
        /// </summary>
#endif
        Exposure = 15,


#if LANG_JP
    /// <summary>
    /// 画像がRGBに変換されるか否かを表す，ブール値のフラグ．
    /// </summary>
#else
        /// <summary>
        /// Boolean flags indicating whether images should be converted to RGB
        /// </summary>
#endif
        ConvertRgb = 16,


        /// <summary>
        /// 
        /// </summary>
        WhiteBalanceBlueU = 17,


#if LANG_JP
    /// <summary>
    /// TOWRITE（注意：現在のところ，DC1394 v 2.x バックエンドでのみサポートされます）．
    /// </summary>
#else
        /// <summary>
        /// TOWRITE (note: only supported by DC1394 v 2.x backend currently)
        /// </summary>
#endif
        Rectification = 18,

        /// <summary>
        /// 
        /// </summary>
        Monocrome = 19,

        /// <summary>
        /// 
        /// </summary>
        Sharpness = 20,

        /// <summary>
        /// exposure control done by camera,
        /// user can adjust refernce level using this feature
        /// </summary>
        AutoExposure = 21,

        /// <summary>
        /// 
        /// </summary>
        Gamma = 22,

        /// <summary>
        /// 
        /// </summary>
        Temperature = 23,

        /// <summary>
        /// 
        /// </summary>
        Trigger = 24,

        /// <summary>
        /// 
        /// </summary>
        TriggerDelay = 25,

        /// <summary>
        /// 
        /// </summary>
        WhiteBalanceRedV = 26,

        /// <summary>
        /// 
        /// </summary>
        Zoom = 27,

        /// <summary>
        /// 
        /// </summary>
        Focus = 28,

        /// <summary>
        /// 
        /// </summary>
        Guid = 29,

        /// <summary>
        /// 
        /// </summary>
        IsoSpeed = 30,

        /// <summary>
        /// 
        /// </summary>
        BackLight = 32,

        /// <summary>
        /// 
        /// </summary>
        Pan = 33,

        /// <summary>
        /// 
        /// </summary>
        Tilt = 34,

        /// <summary>
        /// 
        /// </summary>
        Roll = 35,

        /// <summary>
        /// 
        /// </summary>
        Iris = 36,

        /// <summary>
        /// Pop up video/camera filter dialog (note: only supported by DSHOW backend currently. Property value is ignored)
        /// </summary>
        Settings = 37,

        /// <summary>
        /// 
        /// </summary>
        BufferSize = 38,

        /// <summary>
        /// 
        /// </summary>
        AutoFocus = 39,

        #endregion

        #region OpenNI

        // Properties of cameras available through OpenNI interfaces

        /// <summary>
        /// 
        /// </summary>
        OpenNI_OutputMode = 100,

        /// <summary>
        /// in mm
        /// </summary>
        OpenNI_FrameMaxDepth = 101,

        /// <summary>
        /// in mm
        /// </summary>
        OpenNI_Baseline = 102,

        /// <summary>
        /// in pixels
        /// </summary>
        OpenNI_FocalLength = 103,

        /// <summary>
        /// flag that synchronizes the remapping depth map to image map
        /// by changing depth generator's view point (if the flag is "on") or
        /// sets this view point to its normal one (if the flag is "off").
        /// </summary>
        OpenNI_Registration = 104,

        /// <summary>
        /// 
        /// </summary>
        OPENNI_ApproxFrameSync = 105,

        /// <summary>
        /// 
        /// </summary>
        OPENNI_MaxBufferSize = 106,

        /// <summary>
        /// 
        /// </summary>
        OPENNI_CircleBuffer = 107,

        /// <summary>
        /// 
        /// </summary>
        OPENNI_MaxTimeDuration = 108,

        /// <summary>
        /// 
        /// </summary>
        OPENNI_GeneratorPresent = 109,

        /// <summary>
        /// 
        /// </summary>
        OPENNI2_Sync = 110,

        /// <summary>
        /// 
        /// </summary>
        OPENNI2_Mirror = 111,

        /// <summary>
        /// 
        /// </summary>
        OpenNI_DepthGenerator = 1 << 31,

        /// <summary>
        /// 
        /// </summary>
        OpenNI_ImageGenerator = 1 << 30,

        /// <summary>
        /// 
        /// </summary>
        OpenNI_ImageGeneratorPresent = OpenNI_ImageGenerator + OPENNI_GeneratorPresent,


        /// <summary>
        /// 
        /// </summary>
        OpenNI_ImageGeneratorOutputMode = OpenNI_ImageGenerator + OpenNI_OutputMode,

        /// <summary>
        /// 
        /// </summary>
        OpenNI_DepthGeneratorBaseline = OpenNI_ImageGenerator + OpenNI_Baseline,

        /// <summary>
        /// 
        /// </summary>
        OpenNI_DepthGeneratorFocalLength = OpenNI_ImageGenerator + OpenNI_FocalLength,

        /// <summary>
        /// 
        /// </summary>
        OpenNI_DepthGeneratorRegistrationON = OpenNI_ImageGenerator + OpenNI_Registration,

        #endregion

        #region GStreamer

        // Properties of cameras available through GStreamer interface

        /// <summary>
        /// default is 1
        /// </summary>
        GStreamerQueueLength = 200,

        #endregion

        #region PVAPI

        /// <summary>
        /// ip for anable multicast master mode. 0 for disable multicast
        /// </summary>
        PvAPIMulticastIP = 300,

        /// <summary>
        /// Determines how a frame is initiated
        /// </summary>
        PVAPI_FrameStartTriggerMode = 301, 

        /// <summary>
        /// Horizontal sub-sampling of the image
        /// </summary>
        PVAPI_DecimationHorizontal = 302, 

        /// <summary>
        /// Vertical sub-sampling of the image
        /// </summary>
        PVAPI_DecimationVertical = 303, 

        /// <summary>
        /// Horizontal binning factor
        /// </summary>
        PVAPI_BinningX = 304, 

        /// <summary>
        /// Vertical binning factor
        /// </summary>
        PVAPI_BinningY = 305, 

        /// <summary>
        /// Pixel format
        /// </summary>
        PVAPI_PixelFormat = 306,

        #endregion

        #region XI

        // Properties of cameras available through XIMEA SDK interface

        /// <summary>
        /// Change image resolution by binning or skipping. 
        /// </summary>
        XI_Downsampling = 400,

        /// <summary>
        /// Output data format.
        /// </summary>
        XI_DataFormat = 401,

        /// <summary>
        /// Horizontal offset from the origin to the area of interest (in pixels).
        /// </summary>        
        XI_OffsetX = 402,

        /// <summary>
        /// Vertical offset from the origin to the area of interest (in pixels).
        /// </summary>
        XI_OffsetY = 403,

        /// <summary>
        /// Defines source of trigger.
        /// </summary>
        XI_TrgSource = 404,

        /// <summary>
        /// Generates an internal trigger. PRM_TRG_SOURCE must be set to TRG_SOFTWARE.
        /// </summary>
        XI_TrgSoftware = 405,

        /// <summary>
        /// Selects general purpose input 
        /// </summary>
        XI_GpiSelector = 406,

        /// <summary>
        /// Set general purpose input mode
        /// </summary>
        XI_GpiMode = 407,

        /// <summary>
        /// Get general purpose level
        /// </summary>
        XI_GpiLevel = 408,

        /// <summary>
        /// Selects general purpose output 
        /// </summary>
        XI_GpoSelector = 409,

        /// <summary>
        /// Set general purpose output mode
        /// </summary>
        XI_GpoMode = 410,

        /// <summary>
        /// Selects camera signalling LED 
        /// </summary>
        XI_LedSelector = 411,

        /// <summary>
        /// Define camera signalling LED functionality
        /// </summary>
        XI_LedMode = 412,

        /// <summary>
        /// Calculates White Balance(must be called during acquisition)
        /// </summary>
        XI_ManualWB = 413,

        /// <summary>
        /// Automatic white balance
        /// </summary>
        XI_AutoWB = 414,

        /// <summary>
        /// Automatic exposure/gain
        /// </summary>
        XI_AEAG = 415,

        /// <summary>
        /// Exposure priority (0.5 - exposure 50%, gain 50%).
        /// </summary>
        XI_ExpPriority = 416,

        /// <summary>
        /// Maximum limit of exposure in AEAG procedure
        /// </summary>
        XI_AEMaxLimit = 417,

        /// <summary>
        /// Maximum limit of gain in AEAG procedure
        /// </summary>
        XI_AGMaxLimit = 418,

        /// <summary>
        /// Average intensity of output signal AEAG should achieve(in %)
        /// </summary>
        XI_AEAGLevel = 419,

        /// <summary>
        /// Image capture timeout in milliseconds
        /// </summary>
        XI_Timeout = 420,

        #endregion

        #region iOS

        /// <summary>
        /// 
        /// </summary>
        IOS_DeviceFocus        = 9001,

        /// <summary>
        /// 
        /// </summary>
        IOS_DeviceExposure     = 9002,

        /// <summary>
        /// 
        /// </summary>
        IOS_DeviceFlash      = 9003,

        /// <summary>
        /// 
        /// </summary>
        IOS_DeviceWhiteBalance = 9004,

        /// <summary>
        /// 
        /// </summary>
        IOS_DeviceTorch        = 9005,

        #endregion

        #region GIGA

        /// <summary>
        /// 
        /// </summary>
        GIGA_FrameOffsetX   = 10001,

        /// <summary>
        /// 
        /// </summary>
        GIGA_FrameOffsetY   = 10002,

        /// <summary>
        /// 
        /// </summary>
        GIGA_FrameWidthMax  = 10003,

        /// <summary>
        /// 
        /// </summary>
        GIGA_FrameHeightMax  = 10004,

        /// <summary>
        /// 
        /// </summary>
        GIGA_FrameSensWidth = 10005,

        /// <summary>
        /// 
        /// </summary>
        GIGA_FrameSensHeight = 10006,

        #endregion

        #region INTELPERC

        /// <summary>
        /// 
        /// </summary>
        INTELPERC_ProfileCount               = 11001,

        /// <summary>
        /// 
        /// </summary>
        INTELPERC_ProfileIdx                 = 11002,

        /// <summary>
        /// 
        /// </summary>
        INTELPERC_DepthLowConfidenceValue  = 11003,

        /// <summary>
        /// 
        /// </summary>
        INTELPERC_DepthSaturationValue      = 11004,

        /// <summary>
        /// 
        /// </summary>
        INTELPERC_DepthConfidenceThreshold  = 11005,

        /// <summary>
        /// 
        /// </summary>
        INTELPERC_DepthFocalLengthHorz     = 11006,

        /// <summary>
        /// 
        /// </summary>
        INTELPERC_DepthFocalLengthVert = 11007,

        #endregion

        #region gPhoto2

        /// <summary>
        /// Capture only preview from liveview mode.
        /// </summary>
        GPhoto2_Preview           = 17001,  

        /// <summary>
        /// Readonly, returns (const char *).
        /// </summary>
        GPhoto2_WidgetEnumerate = 17002,  

        /// <summary>
        /// Trigger, only by set. Reload camera settings.
        /// </summary>
        GPhoto2_ReloadConfig = 17003,  

        /// <summary>
        /// Reload all settings on set.
        /// </summary>
        GPhoto2_ReloadOnChange = 17004,  

        /// <summary>
        /// Collect messages with details.
        /// </summary>
        GPhoto2_CollectMsgs = 17005,  

        /// <summary>
        /// Readonly, returns (const char *).
        /// </summary>
        GPhoto2_FlushMsgs = 17006,  

        /// <summary>
        /// Exposure speed. Can be readonly, depends on camera program.
        /// </summary>
        Speed                     = 17007,  
      
        /// <summary>
        /// Aperture. Can be readonly, depends on camera program.
        /// </summary>
        Aperture                  = 17008,  
        
        /// <summary>
        /// Camera exposure program.
        /// </summary>
        ExposureProgram           = 17009,  
       
        /// <summary>
        /// Enter liveview mode.
        /// </summary>
        ViewFinder                = 17010,  

        #endregion
    }
}

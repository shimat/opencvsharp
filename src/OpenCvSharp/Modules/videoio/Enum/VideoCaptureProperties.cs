using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Property identifiers for CvCapture
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/d3bc563c6e01c2bc153f23e7393322a95c7d3974/modules/videoio/include/opencv2/videoio.hpp#L133
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1717: Only FlagsAttribute enums should have plural names")]
public enum VideoCaptureProperties
{
    #region Basic

    /// <summary>
    /// Position in milliseconds from the file beginning
    /// </summary>
    PosMsec = 0,

    /// <summary>
    /// Position in frames (only for video files)
    /// </summary>
    PosFrames = 1,

    /// <summary>
    /// Position in relative units (0 - start of the file, 1 - end of the file)
    /// </summary>
    PosAviRatio = 2,

    /// <summary>
    /// Width of frames in the video stream (only for cameras)
    /// </summary>
    FrameWidth = 3,

    /// <summary>
    /// Height of frames in the video stream (only for cameras)
    /// </summary>
    FrameHeight = 4,

    /// <summary>
    /// Frame rate (only for cameras)
    /// </summary>
    Fps = 5,

    /// <summary>
    /// 4-character code of codec (only for cameras). 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    FourCC = 6,

    /// <summary>
    /// Number of frames in the video stream
    /// </summary>
    FrameCount = 7,

    /// <summary>
    /// The format of the Mat objects returned by retrieve()
    /// </summary>
    Format = 8,

    /// <summary>
    /// A backend-specific value indicating the current capture mode
    /// </summary>
    Mode = 9,

    /// <summary>
    /// Brightness of image (only for cameras) 
    /// </summary>
    Brightness = 10,

    /// <summary>
    /// contrast of image (only for cameras) 
    /// </summary>
    Contrast = 11,

    /// <summary>
    /// Saturation of image (only for cameras) 
    /// </summary>
    Saturation = 12,

    /// <summary>
    /// hue of image (only for cameras) 
    /// </summary>
    Hue = 13,

    /// <summary>
    /// Gain of the image (only for cameras)
    /// </summary>
    Gain = 14,

    /// <summary>
    /// Exposure (only for cameras)
    /// </summary>
    Exposure = 15,

    /// <summary>
    /// Boolean flags indicating whether images should be converted to RGB
    /// </summary>
    ConvertRgb = 16,

    /// <summary>
    /// 
    /// </summary>
    WhiteBalanceBlueU = 17,

    /// <summary>
    /// TOWRITE (note: only supported by DC1394 v 2.x backend currently)
    /// </summary>
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

    /// <summary>
    /// Sample aspect ratio: num/den (num)
    /// </summary>
    SARNum = 40,

    /// <summary>
    /// Sample aspect ratio: num/den (den)
    /// </summary>
    SARDen = 41,

    /// <summary>
    /// Current backend (enum VideoCaptureAPIs). Read-only property
    /// </summary>
    Backend = 42,

    /// <summary>
    /// Video input or Channel Number (only for those cameras that support)
    /// </summary>
    Channel = 43,

    /// <summary>
    /// enable/ disable auto white-balance
    /// </summary>
    AutoWB = 44,

    /// <summary>
    /// white-balance color temperature
    /// </summary>
    WBTemperature = 45,

    /// <summary>
    /// (read-only) codec's pixel format. 4-character code - see VideoWriter::fourcc . Subset of [AV_PIX_FMT_*](https://github.com/FFmpeg/FFmpeg/blob/master/libavcodec/raw.c) or -1 if unknown
    /// </summary>
    CodecPixelFormat = 46,

    /// <summary>
    /// (read-only) Video bitrate in kbits/s
    /// </summary>
    BitRate = 47,

    /// <summary>
    /// (read-only) Frame rotation defined by stream meta (applicable for FFmpeg back-end only)
    /// </summary>
    OrientationMeta = 48,

    /// <summary>
    /// if true - rotates output frames of CvCapture considering video file's metadata  (applicable for FFmpeg back-end only) (https://github.com/opencv/opencv/issues/15499)
    /// </summary>
    OrientationAuto = 49,

    /// <summary>
    /// (open-only) Hardware acceleration type (see VideoAccelerationType). 
    /// Setting supported only via params parameter in cv::VideoCapture constructor / .open() method. 
    /// Default value is backend-specific.
    /// </summary>
    HwAcceleration = 50,

    /// <summary>
    /// (open-only) Hardware device index (select GPU if multiple available). Device enumeration is acceleration type specific.
    /// </summary>
    HwDevice = 51,

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
    IOS_DeviceFocus = 9001,

    /// <summary>
    /// 
    /// </summary>
    IOS_DeviceExposure = 9002,

    /// <summary>
    /// 
    /// </summary>
    IOS_DeviceFlash = 9003,

    /// <summary>
    /// 
    /// </summary>
    IOS_DeviceWhiteBalance = 9004,

    /// <summary>
    /// 
    /// </summary>
    IOS_DeviceTorch = 9005,

    #endregion

    #region GIGA

    /// <summary>
    /// 
    /// </summary>
    GIGA_FrameOffsetX = 10001,

    /// <summary>
    /// 
    /// </summary>
    GIGA_FrameOffsetY = 10002,

    /// <summary>
    /// 
    /// </summary>
    GIGA_FrameWidthMax = 10003,

    /// <summary>
    /// 
    /// </summary>
    GIGA_FrameHeightMax = 10004,

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
    INTELPERC_ProfileCount = 11001,

    /// <summary>
    /// 
    /// </summary>
    INTELPERC_ProfileIdx = 11002,

    /// <summary>
    /// 
    /// </summary>
    INTELPERC_DepthLowConfidenceValue = 11003,

    /// <summary>
    /// 
    /// </summary>
    INTELPERC_DepthSaturationValue = 11004,

    /// <summary>
    /// 
    /// </summary>
    INTELPERC_DepthConfidenceThreshold = 11005,

    /// <summary>
    /// 
    /// </summary>
    INTELPERC_DepthFocalLengthHorz = 11006,

    /// <summary>
    /// 
    /// </summary>
    INTELPERC_DepthFocalLengthVert = 11007,

    #endregion

    #region gPhoto2

    /// <summary>
    /// Capture only preview from liveview mode.
    /// </summary>
    GPhoto2_Preview = 17001,

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
    Speed = 17007,

    /// <summary>
    /// Aperture. Can be readonly, depends on camera program.
    /// </summary>
    Aperture = 17008,

    /// <summary>
    /// Camera exposure program.
    /// </summary>
    ExposureProgram = 17009,

    /// <summary>
    /// Enter liveview mode.
    /// </summary>
    ViewFinder = 17010,

    #endregion
}

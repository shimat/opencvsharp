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

    /// <summary>
    /// (open-only) If non-zero, create new OpenCL context and bind it to current thread. The OpenCL context created with
    /// Video Acceleration context attached it (if not attached yet) for optimized GPU data copy between HW accelerated
    /// decoder and cv::UMat.
    /// </summary>
    HwAccelerationUseOpenCL = 52,

    /// <summary>
    /// (open-only) timeout in milliseconds for opening a video capture (applicable for FFmpeg and GStreamer back-ends only)
    /// </summary>
    OpenTimeoutMsec = 53,

    /// <summary>
    /// (open-only) timeout in milliseconds for reading from a video capture (applicable for FFmpeg and GStreamer back-ends only)
    /// </summary>
    ReadTimeoutMsec = 54,

    /// <summary>
    /// (read-only) time in microseconds since Jan 1 1970 when stream was opened. Applicable for FFmpeg backend only.
    /// Useful for RTSP and other live streams
    /// </summary>
    StreamOpenTimeUsec = 55,

    /// <summary>
    /// (read-only) Number of video channels
    /// </summary>
    VideoTotalChannels = 56,

    /// <summary>
    /// (open-only) Specify video stream, 0-based index. Use -1 to disable video stream from file or IP cameras.
    /// Default value is 0.
    /// </summary>
    VideoStream = 57,

    /// <summary>
    /// (open-only) Specify stream in multi-language media files, -1 - disable audio processing or microphone.
    /// Default value is -1.
    /// </summary>
    AudioStream = 58,

    /// <summary>
    /// (read-only) Audio position is measured in samples. Accurate audio sample timestamp of previous grabbed fragment.
    /// See AudioSamplesPerSecond and AudioShiftNsec.
    /// </summary>
    AudioPos = 59,

    /// <summary>
    /// (read only) Contains the time difference between the start of the audio stream and the video stream in nanoseconds.
    /// Positive value means that audio is started after the first video frame.
    /// Negative value means that audio is started before the first video frame.
    /// </summary>
    AudioShiftNsec = 60,

    /// <summary>
    /// (open, read) Alternative definition to bits-per-sample, but with clear handling of 32F / 32S
    /// </summary>
    AudioDataDepth = 61,

    /// <summary>
    /// (open, read) determined from file/codec input. If not specified, then selected audio sample rate is 44100
    /// </summary>
    AudioSamplesPerSecond = 62,

    /// <summary>
    /// (read-only) Index of the first audio channel for .retrieve() calls. That audio channel number continues
    /// enumeration after video channels.
    /// </summary>
    AudioBaseIndex = 63,

    /// <summary>
    /// (read-only) Number of audio channels in the selected audio stream (mono, stereo, etc)
    /// </summary>
    AudioTotalChannels = 64,

    /// <summary>
    /// (read-only) Number of audio streams.
    /// </summary>
    AudioTotalStreams = 65,

    /// <summary>
    /// (open, read) Enables audio synchronization.
    /// </summary>
    AudioSynchronize = 66,

    /// <summary>
    /// FFmpeg back-end only - Indicates whether the Last Raw Frame (LRF), output from VideoCapture.Read() when
    /// VideoCapture is initialized with VideoCapture.Open(VideoCaptureAPIs.FFMPEG, [Format, -1]) or
    /// Set(Format, -1) is called before the first call to VideoCapture.Read(), contains encoded data for a key frame.
    /// </summary>
    LrfHasKeyFrame = 67,

    /// <summary>
    /// Positive index indicates that returning extra data is supported by the video back end. This can be retrieved
    /// as cap.Retrieve(data, &lt;returned index&gt;). E.g. When reading from a h264 encoded RTSP stream, the FFmpeg
    /// backend could return the SPS and/or PPS if available (if sent in reply to a DESCRIBE request), from calls to
    /// cap.Retrieve(data, &lt;returned index&gt;).
    /// </summary>
    CodecExtradataIndex = 68,

    /// <summary>
    /// (read-only) FFmpeg back-end only - Frame type ascii code (73 = 'I', 80 = 'P', 66 = 'B' or 63 = '?' if unknown)
    /// of the most recently read frame.
    /// </summary>
    FrameType = 69,

    /// <summary>
    /// (open-only) Set the maximum number of threads to use. Use 0 to use as many threads as CPU cores
    /// (applicable for FFmpeg back-end only).
    /// </summary>
    NThreads = 70,

    /// <summary>
    /// (read-only) FFmpeg back-end only - presentation timestamp of the most recently read frame using the FPS time
    /// base. e.g. fps = 25, VideoCapture.Get(Pts) = 3, presentation time = 3/25 seconds.
    /// </summary>
    Pts = 71,

    /// <summary>
    /// (read-only) FFmpeg back-end only - maximum difference between presentation (pts) and decompression timestamps
    /// (dts) using FPS time base. e.g. delay is maximum when frame_num = 0, if true, VideoCapture.Get(Pts) = 0 and
    /// VideoCapture.Get(DtsDelay) = 2, dts = -2. Non zero values usually imply the stream is encoded using B-frames
    /// which are not decoded in presentation order.
    /// </summary>
    DtsDelay = 72,

    /// <summary>
    /// (open-only) Start number for image sequences opened with a printf-style pattern (e.g. `frame_%05d.dpx`).
    /// Sets the initial frame number and disables automatic first-frame detection. Applicable to
    /// VideoCaptureAPIs.FFMPEG (passed as the image2 demuxer `start_number`) and VideoCaptureAPIs.IMAGES backends.
    /// Default: not set (automatic detection).
    /// </summary>
    ImageSeqStart = 73,

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
    OpenNI_IrGenerator = 1 << 29,

    /// <summary>
    ///
    /// </summary>
    OpenNI_GeneratorsMask = OpenNI_DepthGenerator + OpenNI_ImageGenerator + OpenNI_IrGenerator,

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
    OpenNI_DepthGeneratorPresent = OpenNI_DepthGenerator + OPENNI_GeneratorPresent,

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

    /// <summary>
    ///
    /// </summary>
    OpenNI_IrGeneratorPresent = OpenNI_IrGenerator + OPENNI_GeneratorPresent,

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

    /// <summary>
    /// Exposure time in microseconds.
    /// </summary>
    XI_Exposure = 421,

    /// <summary>
    /// Sets the number of times of exposure in one frame.
    /// </summary>
    XI_ExposureBurstCount = 422,

    /// <summary>
    /// Gain selector for parameter Gain allows to select different type of gains.
    /// </summary>
    XI_GainSelector = 423,

    /// <summary>
    /// Gain in dB.
    /// </summary>
    XI_Gain = 424,

    /// <summary>
    /// Change image downsampling type.
    /// </summary>
    XI_DownsamplingType = 426,

    /// <summary>
    /// Binning engine selector.
    /// </summary>
    XI_BinningSelector = 427,

    /// <summary>
    /// Vertical Binning - number of vertical photo-sensitive cells to combine together.
    /// </summary>
    XI_BinningVertical = 428,

    /// <summary>
    /// Horizontal Binning - number of horizontal photo-sensitive cells to combine together.
    /// </summary>
    XI_BinningHorizontal = 429,

    /// <summary>
    /// Binning pattern type.
    /// </summary>
    XI_BinningPattern = 430,

    /// <summary>
    /// Decimation engine selector.
    /// </summary>
    XI_DecimationSelector = 431,

    /// <summary>
    /// Vertical Decimation - vertical sub-sampling of the image - reduces the vertical resolution of the image by the specified vertical decimation factor.
    /// </summary>
    XI_DecimationVertical = 432,

    /// <summary>
    /// Horizontal Decimation - horizontal sub-sampling of the image - reduces the horizontal resolution of the image by the specified vertical decimation factor.
    /// </summary>
    XI_DecimationHorizontal = 433,

    /// <summary>
    /// Decimation pattern type.
    /// </summary>
    XI_DecimationPattern = 434,

    /// <summary>
    /// Output data format.
    /// </summary>
    XI_ImageDataFormat = 435,

    /// <summary>
    /// Change sensor shutter type(CMOS sensor).
    /// </summary>
    XI_ShutterType = 436,

    /// <summary>
    /// Number of taps.
    /// </summary>
    XI_SensorTaps = 437,

    /// <summary>
    /// Automatic exposure/gain ROI offset X.
    /// </summary>
    XI_AEAGRoiOffsetX = 439,

    /// <summary>
    /// Automatic exposure/gain ROI offset Y.
    /// </summary>
    XI_AEAGRoiOffsetY = 440,

    /// <summary>
    /// Automatic exposure/gain ROI Width.
    /// </summary>
    XI_AEAGRoiWidth = 441,

    /// <summary>
    /// Automatic exposure/gain ROI Height.
    /// </summary>
    XI_AEAGRoiHeight = 442,

    /// <summary>
    /// Correction of bad pixels.
    /// </summary>
    XI_BPC = 445,

    /// <summary>
    /// White balance red coefficient.
    /// </summary>
    XI_WBKr = 448,

    /// <summary>
    /// White balance green coefficient.
    /// </summary>
    XI_WBKg = 449,

    /// <summary>
    /// White balance blue coefficient.
    /// </summary>
    XI_WBKb = 450,

    /// <summary>
    /// Width of the Image provided by the device (in pixels).
    /// </summary>
    XI_Width = 451,

    /// <summary>
    /// Height of the Image provided by the device (in pixels).
    /// </summary>
    XI_Height = 452,

    /// <summary>
    /// Set/get bandwidth(datarate)(in Megabits).
    /// </summary>
    XI_LimitBandwidth = 459,

    /// <summary>
    /// Sensor output data bit depth.
    /// </summary>
    XI_SensorDataBitDepth = 460,

    /// <summary>
    /// Device output data bit depth.
    /// </summary>
    XI_OutputDataBitDepth = 461,

    /// <summary>
    /// bitdepth of data returned by function xiGetImage.
    /// </summary>
    XI_ImageDataBitDepth = 462,

    /// <summary>
    /// Device output data packing (or grouping) enabled. Packing could be enabled if output_data_bit_depth &gt; 8 and packing capability is available.
    /// </summary>
    XI_OutputDataPacking = 463,

    /// <summary>
    /// Data packing type. Some cameras supports only specific packing type.
    /// </summary>
    XI_OutputDataPackingType = 464,

    /// <summary>
    /// Returns 1 for cameras that support cooling.
    /// </summary>
    XI_IsCooled = 465,

    /// <summary>
    /// Start camera cooling.
    /// </summary>
    XI_Cooling = 466,

    /// <summary>
    /// Set sensor target temperature for cooling.
    /// </summary>
    XI_TargetTemp = 467,

    /// <summary>
    /// Camera sensor temperature.
    /// </summary>
    XI_ChipTemp = 468,

    /// <summary>
    /// Camera housing temperature.
    /// </summary>
    XI_HousTemp = 469,

    /// <summary>
    /// Mode of color management system.
    /// </summary>
    XI_CMS = 470,

    /// <summary>
    /// Enable applying of CMS profiles to xiGetImage (see XI_PRM_INPUT_CMS_PROFILE, XI_PRM_OUTPUT_CMS_PROFILE).
    /// </summary>
    XI_ApplyCMS = 471,

    /// <summary>
    /// Returns 1 for color cameras.
    /// </summary>
    XI_ImageIsColor = 474,

    /// <summary>
    /// Returns color filter array type of RAW data.
    /// </summary>
    XI_ColorFilterArray = 475,

    /// <summary>
    /// Luminosity gamma.
    /// </summary>
    XI_GammaY = 476,

    /// <summary>
    /// Chromaticity gamma.
    /// </summary>
    XI_GammaC = 477,

    /// <summary>
    /// Sharpness Strength.
    /// </summary>
    XI_Sharpness = 478,

    /// <summary>
    /// Color Correction Matrix element [0][0].
    /// </summary>
    XI_CCMatrix00 = 479,

    /// <summary>
    /// Color Correction Matrix element [0][1].
    /// </summary>
    XI_CCMatrix01 = 480,

    /// <summary>
    /// Color Correction Matrix element [0][2].
    /// </summary>
    XI_CCMatrix02 = 481,

    /// <summary>
    /// Color Correction Matrix element [0][3].
    /// </summary>
    XI_CCMatrix03 = 482,

    /// <summary>
    /// Color Correction Matrix element [1][0].
    /// </summary>
    XI_CCMatrix10 = 483,

    /// <summary>
    /// Color Correction Matrix element [1][1].
    /// </summary>
    XI_CCMatrix11 = 484,

    /// <summary>
    /// Color Correction Matrix element [1][2].
    /// </summary>
    XI_CCMatrix12 = 485,

    /// <summary>
    /// Color Correction Matrix element [1][3].
    /// </summary>
    XI_CCMatrix13 = 486,

    /// <summary>
    /// Color Correction Matrix element [2][0].
    /// </summary>
    XI_CCMatrix20 = 487,

    /// <summary>
    /// Color Correction Matrix element [2][1].
    /// </summary>
    XI_CCMatrix21 = 488,

    /// <summary>
    /// Color Correction Matrix element [2][2].
    /// </summary>
    XI_CCMatrix22 = 489,

    /// <summary>
    /// Color Correction Matrix element [2][3].
    /// </summary>
    XI_CCMatrix23 = 490,

    /// <summary>
    /// Color Correction Matrix element [3][0].
    /// </summary>
    XI_CCMatrix30 = 491,

    /// <summary>
    /// Color Correction Matrix element [3][1].
    /// </summary>
    XI_CCMatrix31 = 492,

    /// <summary>
    /// Color Correction Matrix element [3][2].
    /// </summary>
    XI_CCMatrix32 = 493,

    /// <summary>
    /// Color Correction Matrix element [3][3].
    /// </summary>
    XI_CCMatrix33 = 494,

    /// <summary>
    /// Set default Color Correction Matrix.
    /// </summary>
    XI_DefaultCCMatrix = 495,

    /// <summary>
    /// Selects the type of trigger.
    /// </summary>
    XI_TrgSelector = 498,

    /// <summary>
    /// Sets number of frames acquired by burst. This burst is used only if trigger is set to FrameBurstStart.
    /// </summary>
    XI_AcqFrameBurstCount = 499,

    /// <summary>
    /// Enable/Disable debounce to selected GPI.
    /// </summary>
    XI_DebounceEn = 507,

    /// <summary>
    /// Debounce time (x * 10us).
    /// </summary>
    XI_DebounceT0 = 508,

    /// <summary>
    /// Debounce time (x * 10us).
    /// </summary>
    XI_DebounceT1 = 509,

    /// <summary>
    /// Debounce polarity (pol = 1 t0 - falling edge, t1 - rising edge).
    /// </summary>
    XI_DebouncePol = 510,

    /// <summary>
    /// Status of lens control interface. This shall be set to XI_ON before any Lens operations.
    /// </summary>
    XI_LensMode = 511,

    /// <summary>
    /// Current lens aperture value in stops. Examples: 2.8, 4, 5.6, 8, 11.
    /// </summary>
    XI_LensApertureValue = 512,

    /// <summary>
    /// Lens current focus movement value to be used by XI_PRM_LENS_FOCUS_MOVE in motor steps.
    /// </summary>
    XI_LensFocusMovementValue = 513,

    /// <summary>
    /// Moves lens focus motor by steps set in XI_PRM_LENS_FOCUS_MOVEMENT_VALUE.
    /// </summary>
    XI_LensFocusMove = 514,

    /// <summary>
    /// Lens focus distance in cm.
    /// </summary>
    XI_LensFocusDistance = 515,

    /// <summary>
    /// Lens focal distance in mm.
    /// </summary>
    XI_LensFocalLength = 516,

    /// <summary>
    /// Selects the current feature which is accessible by XI_PRM_LENS_FEATURE.
    /// </summary>
    XI_LensFeatureSelector = 517,

    /// <summary>
    /// Allows access to lens feature value currently selected by XI_PRM_LENS_FEATURE_SELECTOR.
    /// </summary>
    XI_LensFeature = 518,

    /// <summary>
    /// Returns device model id.
    /// </summary>
    XI_DeviceModelId = 521,

    /// <summary>
    /// Returns device serial number.
    /// </summary>
    XI_DeviceSN = 522,

    /// <summary>
    /// The alpha channel of RGB32 output image format.
    /// </summary>
    XI_ImageDataFormatRGB32Alpha = 529,

    /// <summary>
    /// Buffer size in bytes sufficient for output image returned by xiGetImage.
    /// </summary>
    XI_ImagePayloadSize = 530,

    /// <summary>
    /// Current format of pixels on transport layer.
    /// </summary>
    XI_TransportPixelFormat = 531,

    /// <summary>
    /// Sensor clock frequency in Hz.
    /// </summary>
    XI_SensorClockFreqHz = 532,

    /// <summary>
    /// Sensor clock frequency index. Sensor with selected frequencies have possibility to set the frequency only by this index.
    /// </summary>
    XI_SensorClockFreqIndex = 533,

    /// <summary>
    /// Number of output channels from sensor used for data transfer.
    /// </summary>
    XI_SensorOutputChannelCount = 534,

    /// <summary>
    /// Define framerate in Hz.
    /// </summary>
    XI_Framerate = 535,

    /// <summary>
    /// Select counter.
    /// </summary>
    XI_CounterSelector = 536,

    /// <summary>
    /// Counter status.
    /// </summary>
    XI_CounterValue = 537,

    /// <summary>
    /// Type of sensor frames timing.
    /// </summary>
    XI_AcqTimingMode = 538,

    /// <summary>
    /// Calculate and returns available interface bandwidth(int Megabits).
    /// </summary>
    XI_AvailableBandwidth = 539,

    /// <summary>
    /// Data move policy.
    /// </summary>
    XI_BufferPolicy = 540,

    /// <summary>
    /// Activates LUT.
    /// </summary>
    XI_LutEn = 541,

    /// <summary>
    /// Control the index (offset) of the coefficient to access in the LUT.
    /// </summary>
    XI_LutIndex = 542,

    /// <summary>
    /// Value at entry LUTIndex of the LUT.
    /// </summary>
    XI_LutValue = 543,

    /// <summary>
    /// Specifies the delay in microseconds (us) to apply after the trigger reception before activating it.
    /// </summary>
    XI_TrgDelay = 544,

    /// <summary>
    /// Defines how time stamp reset engine will be armed.
    /// </summary>
    XI_TsRstMode = 545,

    /// <summary>
    /// Defines which source will be used for timestamp reset. Writing this parameter will trigger settings of engine (arming).
    /// </summary>
    XI_TsRstSource = 546,

    /// <summary>
    /// Returns 1 if camera connected and works properly.
    /// </summary>
    XI_IsDeviceExist = 547,

    /// <summary>
    /// Acquisition buffer size in buffer_size_unit. Default bytes.
    /// </summary>
    XI_AcqBufferSize = 548,

    /// <summary>
    /// Acquisition buffer size unit in bytes. Default 1. E.g. Value 1024 means that buffer_size is in KiBytes.
    /// </summary>
    XI_AcqBufferSizeUnit = 549,

    /// <summary>
    /// Acquisition transport buffer size in bytes.
    /// </summary>
    XI_AcqTransportBufferSize = 550,

    /// <summary>
    /// Queue of field/frame buffers.
    /// </summary>
    XI_BuffersQueueSize = 551,

    /// <summary>
    /// Number of buffers to commit to low level.
    /// </summary>
    XI_AcqTransportBufferCommit = 552,

    /// <summary>
    /// GetImage returns most recent frame.
    /// </summary>
    XI_RecentFrame = 553,

    /// <summary>
    /// Resets the camera to default state.
    /// </summary>
    XI_DeviceReset = 554,

    /// <summary>
    /// Correction of column FPN.
    /// </summary>
    XI_ColumnFPNCorrection = 555,

    /// <summary>
    /// Current sensor mode. Allows to select sensor mode by one integer. Setting of this parameter affects: image dimensions and downsampling.
    /// </summary>
    XI_SensorMode = 558,

    /// <summary>
    /// Enable High Dynamic Range feature.
    /// </summary>
    XI_HDR = 559,

    /// <summary>
    /// The number of kneepoints in the PWLR.
    /// </summary>
    XI_HDRKneepointCount = 560,

    /// <summary>
    /// Position of first kneepoint(in % of XI_PRM_EXPOSURE).
    /// </summary>
    XI_HDRT1 = 561,

    /// <summary>
    /// Position of second kneepoint (in % of XI_PRM_EXPOSURE).
    /// </summary>
    XI_HDRT2 = 562,

    /// <summary>
    /// Value of first kneepoint (% of sensor saturation).
    /// </summary>
    XI_Kneepoint1 = 563,

    /// <summary>
    /// Value of second kneepoint (% of sensor saturation).
    /// </summary>
    XI_Kneepoint2 = 564,

    /// <summary>
    /// Last image black level counts. Can be used for Offline processing to recall it.
    /// </summary>
    XI_ImageBlackLevel = 565,

    /// <summary>
    /// Returns hardware revision number.
    /// </summary>
    XI_HwRevision = 571,

    /// <summary>
    /// Set debug level.
    /// </summary>
    XI_DebugLevel = 572,

    /// <summary>
    /// Automatic bandwidth calculation.
    /// </summary>
    XI_AutoBandwidthCalculation = 573,

    /// <summary>
    /// Size of file.
    /// </summary>
    XI_FFSFileSize = 580,

    /// <summary>
    /// Size of free camera FFS.
    /// </summary>
    XI_FreeFFSSize = 581,

    /// <summary>
    /// Size of used camera FFS.
    /// </summary>
    XI_UsedFFSSize = 582,

    /// <summary>
    /// Setting of key enables file operations on some cameras.
    /// </summary>
    XI_FFSAccessKey = 583,

    /// <summary>
    /// Selects the current feature which is accessible by XI_PRM_SENSOR_FEATURE_VALUE.
    /// </summary>
    XI_SensorFeatureSelector = 585,

    /// <summary>
    /// Allows access to sensor feature value currently selected by XI_PRM_SENSOR_FEATURE_SELECTOR.
    /// </summary>
    XI_SensorFeatureValue = 586,

    /// <summary>
    /// Selects which test pattern generator is controlled by the TestPattern feature.
    /// </summary>
    XI_TestPatternGeneratorSelector = 587,

    /// <summary>
    /// Selects which test pattern type is generated by the selected generator.
    /// </summary>
    XI_TestPattern = 588,

    /// <summary>
    /// Selects Region in Multiple ROI which parameters are set by width, height, ... ,region mode.
    /// </summary>
    XI_RegionSelector = 589,

    /// <summary>
    /// Camera housing back side temperature.
    /// </summary>
    XI_HousBackSideTemp = 590,

    /// <summary>
    /// Correction of row FPN.
    /// </summary>
    XI_RowFPNCorrection = 591,

    /// <summary>
    /// File number.
    /// </summary>
    XI_FFSFileId = 594,

    /// <summary>
    /// Activates/deactivates Region selected by Region Selector.
    /// </summary>
    XI_RegionMode = 595,

    /// <summary>
    /// Camera sensor board temperature.
    /// </summary>
    XI_SensorBoardTemp = 596,

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

    /// <summary>
    ///
    /// </summary>
#pragma warning disable CA1069
    INTELPERC_DepthGenerator = 1 << 29,
#pragma warning restore CA1069

    /// <summary>
    ///
    /// </summary>
    INTELPERC_ImageGenerator = 1 << 28,

    /// <summary>
    ///
    /// </summary>
    INTELPERC_IrGenerator = 1 << 27,

    /// <summary>
    ///
    /// </summary>
    INTELPERC_GeneratorsMask = INTELPERC_DepthGenerator + INTELPERC_ImageGenerator + INTELPERC_IrGenerator,

    #endregion

    #region ARAVIS

    /// <summary>
    /// Automatically trigger frame capture if camera is configured with software trigger
    /// </summary>
    AravisAutoTrigger = 600,

    #endregion

    #region Android

    /// <summary>
    /// Properties of cameras available through NDK Camera API backend
    /// </summary>
    AndroidDeviceTorch = 8001,

    #endregion

    #region Images

    /// <summary>
    /// Base value for image sequence backend properties (CAP_IMAGES).
    /// </summary>
    ImagesBase = 18000,

    /// <summary>
    /// Last value (excluding) for image sequence backend properties (CAP_IMAGES).
    /// </summary>
    ImagesLast = 19000,

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

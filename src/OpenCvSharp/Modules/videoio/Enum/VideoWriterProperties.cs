#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

/// <summary>
/// VideoWriter generic properties identifier.
/// </summary>
public enum VideoWriterProperties 
{
    /// <summary>
    /// Current quality (0..100%) of the encoded video stream. Can be adjusted dynamically in some codecs.
    /// </summary>
    Quality = 1,

    /// <summary>
    /// (Read-only): Size of just encoded video frame. Note that the encoding order may be different from representation order.
    /// </summary>
    FrameBytes = 2, 

    /// <summary>
    /// Number of stripes for parallel encoding. -1 for auto detection.
    /// </summary>
    NStripes = 3,

    /// <summary>
    /// If it is not zero, the encoder will expect and encode color frames, otherwise it will work with grayscale frames.
    /// </summary>
    IsColor = 4,

    /// <summary>
    /// Defaults to CV_8U.
    /// </summary>
    Depth = 5,

    /// <summary>
    /// (open-only) Hardware acceleration type (see VideoAccelerationType). 
    /// Setting supported only via params parameter in cv::VideoCapture constructor / .open() method. 
    /// Default value is backend-specific.
    /// </summary>
    HwAcceleration = 6,

    /// <summary>
    /// (open-only) Hardware device index (select GPU if multiple available). Device enumeration is acceleration type specific.
    /// </summary>
    HwDevice = 7,

    /// <summary>
    /// (open-only) If non-zero, create new OpenCL context and bind it to current thread. The OpenCL context created with
    /// Video Acceleration context attached it (if not attached yet) for optimized GPU data copy between cv::UMat and
    /// HW accelerated encoder.
    /// </summary>
    HwAccelerationUseOpenCL = 8,

    /// <summary>
    /// (open-only) Set to non-zero to enable encapsulation of an encoded raw video stream. Each raw encoded video frame
    /// should be passed to VideoWriter.Write() as single row or column of a CV_8UC1 Mat. If the key frame interval is
    /// not 1 then it must be manually specified by the user, either during initialization by passing KeyInterval as one
    /// of the extra encoder params, or afterwards by setting KeyFlag with VideoWriter.Set() before writing each frame.
    /// FFmpeg backend only.
    /// </summary>
    RawVideo = 9,

    /// <summary>
    /// (open-only) Set the key frame interval when using raw video encapsulation (RawVideo != 0). Defaults to 1 when
    /// not set. FFmpeg back-end only.
    /// </summary>
    KeyInterval = 10,

    /// <summary>
    /// Set to non-zero to signal that the following frames are key frames or zero if not, when encapsulating raw video
    /// (RawVideo != 0). FFmpeg back-end only.
    /// </summary>
    KeyFlag = 11,

    /// <summary>
    /// Specifies the frame presentation timestamp for each frame using the FPS time base. This property is only
    /// necessary when encapsulating externally encoded video where the decoding order differs from the presentation
    /// order, such as in GOP patterns with bi-directional B-frames. FFmpeg back-end only.
    /// </summary>
    Pts = 12,

    /// <summary>
    /// Specifies the maximum difference between presentation (pts) and decompression timestamps using the FPS time
    /// base. This property is necessary only when encapsulating externally encoded video where the decoding order
    /// differs from the presentation order. FFmpeg back-end only.
    /// </summary>
    DtsDelay = 13,

    /// <summary>
    /// (open-only) GStreamer backend only. Pixel format for the encoding profile. Default is "I420". Other values:
    /// "NV12", "BGRx". See GStreamer raw video formats for more options.
    /// </summary>
    ColorSpace = 14,

    /// <summary>
    /// (open-only) FFmpeg backend only. Defines that input frames contain alpha channel.
    /// </summary>
    EnableAlpha = 15,
}

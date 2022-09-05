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

}

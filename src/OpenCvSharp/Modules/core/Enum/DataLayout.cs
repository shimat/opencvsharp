// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// Data layout of a matrix / tensor (OpenCV 5, cv::DataLayout). Defined in the core module and
/// shared by core (<see cref="MatShape"/>) and dnn (e.g. blob-from-image parameters).
/// </summary>
/// <remarks>
/// The names describe the order of the tensor axes, where each letter is one axis:
/// <list type="bullet">
/// <item><description><b>N</b> — batch size (number of samples)</description></item>
/// <item><description><b>C</b> — channels (e.g. 3 for RGB, or feature-map count)</description></item>
/// <item><description><b>D</b> — depth (the extra spatial axis of volumetric / 3D data)</description></item>
/// <item><description><b>H</b> — height (rows)</description></item>
/// <item><description><b>W</b> — width (columns)</description></item>
/// </list>
/// So "NCHW" means the data is ordered batch → channels → height → width (channel-first), while
/// "NHWC" puts the channels last (channel-last). The order only changes how the same pixels are laid
/// out in memory; it does not change the image itself.
/// </remarks>
public enum DataLayout
{
    /// <summary>
    /// Unknown / unspecified layout.
    /// </summary>
    UNKNOWN = 0,

    /// <summary>
    /// Generic OpenCV layout for plain N-dimensional data (typically 2-D matrices) with no special
    /// channel ordering.
    /// </summary>
    ND = 1,

    /// <summary>
    /// Channel-first 4-D layout: batch, channels, height, width (N, C, H, W). This is the OpenCV /
    /// Caffe / PyTorch / ONNX default for image batches.
    /// </summary>
    NCHW = 2,

    /// <summary>
    /// Channel-first 5-D layout for volumetric (3-D) data: batch, channels, depth, height, width
    /// (N, C, D, H, W).
    /// </summary>
    NCDHW = 3,

    /// <summary>
    /// Channel-last 4-D layout: batch, height, width, channels (N, H, W, C). This is the
    /// TensorFlow-style ordering for image batches.
    /// </summary>
    NHWC = 4,

    /// <summary>
    /// Channel-last 5-D layout for volumetric (3-D) data: batch, depth, height, width, channels
    /// (N, D, H, W, C). TensorFlow-style.
    /// </summary>
    NDHWC = 5,

    /// <summary>
    /// TensorFlow-like planar layout. Intended only for TensorFlow / TFLite model parsing.
    /// </summary>
    PLANAR = 6,

    /// <summary>
    /// Block layout (also written "NC1HWC0"), where channels are split into blocks. Some hardware
    /// accelerators require it, and it can also be faster on CPU. This is the layout for which
    /// <see cref="MatShape.Channels"/> (C) is meaningful.
    /// </summary>
    BLOCK = 7,
}

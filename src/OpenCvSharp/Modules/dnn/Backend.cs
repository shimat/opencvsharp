#pragma warning disable CS1591

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Dnn;

/// <summary>
/// Enum of computation backends supported by layers.
/// </summary>
/// <remarks>
/// DNN_BACKEND_DEFAULT equals to DNN_BACKEND_INFERENCE_ENGINE if
/// OpenCV is built with Intel's Inference Engine library or 
/// DNN_BACKEND_OPENCV otherwise.
/// </remarks>
public enum Backend
{
    //! DNN_BACKEND_DEFAULT equals to DNN_BACKEND_INFERENCE_ENGINE if
    //! OpenCV is built with Intel's Inference Engine library or
    //! DNN_BACKEND_OPENCV otherwise.
    // ReSharper disable once InconsistentNaming
    DEFAULT = 0,

    /// <summary>
    /// Removed in OpenCV 5. The numeric value is kept so the remaining members keep their original values.
    /// </summary>
    [Obsolete("The Halide backend was removed in OpenCV 5.")]
    HALIDE = 1,

    /// <summary>
    /// Intel OpenVINO computational backend.
    /// </summary>
    INFERENCE_ENGINE = 2,
    OPENCV = 3,
    VKCOM = 4,
    CUDA = 5,
    WEBNN = 6,
    TIMVX = 7,
    CANN = 8
}

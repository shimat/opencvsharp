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
    DEFAULT,
    HALIDE,
    INFERENCE_ENGINE,
    OPENCV,
    VKCOM,
    CUDA
}

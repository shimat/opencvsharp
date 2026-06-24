#pragma warning disable CS1591

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Dnn;

/// <summary>
/// Enum of DNN inference engines that can be selected when reading a network (OpenCV 5).
/// </summary>
public enum EngineType
{
    /// <summary>
    /// Force use of the old (classic) DNN engine, similar to the 4.x branch.
    /// </summary>
    Classic = 1,

    /// <summary>
    /// Force use of the new DNN engine. The new engine does not support non-CPU back-ends for now.
    /// </summary>
    New = 2,

    /// <summary>
    /// Try to use the new engine and then fall back to the classic version. This is the default.
    /// </summary>
    Auto = 3,

    /// <summary>
    /// Try to use the ONNX Runtime wrapper (ONNX only, requires a build with WITH_ONNXRUNTIME=ON).
    /// </summary>
    Ort = 4
}

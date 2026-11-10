#pragma warning disable CS1591

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Dnn;

/// <summary>
/// DNN inference engine selected when loading a network (OpenCV 5.1).
/// </summary>
public enum EngineType
{
    /// <summary>
    /// Select the engine automatically. OpenCV 5.1 selects the built-in OpenCV engine.
    /// </summary>
    Auto = 0,

    /// <summary>
    /// Use OpenCV's built-in DNN engine.
    /// </summary>
    OpenCv = 1,

    /// <summary>
    /// Use the ONNX Runtime engine (ONNX only, requires a build with WITH_ONNXRUNTIME=ON).
    /// </summary>
    Ort = 2
}

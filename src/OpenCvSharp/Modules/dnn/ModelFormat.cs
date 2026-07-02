#pragma warning disable CS1591

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Dnn;

/// <summary>
/// Enum of the original framework format a Net was loaded from.
/// </summary>
public enum ModelFormat
{
    /// <summary>
    /// Some generic model format.
    /// </summary>
    Generic = 0,

    /// <summary>
    /// ONNX model.
    /// </summary>
    ONNX = 1,

    /// <summary>
    /// TensorFlow model.
    /// </summary>
    TF = 2,

    /// <summary>
    /// TFLite model.
    /// </summary>
    TFLite = 3,
}

#pragma warning disable CS1591

// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Dnn;

/// <summary>
/// Tracing mode for the new DNN engine (OpenCV 5). See Net.TracingMode.
/// </summary>
public enum TracingMode
{
    /// <summary>
    /// Don't trace anything.
    /// </summary>
    None = 0,

    /// <summary>
    /// Print all executed operations along with the output tensors
    /// (more or less compatible with ONNX Runtime).
    /// </summary>
    All = 1,

    /// <summary>
    /// Print all executed operations. Types and shapes of all inputs and outputs are printed,
    /// but the content is not.
    /// </summary>
    Op = 2
}

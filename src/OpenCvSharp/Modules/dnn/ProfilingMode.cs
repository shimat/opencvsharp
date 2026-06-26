#pragma warning disable CS1591

// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Dnn;

/// <summary>
/// Profiling mode for the new DNN engine (OpenCV 5). See Net.ProfilingMode.
/// </summary>
public enum ProfilingMode
{
    /// <summary>
    /// Don't do any profiling.
    /// </summary>
    None = 0,

    /// <summary>
    /// Collect summary statistics by layer type and print them at the end, sorted by execution time.
    /// </summary>
    Summary = 1,

    /// <summary>
    /// Print the execution time of each single layer.
    /// </summary>
    Detailed = 2
}

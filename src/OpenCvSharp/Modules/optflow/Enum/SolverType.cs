namespace OpenCvSharp.OptFlow;

/// <summary>
/// Iterative refinement solver strategy used by <see cref="RLOFOpticalFlowParameter"/>.
/// </summary>
public enum SolverType
{
    /// <summary>
    /// Apply standard iterative refinement.
    /// </summary>
    Standard = 0,

    /// <summary>
    /// Apply optimized iterative refinement based on bilinear equation solutions.
    /// </summary>
    Bilinear = 1,
}

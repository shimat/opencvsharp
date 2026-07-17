namespace OpenCvSharp.OptFlow;

/// <summary>
/// Vector field interpolation method used to compute a dense optical flow from sparse matches
/// (e.g. by <see cref="DenseRLOFOpticalFlow"/>).
/// </summary>
public enum InterpolationType
{
    /// <summary>
    /// Fast geodesic interpolation.
    /// </summary>
    Geo = 0,

    /// <summary>
    /// Edge-preserving interpolation using ximgproc::EdgeAwareInterpolator.
    /// </summary>
    Epic = 1,

    /// <summary>
    /// SLIC based robust interpolation using ximgproc::RICInterpolator.
    /// </summary>
    Ric = 2,
}

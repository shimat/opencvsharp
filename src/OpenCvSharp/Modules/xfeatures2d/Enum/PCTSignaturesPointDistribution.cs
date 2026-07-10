namespace OpenCvSharp;

/// <summary>
/// Point distributions supported by the random point generator of cv::xfeatures2d::PCTSignatures.
/// </summary>
public enum PCTSignaturesPointDistribution
{
    /// <summary>
    /// Generate numbers uniformly.
    /// </summary>
    Uniform,

    /// <summary>
    /// Generate points in a regular grid.
    /// </summary>
    Regular,

    /// <summary>
    /// Generate points with normal (gaussian) distribution.
    /// </summary>
    Normal
}

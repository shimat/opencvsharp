// ReSharper disable once CheckNamespace
namespace OpenCvSharp;

// ReSharper disable once InconsistentNaming
/// <summary>
/// Metrics used by <see cref="ANNIndex"/> to calculate the distance between two feature vectors.
/// </summary>
public enum ANNIndexDistance
{
    /// <summary>
    /// Euclidean distance (DIST_EUCLIDEAN).
    /// </summary>
    Euclidean = 0,

    /// <summary>
    /// Manhattan (L1) distance (DIST_MANHATTAN).
    /// </summary>
    Manhattan = 1,

    /// <summary>
    /// Angular distance (DIST_ANGULAR).
    /// </summary>
    Angular = 2,

    /// <summary>
    /// Hamming distance (DIST_HAMMING).
    /// </summary>
    Hamming = 3,

    /// <summary>
    /// Dot-product distance (DIST_DOTPRODUCT).
    /// </summary>
    DotProduct = 4
}

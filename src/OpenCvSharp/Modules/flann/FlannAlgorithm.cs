// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Flann;

/// <summary>
/// Nearest neighbour index algorithm.
/// [cvflann::flann_algorithm_t]
/// </summary>
public enum FlannAlgorithm
{
    /// <summary>
    /// [FLANN_INDEX_LINEAR]
    /// </summary>
    Linear = 0,

    /// <summary>
    /// [FLANN_INDEX_KDTREE]
    /// </summary>
    KDTree = 1,

    /// <summary>
    /// [FLANN_INDEX_KMEANS]
    /// </summary>
    KMeans = 2,

    /// <summary>
    /// [FLANN_INDEX_COMPOSITE]
    /// </summary>
    Composite = 3,

    /// <summary>
    /// [FLANN_INDEX_KDTREE_SINGLE]
    /// </summary>
    KDTreeSingle = 4,

    /// <summary>
    /// [FLANN_INDEX_HIERARCHICAL]
    /// </summary>
    Hierarchical = 5,

    /// <summary>
    /// [FLANN_INDEX_LSH]
    /// </summary>
    Lsh = 6,

    /// <summary>
    /// [FLANN_INDEX_SAVED]
    /// </summary>
    Saved = 254,

    /// <summary>
    /// [FLANN_INDEX_AUTOTUNED]
    /// </summary>
    Autotuned = 255,
}

// ReSharper disable InconsistentNaming
// ReSharper disable CommentTypo

namespace OpenCvSharp.Flann;

/// <summary>
/// The algorithm to use for selecting the initial centers when performing a k-means clustering step. 
/// </summary>
public enum FlannCentersInit
{
    /// <summary>
    /// picks the initial cluster centers randomly
    /// [flann_centers_init_t::CENTERS_RANDOM]
    /// </summary>
    Random = 0,

    /// <summary>
    /// picks the initial centers using Gonzales’ algorithm
    /// [flann_centers_init_t::CENTERS_GONZALES]
    /// </summary>
    Gonzales = 1,

    /// <summary>
    /// picks the initial centers using the algorithm suggested in [arthur_kmeanspp_2007]
    /// [flann_centers_init_t::CENTERS_KMEANSPP]
    /// </summary>
    KMeansPP = 2
}

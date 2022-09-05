using System.Diagnostics.CodeAnalysis;

#pragma warning disable CA1027 // Mark enums with FlagsAttribute

namespace OpenCvSharp;

/// <summary>
/// Comparison methods for cvCompareHist
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/d3bc563c6e01c2bc153f23e7393322a95c7d3974/modules/imgproc/include/opencv2/imgproc.hpp#L497
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1717: Only FlagsAttribute enums should have plural names")]
public enum HistCompMethods
{
    /// <summary>
    /// Correlation [CV_COMP_CORREL]
    /// </summary>
    Correl = 0,

    /// <summary>
    /// Chi-Square [CV_COMP_CHISQR]
    /// </summary>
    Chisqr = 1,

    /// <summary>
    /// Intersection [CV_COMP_INTERSECT]
    /// </summary>
    Intersect = 2,

    /// <summary>
    /// Bhattacharyya distance [CV_COMP_BHATTACHARYYA]
    /// </summary>
    Bhattacharyya = 3,

    /// <summary>
    /// Synonym for HISTCMP_BHATTACHARYYA
    /// </summary>
    Hellinger = Bhattacharyya,

    /// <summary>
    /// Alternative Chi-Square
    /// \f[d(H_1,H_2) =  2 * \sum _I  \frac{\left(H_1(I)-H_2(I)\right)^2}{H_1(I)+H_2(I)}\f] 
    /// This alternative formula is regularly used for texture comparison. See e.g. @cite Puzicha1997 
    /// </summary>
    ChisqrAlt = 4,

    /// <summary>
    /// Kullback-Leibler divergence 
    /// \f[d(H_1,H_2) = \sum _I H_1(I) \log \left(\frac{H_1(I)}{H_2(I)}\right)\f] 
    /// </summary>
    // ReSharper disable once InconsistentNaming
    KLDiv = 5
}

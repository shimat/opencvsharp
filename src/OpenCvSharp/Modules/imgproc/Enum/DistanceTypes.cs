using System.Diagnostics.CodeAnalysis;

#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

/// <summary>
/// Type of distance for cvDistTransform
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/d3bc563c6e01c2bc153f23e7393322a95c7d3974/modules/imgproc/include/opencv2/imgproc.hpp#L300
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1717: Only FlagsAttribute enums should have plural names")]
public enum DistanceTypes
{
    /// <summary>
    /// User defined distance  [CV_DIST_USER]
    /// </summary>
    User = -1,

    /// <summary>
    /// distance = |x1-x2| + |y1-y2|  [CV_DIST_L1]
    /// </summary>
    L1 = 1,

    /// <summary>
    /// the simple euclidean distance  [CV_DIST_L2]
    /// </summary>
    L2 = 2,

    /// <summary>
    /// distance = max(|x1-x2|,|y1-y2|)  [CV_DIST_C]
    /// </summary>
    C = 3,

    /// <summary>
    /// L1-L2 metric: distance = 2(sqrt(1+x*x/2) - 1))  [CV_DIST_L12]
    /// </summary>
    L12 = 4,

    /// <summary>
    /// distance = c^2(|x|/c-log(1+|x|/c)), c = 1.3998  [CV_DIST_FAIR]
    /// </summary>
    Fair = 5,

    /// <summary>
    /// distance = c^2/2(1-exp(-(x/c)^2)), c = 2.9846  [CV_DIST_WELSCH]
    /// </summary>
    Welsch = 6,

    /// <summary>
    /// distance = |x|&lt;c ? x^2/2 : c(|x|-c/2), c=1.345  [CV_DIST_HUBER]
    /// </summary>
    Huber = 7,
}

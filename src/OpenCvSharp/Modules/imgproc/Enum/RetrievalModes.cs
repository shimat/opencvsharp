using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// mode of the contour retrieval algorithm
/// </summary>
/// <remarks>
/// https://github.com/opencv/opencv/blob/d3bc563c6e01c2bc153f23e7393322a95c7d3974/modules/imgproc/include/opencv2/imgproc.hpp#L414
/// </remarks>
[SuppressMessage("Microsoft.Design", "CA1717: Only FlagsAttribute enums should have plural names")]
public enum RetrievalModes
{
    /// <summary>
    /// retrieves only the extreme outer contours. 
    /// It sets `hierarchy[i][2]=hierarchy[i][3]=-1` for all the contours.
    /// </summary>
    External = 0,

    /// <summary>
    /// retrieves all of the contours without establishing any hierarchical relationships.
    /// </summary>
    List = 1,

    /// <summary>
    /// retrieves all of the contours and organizes them into a two-level hierarchy. 
    /// At the top level, there are external boundaries of the components. 
    /// At the second level, there are boundaries of the holes. If there is another 
    /// contour inside a hole of a connected component, it is still put at the top level.
    /// </summary>
    CComp = 2,

    /// <summary>
    /// retrieves all of the contours and reconstructs a full hierarchy 
    /// of nested contours.
    /// </summary>
    Tree = 3,

    /// <summary>
    /// 
    /// </summary>
    FloodFill = 4,
}

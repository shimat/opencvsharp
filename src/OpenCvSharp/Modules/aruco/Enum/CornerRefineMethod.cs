namespace OpenCvSharp.Aruco;

/// <summary>
/// corner refinement method
/// </summary>
public enum CornerRefineMethod
{
    /// <summary>
    /// Tag and corners detection based on the ArUco approach.
    /// </summary>
    None,  

    /// <summary>
    /// ArUco approach and refine the corners locations using corner subpixel accuracy.
    /// </summary>
    Subpix, 

    /// <summary>
    /// ArUco approach and refine the corners locations using the contour-points line fitting.
    /// </summary>
    Contour,

    /// <summary>
    /// Tag and corners detection based on the AprilTag 2 approach
    /// </summary>
    AprilTag
}

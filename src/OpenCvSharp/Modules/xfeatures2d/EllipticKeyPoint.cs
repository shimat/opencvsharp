using System.Runtime.InteropServices;

namespace OpenCvSharp.XFeatures2D;

/// <summary>
/// Elliptic region around an interest point, as produced by AffineFeature2D. Mirrors
/// cv::xfeatures2d::Elliptic_KeyPoint.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct EllipticKeyPoint
{
    /// <summary>
    /// Coordinates of the keypoint.
    /// </summary>
    public Point2f Pt;

    /// <summary>
    /// Diameter of the meaningful keypoint neighborhood.
    /// </summary>
    public float Size;

    /// <summary>
    /// Computed orientation of the keypoint (-1 if not applicable). Its possible values are in a
    /// range [0,360) degrees, measured relative to the image coordinate system (y-axis is
    /// directed downward), i.e in clockwise direction.
    /// </summary>
    public float Angle;

    /// <summary>
    /// The response, by which the strongest keypoints have been selected. Can be used for the
    /// further sorting or subsampling.
    /// </summary>
    public float Response;

    /// <summary>
    /// Octave (pyramid layer), from which the keypoint has been extracted.
    /// </summary>
    public int Octave;

    /// <summary>
    /// Object class (if the keypoints need to be clustered by an object they belong to).
    /// </summary>
    public int ClassId;

    /// <summary>
    /// The lengths of the major and minor ellipse axes.
    /// </summary>
    public Size2f Axes;

    /// <summary>
    /// The integration scale at which the parameters were estimated.
    /// </summary>
    public float Si;

    /// <summary>
    /// The transformation between image space and local patch space, row 0 (m00, m01, m02).
    /// </summary>
    public float Transf00, Transf01, Transf02;

    /// <summary>
    /// The transformation between image space and local patch space, row 1 (m10, m11, m12).
    /// </summary>
    public float Transf10, Transf11, Transf12;
}

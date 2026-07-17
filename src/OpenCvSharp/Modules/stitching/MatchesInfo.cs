using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp.Detail;

/// <summary>
/// Structure containing information about matches between two images.
///
/// It's assumed that there is a transformation between those images. Transformation may be 
/// homography or affine transformation based on selected matcher.
/// </summary>
public sealed class MatchesInfo : IDisposable
{
    /// <summary>
    /// Images indices (optional)
    /// </summary>
    public int SrcImgIdx { get; }

    /// <summary>
    /// Images indices (optional)
    /// </summary>
    public int DstImgIdx { get; }

    /// <summary>
    /// 
    /// </summary>
    public IReadOnlyList<DMatch> Matches { get; }

    /// <summary>
    /// Geometrically consistent matches mask
    /// </summary>
    public IReadOnlyList<byte> InliersMask { get; }

    /// <summary>
    /// Number of geometrically consistent matches
    /// </summary>
    public int NumInliers { get; }

    /// <summary>
    /// Estimated transformation
    /// </summary>
    public Mat H { get; }

    /// <summary>
    /// Confidence two images are from the same panorama
    /// </summary>
    public double Confidence { get; }
        
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="srcImgIdx"></param>
    /// <param name="dstImgIdx"></param>
    /// <param name="matches"></param>
    /// <param name="inliersMask"></param>
    /// <param name="numInliers"></param>
    /// <param name="h"></param>
    /// <param name="confidence"></param>
    public MatchesInfo(
        int srcImgIdx,
        int dstImgIdx,
        IReadOnlyList<DMatch> matches, 
        IReadOnlyList<byte> inliersMask,
        int numInliers,
        Mat h, 
        double confidence)
    {
        SrcImgIdx = srcImgIdx;
        DstImgIdx = dstImgIdx;
        Matches = matches;
        InliersMask = inliersMask;
        NumInliers = numInliers;
        H = h;
        Confidence = confidence;
    }

    /// <summary>
    /// Copy constructor
    /// </summary>
    /// <param name="other"></param>
    public MatchesInfo(MatchesInfo other)
    {
        ArgumentNullException.ThrowIfNull(other);
        SrcImgIdx = other.SrcImgIdx;
        DstImgIdx = other.DstImgIdx;
        Matches = other.Matches;
        InliersMask = other.InliersMask;
        NumInliers = other.NumInliers;
        H = other.H;
        Confidence = other.Confidence;
    }

    /// <summary>
    /// Dispose H
    /// </summary>
    public void Dispose()
    {
        H.Dispose();
    }
}

#pragma warning disable 1591
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
[SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
public struct WMatchesInfo
{
    public int SrcImgIdx;
    public int DstImgIdx;
    public IntPtr Matches;
    public IntPtr InliersMask;
    public int NumInliers;
    public IntPtr H;
    public double Confidence;
}
#pragma warning restore 1591

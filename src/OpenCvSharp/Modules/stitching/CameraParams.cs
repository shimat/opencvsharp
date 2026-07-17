using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp.Detail;

/// <summary>
/// Describes camera parameters. Translation is assumed to be zero during the whole stitching pipeline.
/// </summary>
public sealed class CameraParams : IDisposable
{
    /// <summary>
    /// Focal length
    /// </summary>
    public double Focal { get; set; }

    /// <summary>
    /// Aspect ratio
    /// </summary>
    public double Aspect { get; set; } = 1.0;

    /// <summary>
    /// Principal point X
    /// </summary>
    public double Ppx { get; set; }

    /// <summary>
    /// Principal point Y
    /// </summary>
    public double Ppy { get; set; }

    /// <summary>
    /// Rotation
    /// </summary>
    public Mat R { get; }

    /// <summary>
    /// Translation
    /// </summary>
    public Mat T { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    public CameraParams()
        : this(0, 1.0, 0, 0, new Mat(3, 3, MatType.CV_64F, Scalar.All(0)), new Mat(3, 1, MatType.CV_64F, Scalar.All(0)))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public CameraParams(double focal, double aspect, double ppx, double ppy, Mat r, Mat t)
    {
        Focal = focal;
        Aspect = aspect;
        Ppx = ppx;
        Ppy = ppy;
        R = r;
        T = t;
    }

    /// <summary>
    /// Computes the intrinsic camera matrix from the focal length, aspect ratio and principal point.
    /// </summary>
    public Mat K()
    {
        var k = new Mat(3, 3, MatType.CV_64F, Scalar.All(0));
        k.Set(0, 0, Focal);
        k.Set(0, 2, Ppx);
        k.Set(1, 1, Focal * Aspect);
        k.Set(1, 2, Ppy);
        k.Set(2, 2, 1.0);
        return k;
    }

    /// <inheritdoc />
    public void Dispose()
    {
        R.Dispose();
        T.Dispose();
    }
}

#pragma warning disable 1591
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
[SuppressMessage("Microsoft.Design", "CA1815: Override equals and operator equals on value types")]
public struct WCameraParams
{
    public double Focal;
    public double Aspect;
    public double Ppx;
    public double Ppy;
    public IntPtr R;
    public IntPtr T;
}
#pragma warning restore 1591

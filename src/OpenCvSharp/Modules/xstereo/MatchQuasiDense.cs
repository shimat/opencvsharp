using System.Runtime.InteropServices;

#pragma warning disable CA1051

namespace OpenCvSharp;

/// <summary>
/// A basic match structure used by <see cref="QuasiDenseStereo"/>.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct MatchQuasiDense
{
    /// <summary>
    /// The matched point in the left image.
    /// </summary>
    public Point P0;

    /// <summary>
    /// The matched point in the right image.
    /// </summary>
    public Point P1;

    /// <summary>
    /// The zero-mean normalized cross-correlation (ZNCC) value of the match.
    /// </summary>
    public float Corr;
}

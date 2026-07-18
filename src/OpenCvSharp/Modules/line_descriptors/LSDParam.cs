using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp.LineDescriptor;
#pragma warning disable CA1815
#pragma warning disable 1591
/// <summary>
/// Parameters used by <see cref="LSDDetector"/> to configure the underlying Line Segment Detector (LSD) algorithm.
/// The LSD algorithm is defined using the standard values below. Only advanced users may want to edit those,
/// as to tailor it for their own application.
/// </summary>
/// <param name="scale">The scale of the image that will be used to find the lines. Range (0..1].</param>
/// <param name="sigmaScale">Sigma for the Gaussian filter. It is computed as sigma = sigmaScale/scale.</param>
/// <param name="quant">Bound to the quantization error on the gradient norm.</param>
/// <param name="angTh">Gradient angle tolerance in degrees.</param>
/// <param name="logEps">Detection threshold: -log10(NFA) &gt; logEps. Used only when advanced refinement is chosen.</param>
/// <param name="densityTh">Minimal density of aligned region points in the enclosing rectangle.</param>
/// <param name="nBins">Number of bins in pseudo-ordering of gradient modulus.</param>
// ReSharper disable once InconsistentNaming
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
public readonly struct LSDParam(
    double scale = 0.8,
    double sigmaScale = 0.6,
    double quant = 2.0,
    double angTh = 22.5,
    double logEps = 0,
    double densityTh = 0.7,
    int nBins = 1024)
{
    /// <summary>
    /// The scale of the image that will be used to find the lines. Range (0..1].
    /// </summary>
    public readonly double Scale = scale;

    /// <summary>
    /// Sigma for the Gaussian filter. It is computed as sigma = SigmaScale/Scale.
    /// </summary>
    public readonly double SigmaScale = sigmaScale;

    /// <summary>
    /// Bound to the quantization error on the gradient norm.
    /// </summary>
    public readonly double Quant = quant;

    /// <summary>
    /// Gradient angle tolerance in degrees.
    /// </summary>
    public readonly double AngTh = angTh;

    /// <summary>
    /// Detection threshold: -log10(NFA) &gt; LogEps. Used only when advanced refinement is chosen.
    /// </summary>
    public readonly double LogEps = logEps;

    /// <summary>
    /// Minimal density of aligned region points in the enclosing rectangle.
    /// </summary>
    public readonly double DensityTh = densityTh;

    /// <summary>
    /// Number of bins in pseudo-ordering of gradient modulus.
    /// </summary>
    public readonly int NBins = nBins;
}

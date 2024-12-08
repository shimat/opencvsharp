using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp.LineDescriptor;
#pragma warning disable CA1815
#pragma warning disable 1591
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
// ReSharper disable once InconsistentNaming
public readonly struct LSDParam(
    double scale = 0.8,
    double sigmaScale = 0.6,
    double quant = 2.0,
    double angTh = 22.5,
    double logEps = 0,
    double densityTh = 0.7,
    int nBins = 1024)
{
    public readonly double Scale = scale;
    public readonly double SigmaScale = sigmaScale;
    public readonly double Quant = quant;
    public readonly double AngTh = angTh;
    public readonly double LogEps = logEps;
    public readonly double DensityTh = densityTh;
    public readonly int NBins = nBins;
}

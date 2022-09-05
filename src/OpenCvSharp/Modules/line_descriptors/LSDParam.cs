using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace OpenCvSharp.LineDescriptor;
#pragma warning disable CA1815
#pragma warning disable 1591
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("Design", "CA1051: Do not declare visible instance fields")]
// ReSharper disable once InconsistentNaming
public readonly struct LSDParam
{
    public readonly double Scale;
    public readonly double SigmaScale;
    public readonly double Quant;
    public readonly double AngTh;
    public readonly double LogEps;
    public readonly double DensityTh;
    public readonly int NBins;
        
    public LSDParam(
        double scale = 0.8,
        double sigmaScale = 0.6,
        double quant = 2.0,
        double angTh = 22.5,
        double logEps = 0,
        double densityTh = 0.7,
        int nBins = 1024)
    {
        Scale = scale;
        SigmaScale = sigmaScale;
        Quant = quant;
        AngTh = angTh;
        LogEps = logEps;
        DensityTh = densityTh;
        NBins = nBins;
    }
}

namespace OpenCvSharp.StructuredLight;

/// <summary>Method used to recover phase from sinusoidal patterns.</summary>
public enum SinusoidalPatternMethod
{
    /// <summary>Fourier transform profilometry.</summary>
    Ftp = 0,
    /// <summary>Phase-shifting profilometry.</summary>
    Psp = 1,
    /// <summary>Fourier-assisted phase-shifting profilometry.</summary>
    Faps = 2,
}

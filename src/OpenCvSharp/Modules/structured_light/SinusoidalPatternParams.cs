namespace OpenCvSharp.StructuredLight;

/// <summary>Projector and phase-recovery settings for a sinusoidal pattern.</summary>
public sealed class SinusoidalPatternParams
{
    /// <summary>Projector width.</summary>
    public int Width { get; set; } = 800;
    /// <summary>Projector height.</summary>
    public int Height { get; set; } = 600;
    /// <summary>Number of pattern periods.</summary>
    public int NumberOfPeriods { get; set; } = 20;
    /// <summary>Phase shift between consecutive patterns, in radians.</summary>
    public float ShiftValue { get; set; } = (float)(2 * Math.PI / 3);
    /// <summary>Phase recovery method.</summary>
    public SinusoidalPatternMethod Method { get; set; } = SinusoidalPatternMethod.Faps;
    /// <summary>Pixel distance between markers.</summary>
    public int PixelsBetweenMarkers { get; set; } = 56;
    /// <summary>Whether the patterns run horizontally.</summary>
    public bool Horizontal { get; set; }
    /// <summary>Whether markers are drawn on the patterns.</summary>
    public bool SetMarkers { get; set; }
}

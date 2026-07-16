namespace OpenCvSharp.LineDescriptor;

/// <summary>
/// Options for drawing key lines and line matches.
/// </summary>
[Flags]
public enum DrawLinesMatchesFlags
{
    /// <summary>Creates the output and draws matches and unmatched lines.</summary>
    Default = 0,
    /// <summary>Draws over the existing output image.</summary>
    DrawOverOutImg = 1,
    /// <summary>Does not draw unmatched lines.</summary>
    NotDrawSingleLines = 2,
}

namespace OpenCvSharp;

/// <summary>
/// Built-in color checker cards, with 2deg D50 illuminant reference values.
/// </summary>
public enum ColorCheckerType
{
    /// <summary>
    /// Macbeth ColorChecker.
    /// </summary>
    Macbeth,

    /// <summary>
    /// DKK ColorChecker.
    /// </summary>
    Vinyl,

    /// <summary>
    /// DigitalSG ColorChecker with 140 squares.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    DigitalSG,
}

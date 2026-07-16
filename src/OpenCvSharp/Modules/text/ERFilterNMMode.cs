namespace OpenCvSharp.Text;

/// <summary>
/// computeNMChannels operation modes.
/// </summary>
public enum ERFilterNMMode
{
    /// <summary>
    /// Combination of red (R), green (G), blue (B), lightness (L), and gradient magnitude (Grad) channels. Used by default.
    /// </summary>
    RGBLGrad,

    /// <summary>
    /// Combination of intensity (I), hue (H), saturation (S), and gradient magnitude (Grad) channels.
    /// </summary>
    IHSGrad,
}

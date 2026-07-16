namespace OpenCvSharp;

/// <summary>
/// Enum of the possible types of ccm.
/// </summary>
public enum CcmType
{
    /// <summary>
    /// Uses a 3x3 matrix to linearly transform RGB values without offsets.
    /// </summary>
    Linear,

    /// <summary>
    /// Uses a 4x3 matrix to affine transform RGB values with both scaling and offset terms.
    /// </summary>
    Affine,
}

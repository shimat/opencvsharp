namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// Type of the sample consensus model used by <see cref="SACSegmentation"/>.
/// </summary>
public enum SacModelType
{
    /// <summary>
    /// The 3D PLANE model coefficients in list [a, b, c, d], corresponding to the coefficients
    /// of equation ax + by + cz + d = 0.
    /// </summary>
    SAC_MODEL_PLANE = 0,

    /// <summary>
    /// The 3D SPHERE model coefficients in list [center_x, center_y, center_z, radius],
    /// corresponding to the coefficients of equation
    /// (x - center_x)^2 + (y - center_y)^2 + (z - center_z)^2 = radius^2.
    /// </summary>
    SAC_MODEL_SPHERE = 1,
}

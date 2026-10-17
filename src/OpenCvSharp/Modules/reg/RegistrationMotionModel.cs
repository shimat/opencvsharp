namespace OpenCvSharp.Reg;

/// <summary>Motion model used for direct pixel-intensity image registration.</summary>
public enum RegistrationMotionModel
{
    /// <summary>Translation in two dimensions.</summary>
    Shift = 0,
    /// <summary>Rotation and translation.</summary>
    Euclidean = 1,
    /// <summary>Rotation, uniform scale, and translation.</summary>
    Similarity = 2,
    /// <summary>General affine transformation.</summary>
    Affine = 3,
    /// <summary>Projective transformation.</summary>
    Projective = 4,
}

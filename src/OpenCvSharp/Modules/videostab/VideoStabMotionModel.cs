namespace OpenCvSharp.VideoStab;

/// <summary>Motion model used to estimate movement between consecutive video frames.</summary>
public enum VideoStabMotionModel
{
    /// <summary>Horizontal and vertical translation.</summary>
    Translation = 0,
    /// <summary>Translation with uniform scale.</summary>
    TranslationAndScale = 1,
    /// <summary>Rotation around the image center.</summary>
    Rotation = 2,
    /// <summary>Rotation and translation.</summary>
    Rigid = 3,
    /// <summary>Rotation, uniform scale, and translation.</summary>
    Similarity = 4,
    /// <summary>General affine transform.</summary>
    Affine = 5,
    /// <summary>Projective transform.</summary>
    Homography = 6,
}

namespace OpenCvSharp;

/// <summary>Options for omnidirectional camera calibration.</summary>
[Flags]
public enum OmnidirCalibrationFlags
{
    /// <summary>Upstream flag retained for compatibility; single-camera calibration ignores it in OpenCV 5.0.0.</summary>
    UseGuess = 1,
    /// <summary>Keep the camera skew fixed.</summary>
    FixSkew = 2,
    /// <summary>Keep radial coefficient k1 fixed.</summary>
    FixK1 = 4,
    /// <summary>Keep radial coefficient k2 fixed.</summary>
    FixK2 = 8,
    /// <summary>Keep tangential coefficient p1 fixed.</summary>
    FixP1 = 16,
    /// <summary>Keep tangential coefficient p2 fixed.</summary>
    FixP2 = 32,
    /// <summary>Keep the CMei mirror parameter fixed.</summary>
    FixXi = 64,
    /// <summary>Keep the focal length fixed.</summary>
    FixGamma = 128,
    /// <summary>Keep the principal point fixed.</summary>
    FixCenter = 256,
}

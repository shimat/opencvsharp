namespace OpenCvSharp;

/// <summary>
/// Different flags for cvCalibrateCamera2 and cvStereoCalibrate
/// </summary>
[Flags]
public enum CalibrationFlags
{
    /// <summary>
    /// 
    /// </summary>
    None = 0,

    /// <summary>
    /// The flag allows the function to optimize some or all of the intrinsic parameters, depending on the other flags, but the initial values are provided by the user
    /// </summary>
    UseIntrinsicGuess = 0x00001,

    /// <summary>
    /// fyk is optimized, but the ratio fxk/fyk is fixed.
    /// </summary>
    FixAspectRatio = 0x00002,

    /// <summary>
    /// The principal points are fixed during the optimization.
    /// </summary>
    FixPrincipalPoint = 0x00004,

    /// <summary>
    /// Tangential distortion coefficients are set to zeros and do not change during the optimization.
    /// </summary>
    ZeroTangentDist = 0x00008,

    /// <summary>
    /// fxk and fyk are fixed.
    /// </summary>
    FixFocalLength = 0x00010,
       
    /// <summary>
    /// The 0-th distortion coefficients (k1) are fixed 
    /// </summary>
    FixK1 = 0x00020,

    /// <summary>
    /// The 1-th distortion coefficients (k2) are fixed 
    /// </summary>
    FixK2 = 0x00040,

    /// <summary>
    /// The 4-th distortion coefficients (k3) are fixed 
    /// </summary>
    FixK3 = 0x00080,

    /// <summary>
    /// Do not change the corresponding radial distortion coefficient during the optimization. 
    /// If CV_CALIB_USE_INTRINSIC_GUESS is set, the coefficient from the supplied distCoeffs matrix is used, otherwise it is set to 0.
    /// </summary>
    FixK4 = 0x00800,

    /// <summary>
    /// Do not change the corresponding radial distortion coefficient during the optimization. 
    /// If CV_CALIB_USE_INTRINSIC_GUESS is set, the coefficient from the supplied distCoeffs matrix is used, otherwise it is set to 0.
    /// </summary>
    FixK5 = 0x01000,

    /// <summary>
    /// Do not change the corresponding radial distortion coefficient during the optimization. 
    /// If CV_CALIB_USE_INTRINSIC_GUESS is set, the coefficient from the supplied distCoeffs matrix is used, otherwise it is set to 0.
    /// </summary>
    FixK6 = 0x02000,

    /// <summary>
    /// Enable coefficients k4, k5 and k6. 
    /// To provide the backward compatibility, this extra flag should be explicitly specified to make the calibration function 
    /// use the rational model and return 8 coefficients. If the flag is not set, the function will compute only 5 distortion coefficients.
    /// </summary>
    RationalModel = 0x04000,

    /// <summary>
    /// 
    /// </summary>
    ThinPrismModel = 0x08000,

    /// <summary>
    /// 
    /// </summary>
#pragma warning disable CA1069 // Enums should not have duplicate values
    FixS1S2S3S4 = 0x08000,
#pragma warning restore CA1069

    /// <summary>
    /// If it is set, camera_matrix1,2, as well as dist_coeffs1,2 are fixed, so that only extrinsic parameters are optimized.
    /// </summary>
    FixIntrinsic = 0x00100,

    /// <summary>
    /// Enforces fx0=fx1 and fy0=fy1. CV_CALIB_ZERO_TANGENT_DIST - Tangential distortion coefficients for each camera are set to zeros and fixed there.
    /// </summary>
    SameFocalLength = 0x00200,

    /// <summary>
    /// for stereo rectification
    /// </summary>
    ZeroDisparity = 0x00400,
}

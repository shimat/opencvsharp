

// ReSharper disable UnusedMember.Global

namespace OpenCvSharp;
#pragma warning disable CS1591

/// <summary>
/// Different flags for the fisheye camera calibration functions (cv::fisheye::calibrate, cv::fisheye::stereoCalibrate).
/// </summary>
[Flags]
public enum FishEyeCalibrationFlags
{
    None = 0,

    /// <summary>
    /// Use user provided intrinsics as initial point for optimization.
    /// </summary>
    UseIntrinsicGuess = 1,

    /// <summary>
    /// For fisheye model only. Recompute board position on each calibration iteration.
    /// </summary>
    RecomputeExtrinsic = 1 << 1,

    /// <summary>
    /// For fisheye model only. Check SVD decomposition quality for each frame during extrinsics estimation.
    /// </summary>
    CheckCond = 1 << 2,

    /// <summary>
    /// For fisheye model only. Skew coefficient (alpha) is set to zero and stay zero.
    /// </summary>
    FixSkew = 1 << 3,

    /// <summary>
    /// The distortion coefficient k1 is not changed during the optimization. 0 value is used, if UseIntrinsicGuess is not set.
    /// </summary>
    FixK1 = 1 << 4,

    /// <summary>
    /// The distortion coefficient k2 is not changed during the optimization. 0 value is used, if UseIntrinsicGuess is not set.
    /// </summary>
    FixK2 = 1 << 5,

    /// <summary>
    /// The distortion coefficient k3 is not changed during the optimization. 0 value is used, if UseIntrinsicGuess is not set.
    /// </summary>
    FixK3 = 1 << 6,

    /// <summary>
    /// The distortion coefficient k4 is not changed during the optimization. 0 value is used, if UseIntrinsicGuess is not set.
    /// </summary>
    FixK4 = 1 << 7,

    /// <summary>
    /// For stereo and multi-camera calibration only. Do not optimize cameras intrinsics.
    /// </summary>
    FixIntrinsic = 1 << 8,

    /// <summary>
    /// The principal point (cx, cy) stays the same as in the input camera matrix. Image center is used as principal point, if UseIntrinsicGuess is not set.
    /// </summary>
    FixPrincipalPoint = 1 << 9
}

namespace OpenCvSharp;

/// <summary>
/// The operation flags for cvStereoRectify
/// </summary>
[Flags]
public enum StereoRectificationFlags
{
    /// <summary>
    /// Default value (=0).
    /// the function can shift one of the image in horizontal or vertical direction (depending on the orientation of epipolar lines) in order to maximise the useful image area. 
    /// </summary>
    None = 0,

    /// <summary>
    /// the function makes the principal points of each camera have the same pixel coordinates in the rectified views. 
    /// </summary>
    ZeroDisparity = 1024,
};

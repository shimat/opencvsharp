#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

/// <summary>
/// Interpolation algorithm
/// </summary>
[Flags]
public enum InterpolationFlags
{
    /// <summary>
    /// Nearest-neighbor interpolation, 
    /// </summary>
    Nearest = 0,

    /// <summary>
    /// Bilinear interpolation (used by default) 
    /// </summary>
    Linear = 1,

    /// <summary>
    /// Bicubic interpolation. 
    /// </summary>
    Cubic = 2,

    /// <summary>
    /// Resampling using pixel area relation. It is the preferred method for image decimation that gives moire-free results. In case of zooming it is similar to CV_INTER_NN method. 
    /// </summary>
    Area = 3,
        
    /// <summary>
    /// Lanczos interpolation over 8x8 neighborhood
    /// </summary>
    Lanczos4 = 4,

    /// <summary>
    /// Bit exact bilinear interpolation
    /// </summary>
    LinearExact = 5,

    /// <summary>
    /// mask for interpolation codes
    /// </summary>
    Max = 7,

    /// <summary>
    /// Fill all the destination image pixels. If some of them correspond to outliers in the source image, they are set to fillval. 
    /// </summary>
    WarpFillOutliers = 8,

    /// <summary>
    /// Indicates that matrix is inverse transform from destination image to source and, 
    /// thus, can be used directly for pixel interpolation. Otherwise, the function finds the inverse transform from map_matrix. 
    /// </summary>
    WarpInverseMap = 16,
}

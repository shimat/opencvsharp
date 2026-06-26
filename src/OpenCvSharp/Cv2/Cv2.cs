

// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// OpenCV Functions of C++ I/F (cv::xxx) 
/// </summary>
public static partial class Cv2
{
    /// <summary>
    /// The ratio of a circle's circumference to its diameter
    /// </summary>
    public const double PI = 3.1415926535897932384626433832795;

    /// <summary>
    /// 
    /// </summary>
    public const double LOG2 = 0.69314718055994530941723212145818;

    /// <summary>
    /// 
    /// </summary>
    public const int FILLED = -1;
        
    /// <summary>
    /// Returns the object's native pointer, or <see cref="IntPtr.Zero"/> when the object is null
    /// (for optional native arguments such as mask / noArray).
    /// </summary>
    internal static IntPtr ToPtr(CvObject? obj) => obj?.CvPtr ?? IntPtr.Zero;
}

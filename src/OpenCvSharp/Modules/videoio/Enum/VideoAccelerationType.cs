
namespace OpenCvSharp;

/// <summary>
/// Video Acceleration type
/// Used as value in #CAP_PROP_HW_ACCELERATION and #VIDEOWRITER_PROP_HW_ACCELERATION
/// note In case of FFmpeg backend, it translated to enum AVHWDeviceType (https://github.com/FFmpeg/FFmpeg/blob/master/libavutil/hwcontext.h)
/// </summary>
public enum VideoAccelerationType
{
    /// <summary>
    /// Do not require any specific H/W acceleration, prefer software processing.
    /// Reading of this value means that special H/W accelerated handling is not added or not detected by OpenCV.
    /// </summary>
    None = 0,

    /// <summary>
    /// Prefer to use H/W acceleration. If no one supported, then fallback to software processing.
    /// note H/W acceleration may require special configuration of used environment.
    /// note Results in encoding scenario may differ between software and hardware accelerated encoders.
    /// </summary>
    Any = 1,

    /// <summary>
    /// DirectX 11
    /// </summary>
    D3D11 = 2,

    /// <summary>
    /// VAAPI
    /// </summary>
    VAAPI = 3,

    /// <summary>
    /// libmfx (Intel MediaSDK/oneVPL)
    /// </summary>
    MFX = 4,
}

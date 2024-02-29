namespace OpenCvSharp;

/// <summary>
/// Parameters of VideoCature for hardware acceleration
/// Please check the link below for current HW acceleration types support matrix
/// https://github.com/opencv/opencv/wiki/Video-IO-hardware-acceleration
/// </summary>
[Serializable]
public record VideoCapturePara
{
    /// <summary>
    /// Used as value in #CAP_PROP_HW_ACCELERATION and #VIDEOWRITER_PROP_HW_ACCELERATION
    /// note In case of FFmpeg backend, it translated to enum AVHWDeviceType (https://github.com/FFmpeg/FFmpeg/blob/master/libavutil/hwcontext.h)
    /// </summary>
    public VideoAccelerationType AccelerationType { get; }

    /// <summary>
    /// Hardware device index (select GPU if multiple available). Device enumeration is acceleration type specific.
    /// </summary>
    public int HwDeviceIndex { get; }

    /// <summary>
    /// Constructor, parameter of VideoCature for hardware acceleration
    /// </summary>
    public VideoCapturePara()
    {
        AccelerationType = VideoAccelerationType.Any;
        HwDeviceIndex = -1;
    }

    /// <summary>
    /// Constructor, parameter of VideoCature for hardware acceleration
    /// </summary>
    /// <param name="videoAcceleration">Video Acceleration type</param>
    /// <param name="deviceIndex">Hardware device index </param>
    public VideoCapturePara(VideoAccelerationType videoAcceleration, int deviceIndex)
    {
        AccelerationType = videoAcceleration;
        HwDeviceIndex = deviceIndex;
    }

    /// <summary>
    /// Get parameters of VideoCature for hardware acceleration
    /// </summary>
    public int[] GetParameters() => new[] { (int)VideoCaptureProperties.HwAcceleration, (int)AccelerationType,
        (int)VideoCaptureProperties.HwDevice, HwDeviceIndex };
}

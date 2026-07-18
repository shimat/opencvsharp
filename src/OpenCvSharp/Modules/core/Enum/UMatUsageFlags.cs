namespace OpenCvSharp;

/// <summary>
/// cv::UMatUsageFlags
/// </summary>
[Flags]
public enum UMatUsageFlags
{
    /// <summary>
    /// Default allocation policy. Unlike the other flags, this one is not experimental.
    /// </summary>
    None = 0,

    // buffer allocation policy is platform and usage specific

    /// <summary>
    /// Allocate host (CPU) memory. This flag is experimental; the buffer allocation policy is platform and usage specific.
    /// </summary>
    HostMemory = 1 << 0,

    /// <summary>
    /// Allocate device (GPU) memory. This flag is experimental; the buffer allocation policy is platform and usage specific.
    /// </summary>
    DeviceMemory = 1 << 1,

    /// <summary>
    /// Allocate memory shared between host and device. This flag is experimental and, for the OpenCL allocator,
    /// depends on OpenCV's optional OpenCL SVM integration. It is not equal to HostMemory | DeviceMemory.
    /// </summary>
    SharedMemory = 1 << 2,
}

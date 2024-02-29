namespace OpenCvSharp;

/// <summary>
/// cv::UMatUsageFlags
/// </summary>
[Flags]
public enum UMatUsageFlags
{
#pragma warning disable 1591
    None = 0,

    // buffer allocation policy is platform and usage specific
    HostMemory = 1 << 0,
    DeviceMemory = 1 << 1,
    SharedMemory = 1 << 2, // It is not equal to: USAGE_ALLOCATE_HOST_MEMORY | USAGE_ALLOCATE_DEVICE_MEMORY
}

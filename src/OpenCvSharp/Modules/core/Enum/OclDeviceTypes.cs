namespace OpenCvSharp;

/// <summary>
/// OpenCL device types reported by cv::ocl::Device.
/// </summary>
[Flags]
public enum OclDeviceTypes : uint
{
    /// <summary>
    /// The default OpenCL device type.
    /// </summary>
    Default = 1U << 0,

    /// <summary>
    /// A CPU OpenCL device.
    /// </summary>
    Cpu = 1U << 1,

    /// <summary>
    /// A GPU OpenCL device.
    /// </summary>
    Gpu = 1U << 2,

    /// <summary>
    /// A dedicated accelerator OpenCL device.
    /// </summary>
    Accelerator = 1U << 3,

    /// <summary>
    /// A discrete GPU selector used by OpenCV device configuration.
    /// </summary>
    DiscreteGpu = Gpu | (1U << 16),

    /// <summary>
    /// An integrated GPU selector used by OpenCV device configuration.
    /// </summary>
    IntegratedGpu = Gpu | (1U << 17),

    /// <summary>
    /// All OpenCL device types.
    /// </summary>
    All = uint.MaxValue,
}

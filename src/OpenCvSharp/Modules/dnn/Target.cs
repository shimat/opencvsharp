#pragma warning disable CS1591

// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming

namespace OpenCvSharp.Dnn;

/// <summary>
/// Enum of target devices for computations.
/// </summary>
public enum Target
{
    CPU,
    OPENCL,
    OPENCL_FP16,
    MYRIAD,
    VULKAN,

    /// <summary>
    /// FPGA device with CPU fallbacks using Inference Engine's Heterogeneous plugin.
    /// </summary>
    FPGA,
    CUDA,
    CUDA_FP16,
    HDDL
}

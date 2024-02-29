

// ReSharper disable InconsistentNaming

namespace OpenCvSharp;

/// <summary>
/// cv::AccessFlag
/// </summary>
[Flags]
public enum AccessFlag
{
#pragma warning disable 1591
    READ = 1 << 24,
    WRITE = 1 << 25,
    RW = 3 << 24, 
    MASK = RW, 
    FAST = 1 << 26
}

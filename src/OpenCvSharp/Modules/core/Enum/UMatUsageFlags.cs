using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cv::UMatUsageFlags
    /// </summary>
#else
    /// <summary>
    /// Usage flags for allocator.
    /// </summary>
#endif
    [Flags]
    public enum UMatUsageFlags
    {
        USAGE_DEFAULT = 0,

        // buffer allocation policy is platform and usage specific
        USAGE_ALLOCATE_HOST_MEMORY = 1 << 0,
        USAGE_ALLOCATE_DEVICE_MEMORY = 1 << 1,
        USAGE_ALLOCATE_SHARED_MEMORY = 1 << 2, // It is not equal to: USAGE_ALLOCATE_HOST_MEMORY | USAGE_ALLOCATE_DEVICE_MEMORY

        __UMAT_USAGE_FLAGS_32BIT = 0x7fffffff, // Binary compatibility hint
    }
}

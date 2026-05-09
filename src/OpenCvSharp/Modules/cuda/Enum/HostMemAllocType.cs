#if ENABLED_CUDA
namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Type of memory allocation for HostMem.
    /// </summary>
    public enum HostMemAllocType
    {
        PageLocked = 1,
        Shared = 2,
        WriteCombined = 4
    }
}
#endif

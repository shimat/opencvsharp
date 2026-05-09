#if ENABLED_CUDA
namespace OpenCvSharp.Cuda
{
    /// <summary>
    /// Enumeration of CUDA event creation flags.
    /// </summary>
    [Flags]
    public enum EventCreateFlags : uint
    {
        /// <summary>
        /// Default event creation flag.
        /// </summary>
        Default = 0x00,

        /// <summary>
        /// Event uses blocking synchronization.
        /// </summary>
        BlockingSync = 0x01,

        /// <summary>
        /// Event will not record timing data (better performance).
        /// </summary>
        DisableTiming = 0x02,

        /// <summary>
        /// Event can be used as an interprocess event.
        /// </summary>
        Interprocess = 0x04
    }
}
#endif

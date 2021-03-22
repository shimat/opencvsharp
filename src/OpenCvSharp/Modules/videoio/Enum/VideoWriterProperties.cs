#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp
{
    /// <summary>
    /// VideoWriter generic properties identifier.
    /// </summary>
    public enum VideoWriterProperties 
    {
        /// <summary>
        /// Current quality (0..100%) of the encoded video stream. Can be adjusted dynamically in some codecs.
        /// </summary>
        Quality = 1,

        /// <summary>
        /// (Read-only): Size of just encoded video frame. Note that the encoding order may be different from representation order.
        /// </summary>
        FrameBytes = 2, 

        /// <summary>
        /// Number of stripes for parallel encoding. -1 for auto detection.
        /// </summary>
        NStripes = 3,
    }
}
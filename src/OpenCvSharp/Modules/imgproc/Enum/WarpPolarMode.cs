using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Specify the polar mapping mode
    /// </summary>
    [Flags]
    public enum WarpPolarMode
    {
        /// <summary>
        /// Remaps an image to/from polar space.
        /// </summary>
        Linear = 0, 

        /// <summary>
        /// Remaps an image to/from semilog-polar space.
        /// </summary>
        Log = 256
    }
}
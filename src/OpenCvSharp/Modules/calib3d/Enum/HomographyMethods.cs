using System;

namespace OpenCvSharp
{
    /// <summary>
    /// The method used to computed homography matrix
    /// </summary>
    [Flags]
    public enum HomographyMethods
    {
        /// <summary>
        /// Regular method using all the point pairs
        /// </summary>
        None = 0,

        /// <summary>
        /// Least-Median robust method
        /// </summary>
        LMedS = 4,

        /// <summary>
        /// RANSAC-based robust method
        /// </summary>
        Ransac = 8,

        /// <summary>
        /// RHO algorithm
        /// </summary>
        Rho = 16,
    }
}

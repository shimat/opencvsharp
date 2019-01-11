using System;

namespace OpenCvSharp
{
    /// <summary>
    /// Method for computing the essential matrix 
    /// </summary>
    [Flags]
    public enum EssentialMatMethod : int
    {
        /// <summary>
        /// for LMedS algorithm.
        /// </summary>
        LMedS = 4,


        /// <summary>
        /// for RANSAC algorithm.
        /// </summary>
        Ransac = 8,
    }
}

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// type of the robust estimation algorithm
    /// </summary>
    public enum RobustEstimationAlgorithms
    {
        /// <summary>
        /// least-median of squares algorithm
        /// </summary>
        LMEDS = 4,

        /// <summary>
        /// RANSAC algorithm
        /// </summary>
        RANSAC = 8,

        /// <summary>
        /// RHO algorithm
        /// </summary>
        RHO = 16 
    }
}
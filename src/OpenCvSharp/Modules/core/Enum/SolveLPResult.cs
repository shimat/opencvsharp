namespace OpenCvSharp
{
    /// <summary>
    /// return codes for cv::solveLP() function
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public enum SolveLPResult
    {
        /// <summary>
        /// problem is unbounded (target function can achieve arbitrary high values)
        /// </summary>
        Unbounded = -2,

        /// <summary>
        /// problem is unfeasible (there are no points that satisfy all the constraints imposed)
        /// </summary>
        Unfeasible = -1,

        /// <summary>
        /// there is only one maximum for target function
        /// </summary>
        Single = 0,

        /// <summary>
        /// there are multiple maxima for target function - the arbitrary one is returned
        /// </summary>
        Multi = 1 
    }
}
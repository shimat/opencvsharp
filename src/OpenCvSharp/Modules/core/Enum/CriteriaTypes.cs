namespace OpenCvSharp;

/// <summary>
/// Type of termination criteria 
/// </summary>
[Flags]
public enum CriteriaTypes
{
    /// <summary>
    /// the maximum number of iterations or elements to compute
    /// </summary>
    Count = 1,

    /// <summary>
    /// the maximum number of iterations or elements to compute
    /// </summary>
    MaxIter = Count,

    /// <summary>
    /// the desired accuracy or change in parameters at which the iterative algorithm stops
    /// </summary>
    Eps = 2,
}

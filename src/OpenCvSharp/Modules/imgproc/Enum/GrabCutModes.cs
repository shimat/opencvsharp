#pragma warning disable CA1008 // Enums should have zero value

namespace OpenCvSharp;

/// <summary>
/// GrabCut algorithm flags
/// </summary>
[Flags]
public enum GrabCutModes 
{
    /// <summary>
    ///  The function initializes the state and the mask using the provided rectangle. 
    /// After that it runs iterCount iterations of the algorithm.
    /// </summary>
    InitWithRect = 0,

    /// <summary>
    ///  The function initializes the state using the provided mask. 
    /// Note that GC_INIT_WITH_RECT and GC_INIT_WITH_MASK can be combined. 
    /// Then, all the pixels outside of the ROI are automatically initialized with GC_BGD .
    /// </summary>
    InitWithMask = 1,

    /// <summary>
    ///  The value means that the algorithm should just resume.
    /// </summary>
    Eval = 2,
}

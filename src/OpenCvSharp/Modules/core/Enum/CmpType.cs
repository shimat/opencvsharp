namespace OpenCvSharp;

// ReSharper disable InconsistentNaming
/// <summary>
/// The flag specifying the relation between the elements to be checked
/// </summary>
public enum CmpType
{
    /// <summary>
    /// src1(I) "equal to" src2(I)
    /// </summary>
    EQ = 0,
        
    /// <summary>
    /// src1(I) "greater than" src2(I)
    /// </summary>
    GT = 1,
        
    /// <summary>
    /// src1(I) "greater or equal" src2(I)
    /// </summary>
    GE = 2,

    /// <summary>
    /// src1(I) "less than" src2(I)
    /// </summary>
    LT = 3,

    /// <summary>
    /// src1(I) "less or equal" src2(I)
    /// </summary>
    LE = 4,

    /// <summary>
    /// src1(I) "not equal to" src2(I)
    /// </summary>
    NE = 5,
}

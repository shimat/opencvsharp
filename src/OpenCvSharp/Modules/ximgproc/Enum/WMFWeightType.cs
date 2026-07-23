namespace OpenCvSharp.XImgProc;

// ReSharper disable InconsistentNaming
/// <summary>
/// Specifies weight types of weighted median filter.
/// </summary>
[Flags]
public enum WMFWeightType
{
    /// <summary>
    /// \f$exp(-|I1-I2|^2/(2*sigma^2))\f$
    /// </summary>
    EXP = 1,

    /// <summary>
    /// \f$(|I1-I2|+sigma)^-1\f$
    /// </summary>
    IV1 = 1 << 1,

    /// <summary>
    /// \f$(|I1-I2|^2+sigma^2)^-1\f$
    /// </summary>
    IV2 = 1 << 2,

    /// <summary>
    ///  \f$dot(I1,I2)/(|I1|*|I2|)\f$
    /// </summary>
    COS = 1 << 3,

    /// <summary>
    /// \f$(min(r1,r2)+min(g1,g2)+min(b1,b2))/(max(r1,r2)+max(g1,g2)+max(b1,b2))\f$
    /// </summary>
    JAC = 1 << 4,

    /// <summary>
    /// unweighted
    /// </summary>
    OFF = 1 << 5
}

using System;
using System.Collections.Generic;

namespace OpenCvSharp.XImgProc
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Specifies weight types of weighted median filter.
    /// </summary>
    public enum WMFWeightType : int
    {
        /// <summary>
        /// \f$exp(-|I1-I2|^2/(2*sigma^2))\f$
        /// </summary>
        EXP,

        /// <summary>
        /// \f$(|I1-I2|+sigma)^-1\f$
        /// </summary>
        IV1,

        /// <summary>
        /// \f$(|I1-I2|^2+sigma^2)^-1\f$
        /// </summary>
        IV2,

        /// <summary>
        ///  \f$dot(I1,I2)/(|I1|*|I2|)\f$
        /// </summary>
        COS,

        /// <summary>
        /// \f$(min(r1,r2)+min(g1,g2)+min(b1,b2))/(max(r1,r2)+max(g1,g2)+max(b1,b2))\f$
        /// </summary>
        JAC,

        /// <summary>
        /// unweighted
        /// </summary>
        OFF 
    }
}
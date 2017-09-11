using System;
using System.Collections.Generic;

namespace OpenCvSharp.XImgProc
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Specifies binary operations.
    /// </summary>
    /// <remarks>
    /// The enum specifies binary operations, that is such ones which involve 
    /// two operands. Formally, a binary operation @f$ f @f$ on a set @f$ S @f$ 
    /// is a binary relation that maps elements of the Cartesian product 
    /// @f$ S \times S @f$ to @f$ S @f$: 
    /// @f[ f: S \times S \to S @f]
    /// </remarks>
    public enum HoughOP : int
    {
        /// <summary>
        /// Binary minimum operation. The constant specifies the binary minimum operation
        /// @f$ f @f$ that is defined as follows: @f[ f(x, y) = \min(x, y) @f]
        /// </summary>
        FHT_MIN = 0, 

        /// <summary>
        /// Binary maximum operation. The constant specifies the binary maximum operation
        /// @f$ f @f$ that is defined as follows: @f[ f(x, y) = \max(x, y) @f]
        /// </summary>
        FHT_MAX = 1, 

        /// <summary>
        /// Binary addition operation. The constant specifies the binary addition operation
        /// @f$ f @f$ that is defined as follows: @f[ f(x, y) = x + y @f]
        /// </summary>
        FHT_ADD = 2,

        /// <summary>
        /// Binary average operation. The constant specifies the binary average operation
        /// @f$ f @f$ that is defined as follows: @f[ f(x, y) = \frac{x + y}{2} @f]
        /// </summary>
        FHT_AVE = 3
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Prototype
{
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// Constantt values
    /// </summary>
    internal static class CppConst
    {
        // matrix decomposition types
        public const int DECOMP_LU = 0,
                         DECOMP_SVD = 1,
                         DECOMP_EIG = 2,
                         DECOMP_CHOLESKY = 3,
                         DECOMP_QR = 4,
                         DECOMP_NORMAL = 16;
    }
}

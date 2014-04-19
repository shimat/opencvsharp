using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// MatrixDecomposition
    /// </summary>
    public enum MatrixDecomposition : int
    {
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
       LU = CppConst.DECOMP_LU,
       SVD = CppConst.DECOMP_SVD,
       EIG = CppConst.DECOMP_EIG,
       Cholesky = CppConst.DECOMP_CHOLESKY,
       QR = CppConst.DECOMP_QR,
       NORMAL = CppConst.DECOMP_NORMAL,
    }
}

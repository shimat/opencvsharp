using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.CPlusPlus.Prototype;

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// MatrixDecomposition
    /// </summary>
    public enum MatrixDecomposition : int
    {   
       LU = CppConst.DECOMP_LU,
       SVD = CppConst.DECOMP_SVD,
       EIG = CppConst.DECOMP_EIG,
       Cholesky = CppConst.DECOMP_CHOLESKY,
       QR = CppConst.DECOMP_QR,
       NORMAL = CppConst.DECOMP_NORMAL,
    }
}

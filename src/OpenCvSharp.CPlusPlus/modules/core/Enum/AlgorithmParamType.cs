/*
 * (C) 2008-2014 shimat
 * This code is licenced under the LGPL.
 */

using System;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// cv::Algorithm parameter type
    /// </summary>
    public enum AlgorithmParamType : int
    {
        Int = CppConst.Param_INT,
        Boolean = CppConst.Param_BOOLEAN,
        Real = CppConst.Param_REAL,
        String = CppConst.Param_STRING,
        Mat = CppConst.Param_MAT,
        MatVector = CppConst.Param_MAT_VECTOR,
        Algorithm = CppConst.Param_ALGORITHM,
        Float = CppConst.Param_FLOAT,
        UnsignedInt = CppConst.Param_UNSIGNED_INT,
        UInt64 = CppConst.Param_UINT64,
        Short = CppConst.Param_SHORT,
        UChar = CppConst.Param_UCHAR
    }
}

using System;

#pragma warning disable 1591

namespace OpenCvSharp
{
    /// <summary>
    /// cv::Algorithm parameter type
    /// </summary>
    public enum AlgorithmParamType : int
    {
        Int = 0,
        Boolean = 1,
        Real = 2,
        String = 3,
        Mat = 4,
        MatVector = 5,
        Algorithm = 6,
        Float = 7,
        UnsignedInt = 8,
        UInt64 = 9,
        Short = 10,
        UChar = 11
    }
}

using System;

namespace OpenCvSharp
{
    #pragma warning disable CS1591

    [Flags]
    public enum FishEyeCalibrationFlags
    {
        None = 0,
        UseIntrinsicGuess = 1 << 0,
        RecomputeExtrinsic = 1 << 1,
        CheckCond = 1 << 2,
        FixSkew = 1 << 3,
        FixK1 = 1 << 4,
        FixK2 = 1 << 5,
        FixK3 = 1 << 6,
        FixK4 = 1 << 7,
        FixIntrinsic = 1 << 8,
        FixPrincipalPoint = 1 << 9
    }
}

using System;

namespace OpenCvSharp
{
    #pragma warning disable CS1591

    [Flags]
    public enum FishEyeCalibrationFlags
    {
        None = 0,
        USE_INTRINSIC_GUESS = 1 << 0,
        RECOMPUTE_EXTRINSIC = 1 << 1,
        CHECK_COND = 1 << 2,
        FIX_SKEW = 1 << 3,
        FIX_K1 = 1 << 4,
        FIX_K2 = 1 << 5,
        FIX_K3 = 1 << 6,
        FIX_K4 = 1 << 7,
        FIX_INTRINSIC = 1 << 8,
        FIX_PRINCIPAL_POINT = 1 << 9
    };
}

        


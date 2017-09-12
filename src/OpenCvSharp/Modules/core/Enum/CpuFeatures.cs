namespace OpenCvSharp
{
    /// <summary>
    /// 
    /// </summary>
    public enum CpuFeatures : int
    {
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
        MMX = 1,
        SSE = 2,
        SSE2 = 3,
        SSE3 = 4,
        SSSE3 = 5,
        SSE4_1 = 6,
        SSE4_2 = 7,
        POPCNT = 8,

        AVX = 10,
        AVX2 = 11,
        FMA3 = 12,

        AVX_512F = 13,
        AVX_512BW = 14,
        AVX_512CD = 15,
        AVX_512DQ = 16,
        AVX_512ER = 17,
        AVX_512IFMA512 = 18,
        AVX_512PF = 19,
        AVX_512VBMI = 20,
        AVX_512VL = 21,

        NEON = 100
    }
}



using System.Diagnostics.CodeAnalysis;

namespace OpenCvSharp;

/// <summary>
/// 
/// </summary>
[SuppressMessage("Microsoft.Design", "CA1008: Enums should have zero value")]
[SuppressMessage("Microsoft.Design", "CA1069: Enums should not have duplicate values")]
public enum CpuFeatures
{
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
    MMX             = 1,
    SSE             = 2,
    SSE2            = 3,
    SSE3            = 4,
    SSSE3           = 5,
    SSE4_1          = 6,
    SSE4_2          = 7,
    POPCNT          = 8,
    FP16            = 9,
    AVX             = 10,
    AVX2            = 11,
    FMA3            = 12,

    AVX_512F        = 13,
    AVX_512BW       = 14,
    AVX_512CD       = 15,
    AVX_512DQ       = 16,
    AVX_512ER       = 17,
    AVX_512IFMA512  = 18, // deprecated
    AVX_512IFMA     = 18,
    AVX_512PF       = 19,
    AVX_512VBMI     = 20,
    AVX_512VL       = 21,
    AVX_512VBMI2    = 22,
    AVX_512VNNI     = 23,
    AVX_512BITALG   = 24,
    AVX_512VPOPCNTDQ= 25,
    AVX_5124VNNIW   = 26,
    AVX_5124FMAPS   = 27,

    NEON            = 100,

    VSX             = 200,
    VSX3            = 201,

    AVX512_SKX      = 256, //!< Skylake-X with AVX-512F/CD/BW/DQ/VL
    AVX512_COMMON   = 257, //!< Common instructions AVX-512F/CD for all CPUs that support AVX-512
    AVX512_KNL      = 258, //!< Knights Landing with AVX-512F/CD/ER/PF
    AVX512_KNM      = 259, //!< Knights Mill with AVX-512F/CD/ER/PF/4FMAPS/4VNNIW/VPOPCNTDQ
    AVX512_CNL      = 260, //!< Cannon Lake with AVX-512F/CD/BW/DQ/VL/IFMA/VBMI
    AVX512_CEL      = 261, //!< Cascade Lake with AVX-512F/CD/BW/DQ/VL/IFMA/VBMI/VNNI
    AVX512_ICL      = 262, //!< Ice Lake with AVX-512F/CD/BW/DQ/VL/IFMA/VBMI/VNNI/VBMI2/BITALG/VPOPCNTDQ

    MAX_FEATURE     = 512  // see CV_HARDWARE_MAX_FEATURE
}

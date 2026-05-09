#if ENABLED_CUDA
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Cuda;

public enum AlphaCompTypes
{
    Over = 0,
    In = 1,
    Out = 2,
    Atop = 3,
    Xor = 4,
    Plus = 5,
    OverPremul = 6,
    InPremul = 7,
    OutPremul = 8,
    AtopPremul = 9,
    XorPremul = 10,
    PlusPremul = 11,
    Premul = 12
}
#endif

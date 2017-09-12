using System;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming
#pragma warning disable 1591

    /// <summary>
    /// AGAST type one of the four neighborhoods as defined in the paper
    /// </summary>
    public enum AGASTType : int
    {
        AGAST_5_8 = 0, 
        AGAST_7_12d = 1, 
        AGAST_7_12s = 2,
        OAST_9_16 = 3,
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.Flann
{
#pragma warning disable 1591
// ReSharper disable InconsistentNaming

    /// <summary>
    /// 
    /// </summary>
    public enum FlannDistance
    {
        Euclidean = 1,
        L2 = 1,
        Manhattan = 2,
        L1 = 2,
        Minkowski = 3,
        Max = 4,
        HistIntersect = 5,
        Hellinger = 6,
        ChiSquare = 7,
        CS = 7,
        KullbackLeibler =  8,
        KL = 8,
        Hamming = 9,
    }
}

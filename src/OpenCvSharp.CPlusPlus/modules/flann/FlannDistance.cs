using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp.CPlusPlus.Flann
{
#pragma warning disable 1591

    /// <summary>
    /// 
    /// </summary>
    public enum FlannDistance
    {
        Euclidean = CppConst.FLANN_DIST_EUCLIDEAN,
        L2 = CppConst.FLANN_DIST_L2,
        Manhattan = CppConst.FLANN_DIST_MANHATTAN,
        L1 = CppConst.FLANN_DIST_L1,
        Minkowski = CppConst.FLANN_DIST_MINKOWSKI,
        Max = CppConst.FLANN_DIST_MAX,
        HistIntersect = CppConst.FLANN_DIST_HIST_INTERSECT,
        Hellinger = CppConst.FLANN_DIST_HELLINGER,
        ChiSquare = CppConst.FLANN_DIST_CHI_SQUARE,
        CS = CppConst.FLANN_DIST_CS,
        KullbackLeibler =  CppConst.FLANN_DIST_KULLBACK_LEIBLER,
        KL = CppConst.FLANN_DIST_KL,
        Hamming = CppConst.FLANN_DIST_HAMMING,
    }
}

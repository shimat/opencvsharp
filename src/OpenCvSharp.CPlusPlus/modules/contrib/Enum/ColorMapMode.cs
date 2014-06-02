using System;

#pragma warning disable 1591

namespace OpenCvSharp.CPlusPlus
{
    /// <summary>
    /// Flags for applyColorMap
    /// </summary>
    public enum ColorMapMode : int
    {
        Autumn = CppConst.COLORMAP_AUTUMN,
        Bone = CppConst.COLORMAP_BONE,
        Jet = CppConst.COLORMAP_JET,
        Winter = CppConst.COLORMAP_WINTER,
        Rainbow =CppConst.COLORMAP_RAINBOW,
        Ocean = CppConst.COLORMAP_OCEAN,
        Summer = CppConst.COLORMAP_SUMMER,
        Spring = CppConst.COLORMAP_SPRING,
        Cool = CppConst.COLORMAP_COOL,
        Hsv = CppConst.COLORMAP_HSV,
        Pink =CppConst.COLORMAP_PINK,
        Hot = CppConst.COLORMAP_HOT
    }
}

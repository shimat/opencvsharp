
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// CvLineIteratorにおける、走査した線分の接続性
    /// </summary>
#else
    /// <summary>
    /// PixelConnectivity for LineIterator
    /// </summary>
#endif
    public enum PixelConnectivity : int
    {
#if LANG_JP
        /// <summary>
        /// 周囲4方向(上下左右)
        /// </summary>
#else
        /// <summary>
        /// Connectivity 4 (N,S,E,W)
        /// </summary>
#endif
        Connectivity4 = 4,


#if LANG_JP
        /// <summary>
        /// 周囲8方向
        /// </summary>
#else
        /// <summary>
        /// Connectivity 8 (N,S,E,W,NE,SE,SW,NW)
        /// </summary>
#endif
        Connectivity8 = 8,
    }
}

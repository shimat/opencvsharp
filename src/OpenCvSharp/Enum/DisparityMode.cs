
namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 視差を計算するためのアルゴリズム
    /// </summary>
#else
    /// <summary>
    /// Mode of correspondence retrieval
    /// </summary>
#endif
    public enum DisparityMode
    {
        /// <summary>
        /// [CV_DISPARITY_BIRCHFIELD]
        /// </summary>
        Birchfield = CvConst.CV_DISPARITY_BIRCHFIELD,
    }
}

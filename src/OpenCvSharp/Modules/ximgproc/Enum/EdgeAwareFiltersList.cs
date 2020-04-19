namespace OpenCvSharp.XImgProc
{
    /// <summary>
    /// one form three modes DTF_NC, DTF_RF and DTF_IC which corresponds to three modes for
    /// filtering 2D signals in the article.
    /// </summary>
    public enum EdgeAwareFiltersList
    {
#pragma warning disable 1591
        DTF_NC,
        DTF_IC,
        DTF_RF,
        GUIDED_FILTER,
        AM_FILTER
    }
}
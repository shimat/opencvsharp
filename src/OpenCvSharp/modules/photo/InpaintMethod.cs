
namespace OpenCvSharp
{
#if LANG_JP
   	/// <summary>
	/// cvInpaintの修復方法
	/// </summary>
#else
    /// <summary>
    /// The inpainting method
    /// </summary>
#endif
    public enum InpaintMethod
    {
#if LANG_JP
		/// <summary>
		/// ナビエ・ストークス(Navier-Stokes)ベースの手法
        /// [CV_INPAINT_NS]
		/// </summary>
#else
        /// <summary>
        /// Navier-Stokes based method.
        /// [CV_INPAINT_NS]
        /// </summary>
#endif
// ReSharper disable once InconsistentNaming
        NS = 0,


#if LANG_JP
		/// <summary>
		/// Alexandru Teleaによる手法 
        /// [CV_INPAINT_TELEA]
		/// </summary>
#else
        /// <summary>
        /// The method by Alexandru Telea
        /// [CV_INPAINT_TELEA]
        /// </summary>
#endif
        Telea = 1,
    }
}

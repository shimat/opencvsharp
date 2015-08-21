using System;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvLoadImageで用いる読み込みフラグ ．
	/// </summary>
#else
    /// <summary>
    /// Specifies colorness and Depth of the loaded image
    /// </summary>
#endif
	[Flags]
    public enum ImreadModes : int
	{
        #if LANG_JP
		/// <summary>
		/// 8 ビット，カラーまたはグレースケール [CV_LOAD_IMAGE_UNCHANGED]
		/// </summary>
#else
        /// <summary>
        /// If set, return the loaded image as is (with alpha channel, otherwise it gets cropped).
        /// </summary>
#endif		
        Unchanged = -1,


#if LANG_JP
		/// <summary>
		/// 8 ビット，グレースケール [CV_LOAD_IMAGE_GRAYSCALE]
		/// </summary>
#else
        /// <summary>
        /// If set, always convert image to the single channel grayscale image.
        /// </summary>
#endif
		GrayScale = 0,


#if LANG_JP
		/// <summary>
		/// AnyDepth と併用されない限り 8 ビット，カラー [CV_LOAD_IMAGE_COLOR]
		/// </summary>
#else
        /// <summary>
        /// If set, always convert image to the 3 channel BGR color image.
        /// </summary>
#endif
		Color = 1,


#if LANG_JP
		/// <summary>
		///任意のデプス，グレー [CV_LOAD_IMAGE_ANYDEPTH]
		/// </summary>
#else
        /// <summary>
        /// If set, return 16-bit/32-bit image when the input has the corresponding depth, otherwise convert it to 8-bit.
        /// </summary>
#endif
		AnyDepth = 2,


#if LANG_JP
		/// <summary>
		/// 8 ビット，カラーまたはグレースケール [CV_LOAD_IMAGE_ANYCOLOR]. 
		/// AnyDepth と併用可能.
		/// </summary>
#else
        /// <summary>
        /// If set, the image is read in any possible color format.
        /// </summary>
#endif
        AnyColor = 4,

        /// <summary>
        /// If set, use the gdal driver for loading the image.
        /// </summary>
        LoadGdal = 8,
	};
}

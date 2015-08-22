
namespace OpenCvSharp
{
    // TODO support createButton

#if LANG_JP
    /// <summary>
	/// cv::createButton で用いるボタンの種類
	/// </summary>
#else
    /// <summary>
    /// Button type flags (cv::createButton)
    /// </summary>
#endif
    public enum ButtonTypes : int
    {
#if LANG_JP
		/// <summary>
		/// 通常のプッシュボタン．
		/// </summary>
#else
        /// <summary>
        /// The button will be a push button.
        /// </summary>
#endif
        PushButton = 0,

#if LANG_JP
		/// <summary>
		/// チェックボックスボタン
		/// </summary>
#else
        /// <summary>
        /// The button will be a checkbox button.
        /// </summary>
#endif
        Checkbox = 1,

#if LANG_JP
		/// <summary>
		/// ラジオボックスボタン．
		/// 同じボタンバー（同じライン上）にあるラジオボックスは，排他的です．
		/// つまり，同時に1つしか選択できません．
		/// </summary>
#else
        /// <summary>
        /// The button will be a radiobox button. The radiobox on the same buttonbar (same line) are exclusive; one on can be select at the time.
        /// </summary>
#endif
        Radiobox = 2,
    }
}

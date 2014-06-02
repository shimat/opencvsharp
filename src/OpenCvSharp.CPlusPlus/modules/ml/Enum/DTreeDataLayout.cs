using System;

namespace OpenCvSharp.CPlusPlus
{
#if LANG_JP
    /// <summary>
	/// 決定木のデータレイアウト
	/// </summary>
#else
	/// <summary>
	/// Data layout of decision tree
	/// </summary>
#endif
	public enum DTreeDataLayout : int
	{
#if LANG_JP
		/// <summary>
		/// 
		/// [CV_ROW_SAMPLE]
		/// </summary>
#else
		/// <summary>
		/// 
		/// [CV_ROW_SAMPLE]
		/// </summary>
#endif
		RowSample = 1,



#if LANG_JP
		/// <summary>
		/// 
		/// [CV_COL_SAMPLE]
		/// </summary>
#else
		/// <summary>
		/// 
		/// [CV_COL_SAMPLE]
		/// </summary>
#endif
		ColSample = 0,
	}
}


namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
	/// 輪郭の抽出モード 
	/// </summary>
#else
    /// <summary>
    /// mode of the contour retrieval algorithm
    /// </summary>
#endif
    public enum RetrievalModes : int
    {
#if LANG_JP
		/// <summary>
		/// 最も外側の輪郭のみ抽出 
		/// </summary>
#else
        /// <summary>
        /// retrieves only the extreme outer contours. 
        /// It sets `hierarchy[i][2]=hierarchy[i][3]=-1` for all the contours.
        /// </summary>
#endif
        External = 0,
        
#if LANG_JP
		/// <summary>
		/// 全ての輪郭を抽出し，リストに追加 
        /// [CV_RETR_LIST]
		/// </summary>
#else
        /// <summary>
        /// retrieves all of the contours without establishing any hierarchical relationships.
        /// </summary>
#endif
        List = 1,


#if LANG_JP
		/// <summary>
		/// 全ての輪郭を抽出し，二つのレベルを持つ階層構造を構成する．1番目のレベルは連結成分の外側の境界線，2番目のレベルは穴（連結成分の内側に存在する）の境界線 
		/// </summary>
#else
        /// <summary>
        /// retrieves all of the contours and organizes them into a two-level hierarchy. 
        /// At the top level, there are external boundaries of the components. 
        /// At the second level, there are boundaries of the holes. If there is another 
        /// contour inside a hole of a connected component, it is still put at the top level.
        /// </summary>
#endif
        CComp = 2,


#if LANG_JP
		/// <summary>
		/// 全ての輪郭を抽出し，枝分かれした輪郭を完全に表現する階層構造を構成する 
		/// </summary>
#else
        /// <summary>
        /// retrieves all of the contours and reconstructs a full hierarchy 
        /// of nested contours.
        /// </summary>
#endif
        Tree = 3,


#if LANG_JP
		/// <summary>
		/// 
        /// [CV_RETR_FLOODFILL]
		/// </summary>
#else
        /// <summary>
        /// 
        /// </summary>
#endif
        FloodFill = 4,
    }
}

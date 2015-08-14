using System;

#pragma warning disable 1591

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvSortで用いる、配列の並び順指定
    /// </summary>
#else
    /// <summary>
    /// Order flags for cvSort
    /// </summary>
#endif
    [Flags]
    public enum SortFlag : int
    {
        EveryRow = CvConst.CV_SORT_EVERY_ROW,
        EveryColumn = CvConst.CV_SORT_EVERY_COLUMN,
        Ascending = CvConst.CV_SORT_ASCENDING,
        Descending = CvConst.CV_SORT_DESCENDING,
    }
}

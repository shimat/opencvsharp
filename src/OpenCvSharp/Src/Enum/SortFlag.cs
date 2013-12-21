/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

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

/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// cvSeqPushMulti / cvSeqPopMulti で要素を追加する位置
    /// </summary>
#else
    /// <summary>
    /// The flags specifying the modified sequence end
    /// </summary>
#endif
    public enum InsertPosition : int
    {
#if LANG_JP
        /// <summary>
        /// 要素をシーケンスの末尾に追加/削除する
        /// </summary>
#else
        /// <summary>
        /// the elements are added/removed to the end of sequence
        /// </summary>
#endif
        Back = 0,
#if LANG_JP
        /// <summary>
        /// 要素をシーケンスの先頭に追加/削除する
        /// </summary>
#else
        /// <summary>
        /// the elements are added/removed to the beginning of sequenc
        /// </summary>
#endif
        Front = 1
    }
}

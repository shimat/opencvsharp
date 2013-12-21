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
    /// ノードの集合
    /// </summary>
#else
    /// <summary>
    /// Collection of nodes
    /// </summary>
#endif
    public class CvSet<T> : CvSet where T : struct
    {
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvSet*</param>
#else
        /// <summary>
        /// Initializes from native pointer
        /// </summary>
        /// <param name="ptr">struct CvSet*</param>
#endif
        public CvSet(IntPtr ptr)
            : base(ptr)
        {
        }
#if LANG_JP
        /// <summary>
        /// 空のセットを生成する
        /// </summary>
        /// <param name="set_flags">生成するセットのタイプ． </param>
        /// <param name="header_size">セットのヘッダのサイズ（sizeof(CvSet)以上）． </param>
        /// <param name="elem_size">セットの要素のサイズ（CvSetElem 以上）． </param>
        /// <param name="storage">セットのためのコンテナ． </param>
#else
        /// <summary>
        /// Creates empty set
        /// </summary>
        /// <param name="set_flags">Type of the created set. </param>
        /// <param name="header_size">Set header size; may not be less than sizeof(CvSet). </param>
        /// <param name="elem_size">Set element size; may not be less than CvSetElem. </param>
        /// <param name="storage">Container for the set. </param>
#endif
        public CvSet(SeqType set_flags, int header_size, int elem_size, CvMemStorage storage)
            : base(set_flags, header_size, elem_size, storage)
        {
        }
#if LANG_JP
        /// <summary>
        /// CvSetから初期化
        /// </summary>
        /// <param name="set">CvSet</param>
#else
        /// <summary>
        /// Initializes from non generic instance
        /// </summary>
        /// <param name="set">CvSet</param>
#endif
        public CvSet(CvSet set)
            : base(set.CvPtr)
        {
        }

    }
}

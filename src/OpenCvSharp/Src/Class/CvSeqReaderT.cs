/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// CvSeqからデータを読み取るためのクラス
    /// </summary>
#else
    /// <summary>
    /// Sequence reader
    /// </summary>
    /// <typeparam name="T"></typeparam>
#endif
    public class CvSeqReader<T> : CvSeqReader where T : struct
    {
        #region Initialization and Disposal
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
        /// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvSeqReader()
            : base()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Sequence, beign read
        /// </summary>
        new public CvSeq<T> Seq
        {
            get
            {
                if (base.Seq == null)
                    return null;
                else
                    return new CvSeq<T>(base.Seq);
            }
        }
        #endregion

        #region OpenCV Methods
        #region ReadSeqElem
        /// <summary>
        /// シーケンスの要素を一つ読みだして、読み出しポインタを次へ1つ移動させる (CV_READ_SEQ_ELEM相当)
        /// </summary>
        public T ReadSeqElem() 
        {
            T result;
            Cv.READ_SEQ_ELEM<T>(out result, this);
            return result;
        }
        #endregion
        #region RevReadSeqElem
        /// <summary>
        /// シーケンスの前の要素を一つ読みだして、読み出しポインタを前へ1つ移動させる (CV_REV_READ_SEQ_ELEM相当)
        /// </summary>
        public T RevReadSeqElem() 
        {
            T result;
            Cv.REV_READ_SEQ_ELEM<T>(out result, this);
            return result;
        }
        #endregion
        #endregion
    }
}

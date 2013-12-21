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
	/// cvCreateButtonで用いるボタンの種類
	/// </summary>
#else
    /// <summary>
    /// Button type flags (cvCreateButton)
    /// </summary>
#endif
    public enum ButtonType : int
    {
#if LANG_JP
		/// <summary>
		/// ボタンは，通常のプッシュボタンになります．
        /// [CV_PUSH_BUTTON]
		/// </summary>
#else
        /// <summary>
        /// The button will be a push button.
        /// [CV_PUSH_BUTTON]
        /// </summary>
#endif
        PushButton = CvConst.CV_PUSH_BUTTON,


#if LANG_JP
		/// <summary>
		/// ボタンは，チェックボックスボタンになります．
        /// [CV_CHECKBOX]
		/// </summary>
#else
        /// <summary>
        /// The button will be a checkbox button.
        /// [CV_CHECKBOX]
        /// </summary>
#endif
        Checkbox = CvConst.CV_CHECKBOX,


#if LANG_JP
		/// <summary>
		/// ボタンは，ラジオボックスボタンになります．同じボタンバー（同じライン上）にあるラジオボックスは，排他的です．つまり，同時に1つしか選択できません．
        /// [CV_RADIOBOX]
		/// </summary>
#else
        /// <summary>
        /// The button will be a radiobox button. The radiobox on the same buttonbar (same line) are exclusive; one on can be select at the time.
        /// [CV_RADIOBOX]
        /// </summary>
#endif
        Radiobox = CvConst.CV_RADIOBOX,
    }
}

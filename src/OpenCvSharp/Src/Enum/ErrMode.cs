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
    /// エラーモード
    /// </summary>
#else
    /// <summary>
    /// Error mode
    /// </summary>
#endif
    public enum ErrMode : int 
    {
#if LANG_JP
        /// <summary>
        /// プログラムはエラーハンドラを呼び出した後，途中終了する．デフォルト．
        /// エラー発生後，直ちに通知されるので，デバッグ時に有効． 
        /// しかし，製品（完成版の）システムでは，他の二つのモードの使用が制御しやすいので好ましい． 
        /// [CV_ErrModeLeaf]
        /// </summary>
#else
        /// <summary>
        /// The program is terminated after error handler is called. This is the default value. 
        /// It is useful for debugging, as the error is signalled immediately after it occurs. 
        /// However, for production systems other two methods may be preferable as they provide more control. 
        /// [CV_ErrModeLeaf]
        /// </summary>
#endif
        CV_ErrModeLeaf = CvConst.CV_ErrModeLeaf,


#if LANG_JP
        /// <summary>
        /// プログラムは途中終了しないが，エラーハンドラが呼び出される．
        /// スタックは解放されない（C++の例外処理を用いないため）．
        /// ユーザはCxCoreの関数cvGetErrStatusを呼び出し，エラーコードをチェックし，対処を行わなければならない． 
        /// [CV_ErrModeParent]
        /// </summary>
#else
        /// <summary>
        /// The program is not terminated, but the error handler is called. 
        /// The stack is unwinded (it is done w/o using C++ exception mechanism). 
        /// User may check error code after calling Cxcore function with cvGetErrStatus and react. 
        /// [CV_ErrModeParent]
        /// </summary>
#endif
        CV_ErrModeParent = CvConst.CV_ErrModeParent,


#if LANG_JP
        /// <summary>
        /// Parentモードとほぼ同じだが，エラーハンドラは呼び出されない．
        /// [CV_ErrModeSilent]
        /// </summary>
#else
        /// <summary>
        /// Similar to Parent mode, but no error handler is called. 
        /// [CV_ErrModeSilent]
        /// </summary>
#endif
        CV_ErrModeSilent = CvConst.CV_ErrModeSilent,
    }
}

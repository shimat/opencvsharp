/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// 反復アルゴリズムのための終了条件
    /// </summary>
#else
    /// <summary>
    /// Termination criteria for iterative algorithms
    /// </summary>
#endif
    [StructLayout(LayoutKind.Sequential)]
    [Serializable]
    public struct CvTermCriteria
    {
        #region Fields
#if LANG_JP
        /// <summary>
        /// 終了条件の種類
        /// </summary>
#else
        /// <summary>
        /// A combination of CriteriaType flags
        /// </summary>
#endif
        public CriteriaType Type;
#if LANG_JP
        /// <summary>
        /// 反復回数
        /// </summary>
#else
        /// <summary>
        /// Maximum number of iterations
        /// </summary>
#endif
        public int MaxIter;
#if LANG_JP
        /// <summary>
        /// 目標精度
        /// </summary>
#else
        /// <summary>
        /// Accuracy to achieve
        /// </summary>
#endif
        public double Epsilon;


        /// <summary>
        /// sizeof(CvTermCriteria)
        /// </summary>
        public const int SizeOf = sizeof(int) + sizeof(int) + sizeof(double);
        #endregion

        #region Constructors
#if LANG_JP
        /// <summary>
        /// 反復回数による終了条件を設定して初期化
        /// </summary>
        /// <param name="max_iter">反復数の最大値</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="max_iter">maximum number of iterations</param>
#endif
        public CvTermCriteria(int max_iter)
            : this(CriteriaType.Iteration, max_iter, 0)
        {
        }
#if LANG_JP
        /// <summary>
        /// 目標精度による終了条件を設定して初期化
        /// </summary>
        /// <param name="epsilon">目標精度</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="epsilon">accuracy to achieve</param>
#endif
        public CvTermCriteria(double epsilon)
            : this(CriteriaType.Epsilon, 0, epsilon)
        {
        }
#if LANG_JP
        /// <summary>
        /// 繰り返し回数と目標精度による終了条件を設定して初期化
        /// </summary>yy
        /// <param name="max_iter">反復数の最大値</param>
        /// <param name="epsilon">目標精度</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="max_iter">maximum number of iterations</param>
        /// <param name="epsilon">accuracy to achieve</param>
#endif
        public CvTermCriteria(int max_iter, double epsilon)
            : this(CriteriaType.Epsilon | CriteriaType.Iteration, max_iter, epsilon)
        {
        }
#if LANG_JP
        /// <summary>
        /// すべて指定して初期化
        /// </summary>
        /// <param name="type">終了条件</param>
        /// <param name="max_iter">反復数の最大値</param>
        /// <param name="epsilon">目標精度</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">a combination of CriteriaType flags</param>
        /// <param name="max_iter">maximum number of iterations</param>
        /// <param name="epsilon">accuracy to achieve</param>
#endif
        public CvTermCriteria(CriteriaType type,  int max_iter, double epsilon)
        {
            this.Type = type;
            this.MaxIter = max_iter;
            this.Epsilon = epsilon;
        }
        #endregion

        #region Methods
        #region Check
#if LANG_JP
        /// <summary>
        /// 終了条件をチェックし，type= Iteration|Epsilon に設定し，反復数の max_iterとeprilon の両方が有効になるように変換する
        /// </summary>
        /// <param name="default_eps"></param>
        /// <param name="default_max_iters"></param>
        /// <returns>変換結果</returns>
#else
        /// <summary>
        /// Check termination criteria and transform it so that type=CriteriaType.Iteration | CriteriaType.Epsilon,
        /// and both max_iter and epsilon are valid
        /// </summary>
        /// <param name="default_eps">Default epsilon</param>
        /// <param name="default_max_iters">Default maximum number of iteration</param>
        /// <returns></returns>
#endif
        public CvTermCriteria Check(double default_eps, int default_max_iters)
        {
            return Cv.CheckTermCriteria(this, default_eps, default_max_iters);
        }
        #endregion
        #endregion
    }
}

using System;
using System.Runtime.InteropServices;

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
        /// <param name="maxIter">反復数の最大値</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxIter">maximum number of iterations</param>
#endif
        public CvTermCriteria(int maxIter)
            : this(CriteriaType.Iteration, maxIter, 0)
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
        /// <param name="maxIter">反復数の最大値</param>
        /// <param name="epsilon">目標精度</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxIter">maximum number of iterations</param>
        /// <param name="epsilon">accuracy to achieve</param>
#endif
        public CvTermCriteria(int maxIter, double epsilon)
            : this(CriteriaType.Epsilon | CriteriaType.Iteration, maxIter, epsilon)
        {
        }
#if LANG_JP
        /// <summary>
        /// すべて指定して初期化
        /// </summary>
        /// <param name="type">終了条件</param>
        /// <param name="maxIter">反復数の最大値</param>
        /// <param name="epsilon">目標精度</param>
#else
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">a combination of CriteriaType flags</param>
        /// <param name="maxIter">maximum number of iterations</param>
        /// <param name="epsilon">accuracy to achieve</param>
#endif
        public CvTermCriteria(CriteriaType type, int maxIter, double epsilon)
        {
            this.Type = type;
            this.MaxIter = maxIter;
            this.Epsilon = epsilon;
        }
        #endregion

        #region Methods
        #region Check
#if LANG_JP
        /// <summary>
        /// 終了条件をチェックし，type= Iteration|Epsilon に設定し，反復数の max_iterとeprilon の両方が有効になるように変換する
        /// </summary>
        /// <param name="defaultEps"></param>
        /// <param name="defaultMaxIters"></param>
        /// <returns>変換結果</returns>
#else
        /// <summary>
        /// Check termination criteria and transform it so that type=CriteriaType.Iteration | CriteriaType.Epsilon,
        /// and both max_iter and epsilon are valid
        /// </summary>
        /// <param name="defaultEps">Default epsilon</param>
        /// <param name="defaultMaxIters">Default maximum number of iteration</param>
        /// <returns></returns>
#endif
        public CvTermCriteria Check(double defaultEps, int defaultMaxIters)
        {
            return Cv.CheckTermCriteria(this, defaultEps, defaultMaxIters);
        }
        #endregion
        #endregion
    }
}

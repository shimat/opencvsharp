/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp.MachineLearning
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvANN_MLP_TrainParams
    {
        public CvTermCriteria term_crit;
        public int train_method;

        // backpropagation parameters
        public double bp_dw_scale, bp_moment_scale;

        // rprop parameters
        public double rp_dw0, rp_dw_plus, rp_dw_minus, rp_dw_min, rp_dw_max;
    }

#if LANG_JP
    /// <summary>
    /// MLP学習アルゴリズムのパラメータ
    /// </summary>
#else
	/// <summary>
    /// Parameters of MLP training algorithm
    /// </summary>
#endif
    public class CvANN_MLP_TrainParams
    {
        private WCvANN_MLP_TrainParams _data;

        #region Constructors
#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
		/// <summary>
		/// Default constructor
		/// </summary>
#endif
		public CvANN_MLP_TrainParams()
		{
            IntPtr p = MLInvoke.CvANN_MLP_TrainParams_construct_default();
            _data = (WCvANN_MLP_TrainParams)Marshal.PtrToStructure(p, typeof(WCvANN_MLP_TrainParams));
            MLInvoke.CvANN_MLP_TrainParams_destruct(p);
		}
#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
		/// <param name="term_crit">学習アルゴリズムの終了条件．アルゴリズムにより何度繰り返されるか （逐次型の誤差逆伝播アルゴリズムでは，この数は学習データセットのサイズと掛け合わされる）と，1ターンで重みをどの程度変更するかを指定する．</param>
		/// <param name="train_method">用いる学習アルゴリズム</param>
		/// <param name="param1"></param>
#else
		/// <summary>
        /// Training constructor
        /// </summary>
		/// <param name="term_crit">The termination criteria for the training algorithm. It identifies how many iterations is done by the algorithm (for sequential backpropagation algorithm the number is multiplied by the size of the training set) and how much the weights could change between the iterations to make the algorithm continue. </param>
		/// <param name="train_method">The training algorithm to use</param>
		/// <param name="param1"></param>
#endif
		public CvANN_MLP_TrainParams(CvTermCriteria term_crit, MLPTrainingMethod train_method, double param1)
		{
            IntPtr p = MLInvoke.CvANN_MLP_TrainParams_construct(term_crit, (int)train_method, param1, 0);
            _data = (WCvANN_MLP_TrainParams)Marshal.PtrToStructure(p, typeof(WCvANN_MLP_TrainParams));
            MLInvoke.CvANN_MLP_TrainParams_destruct(p);
		}
#if LANG_JP
        /// <summary>
        /// 学習データを与えて初期化
        /// </summary>
		/// <param name="term_crit">学習アルゴリズムの終了条件．アルゴリズムにより何度繰り返されるか （逐次型の誤差逆伝播アルゴリズムでは，この数は学習データセットのサイズと掛け合わされる）と，1ターンで重みをどの程度変更するかを指定する．</param>
		/// <param name="train_method">用いる学習アルゴリズム</param>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
#else
		/// <summary>
        /// Training constructor
        /// </summary>
		/// <param name="term_crit">The termination criteria for the training algorithm. It identifies how many iterations is done by the algorithm (for sequential backpropagation algorithm the number is multiplied by the size of the training set) and how much the weights could change between the iterations to make the algorithm continue. </param>
		/// <param name="train_method">The training algorithm to use</param>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
#endif
		public CvANN_MLP_TrainParams(CvTermCriteria term_crit, MLPTrainingMethod train_method, double param1, double param2)
		{
            IntPtr p = MLInvoke.CvANN_MLP_TrainParams_construct(term_crit, (int)train_method, param1, param2);
            _data = (WCvANN_MLP_TrainParams)Marshal.PtrToStructure(p, typeof(WCvANN_MLP_TrainParams));
            MLInvoke.CvANN_MLP_TrainParams_destruct(p);
		}
		#endregion

        #region Properties
        /// <summary>
        /// sizeof(CvANN_MLP_TrainParams)
        /// </summary>
		public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvANN_MLP_TrainParams));



        /// <summary>
        /// Native struct
        /// </summary>
        /// <returns></returns>
        internal WCvANN_MLP_TrainParams NativeStruct
        {
            get { return _data; }
        }

#if LANG_JP
        /// <summary>
        /// 学習アルゴリズムの終了条件．
		/// アルゴリズムにより何度繰り返されるか （逐次型の誤差逆伝播アルゴリズムでは，この数は学習データセットのサイズと掛け合わされる）と，1ターンで重みをどの程度変更するかを指定する． 
        /// </summary>
#else
		/// <summary>
        /// The termination criteria for the training algorithm. 
		/// It identifies how many iterations is done by the algorithm (for sequential backpropagation algorithm the number is multiplied by the size of the training set) 
		/// and how much the weights could change between the iterations to make the algorithm continue. 
        /// </summary>
#endif
		public CvTermCriteria TermCrit
		{
			get{ return _data.term_crit; }
			set{ _data.term_crit = value; }
		}
#if LANG_JP
        /// <summary>
        /// 用いる学習アルゴリズム
        /// </summary>
#else
		/// <summary>
        /// The training algorithm to use
        /// </summary>
#endif
		public MLPTrainingMethod TrainMethod
		{
            get { return (MLPTrainingMethod)_data.train_method; }
			set{ _data.train_method = (int)value; }
		}

#if LANG_JP
        /// <summary>
        /// (誤差逆伝播のみ) ：算出された重さの勾配に掛け合わされる係数．推奨される値は0.1程度である．
		/// このパラメータはコンストラクタのparam1で設定できる． 
        /// </summary>
#else
		/// <summary>
        /// (Backpropagation only): The coefficient to multiply the computed weight gradient by. 
		/// The recommended value is about 0.1. The parameter can be set via param1 of the constructor. 
        /// </summary>
#endif
		public double BpDwScale
		{
			get{ return _data.bp_dw_scale; }
			set{ _data.bp_dw_scale = value; }
		}
#if LANG_JP
        /// <summary>
		/// （誤差逆伝播のみ）：2つ前までのターンの重みの差を掛ける係数．
		/// このパラメータでは，重みのランダムな変動を滑らかにするための慣性を決定する． この値は0（無効にする）から1か，それ以上を取り得る．0.1程度が適当である．
        /// </summary>
#else
		/// <summary>
		/// (Backpropagation only): The coefficient to multiply the difference between weights on the 2 previous iterations. 
		/// This parameter provides some inertia to smooth the random fluctuations of the weights. It can vary from 0 (the feature is disabled) to 1 and beyond. 
		/// The value 0.1 or so is good enough. The parameter can be set via param2 of the constructor. 		
        /// </summary>
#endif
		public double BpMomentScale
		{
			get{ return _data.bp_moment_scale; }
			set{ _data.bp_moment_scale = value; }
		}

#if LANG_JP
        /// <summary>
        /// （RPROPのみ）：重みdeltaの初期値．デフォルト値は0.1．
		/// このパラメータはコンストラクタのparam1を通して設定できる．  
        /// </summary>
#else
		/// <summary>
        /// (RPROP only): Initial magnitude of the weight delta. 
		/// The default value is 0.1. This parameter can be set via param1 of the constructor. 
        /// </summary>
#endif
		public double RpDw0
		{
			get{ return _data.rp_dw0; }
			set{ _data.rp_dw0 = value; }
		}
#if LANG_JP
        /// <summary>
        /// （RPROPのみ）：重みdeltaの増加係数．>1でなければならない．
		/// デフォルト値は1.2で，アルゴリズムの製作者によれば，多くの場合これで問題はない． このパラメータは構造体のメンバを修正して明示的に変えるしかない．  
        /// </summary>
#else
		/// <summary>
        /// (RPROP only): The increase factor for the weight delta. 
		/// It must be >1, default value is 1.2 that should work well in most cases, according to the algorithm's author. 
		/// The parameter can only be changed explicitly by modifying the structure member. 
        /// </summary>
#endif
		public double RpDwPlus
		{
			get{ return _data.rp_dw_plus; }
			set{ _data.rp_dw_plus = value; }
		}
#if LANG_JP
        /// <summary>
        /// （RPROPのみ）：重みdeltaの減少係数． &lt;1でなければならない．
		/// デフォルト値は0.5で，アルゴリズムの製作者によれば，多くの場合これで問題はない．このパラメータは構造体のメンバを修正して明示的に変えるしかない．  
        /// </summary>
#else
		/// <summary>
        /// (RPROP only): The decrease factor for the weight delta. 
		/// It must be &lt;1, default value is 0.5 that should work well in most cases, according to the algorithm's author.
		/// The parameter can only be changed explicitly by modifying the structure member. 
        /// </summary>
#endif
		public double RpDwMinus
		{
			get{ return _data.rp_dw_minus; }
			set{ _data.rp_dw_minus = value; }
		}
#if LANG_JP
        /// <summary>
        /// （RPROPのみ）：重みdeltaの最小値．&gt;0でなければならない．
		/// デフォルト値はFLT_EPSILON．このパラメータはコンストラクタのparam2を通して設定できる． 
        /// </summary>
#else
		/// <summary>
        /// (RPROP only): The minimum value of the weight delta. 
		/// It must be &gt;0, the default value is FLT_EPSILON. The parameter can be set via param2 of the constructor. 
        /// </summary>
#endif
		public double RpDwMin
		{
			get{ return _data.rp_dw_min; }
			set{ _data.rp_dw_min = value; }
		}
#if LANG_JP
        /// <summary>
        /// （RPROPのみ）：重みdeltaの最大値．>1でなければならない．
		/// デフォルト値は50．このパラメータは構造体のメンバを修正して明示的に変えるしかない．  
        /// </summary>
#else
		/// <summary>
        /// (RPROP only): The maximum value of the weight delta. 
		/// It must be >1, the default value is 50. The parameter can only be changed explicitly by modifying the structure member. 
        /// </summary>
#endif
		public double RpDwMax
		{
			get{ return _data.rp_dw_max; }
			set{ _data.rp_dw_max = value; }
		}
        #endregion
    }
}

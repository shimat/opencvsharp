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
    internal unsafe struct WCvEMParams
    {
        public int nclusters;
        public int cov_mat_type;
        public int start_step;
        public void* probs;
        public void* weights;
        public void* means;
        public void** covs;
        public CvTermCriteria term_crit;
    }

#if LANG_JP
    /// <summary>
    /// EMアルゴリズムのパラメータ
    /// </summary>
#else
	/// <summary>
    /// Parameters of EM algorithm
    /// </summary>
#endif
    public class CvEMParams
    {
        private WCvEMParams _data;
        private CvMat[] _covs;
        private GCHandle _handle;

#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
#else
		/// <summary>
		/// Default constructor
		/// </summary>
#endif
        public CvEMParams()
        {
            _data = new WCvEMParams()
            {
                nclusters = 10,
                cov_mat_type = 1,
                start_step = 0,
                probs = null,
                weights = null,
                means = null,
                //covs = null
            };
            Covs = null;
        }
#if LANG_JP
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="_nclusters">混合数</param>
        /// <param name="_cov_mat_type">混合分布共変動行列のタイプ</param>
        /// <param name="_start_step">アルゴリズムをスタートする最初のステップ</param>
        /// <param name="_term_crit">処理の終了条件</param>
        /// <param name="_probs">確率p_i,kの初期値． start_step=EMStartStep.Eのときのみ使用する（その場合はnullであってはならない）.</param>
        /// <param name="_weights">混合分布の重みπ_kの初期値． start_step=EMStartStep.Eのときのみ（nullでない場合は）使用する. </param>
        /// <param name="_means">混合分布の平均 a_kの初期値． start_step=EMStartStep.Eのときのみ使用する（その場合はnullであってはならない）.</param>
        /// <param name="_covs">混合分布の共変動行列Skの初期値． start_step=EMStartStep.Eのときのみ（nullでない場合は）使用する．</param>
#else
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_nclusters">The number of mixtures. Some of EM implementation could determine the optimal number of mixtures within a specified value range, but that is not the case in ML yet. </param>
        /// <param name="_cov_mat_type">The type of the mixture covariation matrices</param>
        /// <param name="_start_step">The initial step the algorithm starts from</param>
        /// <param name="_term_crit">Termination criteria of the procedure. </param>
        /// <param name="_probs">Initial probabilities p_i,k; are used (and must be not null) only when start_step=EMStartStep.E. </param>
        /// <param name="_weights">Initial mixture weights π_k; are used (if not null) only when start_step=EMStartStep.E. </param>
        /// <param name="_means">Initial mixture means a_k; are used (and must be not null) only when start_step=EMStartStep.E. </param>
        /// <param name="_covs">Initial mixture covariation matrices S_k; are used (if not null) only when start_step=EMStartStep.E. </param>
#endif
		public CvEMParams(int _nclusters, EMCovMatType _cov_mat_type, EMStartStep _start_step, CvTermCriteria _term_crit, 
            CvMat _probs, CvMat _weights, CvMat _means, CvMat[] _covs ) 
        {
            unsafe
            {
                _data = new WCvEMParams()
                {
                    nclusters = _nclusters,
                    cov_mat_type = (int)_cov_mat_type,
                    start_step = (int)_start_step,
                    term_crit = _term_crit,
                    probs = (_probs == null) ? null : _probs.CvPtr.ToPointer(),
                    weights = (_weights == null) ? null : _weights.CvPtr.ToPointer(),
                    means = (_means == null) ? null : _means.CvPtr.ToPointer(),
                    //covs = (_means == null) ? null : (void**)_means.CvPtr,
                };
            }
            Covs = _covs;
        }
        /// <summary>
        /// Destructor
        /// </summary>
        ~CvEMParams()
        {
            if (_handle.IsAllocated)
            {
                _handle.Free();
            }
        }

        /// <summary>
        /// Native struct
        /// </summary>
        /// <returns></returns>
        internal WCvEMParams NativeStruct
        {
            get { return _data; }
        }


        #region Properties
#if LANG_JP
        /// <summary>
        /// 混合数
        /// </summary>
#else
		/// <summary>
        /// The number of mixtures. 
		/// (Some of EM implementation could determine the optimal number of mixtures within a specified value range, but that is not the case in ML yet.)
        /// </summary>
#endif
        public int NClusters
        {
            get { return _data.nclusters; }
            set { _data.nclusters = value; }
        }
#if LANG_JP
        /// <summary>
        /// 混合分布共変動行列のタイプ
        /// </summary>
#else
		/// <summary>
        /// The type of the mixture covariation matrices
        /// </summary>
#endif
		public EMCovMatType CovMatType
        {
            get { return (EMCovMatType)_data.cov_mat_type; }
            set { _data.cov_mat_type = (int)value; }
        }
#if LANG_JP
        /// <summary>
        /// アルゴリズムをスタートする最初のステップ
        /// </summary>
#else
		/// <summary>
        /// The initial step the algorithm starts from
        /// </summary>
#endif
        public EMStartStep StartStep
        {
            get { return (EMStartStep)_data.start_step; }
            set { _data.start_step = (int)value; }
        }
#if LANG_JP
        /// <summary>
        /// 確率p_i,kの初期値． start_step=EMStartStep.Eのときのみ使用する（その場合はnullであってはならない）.
        /// </summary>
#else
		/// <summary>
        /// Initial probabilities p_i,k; are used (and must be not null) only when start_step=EMStartStep.E. 
        /// </summary>
#endif
		public CvMat Probs
        {
			get 
            {
                unsafe
                {
                    IntPtr p = new IntPtr(_data.probs);
                    if (p == IntPtr.Zero)
                        return null;
                    else
                        return new CvMat(p, false);
                }
            }
            set 
            {
                unsafe
                {
                    _data.probs = (value == null) ? null : value.CvPtr.ToPointer();
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 混合分布の重みπ_kの初期値． start_step=EMStartStep.Eのときのみ（nullでない場合は）使用する. 
        /// </summary>
#else
		/// <summary>
        /// Initial mixture weights πk; are used (if not null) only when start_step=EMStartStep.E. 
        /// </summary>
#endif
        public CvMat Weights
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(_data.weights);
                    if (p == IntPtr.Zero)
                        return null;
                    else
                        return new CvMat(p, false);
                }
            }
            set
            {
                unsafe
                {
                    _data.weights = (value == null) ? null : value.CvPtr.ToPointer();
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 混合分布の平均 a_kの初期値． start_step=EMStartStep.Eのときのみ使用する（その場合はnullであってはならない）.
        /// </summary>
#else
		/// <summary>
        /// Initial mixture means a_k; are used (and must be not null) only when start_step=EMStartStep.E.
        /// </summary>
#endif
        public CvMat Means
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(_data.means);
                    if (p == IntPtr.Zero)
                        return null;
                    else
                        return new CvMat(p, false);
                }
            }
            set
            {
                unsafe
                {
                    _data.means = (value == null) ? null : value.CvPtr.ToPointer();
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 混合分布の共変動行列Skの初期値． start_step=EMStartStep.Eのときのみ（nullでない場合は）使用する． 
        /// </summary>
#else
		/// <summary>
        /// Initial mixture covariation matrices S_k; are used (if not null) only when start_step=EMStartStep.E.
        /// </summary>
#endif
		public CvMat[] Covs
        {
            get
            {
                return _covs;
            }
            set
            {
                if (_handle.IsAllocated)
                {
                    _handle.Free();
                }

                unsafe
                {
                    _covs = value;
                    if (value == null)
                    {
                        _data.covs = null;
                    }
                    else
                    {
                        IntPtr[] p = new IntPtr[value.Length];
                        for (int i = 0; i < value.Length; i++)
                        {
                            p[i] = value[i].CvPtr;
                        }

                        _handle = GCHandle.Alloc(p, GCHandleType.Pinned);
                        _data.covs = (void**)_handle.AddrOfPinnedObject();
                    }
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 混合分布の共変動行列Skの初期値． start_step=EMStartStep.Eのときのみ（nullでない場合は）使用する． 
        /// </summary>
#else
        /// <summary>
        /// Initial mixture covariation matrices S_k; are used (if not null) only when start_step=EMStartStep.E.
        /// </summary>
#endif
        public IntPtr CovsPtr
        {
            get
            {
                unsafe
                {
                    return new IntPtr(_data.covs);
                }
            }
            set
            {
                if (_handle.IsAllocated)
                {
                    _handle.Free();
                }

                unsafe
                {
                    _data.covs = (void**)value;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 処理の終了条件
        /// </summary>
#else
		/// <summary>
        /// Termination criteria of the procedure. 
		/// EM algorithm stops either after a certain number of iterations (term_crit.Iter), 
		/// or when the parameters change too little (no more than term_crit.Epsilon) from iteration to iteration. 
        /// </summary>
#endif
		public CvTermCriteria TermCrit
        {
			get { return _data.term_crit; }
			set { _data.term_crit = value; }
        }
		#endregion
    }
}

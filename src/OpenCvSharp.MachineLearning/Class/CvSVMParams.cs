/*
 * (C) 2008-2013 Schima
 * This code is licenced under the LGPL.
 */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.MachineLearning
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal unsafe struct WCvSVMParams
    {
        public int svm_type;
        public int kernel_type;
        public double degree; 
        public double gamma; 
        public double coef0;

        public double C; 
        public double nu; 
        public double p; 
        public void* class_weights; 
        public CvTermCriteria term_crit; 
    }

#if LANG_JP
    /// <summary>
    /// SVM 学習パラメータ
    /// </summary>
#else
	/// <summary>
    /// SVM training parameters
    /// </summary>
#endif
    public class CvSVMParams
    {
        private WCvSVMParams _data;


        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        internal CvSVMParams(WCvSVMParams data)
        {
            _data = data;
        }
#if LANG_JP
        /// <summary>
        /// 既定の初期化
        /// </summary>
#else
		/// <summary>
        /// Default constructor
        /// </summary>
#endif
        public CvSVMParams()
        {
			_data = new WCvSVMParams();
            MLInvoke.CvSVMParams_construct_default(ref _data);
        }
#if LANG_JP
        /// <summary>
	    /// 初期化
	    /// </summary>
	    /// <param name="_svm_type">SVMの種類</param>
	    /// <param name="_kernel_type">SVMカーネルの種類</param>
	    /// <param name="_degree">poly 用</param>
	    /// <param name="_gamma">poly/rbf/sigmoid 用</param>
	    /// <param name="_coef0">poly/sigmoid 用</param>
	    /// <param name="_C">SVMType.CSvc, SVMType.EpsSvr, SVMType.NuSvr 用</param>
	    /// <param name="_nu">SVMType.NuSvc, SVMType.OneClass, SVMType.NuSvr 用</param>
	    /// <param name="_p">SVMType.EpsSvr 用</param>
	    /// <param name="_class_weights">SVMType.CSvc 用</param>
	    /// <param name="_term_crit">終了条件</param>
#else
		/// <summary>
	    /// Constructor
	    /// </summary>
	    /// <param name="_svm_type">Type of SVM</param>
	    /// <param name="_kernel_type">The kernel type</param>
	    /// <param name="_degree">for poly</param>
	    /// <param name="_gamma">for poly/rbf/sigmoid</param>
	    /// <param name="_coef0">for poly/sigmoid</param>
	    /// <param name="_C">for SVMType.CSvc, SVMType.EpsSvr and SVMType.NuSvr</param>
	    /// <param name="_nu">for SVMType.NuSvc, SVMType.OneClass and SVMType.NuSvr</param>
	    /// <param name="_p">for SVMType.EpsSvr</param>
	    /// <param name="_class_weights">for SVMType.CSvc</param>
	    /// <param name="_term_crit">Termination criteria</param>
#endif
		public CvSVMParams(SVMType _svm_type, SVMKernelType _kernel_type, double _degree, double _gamma, double _coef0, 
            double _C, double _nu, double _p, CvMat _class_weights, CvTermCriteria _term_crit )
	    {
            _data = new WCvSVMParams();
            IntPtr _class_weights_ptr = (_class_weights == null) ? IntPtr.Zero : _class_weights.CvPtr;
            MLInvoke.CvSVMParams_construct(ref _data, (int)_svm_type, (int)_kernel_type, _degree, _gamma, _coef0, _C, _nu, _p, _class_weights_ptr, _term_crit);
	    }
#endregion

        /// <summary>
        /// Native struct
        /// </summary>
        /// <returns></returns>
        internal WCvSVMParams NativeStruct
        {
            get { return _data; }
        }


		#region Properties
#if LANG_JP
        /// <summary>
		/// SVMの種類
		/// </summary>
#else
		/// <summary>
		/// Type of SVM
		/// </summary>
#endif
		public SVMType SVMType
        {
            get 
			{ 
				return (SVMType)_data.svm_type; 
			}
            set
			{ 
				_data.svm_type = (int)value;
			}
        }
#if LANG_JP
		/// <summary>
		/// SVMカーネルの種類
		/// </summary>
#else
		/// <summary>
		/// The kernel type
		/// </summary>
#endif
		public SVMKernelType KernelType
        {
			get 
			{ 
				return (SVMKernelType)_data.kernel_type; 
			}
			set
			{ 
				_data.kernel_type = (int)value; 
			}
        }

#if LANG_JP
		/// <summary>
		/// poly 用
		/// </summary>
#else
		/// <summary>
		/// for poly
		/// </summary>
#endif
        public double Degree
        {
            get 
			{ 
				return _data.degree; 
			}
            set
			{ 
				_data.degree = value; 
			}
        }
#if LANG_JP
		/// <summary>
		/// poly/rbf/sigmoid 用
		/// </summary>
#else
		/// <summary>
		/// for poly/rbf/sigmoid
		/// </summary>
#endif
        public double Gamma
        {
            get 
			{ 
				return _data.gamma; 
			}
            set
			{ 
				_data.gamma = value; 
			}
        } 
#if LANG_JP
		/// <summary>
		/// poly/sigmoid 用
		/// </summary>
#else
		/// <summary>
		/// for poly/sigmoid
		/// </summary>
#endif
        public double Coef0
        {
            get 
			{ 
				return _data.coef0;
			}
            set
			{ 
				_data.coef0 = value;
			}
        } 

#if LANG_JP
		/// <summary>
		/// SVMType.CSvc, SVMType.EpsSvr, SVMType.NuSvr 用
		/// </summary>
#else
		/// <summary>
		/// for SVMType.CSvc, SVMType.EpsSvr and SVMType.NuSvr
		/// </summary>
#endif
        public double C
        {
            get 
			{ 
				return _data.C; 
			}
            set
			{ 
				_data.C = value;
			}
        } 
#if LANG_JP
		/// <summary>
		/// SVMType.NuSvc, SVMType.OneClass, SVMType.NuSvr 用
		/// </summary>
#else
		/// <summary>
		/// for SVMType.NuSvc, SVMType.OneClass and SVMType.NuSvr
		/// </summary>
#endif
        public double Nu
        {
            get 
			{ 
				return _data.nu; 
			}
            set
			{ 
				_data.nu = value;
			}
        }
#if LANG_JP
		/// <summary>
		/// SVMType.EpsSvr 用
		/// </summary>
#else
		/// <summary>
		/// for SVMType.EpsSvr
		/// </summary>
#endif
        public double P
        {
            get 
			{ 
				return _data.p;
			}
            set
			{
				_data.p = value;
			}
        } 
#if LANG_JP
		/// <summary>
		/// SVMType.CSvc 用
		/// </summary>
#else
		/// <summary>
		/// for SVMType.CSvc
		/// </summary>
#endif
		public CvMat ClassWeights
        {
            get
            {
                unsafe
                {
                    IntPtr p = new IntPtr(_data.class_weights);
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
                    if (value == null)
                        _data.class_weights = null;
                    else
                        _data.class_weights = value.CvPtr.ToPointer();
                }
			}
        }
#if LANG_JP
		/// <summary>
		/// 終了条件
		/// </summary>
#else
		/// <summary>
		/// Termination criteria
		/// </summary>
#endif
		public CvTermCriteria TermCrit
        {
            get 
			{ 
				return _data.term_crit;
			}
            set
			{ 
				_data.term_crit = value; 
			}
        } 
		#endregion
    }
}

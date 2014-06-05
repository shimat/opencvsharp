using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace OpenCvSharp.CPlusPlus
{
#pragma warning disable 1591
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct WCvSVMParams
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
#pragma warning restore 1591

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
        private WCvSVMParams data;

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        internal CvSVMParams(WCvSVMParams data)
        {
            this.data = data;
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
			data = new WCvSVMParams();
            NativeMethods.ml_CvSVMParams_new1(ref data);
        }
#if LANG_JP
        /// <summary>
	    /// 初期化
	    /// </summary>
        /// <param name="svmType">SVMの種類</param>
        /// <param name="kernelType">SVMカーネルの種類</param>
        /// <param name="degree">poly 用</param>
        /// <param name="gamma">poly/rbf/sigmoid 用</param>
        /// <param name="coef0">poly/sigmoid 用</param>
	    /// <param name="c">SVMType.CSvc, SVMType.EpsSvr, SVMType.NuSvr 用</param>
	    /// <param name="nu">SVMType.NuSvc, SVMType.OneClass, SVMType.NuSvr 用</param>
	    /// <param name="p">SVMType.EpsSvr 用</param>
        /// <param name="classWeights">SVMType.CSvc 用</param>
        /// <param name="termCrit">終了条件</param>
#else
		/// <summary>
	    /// Constructor
	    /// </summary>
	    /// <param name="svmType">Type of SVM</param>
	    /// <param name="kernelType">The kernel type</param>
	    /// <param name="degree">for poly</param>
	    /// <param name="gamma">for poly/rbf/sigmoid</param>
	    /// <param name="coef0">for poly/sigmoid</param>
	    /// <param name="c">for SVMType.CSvc, SVMType.EpsSvr and SVMType.NuSvr</param>
	    /// <param name="nu">for SVMType.NuSvc, SVMType.OneClass and SVMType.NuSvr</param>
	    /// <param name="p">for SVMType.EpsSvr</param>
	    /// <param name="classWeights">for SVMType.CSvc</param>
	    /// <param name="termCrit">Termination criteria</param>
#endif
		public CvSVMParams(SVMType svmType, SVMKernelType kernelType, double degree, 
            double gamma, double coef0, double c, double nu, double p, 
            CvMat classWeights, CvTermCriteria termCrit )
	    {
            data = new WCvSVMParams();
            NativeMethods.ml_CvSVMParams_new2(
                ref data, (int)svmType, (int)kernelType, degree, gamma, coef0,
                c, nu, p, Cv2.ToPtr(classWeights), termCrit);
	    }
#endregion

        /// <summary>
        /// Native struct
        /// </summary>
        /// <returns></returns>
        internal WCvSVMParams NativeStruct
        {
            get { return data; }
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
				return (SVMType)data.svm_type; 
			}
            set
			{ 
				data.svm_type = (int)value;
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
				return (SVMKernelType)data.kernel_type; 
			}
			set
			{ 
				data.kernel_type = (int)value; 
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
				return data.degree; 
			}
            set
			{ 
				data.degree = value; 
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
				return data.gamma; 
			}
            set
			{ 
				data.gamma = value; 
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
				return data.coef0;
			}
            set
			{ 
				data.coef0 = value;
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
				return data.C; 
			}
            set
			{ 
				data.C = value;
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
				return data.nu; 
			}
            set
			{ 
				data.nu = value;
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
				return data.p;
			}
            set
			{
				data.p = value;
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
                    IntPtr p = new IntPtr(data.class_weights);
                    if (p == IntPtr.Zero)
                        return null;
                    return new CvMat(p, false);
                }
			}
            set
			{
                unsafe
                {
                    if (value == null)
                        data.class_weights = null;
                    data.class_weights = value.CvPtr.ToPointer();
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
				return data.term_crit;
			}
            set
			{ 
				data.term_crit = value; 
			}
        } 
		#endregion
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp.Utilities;

namespace OpenCvSharp
{
#if LANG_JP
    /// <summary>
    /// ConDenstation 状態
    /// </summary>
#else
    /// <summary>
    /// CvConDensation
    /// </summary>
#endif
    public class CvConDensation : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed = false;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// ポインタから初期化
        /// </summary>
        /// <param name="ptr">struct CvConDensation*</param>
#else
        /// <summary>
        /// Initialize from pointer
        /// </summary>
        /// <param name="ptr">struct CvConDensation*</param>
#endif
        public CvConDensation(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new ArgumentNullException("ptr");
            
            this.ptr = ptr;
        }
#if LANG_JP
        /// <summary>
        /// ConDensation フィルタ構造体の領域確保を行う
        /// </summary>
        /// <param name="dynamParams">状態ベクトルの次元</param>
        /// <param name="measureParams">観測ベクトルの次元</param>
        /// <param name="sampleCount">サンプル数</param>
#else
        /// <summary>
        /// Allocates ConDensation filter structure
        /// </summary>
        /// <param name="dynamParams">Dimension of the state vector. </param>
        /// <param name="measureParams">Dimension of the measurement vector. </param>
        /// <param name="sampleCount">Number of samples. </param>
#endif
        public CvConDensation(int dynamParams, int measureParams, int sampleCount)
        {
            ptr = NativeMethods.cvCreateConDensation(dynamParams, measureParams, sampleCount);
        }

#if LANG_JP
        /// <summary>
        /// リソースの解放
        /// </summary>
        /// <param name="disposing">
        /// trueの場合は、このメソッドがユーザコードから直接が呼ばれたことを示す。マネージ・アンマネージ双方のリソースが解放される。
        /// falseの場合は、このメソッドはランタイムからファイナライザによって呼ばれ、もうほかのオブジェクトから参照されていないことを示す。アンマネージリソースのみ解放される。
        ///</param>
#else
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources can be disposed.
        /// If false, the method has been called by the runtime from inside the finalizer and you should not reference other objects. Only unmanaged resources can be disposed.
        /// </param>
#endif
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                try
                {
                    if (disposing)
                    {
                    }
                    if (IsEnabledDispose)
                    {
                        NativeMethods.cvReleaseConDensation(ref ptr);
                    }
                    disposed = true;
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// sizeof(CvConDensation) 
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvConDensation));

#if LANG_JP
        /// <summary>
        /// 観測ベクトルの次元
        /// </summary>
#else
        /// <summary>
        /// Dimension of measurement vector
        /// </summary>
#endif
        public int MP
        {
            get
            {
                unsafe
                {
                    return ((WCvConDensation*)ptr)->MP;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 状態ベクトルの次元
        /// </summary>
#else
        /// <summary>
        /// Dimension of state vector 
        /// </summary>
#endif
        public int DP
        {
            get
            {
                unsafe
                {
                    return ((WCvConDensation*)ptr)->DP;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 線形ダイナミクスを表す行列
        /// </summary>
#else
        /// <summary>
        /// Matrix of the linear Dynamics system 
        /// </summary>
#endif
        public PointerAccessor1D_Single DynamMatr
        {
            get
            {
                unsafe
                {
                    float* p = ((WCvConDensation*)ptr)->DynamMatr;
                    return new PointerAccessor1D_Single(p);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 状態ベクトル
        /// </summary>
#else
        /// <summary>
        /// Vector of State
        /// </summary>
#endif
        public PointerAccessor1D_Single State
        {
            get
            {
                unsafe
                {
                    float* p = ((WCvConDensation*)ptr)->State;
                    return new PointerAccessor1D_Single(p);
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// サンプル数
        /// </summary>
#else
        /// <summary>
        /// Number of the Samples
        /// </summary>
#endif
        public int SamplesNum
        {
            get
            {
                unsafe
                {
                    return ((WCvConDensation*)ptr)->SamplesNum;
                }
            }
            //set { _data.SamplesNum = value; }
        }
#if LANG_JP
        /// <summary>
        /// サンプルベクトルの配列
        /// </summary>
#else
        /// <summary>
        /// Array of the Sample Vectors
        /// </summary>
#endif
        public PointerAccessor2D_Single FlSamples
        {
            get
            {
                unsafe
                {
                    float** p = ((WCvConDensation*)ptr)->flSamples;
                    return new PointerAccessor2D_Single(p);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float[,] GetFlSamples()
        {
            unsafe
            {
                int rows = SamplesNum, cols = DP;
                float[,] dst = new float[rows, cols];
                float** src = ((WCvConDensation*)ptr)->flSamples;
                using (var dstPtr = new ArrayAddress1<float>(dst))
	            {
                    Util.CopyMemory(dstPtr, new IntPtr(src), rows * cols);
                }
                return dst;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void SetFlSamples(float[,] value)
        {            
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            int rows = SamplesNum, cols = DP;
            if (value.GetLength(0) != rows || value.GetLength(1) != cols)
            {
                throw new ArgumentException();
            }

            unsafe
            {
                float[,] dst = new float[rows, cols];
                float** src = ((WCvConDensation*)ptr)->flSamples;
                using (var dstPtr = new ArrayAddress1<float>(dst))
                {
                    Util.CopyMemory(new IntPtr(src), dstPtr, rows * cols);
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// サンプルベクトルのテンポラリ配列
        /// </summary>
#else
        /// <summary>
        /// Temporary array of the Sample Vectors
        /// </summary>
#endif
        public PointerAccessor2D_Single FlNewSamples
        {
            get
            {
                unsafe
                {
                    float** p = ((WCvConDensation*)ptr)->flNewSamples;
                    return new PointerAccessor2D_Single(p);
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 各サンプルの確かさ
        /// </summary>
#else
        /// <summary>
        /// Confidence for each Sample
        /// </summary>
#endif
        public PointerAccessor1D_Single FlConfidence
        {
            get
            {
                unsafe
                {
                    float* p = ((WCvConDensation*)ptr)->flConfidence;
                    return new PointerAccessor1D_Single(p);
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// 確かさの累積値
        /// </summary>
#else
        /// <summary>
        /// Cumulative confidence
        /// </summary>
#endif
        public PointerAccessor1D_Single FlCumulative
        {
            get
            {
                unsafe
                {
                    float* p = ((WCvConDensation*)ptr)->flCumulative;
                    return new PointerAccessor1D_Single(p);
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// テンポラリベクトル
        /// </summary>
#else
        /// <summary>
        /// Temporary vector
        /// </summary>
#endif
        public PointerAccessor1D_Single Temp
        {
            get
            {
                unsafe
                {
                    float* p = ((WCvConDensation*)ptr)->Temp;
                    return new PointerAccessor1D_Single(p);
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// サンプルセットを更新するためのランダムベクトル
        /// </summary>
#else
        /// <summary>
        /// RandomVector to update sample set
        /// </summary>
#endif
        public PointerAccessor1D_Single RandomSample
        {
            get
            {
                unsafe
                {
                    float* p = ((WCvConDensation*)ptr)->RandomSample;
                    return new PointerAccessor1D_Single(p);
                }
            }
        }

#if LANG_JP
        /// <summary>
        /// ランダムベクトルを生成するための構造体配列
        /// </summary>
#else
        /// <summary>
        /// RandomVector to update sample set
        /// </summary>
#endif
        public PointerAccessor1D<CvRandState> RandS
        {
            get
            {
                unsafe
                {
                    void* p = (((WCvConDensation*)ptr)->RandS);
                    return new PointerAccessor1D<CvRandState>(p);
                }
            }
        }
        #endregion
    }
}
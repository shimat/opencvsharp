using System;
using System.Runtime.InteropServices;

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

#if LANG_JP
    /// <summary>
    /// カルマンフィルタ状態
    /// </summary>
#else
    /// <summary>
    /// Kalman filter state
    /// </summary>
#endif
    public class CvKalman : DisposableCvObject
    {
        /// <summary>
        /// Track whether Dispose has been called
        /// </summary>
        private bool disposed;

        #region Init and Disposal
#if LANG_JP
        /// <summary>
        /// カルマンフィルタ構造体の領域確保を行う.
        /// </summary>
        /// <param name="dynamParams">状態ベクトルの次元数</param>
        /// <param name="measureParams">観測ベクトルの次元</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates Kalman filter structure
        /// </summary>
        /// <param name="dynamParams">dimensionality of the state vector </param>
        /// <param name="measureParams">dimensionality of the measurement vector </param>
        /// <returns></returns>
#endif
        public CvKalman(int dynamParams, int measureParams)
            : this(dynamParams, measureParams, 0)
	    {
	    }
#if LANG_JP
        /// <summary>
        /// カルマンフィルタ構造体の領域確保を行う.
        /// </summary>
        /// <param name="dynamParams">状態ベクトルの次元数</param>
        /// <param name="measureParams">観測ベクトルの次元</param>
        /// <param name="controlParams">コントロールベクトルの次元</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Allocates Kalman filter structure
        /// </summary>
        /// <param name="dynamParams">dimensionality of the state vector </param>
        /// <param name="measureParams">dimensionality of the measurement vector </param>
        /// <param name="controlParams">dimensionality of the control vector </param>
        /// <returns></returns>
#endif
        public CvKalman(int dynamParams, int measureParams, int controlParams)
        {
            ptr = NativeMethods.cvCreateKalman(dynamParams, measureParams, controlParams);
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvKalman");
        }
#if LANG_JP
        /// <summary>
        /// ポインタで初期化
        /// </summary>
        /// <param name="ptr">struct CvMemStorage*</param>
#else
        /// <summary>
        /// Initializes by native pointer
        /// </summary>
        /// <param name="ptr"></param>
#endif
        public CvKalman(IntPtr ptr)
            : this(ptr, false)
        {
        }
        /// <summary>
        /// ポインタと自動解放の可否を指定して初期化
        /// </summary>
        /// <param name="ptr">struct CvMemStorage*</param>
        /// <param name="isEnabledDispose">自動的にGCで解放してよいかどうか</param>
        internal CvKalman(IntPtr ptr, bool isEnabledDispose)
            : base(isEnabledDispose)
        {
            if (ptr == IntPtr.Zero)
                throw new OpenCvSharpException("Failed to create CvKalman");

            this.ptr = ptr;
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
                        NativeMethods.cvReleaseKalman(ref ptr);
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
        /// sizeof(CvKalman)
        /// </summary>
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WCvKalman));


#if LANG_JP
        /// <summary>
        /// 観測ベクトルの次元数
        /// </summary>
#else
        /// <summary>
        /// Number of measurement vector dimensions
        /// </summary>
#endif
        public int MP
        {
            get
            {
                unsafe
                {
                    return ((WCvKalman*)ptr)->MP;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 状態ベクトルの次元数
        /// </summary>
#else
        /// <summary>
        /// Number of state vector dimensions
        /// </summary>
#endif
        public int DP
        {
            get
            {
                unsafe
                {
                    return ((WCvKalman*)ptr)->DP;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// コントロールベクトルの次元数
        /// </summary>
#else
        /// <summary>
        /// Number of control vector dimensions
        /// </summary>
#endif
        public int CP
        {
            get
            {
                unsafe
                {
                    return ((WCvKalman*)ptr)->CP;
                }
            }
        }
#if LANG_JP
        /// <summary>
        /// 予測状態 (x'(k)): x(k)=A*x(k-1)+B*u(k)
        /// </summary>
#else
        /// <summary>
        /// Predicted state (x'(k)): x(k)=A*x(k-1)+B*u(k)
        /// </summary>
#endif
        public CvMat StatePre
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->state_pre);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false); 
            }
        }
#if LANG_JP
        /// <summary>
        /// 修正後の状態 (x(k)): x(k)=x'(k)+K(k)*(z(k)-H*x'(k)) 
        /// </summary>
#else
        /// <summary>
        /// Corrected state (x(k)): x(k)=x'(k)+K(k)*(z(k)-H*x'(k))
        /// </summary>
#endif
        public CvMat StatePost
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->state_post);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// 状態遷移行列 (A)
        /// </summary>
#else
        /// <summary>
        /// State transition matrix (A) 
        /// </summary>
#endif
        public CvMat TransitionMatrix
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->transition_matrix);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// コントロール行列 (B) （コントロールされない場合は，用いられない）
        /// </summary>
#else
        /// <summary>
        /// Control matrix (B)  (it is not used if there is no control
        /// </summary>
#endif
        public CvMat ControlMatrix
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->control_matrix);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// 観測行列 (H)
        /// </summary>
#else
        /// <summary>
        /// Measurement matrix (H)
        /// </summary>
#endif
        public CvMat MeasurementMatrix
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->measurement_matrix);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// プロセスノイズ共分散行列 (Q)
        /// </summary>
#else
        /// <summary>
        /// Process noise covariance matrix (Q)
        /// </summary>
#endif
        public CvMat ProcessNoiseCov
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->process_noise_cov);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// 観測ノイズ共分散行列 (R)
        /// </summary>
#else
        /// <summary>
        /// Measurement noise covariance matrix (R)
        /// </summary>
#endif
        public CvMat MeasurementNoiseCov
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->measurement_noise_cov);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// 事前誤差推定共分散行列 (P'(k)): P'(k)=A*P(k-1)*At + Q)
        /// </summary>
#else
        /// <summary>
        /// Priori error estimate covariance matrix (P'(k)):  P'(k)=A*P(k-1)*At + Q)
        /// </summary>
#endif
        public CvMat ErrorCovPre
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->error_cov_pre);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// カルマンゲイン行列 (K(k)): K(k)=P'(k)*Ht*inv(H*P'(k)*Ht+R)
        /// </summary>
#else
        /// <summary>
        /// Kalman gain matrix (K(k)): K(k)=P'(k)*Ht*inv(H*P'(k)*Ht+R)
        /// </summary>
#endif
        public CvMat Gain
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->gain);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// 事後誤差推定共分散行列 (P(k)): P(k)=(I-K(k)*H)*P'(k)
        /// </summary>
#else
        /// <summary>
        /// Posteriori error estimate covariance matrix (P(k)): P(k)=(I-K(k)*H)*P'(k)
        /// </summary>
#endif
        public CvMat ErrorCovPost
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->error_cov_post);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// テンポラリ行列1
        /// </summary>
#else
        /// <summary>
        /// Temporary matrix 1
        /// </summary>
#endif
        public CvMat Temp1
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->temp1);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// テンポラリ行列2
        /// </summary>
#else
        /// <summary>
        /// Temporary matrix 2
        /// </summary>
#endif
        public CvMat Temp2
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->temp2);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// テンポラリ行列3
        /// </summary>
#else
        /// <summary>
        /// Temporary matrix 3
        /// </summary>
#endif
        public CvMat Temp3
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->temp3);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// テンポラリ行列4
        /// </summary>
#else
        /// <summary>
        /// Temporary matrix 4
        /// </summary>
#endif
        public CvMat Temp4
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->temp4);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
#if LANG_JP
        /// <summary>
        /// テンポラリ行列5
        /// </summary>
#else
        /// <summary>
        /// Temporary matrix 5
        /// </summary>
#endif
        public CvMat Temp5
        {
            get
            {
                IntPtr p;
                unsafe
                {
                    p = new IntPtr(((WCvKalman*)ptr)->temp5);
                }
                if (p == IntPtr.Zero)
                    return null;
                return new CvMat(p, false);
            }
        }
        #region Backward compatibility fields
        /// <summary>
        /// state_pre->data.fl
        /// </summary>
        public unsafe float* PosterState
        {
            get
            {
                return ((WCvKalman*)ptr)->PosterState;
            }
        }
        /// <summary>
        /// state_post->data.fl
        /// </summary>
        public unsafe float* PriorState
        {
            get
            {
                return ((WCvKalman*)ptr)->PriorState;
            }
        }
        /// <summary>
        /// transition_matrix->data.fl
        /// </summary>
        public unsafe float* DynamMatr
        {
            get
            {
                return ((WCvKalman*)ptr)->DynamMatr;
            }
        }
        /// <summary>
        /// measurement_matrix->data.fl
        /// </summary>
        public unsafe float* MeasurementMatr
        {
            get
            {
                return ((WCvKalman*)ptr)->MeasurementMatr;
            }
        }
        /// <summary>
        /// measurement_noise_cov->data.fl
        /// </summary>
        public unsafe float* MNCovariance
        {
            get
            {
                return ((WCvKalman*)ptr)->MNCovariance;
            }
        }
        /// <summary>
        /// process_noise_cov->data.fl
        /// </summary>
        public unsafe float* PNCovariance
        {
            get
            {
                return ((WCvKalman*)ptr)->PNCovariance;
            }
        }
        /// <summary>
        /// gain->data.fl
        /// </summary>
        public unsafe float* KalmGainMatr
        {
            get
            {
                return ((WCvKalman*)ptr)->KalmGainMatr;
            }
        }
        /// <summary>
        /// error_cov_pre->data.fl
        /// </summary>
        public unsafe float* PriorErrorCovariance
        {
            get
            {
                return ((WCvKalman*)ptr)->PriorErrorCovariance;
            }
        }
        /// <summary>
        /// error_cov_post->data.fl
        /// </summary>
        public unsafe float* PosterErrorCovariance
        {
            get
            {
                return ((WCvKalman*)ptr)->PosterErrorCovariance;
            }
        }
        /// <summary>
        /// temp1->data.fl
        /// </summary>
        public unsafe float* Temp1Data
        {
            get
            {
                return ((WCvKalman*)ptr)->Temp1;
            }
        }
        /// <summary>
        /// temp2->data.fl
        /// </summary>
        public unsafe float* Temp2Data
        {
            get
            {
                return ((WCvKalman*)ptr)->Temp2;
            }
        }
        #endregion
        #endregion

        #region Methods
	    #region KalmanCorrect
#if LANG_JP
        /// <summary>
        /// モデル状態を修正する (cvKalmanCorrect). 修正された状態を kalman->state_post に保存し，これを出力として返す.
        /// </summary>
        /// <param name="measurement">観測ベクトルを含むCvMat</param>
        /// <returns>修正された状態を kalman->state_post に保存し，これを出力として返す．</returns>
#else
        /// <summary>
        /// Adjusts model state (cvKalmanCorrect). 
        /// </summary>
        /// <param name="measurement">CvMat containing the measurement vector. </param>
        /// <returns>The function stores adjusted state at kalman->state_post and returns it on output.</returns>
#endif
        public CvMat Correct(CvMat measurement)
	    {
		    return Cv.KalmanCorrect(this, measurement);
	    }
#if LANG_JP
        /// <summary>
        /// モデル状態を修正する. 修正された状態を kalman->state_post に保存し，これを出力として返す．cvKalmanCorrectのエイリアス.
        /// </summary>
        /// <param name="measurement">観測ベクトルを含むCvMat</param>
        /// <returns>修正された状態を kalman->state_post に保存し，これを出力として返す．</returns>
#else
        /// <summary>
        /// Adjusts model state
        /// </summary>
        /// <param name="measurement">CvMat containing the measurement vector. </param>
        /// <returns>The function stores adjusted state at kalman->state_post and returns it on output.</returns>
#endif
        public CvMat UpdateByMeasurement(CvMat measurement)
	    {
		    return Cv.KalmanUpdateByMeasurement(this, measurement);
	    }
	    #endregion
	    #region KalmanPredict
#if LANG_JP
        /// <summary>
        /// 次のモデル状態を推定する (cvKalmanPredict).
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Estimates subsequent model state (cvKalmanPredict).
        /// </summary>
        /// <returns>The function returns the estimated state. </returns>
#endif
        public CvMat Predict()
	    {
		    return Cv.KalmanPredict(this);
	    }
#if LANG_JP
        /// <summary>
        /// 次のモデル状態を推定する (cvKalmanPredict).
        /// </summary>
        /// <param name="control">コントロールベクトル (uk)．外部コントロールが存在しない場合（control_params=0）に限り，null である．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Estimates subsequent model state (cvKalmanPredict).
        /// </summary>
        /// <param name="control">Control vector (uk), should be null iff there is no external control (control_params=0).</param>
        /// <returns>The function returns the estimated state. </returns>
#endif
        public CvMat Predict(CvMat control)
	    {
		    return Cv.KalmanPredict(this, control);
	    }
#if LANG_JP
        /// <summary>
        /// 次のモデル状態を推定する. cvKalmanPredictのエイリアス.
        /// </summary>
        /// <returns></returns>
#else
        /// <summary>
        /// Estimates subsequent model state
        /// </summary>
        /// <returns>The function returns the estimated state. </returns>
#endif
        public CvMat UpdateByTime()
	    {
		    return Cv.KalmanUpdateByTime(this);
	    }
#if LANG_JP
        /// <summary>
        /// 次のモデル状態を推定する. cvKalmanPredictのエイリアス.
        /// </summary>
        /// <param name="control">コントロールベクトル (uk)．外部コントロールが存在しない場合（control_params=0）に限り，null である．</param>
        /// <returns></returns>
#else
        /// <summary>
        /// Estimates subsequent model state
        /// </summary>
        /// <param name="control">Control vector (uk), should be null iff there is no external control (control_params=0).</param>
        /// <returns>The function returns the estimated state. </returns>
#endif
	    public CvMat UpdateByTime( CvMat control )
	    {
		    return Cv.KalmanUpdateByTime(this, control);
	    }
	    #endregion
	    #endregion
    }
}

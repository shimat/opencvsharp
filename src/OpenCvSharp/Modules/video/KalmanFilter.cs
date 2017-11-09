using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCvSharp
{
    /// <summary>
    /// Kalman filter.
    /// The class implements standard Kalman filter \url{http://en.wikipedia.org/wiki/Kalman_filter}.
    /// However, you can modify KalmanFilter::transitionMatrix, KalmanFilter::controlMatrix and
    /// KalmanFilter::measurementMatrix to get the extended Kalman filter functionality.
    /// </summary>
    public class KalmanFilter : DisposableCvObject
    {
        #region Init & Disposal

        /// <summary>
        /// the default constructor
        /// </summary>
        public KalmanFilter()
        {
            ptr = NativeMethods.video_KalmanFilter_new1();
        }

        /// <summary>
        /// the full constructor taking the dimensionality of the state, of the measurement and of the control vector
        /// </summary>
        /// <param name="dynamParams"></param>
        /// <param name="measureParams"></param>
        /// <param name="controlParams"></param>
        /// <param name="type"></param>
        public KalmanFilter(int dynamParams, int measureParams, int controlParams = 0, int type = MatType.CV_32F)
        {
            ptr = NativeMethods.video_KalmanFilter_new2(
                dynamParams, measureParams, controlParams, type);
        }

        /// <summary>
        /// Releases unmanaged resources
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.video_KalmanFilter_delete(ptr);
            base.DisposeUnmanaged();
        }

        #endregion

        #region Properties
        /// <summary>
        /// predicted state (x'(k)): x(k)=A*x(k-1)+B*u(k)
        /// </summary>
        public Mat StatePre
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.video_KalmanFilter_statePre(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// corrected state (x(k)): x(k)=x'(k)+K(k)*(z(k)-H*x'(k))
        /// </summary>
        public Mat StatePost
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.video_KalmanFilter_statePost(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// state transition matrix (A)
        /// </summary>
        public Mat TransitionMatrix
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.video_KalmanFilter_transitionMatrix(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// control matrix (B) (not used if there is no control)
        /// </summary>
        public Mat ControlMatrix
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.video_KalmanFilter_controlMatrix(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// measurement matrix (H)
        /// </summary>
        public Mat MeasurementMatrix
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.video_KalmanFilter_measurementMatrix(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// process noise covariance matrix (Q)
        /// </summary>
        public Mat ProcessNoiseCov
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.video_KalmanFilter_processNoiseCov(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// measurement noise covariance matrix (R)
        /// </summary>
        public Mat MeasurementNoiseCov
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.video_KalmanFilter_measurementNoiseCov(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// priori error estimate covariance matrix (P'(k)): P'(k)=A*P(k-1)*At + Q)*/
        /// </summary>
        public Mat ErrorCovPre
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.video_KalmanFilter_errorCovPre(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// Kalman gain matrix (K(k)): K(k)=P'(k)*Ht*inv(H*P'(k)*Ht+R)
        /// </summary>
        public Mat Gain
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.video_KalmanFilter_gain(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        /// <summary>
        /// posteriori error estimate covariance matrix (P(k)): P(k)=(I-K(k)*H)*P'(k)
        /// </summary>
        public Mat ErrorCovPost
        {
            get
            {
                ThrowIfDisposed();
                IntPtr ret = NativeMethods.video_KalmanFilter_errorCovPost(ptr);
                GC.KeepAlive(this);
                return new Mat(ret);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// re-initializes Kalman filter. The previous content is destroyed.
        /// </summary>
        /// <param name="dynamParams"></param>
        /// <param name="measureParams"></param>
        /// <param name="controlParams"></param>
        /// <param name="type"></param>
        public void Init(int dynamParams, int measureParams, int controlParams = 0, int type = MatType.CV_32F)
        {
            ThrowIfDisposed();
            NativeMethods.video_KalmanFilter_init(ptr, 
                dynamParams, measureParams, controlParams, type);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// computes predicted state
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public Mat Predict(Mat control = null)
        {
            ThrowIfDisposed();

            IntPtr ret = NativeMethods.video_KalmanFilter_predict(ptr, Cv2.ToPtr(control));
            GC.KeepAlive(this);
            GC.KeepAlive(control);
            return new Mat(ret);
        }

        /// <summary>
        /// updates the predicted state from the measurement
        /// </summary>
        /// <param name="measurement"></param>
        /// <returns></returns>
        public Mat Correct(Mat measurement)
        {
            ThrowIfDisposed();
            if (measurement == null)
                throw new ArgumentNullException(nameof(measurement));
            measurement.ThrowIfDisposed();

            IntPtr ret = NativeMethods.video_KalmanFilter_correct(ptr, measurement.CvPtr);
            GC.KeepAlive(this);
            GC.KeepAlive(measurement);
            return new Mat(ret);
        }

        #endregion
    }
}

using OpenCvSharp.Internal;

namespace OpenCvSharp;

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
        NativeMethods.HandleException(
            NativeMethods.video_KalmanFilter_new1(out ptr));
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
        NativeMethods.HandleException(
            NativeMethods.video_KalmanFilter_new2(
                dynamParams, measureParams, controlParams, type, out ptr));
    }

    /// <summary>
    /// Releases unmanaged resources
    /// </summary>
    protected override void DisposeUnmanaged()
    {
        NativeMethods.HandleException(
            NativeMethods.video_KalmanFilter_delete(ptr));
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
            NativeMethods.HandleException(
                NativeMethods.video_KalmanFilter_statePre(ptr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret) { IsEnabledDispose = false };
        }
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();

            using var get = StatePre; 
            value.CopyTo(get);
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
            NativeMethods.HandleException(
                NativeMethods.video_KalmanFilter_statePost(ptr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret) { IsEnabledDispose = false };
        }
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();

            using var get = StatePost;
            value.CopyTo(get);
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
            NativeMethods.HandleException(
                NativeMethods.video_KalmanFilter_transitionMatrix(ptr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret) { IsEnabledDispose = false };
        }
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();

            using var get = TransitionMatrix;
            value.CopyTo(get);
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
            NativeMethods.HandleException(
                NativeMethods.video_KalmanFilter_controlMatrix(ptr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret) { IsEnabledDispose = false };
        }
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();

            using var get = ControlMatrix;
            value.CopyTo(get);
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
            NativeMethods.HandleException(
                NativeMethods.video_KalmanFilter_measurementMatrix(ptr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret) { IsEnabledDispose = false };
        }
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();

            using var get = MeasurementMatrix;
            value.CopyTo(get);
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
            NativeMethods.HandleException(
                NativeMethods.video_KalmanFilter_processNoiseCov(ptr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret) { IsEnabledDispose = false };
        }
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();

            using var get = ProcessNoiseCov;
            value.CopyTo(get);
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
            NativeMethods.HandleException(
                NativeMethods.video_KalmanFilter_measurementNoiseCov(ptr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret) { IsEnabledDispose = false };
        }
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();

            using var get = MeasurementNoiseCov;
            value.CopyTo(get);
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
            NativeMethods.HandleException(
                NativeMethods.video_KalmanFilter_errorCovPre(ptr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret) { IsEnabledDispose = false };
        }
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();

            using var get = ErrorCovPre;
            value.CopyTo(get);
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
            NativeMethods.HandleException(
                NativeMethods.video_KalmanFilter_gain(ptr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret) { IsEnabledDispose = false };
        }
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();

            using var get = Gain;
            value.CopyTo(get);
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
            NativeMethods.HandleException(
                NativeMethods.video_KalmanFilter_errorCovPost(ptr, out var ret));
            GC.KeepAlive(this);
            return new Mat(ret) { IsEnabledDispose = false };
        }
        set
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            value.ThrowIfDisposed();

            using var get = ErrorCovPost;
            value.CopyTo(get);
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
        NativeMethods.HandleException(
            NativeMethods.video_KalmanFilter_init(
                ptr, dynamParams, measureParams, controlParams, type));
        GC.KeepAlive(this);
    }

    /// <summary>
    /// computes predicted state
    /// </summary>
    /// <param name="control"></param>
    /// <returns></returns>
    public Mat Predict(Mat? control = null)
    {
        ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.video_KalmanFilter_predict(ptr, Cv2.ToPtr(control), out var ret));
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
        if (measurement is null)
            throw new ArgumentNullException(nameof(measurement));
        measurement.ThrowIfDisposed();

        NativeMethods.HandleException(
            NativeMethods.video_KalmanFilter_correct(ptr, measurement.CvPtr, out var ret));
        GC.KeepAlive(this);
        GC.KeepAlive(measurement);
        return new Mat(ret);
    }

    #endregion
}

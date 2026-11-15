using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp;

/// <summary>Estimates camera motion and builds a sparse map from a sequence of monocular images.</summary>
public sealed class VisualOdometry : CvObject
{
    private VisualOdometry(OpenCvSafeHandle handle) : base(handle)
    {
    }

    /// <summary>Creates a monocular visual odometry pipeline.</summary>
    /// <param name="detector">Feature detector and descriptor extractor.</param>
    /// <param name="matcher">Matcher compatible with the detector's descriptors.</param>
    /// <param name="cameraMatrix">Camera intrinsic matrix.</param>
    /// <param name="distCoeffs">Optional camera distortion coefficients.</param>
    /// <param name="parameters">Optional parameters. The default OpenCV parameters are used if omitted.</param>
    /// <remarks>The pipeline keeps the native detector and matcher alive until it is disposed.</remarks>
    public static VisualOdometry Create(Feature2D detector, DescriptorMatcher matcher, InputArray cameraMatrix,
        InputArray distCoeffs = default, VisualOdometryParams? parameters = null)
    {
        ArgumentNullException.ThrowIfNull(detector);
        ArgumentNullException.ThrowIfNull(matcher);

        var detectorHandle = detector.Handle;
        var matcherHandle = matcher.Handle;
        var detectorRetained = false;
        var matcherRetained = false;
        try
        {
            detectorHandle.DangerousAddRef(ref detectorRetained);
            matcherHandle.DangerousAddRef(ref matcherRetained);

            var options = parameters ?? VisualOdometryParams.Default;
            NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_create(
                detectorHandle.DangerousGetHandle(), matcherHandle.DangerousGetHandle(),
                cameraMatrix.Proxy, distCoeffs.Proxy, options, out var ptr));
            GC.KeepAlive(cameraMatrix.Source);
            GC.KeepAlive(distCoeffs.Source);

            var handle = new OpenCvPtrSafeHandle(ptr, ownsHandle: true,
                static h => NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_delete(h)));
            handle.SetPostReleaseAction(() =>
            {
                matcherHandle.DangerousRelease();
                detectorHandle.DangerousRelease();
            });
            detectorRetained = matcherRetained = false;
            return new VisualOdometry(handle);
        }
        finally
        {
            if (matcherRetained)
                matcherHandle.DangerousRelease();
            if (detectorRetained)
                detectorHandle.DangerousRelease();
        }
    }

    /// <summary>Feeds an image to the pipeline.</summary>
    /// <returns>Whether a pose was emitted.</returns>
    public bool ProcessFrame(InputArray image)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_processFrame(Handle, image.Proxy, out var emitted));
        GC.KeepAlive(image.Source);
        return emitted != 0;
    }

    /// <summary>Clears the map and trajectory and returns the pipeline to its initial state.</summary>
    public void Reset()
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_reset(Handle));
    }

    /// <summary>Gets the current pipeline state.</summary>
    public VisualOdometryState State
    {
        get
        {
            NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_getState(Handle, out var result));
            return result;
        }
    }

    /// <summary>Gets the current number of keyframes in the map.</summary>
    public int KeyframeCount
    {
        get
        {
            NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_getNumKeyframes(Handle, out var result));
            return result;
        }
    }

    /// <summary>Gets the current number of points in the map.</summary>
    public int MapPointCount
    {
        get
        {
            NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_getNumMapPoints(Handle, out var result));
            return result;
        }
    }

    /// <summary>Copies the most recent camera pose into a 4-by-4 CV_64F matrix.</summary>
    public void GetLastPose(OutputArray pose)
    {
        NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_getLastPose(Handle, pose.Proxy));
        GC.KeepAlive(pose.Source);
    }

    /// <summary>Returns the trajectory as independent 4-by-4 CV_64F matrices. Dispose each returned matrix after use.</summary>
    public Mat[] GetTrajectory()
    {
        using var poses = new VectorOfMat();
        NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_getTrajectory(Handle, poses.Handle));
        return poses.ToArray();
    }

    /// <summary>Gets or sets the parameters used by the pipeline.</summary>
    public VisualOdometryParams Parameters
    {
        get
        {
            NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_getParams(Handle, out var parameters));
            return parameters;
        }
        set => NativeMethods.HandleException(NativeMethods.ptcloud_VisualOdometry_setParams(Handle, value));
    }
}

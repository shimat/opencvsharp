using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Rgbd;

/// <summary>Parameters for <see cref="LargeKinfu"/>.</summary>
/// <remarks>
/// Instances can only be obtained via <see cref="DefaultParams"/>, <see cref="CoarseParams"/>,
/// <see cref="HashTsdfParams"/>, or <see cref="LargeKinfu.GetParams"/>, ensuring the values are
/// always initialized from the native C++ defaults.
/// </remarks>
public sealed class LargeKinfuParams
{
    internal LargeKinfuParams(
        CvLargeKinfuParams p, Mat intr, Mat rgbIntr, int[] icpIterations, LargeKinfuVolumeParams volumeParams)
    {
        FrameSize = p.FrameSize;
        DepthFactor = p.DepthFactor;
        BilateralSigmaDepth = p.BilateralSigmaDepth;
        BilateralSigmaSpatial = p.BilateralSigmaSpatial;
        BilateralKernelSize = p.BilateralKernelSize;
        PyramidLevels = p.PyramidLevels;
        TsdfMinCameraMovement = p.TsdfMinCameraMovement;
        LightPose = p.LightPose;
        IcpDistThresh = p.IcpDistThresh;
        IcpAngleThresh = p.IcpAngleThresh;
        TruncateThreshold = p.TruncateThreshold;
        Intr = intr;
        RgbIntr = rgbIntr;
        IcpIterations = icpIterations;
        VolumeParams = volumeParams;
    }

    private delegate ExceptionStatus Factory(
        out CvLargeKinfuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        IntPtr icpIterations, out CvLargeKinfuVolumeParams volumePod, in OutputArrayProxy volumePose);

    private static LargeKinfuParams FromFactory(Factory factory)
    {
        var intr = new Mat();
        var rgbIntr = new Mat();
        var volumePose = new Mat();
        using var icpIterations = new StdVector<int>();
        OutputArray intrArray = intr;
        OutputArray rgbIntrArray = rgbIntr;
        OutputArray volumePoseArray = volumePose;
        NativeMethods.HandleException(factory(
            out var pod, intrArray.Proxy, rgbIntrArray.Proxy, icpIterations.CvPtr,
            out var volumePod, volumePoseArray.Proxy));
        GC.KeepAlive(intr); GC.KeepAlive(rgbIntr); GC.KeepAlive(volumePose);
        var volumeParams = new LargeKinfuVolumeParams(volumePod, volumePose);
        return new LargeKinfuParams(pod, intr, rgbIntr, icpIterations.ToArray(), volumeParams);
    }

    /// <summary>Default parameters providing better model quality, can be very slow.</summary>
    public static LargeKinfuParams DefaultParams() =>
        FromFactory(NativeMethods.rgbd_large_kinfu_Params_defaultParams);

    /// <summary>Coarse parameters providing better speed, can fail to match frames in case of rapid sensor motion.</summary>
    public static LargeKinfuParams CoarseParams() =>
        FromFactory(NativeMethods.rgbd_large_kinfu_Params_coarseParams);

    /// <summary>Parameters suitable for use with a hash-based TSDF volume.</summary>
    public static LargeKinfuParams HashTsdfParams(bool isCoarse) =>
        FromFactory((out CvLargeKinfuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
                IntPtr icpIterations, out CvLargeKinfuVolumeParams volumePod, in OutputArrayProxy volumePose) =>
            NativeMethods.rgbd_large_kinfu_Params_hashTSDFParams(
                isCoarse ? 1 : 0, out pod, intr, rgbIntr, icpIterations, out volumePod, volumePose));

    internal CvLargeKinfuParams ToNative() => new()
    {
        FrameSize = FrameSize,
        DepthFactor = DepthFactor,
        BilateralSigmaDepth = BilateralSigmaDepth,
        BilateralSigmaSpatial = BilateralSigmaSpatial,
        BilateralKernelSize = BilateralKernelSize,
        PyramidLevels = PyramidLevels,
        TsdfMinCameraMovement = TsdfMinCameraMovement,
        LightPose = LightPose,
        IcpDistThresh = IcpDistThresh,
        IcpAngleThresh = IcpAngleThresh,
        TruncateThreshold = TruncateThreshold,
    };

    /// <summary>Frame size in pixels.</summary>
    public Size FrameSize { get; set; }

    /// <summary>Camera intrinsics (3x3).</summary>
    public Mat Intr { get; set; }

    /// <summary>RGB camera intrinsics (3x3).</summary>
    public Mat RgbIntr { get; set; }

    /// <summary>Pre-scale per 1 meter for input depth values.</summary>
    public float DepthFactor { get; set; }

    /// <summary>Depth sigma in meters for bilateral smoothing.</summary>
    public float BilateralSigmaDepth { get; set; }

    /// <summary>Spatial sigma in pixels for bilateral smoothing.</summary>
    public float BilateralSigmaSpatial { get; set; }

    /// <summary>Kernel size in pixels for bilateral smoothing.</summary>
    public int BilateralKernelSize { get; set; }

    /// <summary>Number of pyramid levels for ICP.</summary>
    public int PyramidLevels { get; set; }

    /// <summary>Minimal camera movement in meters; a new depth frame is integrated only if camera movement exceeds this value.</summary>
    public float TsdfMinCameraMovement { get; set; }

    /// <summary>Light pose for rendering, in meters.</summary>
    public Vec3f LightPose { get; set; }

    /// <summary>Distance threshold for ICP, in meters.</summary>
    public float IcpDistThresh { get; set; }

    /// <summary>Angle threshold for ICP, in radians.</summary>
    public float IcpAngleThresh { get; set; }

    /// <summary>Number of ICP iterations for each pyramid level.</summary>
    public int[] IcpIterations { get; set; }

    /// <summary>Threshold for depth truncation in meters; depth values beyond this threshold are set to zero.</summary>
    public float TruncateThreshold { get; set; }

    /// <summary>Volume parameters.</summary>
    public LargeKinfuVolumeParams VolumeParams { get; set; }
}

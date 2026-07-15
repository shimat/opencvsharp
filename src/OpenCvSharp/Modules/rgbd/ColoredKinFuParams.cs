using OpenCvSharp.Internal;
using OpenCvSharp.Internal.Vectors;

namespace OpenCvSharp.Rgbd;

/// <summary>Parameters for <see cref="ColoredKinFu"/>.</summary>
/// <remarks>
/// Instances can only be obtained via <see cref="DefaultParams"/>, <see cref="CoarseParams"/>,
/// <see cref="HashTsdfParams"/>, <see cref="ColoredTsdfParams"/>, or <see cref="ColoredKinFu.GetParams"/>,
/// ensuring the values are always initialized from the native C++ defaults.
/// </remarks>
public sealed class ColoredKinFuParams
{
    internal ColoredKinFuParams(CvColoredKinFuParams p, Mat intr, Mat rgbIntr, Mat volumePose, int[] icpIterations)
    {
        FrameSize = p.FrameSize;
        RgbFrameSize = p.RgbFrameSize;
        VolumeKind = (VolumeType)p.VolumeKind;
        DepthFactor = p.DepthFactor;
        BilateralSigmaDepth = p.BilateralSigmaDepth;
        BilateralSigmaSpatial = p.BilateralSigmaSpatial;
        BilateralKernelSize = p.BilateralKernelSize;
        PyramidLevels = p.PyramidLevels;
        VolumeDims = p.VolumeDims;
        VoxelSize = p.VoxelSize;
        TsdfMinCameraMovement = p.TsdfMinCameraMovement;
        TsdfTruncDist = p.TsdfTruncDist;
        TsdfMaxWeight = p.TsdfMaxWeight;
        RaycastStepFactor = p.RaycastStepFactor;
        LightPose = p.LightPose;
        IcpDistThresh = p.IcpDistThresh;
        IcpAngleThresh = p.IcpAngleThresh;
        TruncateThreshold = p.TruncateThreshold;
        Intr = intr;
        RgbIntr = rgbIntr;
        VolumePose = volumePose;
        IcpIterations = icpIterations;
    }

    private delegate ExceptionStatus Factory(
        out CvColoredKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
        in OutputArrayProxy volumePose, IntPtr icpIterations);

    private static ColoredKinFuParams FromFactory(Factory factory)
    {
        var intr = new Mat();
        var rgbIntr = new Mat();
        var volumePose = new Mat();
        using var icpIterations = new StdVector<int>();
        OutputArray intrArray = intr;
        OutputArray rgbIntrArray = rgbIntr;
        OutputArray volumePoseArray = volumePose;
        NativeMethods.HandleException(factory(
            out var pod, intrArray.Proxy, rgbIntrArray.Proxy, volumePoseArray.Proxy, icpIterations.CvPtr));
        GC.KeepAlive(intr); GC.KeepAlive(rgbIntr); GC.KeepAlive(volumePose);
        return new ColoredKinFuParams(pod, intr, rgbIntr, volumePose, icpIterations.ToArray());
    }

    /// <summary>Default parameters providing better model quality, can be very slow.</summary>
    public static ColoredKinFuParams DefaultParams() =>
        FromFactory(NativeMethods.rgbd_colored_kinfu_Params_defaultParams);

    /// <summary>Coarse parameters providing better speed, can fail to match frames in case of rapid sensor motion.</summary>
    public static ColoredKinFuParams CoarseParams() =>
        FromFactory(NativeMethods.rgbd_colored_kinfu_Params_coarseParams);

    /// <summary>Parameters suitable for use with a hash-based TSDF volume.</summary>
    public static ColoredKinFuParams HashTsdfParams(bool isCoarse) =>
        FromFactory((out CvColoredKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
                in OutputArrayProxy volumePose, IntPtr icpIterations) =>
            NativeMethods.rgbd_colored_kinfu_Params_hashTSDFParams(
                isCoarse ? 1 : 0, out pod, intr, rgbIntr, volumePose, icpIterations));

    /// <summary>Parameters suitable for use with a colored TSDF volume.</summary>
    public static ColoredKinFuParams ColoredTsdfParams(bool isCoarse) =>
        FromFactory((out CvColoredKinFuParams pod, in OutputArrayProxy intr, in OutputArrayProxy rgbIntr,
                in OutputArrayProxy volumePose, IntPtr icpIterations) =>
            NativeMethods.rgbd_colored_kinfu_Params_coloredTSDFParams(
                isCoarse ? 1 : 0, out pod, intr, rgbIntr, volumePose, icpIterations));

    internal CvColoredKinFuParams ToNative() => new()
    {
        FrameSize = FrameSize,
        RgbFrameSize = RgbFrameSize,
        VolumeKind = (int)VolumeKind,
        DepthFactor = DepthFactor,
        BilateralSigmaDepth = BilateralSigmaDepth,
        BilateralSigmaSpatial = BilateralSigmaSpatial,
        BilateralKernelSize = BilateralKernelSize,
        PyramidLevels = PyramidLevels,
        VolumeDims = VolumeDims,
        VoxelSize = VoxelSize,
        TsdfMinCameraMovement = TsdfMinCameraMovement,
        TsdfTruncDist = TsdfTruncDist,
        TsdfMaxWeight = TsdfMaxWeight,
        RaycastStepFactor = RaycastStepFactor,
        LightPose = LightPose,
        IcpDistThresh = IcpDistThresh,
        IcpAngleThresh = IcpAngleThresh,
        TruncateThreshold = TruncateThreshold,
    };

    /// <summary>Depth frame size in pixels.</summary>
    public Size FrameSize { get; set; }

    /// <summary>RGB frame size in pixels.</summary>
    public Size RgbFrameSize { get; set; }

    /// <summary>Volume kind.</summary>
    public VolumeType VolumeKind { get; set; }

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

    /// <summary>Resolution of voxel space (number of voxels in each dimension).</summary>
    public Vec3i VolumeDims { get; set; }

    /// <summary>Size of voxel in meters.</summary>
    public float VoxelSize { get; set; }

    /// <summary>Minimal camera movement in meters; a new depth frame is integrated only if camera movement exceeds this value.</summary>
    public float TsdfMinCameraMovement { get; set; }

    /// <summary>Initial volume pose in meters (4x4 homogeneous transform).</summary>
    public Mat VolumePose { get; set; }

    /// <summary>Distance to truncate in meters; distances beyond this value are truncated to 1.0.</summary>
    public float TsdfTruncDist { get; set; }

    /// <summary>Max number of frames per voxel; each voxel keeps a running average of distances no longer than this value.</summary>
    public int TsdfMaxWeight { get; set; }

    /// <summary>Fraction of a voxel size skipped per raycast step.</summary>
    public float RaycastStepFactor { get; set; }

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
}

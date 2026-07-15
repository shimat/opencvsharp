using OpenCvSharp.Internal;

namespace OpenCvSharp.Rgbd;

/// <summary>Volume parameters used by <see cref="LargeKinfuParams"/>.</summary>
/// <remarks>
/// Instances can only be obtained via <see cref="DefaultParams"/> or <see cref="CoarseParams"/>,
/// ensuring the values are always initialized from the native C++ defaults.
/// </remarks>
public sealed class LargeKinfuVolumeParams
{
    internal LargeKinfuVolumeParams(CvLargeKinfuVolumeParams v, Mat pose)
    {
        Kind = (VolumeType)v.Kind;
        ResolutionX = v.ResolutionX;
        ResolutionY = v.ResolutionY;
        ResolutionZ = v.ResolutionZ;
        UnitResolution = v.UnitResolution;
        VolumSize = v.VolumSize;
        VoxelSize = v.VoxelSize;
        TsdfTruncDist = v.TsdfTruncDist;
        MaxWeight = v.MaxWeight;
        DepthTruncThreshold = v.DepthTruncThreshold;
        RaycastStepFactor = v.RaycastStepFactor;
        Pose = pose;
    }

    private delegate ExceptionStatus Factory(int volumeType, out CvLargeKinfuVolumeParams pod, in OutputArrayProxy pose);

    private static LargeKinfuVolumeParams FromFactory(Factory factory, VolumeType volumeType)
    {
        var pose = new Mat();
        OutputArray poseArray = pose;
        NativeMethods.HandleException(factory((int)volumeType, out var pod, poseArray.Proxy));
        GC.KeepAlive(pose);
        return new LargeKinfuVolumeParams(pod, pose);
    }

    /// <summary>Default parameters providing higher-quality reconstruction at the cost of slower performance.</summary>
    public static LargeKinfuVolumeParams DefaultParams(VolumeType volumeType) =>
        FromFactory(NativeMethods.rgbd_large_kinfu_VolumeParams_defaultParams, volumeType);

    /// <summary>Coarse parameters providing relatively higher performance at the cost of reconstruction quality.</summary>
    public static LargeKinfuVolumeParams CoarseParams(VolumeType volumeType) =>
        FromFactory(NativeMethods.rgbd_large_kinfu_VolumeParams_coarseParams, volumeType);

    internal CvLargeKinfuVolumeParams ToNative() => new()
    {
        Kind = (int)Kind,
        ResolutionX = ResolutionX,
        ResolutionY = ResolutionY,
        ResolutionZ = ResolutionZ,
        UnitResolution = UnitResolution,
        VolumSize = VolumSize,
        VoxelSize = VoxelSize,
        TsdfTruncDist = TsdfTruncDist,
        MaxWeight = MaxWeight,
        DepthTruncThreshold = DepthTruncThreshold,
        RaycastStepFactor = RaycastStepFactor,
    };

    /// <summary>Kind of volume (TSDF or HashTSDF).</summary>
    public VolumeType Kind { get; set; }

    /// <summary>Resolution of voxel space along X (number of voxels). Applicable only for TSDF volume.</summary>
    public int ResolutionX { get; set; }

    /// <summary>Resolution of voxel space along Y (number of voxels). Applicable only for TSDF volume.</summary>
    public int ResolutionY { get; set; }

    /// <summary>Resolution of voxel space along Z (number of voxels). Applicable only for TSDF volume.</summary>
    public int ResolutionZ { get; set; }

    /// <summary>Resolution of a volume unit in voxel space. Applicable only for HashTSDF.</summary>
    public int UnitResolution { get; set; }

    /// <summary>Size of the volume in meters.</summary>
    public float VolumSize { get; set; }

    /// <summary>Initial pose of the volume in meters (4x4 homogeneous transform).</summary>
    public Mat Pose { get; set; }

    /// <summary>Length of voxels in meters.</summary>
    public float VoxelSize { get; set; }

    /// <summary>TSDF truncation distance; distances greater than this from the surface are truncated to 1.0.</summary>
    public float TsdfTruncDist { get; set; }

    /// <summary>Max number of frames to integrate per voxel.</summary>
    public int MaxWeight { get; set; }

    /// <summary>Threshold for depth truncation in meters; depth greater than this is truncated to 0.</summary>
    public float DepthTruncThreshold { get; set; }

    /// <summary>Length of a single raycast step, as a fraction of the voxel length.</summary>
    public float RaycastStepFactor { get; set; }
}

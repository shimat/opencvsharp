using Xunit;

namespace OpenCvSharp.Tests.PtCloud;

public class VisualOdometryTest
{
    [Fact]
    public void ProcessFrameAndResetPreserveNativePipelineLifecycle()
    {
        using var detector = ORB.Create();
        using var matcher = new BFMatcher(NormTypes.Hamming);
        using var intrinsics = Mat.Eye(3, 3, MatType.CV_64F).ToMat();
        intrinsics.Set(0, 0, 160d);
        intrinsics.Set(1, 1, 160d);
        intrinsics.Set(0, 2, 80d);
        intrinsics.Set(1, 2, 80d);

        var parameters = VisualOdometryParams.Default;
        Assert.Equal(40, parameters.MinInitInliers);
        Assert.Equal(7d, parameters.LocalMapRadius);
        parameters.MinInitInliers = 20;
        using var odometry = VisualOdometry.Create(detector, matcher, intrinsics, parameters: parameters);
        Assert.Equal(20, odometry.Parameters.MinInitInliers);
        parameters.LocalMapRadius = 9d;
        odometry.Parameters = parameters;
        Assert.Equal(9d, odometry.Parameters.LocalMapRadius);

        detector.Dispose();
        matcher.Dispose();
        using var frame = new Mat(160, 160, MatType.CV_8UC1);
        var data = new byte[160, 160];
        var random = new Random(42);
        for (var y = 0; y < frame.Rows; y++)
        for (var x = 0; x < frame.Cols; x++)
            data[y, x] = (byte)random.Next(256);
        frame.SetRectangularArray(data);

        Assert.Equal(VisualOdometryState.NotInitialized, odometry.State);
        using var empty = new Mat();
        Assert.False(odometry.ProcessFrame(empty));
        Assert.Equal(VisualOdometryState.NotInitialized, odometry.State);
        Assert.False(odometry.ProcessFrame(frame));
        Assert.Equal(VisualOdometryState.Initializing, odometry.State);

        odometry.Reset();
        Assert.Equal(VisualOdometryState.NotInitialized, odometry.State);
        Assert.Equal(0, odometry.KeyframeCount);
        Assert.Equal(0, odometry.MapPointCount);
        Assert.Empty(odometry.GetTrajectory());
        using var pose = new Mat();
        odometry.GetLastPose(pose);
        Assert.Equal(new Size(4, 4), pose.Size());
        Assert.Equal(1d, pose.At<double>(3, 3));
        Assert.Equal(0d, pose.At<double>(0, 3));
    }
}

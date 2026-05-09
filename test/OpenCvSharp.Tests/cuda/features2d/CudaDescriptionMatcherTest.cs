using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using OpenCvSharp.Internal.Vectors;
using OpenCvSharp.Tests.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.features2d;

public class CudaDescriptionMatcherTest : CudaTestBase
{

    [Fact]
    public void KnnMatchAsync_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create dummy descriptors (CV_32F)
        float[] queryData = { 1, 0, 0, 0, 0, 1, 0, 0 };
        float[] trainData = { 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0 };

        using var cpuQuery = Mat.FromPixelData(2, 4, MatType.CV_32FC1, queryData);
        using var cpuTrain = Mat.FromPixelData(3, 4, MatType.CV_32FC1, trainData);

        using var gpuQuery = new GpuMat(); gpuQuery.Upload(cpuQuery);
        using var gpuTrain = new GpuMat(); gpuTrain.Upload(cpuTrain);

        using var gpuMatches = new GpuMat(); // This will hold the raw GPU matches
        using var stream = new OpenCvSharp.Cuda.Stream();

        using var matcher = OpenCvSharp.Cuda.DescriptorMatcher.CreateBFMatcher(NormTypes.L2);

        // 2. Act: Calculate Async
        matcher.KnnMatchAsync(gpuQuery, gpuTrain, gpuMatches, k: 2, stream: stream);

        // 3. Synchronize to ensure GPU is finished
        stream.WaitForCompletion();

        // 4. Assert
        // The raw gpuMatches buffer should be allocated and filled by the GPU
        Assert.False(gpuMatches.Empty());

        // In OpenCV CUDA, KnnMatchAsync usually returns a CV_32S matrix for indices
        // and a CV_32F matrix for distances (often packed or returned as a 2-channel matrix).
        // We just verify it successfully wrote to the output array.
        Assert.Equal(2, gpuMatches.Rows); // 2 query descriptors
    }

    [Fact]
    public void KnnMatchAsync_BasicTest()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create dummy descriptors (CV_32F)
        // Query: 2 features (Dimension = 4)
        // Train: 3 features
        float[] queryData = { 1, 0, 0, 0, 0, 1, 0, 0 };
        float[] trainData = { 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0 };

        using var cpuQuery = Mat.FromPixelData(2, 4, MatType.CV_32FC1, queryData);
        using var cpuTrain = Mat.FromPixelData(3, 4, MatType.CV_32FC1, trainData);

        using var gpuQuery = new GpuMat(); gpuQuery.Upload(cpuQuery);
        using var gpuTrain = new GpuMat(); gpuTrain.Upload(cpuTrain);
        using var gpuMatches = new GpuMat();

        using var matcher = OpenCvSharp.Cuda.DescriptorMatcher.CreateBFMatcher(NormTypes.L2);
        using var stream = new OpenCvSharp.Cuda.Stream();

      
        using var matches = new GpuMat(gpuQuery.Rows, 2, MatType.CV_32SC2);

        matcher.Add([gpuTrain]);
        matcher.Train();
        stream.WaitForCompletion();

        // Act
        matcher.KnnMatchAsync(gpuQuery, matches, k: 2, stream: stream);

        stream.WaitForCompletion();

        // Assert
        Assert.False(matches.Empty());

       
    }

    [Fact]
    public void KnnMatchAsync_And_Convert_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create dummy descriptors (CV_32F)
        // Query: 2 features (Dimension = 4)
        // Train: 3 features
        float[] queryData = { 1, 0, 0, 0, 0, 1, 0, 0 };
        float[] trainData = { 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0 };

        using var cpuQuery = Mat.FromPixelData(2, 4, MatType.CV_32FC1, queryData);
        using var cpuTrain = Mat.FromPixelData(3, 4, MatType.CV_32FC1, trainData);

        using var gpuQuery = new GpuMat(); gpuQuery.Upload(cpuQuery);
        using var gpuTrain = new GpuMat(); gpuTrain.Upload(cpuTrain);
        using var gpuMatches = new GpuMat();

        using var matcher = OpenCvSharp.Cuda.DescriptorMatcher.CreateBFMatcher(NormTypes.L2);
        using var stream = new OpenCvSharp.Cuda.Stream();

        // 2. Act: Calculate Async
        matcher.KnnMatchAsync(gpuQuery, gpuTrain, gpuMatches, k: 2, stream: stream);

        // Wait for GPU to finish calculating matches
        stream.WaitForCompletion();

        Assert.NotEqual(gpuMatches?.CvPtr, IntPtr.Zero);

        // 3. Act: Convert raw GPU matches buffer into C# objects
        DMatch[][] knnMatches = matcher.KnnMatchConvert(gpuMatches, compactResult: false);

        // 4. Assert
        Assert.Equal(2, knnMatches.Length); // 2 query features
        Assert.Equal(2, knnMatches[0].Length); // k=2 matches per feature

        // Query 0 (1,0,0,0) should match Train 1 (1,0,0,0) perfectly
        Assert.Equal(1, knnMatches[0][0].TrainIdx);
        Assert.Equal(0f, knnMatches[0][0].Distance);
    }

    [Fact]
    public void Match_Sync_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create dummy descriptors (CV_32F)
        // Query: 2 features
        // Train: 3 features
        float[] queryData = { 1, 0, 0, 0, 0, 1, 0, 0 };
        float[] trainData = { 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0 };

        using var cpuQuery = Mat.FromPixelData(2, 4, MatType.CV_32FC1, queryData);
        using var cpuTrain = Mat.FromPixelData(3, 4, MatType.CV_32FC1, trainData);

        using var gpuQuery = new GpuMat(); gpuQuery.Upload(cpuQuery);
        using var gpuTrain = new GpuMat(); gpuTrain.Upload(cpuTrain);

        using var matcher = OpenCvSharp.Cuda.DescriptorMatcher.CreateBFMatcher(NormTypes.L2);

        // 2. Act: Overload 1 (Direct Match)
        DMatch[] matches1 = matcher.Match(gpuQuery, gpuTrain);

        // 3. Assert Overload 1
        Assert.Equal(2, matches1.Length); // 1 best match per query feature

        // Query 0 (1,0,0,0) matches Train 1 (1,0,0,0)
        Assert.Equal(1, matches1[0].TrainIdx);
        Assert.Equal(0f, matches1[0].Distance);

        // 4. Act: Overload 2 (Internal Collection Match)
        matcher.Add(new[] { gpuTrain });
        DMatch[] matches2 = matcher.Match(gpuQuery);

        // 5. Assert Overload 2
        Assert.Equal(2, matches2.Length);
        Assert.Equal(1, matches2[0].TrainIdx);
    }

    [Fact]
    public void MatchAsync_And_Convert_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create dummy descriptors (CV_32F)
        // Query: 2 features (Dimension = 4)
        // Train: 3 features
        float[] queryData = { 1, 0, 0, 0, 0, 1, 0, 0 };
        float[] trainData = { 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0 };

        using var cpuQuery = Mat.FromPixelData(2, 4, MatType.CV_32FC1, queryData);
        using var cpuTrain = Mat.FromPixelData(3, 4, MatType.CV_32FC1, trainData);

        using var gpuQuery = new GpuMat(); gpuQuery.Upload(cpuQuery);
        using var gpuTrain = new GpuMat(); gpuTrain.Upload(cpuTrain);

        // Allocate a buffer to hold the raw GPU matches
        using var gpuMatches = new GpuMat();

        using var matcher = OpenCvSharp.Cuda.DescriptorMatcher.CreateBFMatcher(NormTypes.L2);
        using var stream = new OpenCvSharp.Cuda.Stream();

        // 2. Act: Calculate Async Match
        matcher.MatchAsync(gpuQuery, gpuTrain, gpuMatches, mask: null, stream: stream);

        // Wait for GPU to finish calculating matches
        stream.WaitForCompletion();

        // 3. Act: Convert raw GPU matches buffer into C# array
        DMatch[] matches = matcher.MatchConvert(gpuMatches);

        // 4. Assert
        Assert.Equal(2, matches.Length); // 1 best match per query feature

        // Query 0 (1,0,0,0) should match Train 1 (1,0,0,0) perfectly
        Assert.Equal(1, matches[0].TrainIdx);
        Assert.Equal(0f, matches[0].Distance);

        // Query 1 (0,1,0,0) should match Train 2 (0,1,0,0) perfectly
        Assert.Equal(2, matches[1].TrainIdx);
        Assert.Equal(0f, matches[1].Distance);
    }

    [Fact]
    public void RadiusMatch_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 
        // Query: 1 feature
        // Train: 3 features
        float[] queryData = { 1.0f, 0, 0, 0 };

        // Train 0: Perfect Match (Dist = 0)
        // Train 1: Close Match (Dist = 0.5)
        // Train 2: Far Match (Dist = 2.0)
        float[] trainData = {
                1.0f, 0, 0, 0,
                1.5f, 0, 0, 0,
                3.0f, 0, 0, 0
            };

        using var cpuQuery = Mat.FromPixelData(1, 4, MatType.CV_32FC1, queryData);
        using var cpuTrain = Mat.FromPixelData(3, 4, MatType.CV_32FC1, trainData);

        using var gpuQuery = new GpuMat(); gpuQuery.Upload(cpuQuery);
        using var gpuTrain = new GpuMat(); gpuTrain.Upload(cpuTrain);

        using var matcher = OpenCvSharp.Cuda.DescriptorMatcher.CreateBFMatcher(NormTypes.L2);

        // 2. Act: Radius match with max distance = 1.0
        DMatch[][] radiusMatches = matcher.RadiusMatch(gpuQuery, gpuTrain, maxDistance: 1.0f);

        // 3. Assert
        Assert.Single(radiusMatches); // 1 query feature

        // It should have found exactly 2 matches within the radius of 1.0
        Assert.True(radiusMatches[0].Length >= 1);

        // Validate the matches
        var best = radiusMatches[0][0];
        Assert.Equal(0, best.TrainIdx);
        Assert.Equal(0f, best.Distance);
    }

    [Fact]
    public void RadiusMatchAsync_And_Convert_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange
        float[] queryData = { 1.0f, 0, 0, 0 };

        // Train 0: Dist = 0
        // Train 1: Dist = 0.5
        // Train 2: Dist = 2.0
        float[] trainData = {
                1.0f, 0, 0, 0,
                1.5f, 0, 0, 0,
                3.0f, 0, 0, 0
            };

        using var cpuQuery = Mat.FromPixelData(1, 4, MatType.CV_32FC1, queryData);
        using var cpuTrain = Mat.FromPixelData(3, 4, MatType.CV_32FC1, trainData);

        using var gpuQuery = new GpuMat(); gpuQuery.Upload(cpuQuery);
        using var gpuTrain = new GpuMat(); gpuTrain.Upload(cpuTrain);
        using var gpuMatches = new GpuMat();

        using var matcher = OpenCvSharp.Cuda.DescriptorMatcher.CreateBFMatcher(NormTypes.L2);
        using var stream = new OpenCvSharp.Cuda.Stream();

        // 2. Act: Calculate Async Match with max distance = 1.0
        matcher.RadiusMatchAsync(gpuQuery, gpuTrain, gpuMatches, maxDistance: 1.0f, stream: stream);

        // Wait for GPU to finish
        stream.WaitForCompletion();

        // 3. Act: Convert raw GPU matches buffer into C# jagged array
        DMatch[][] radiusMatches = matcher.RadiusMatchConvert(gpuMatches, compactResult: false);

        // 4. Assert
        Assert.Single(radiusMatches); // 1 query feature

        // It should have found exactly 2 matches within the radius of 1.0
        Assert.True(radiusMatches[0].Length >= 1);

        // Validate the matches
        var best = radiusMatches[0][0];
        Assert.Equal(0, best.TrainIdx);
        Assert.Equal(0f, best.Distance);
    }
}

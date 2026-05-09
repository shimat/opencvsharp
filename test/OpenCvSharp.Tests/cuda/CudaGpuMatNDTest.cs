using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class CudaGpuMatNDTest : CudaTestBase
{
    [Fact]
    public void GpuMatND_3D_Create_Test()
    {
        VerifyCudaSupport();

        // Arrange: 3D dimensions (Depth=5, Height=10, Width=10)
        int[] sizes = { 5, 10, 10 };

        // Act
        using var matNd = new GpuMatND(sizes, MatType.CV_32FC1);

        // Assert
        Assert.False(matNd.Empty());
    }

    [Fact]
    public void GpuMatND_Default_Create_Test()
    {
        VerifyCudaSupport(); ;

        // Arrange
        using var matNd = new GpuMatND();
        Assert.True(matNd.Empty());

        // Act
        int[] sizes = { 2, 2 };
        matNd.Create(sizes, MatType.CV_8UC1);

        // Assert
        Assert.False(matNd.Empty());
    }

    [Fact]
    public void GpuMatND_Clone_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a 3D GpuMatND
        int[] sizes = { 4, 4, 4 };
        using var original = new GpuMatND(sizes, MatType.CV_32FC1);
        Assert.False(original.Empty());

        // 2. Act: Clone
        using var cloned = original.Clone();

        // 3. Assert
        Assert.False(original.Empty());

    }

    [Fact]
    public void GpuMatND_CloneAsync_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange
        int[] sizes = { 10, 10 };
        using var original = new GpuMatND(sizes, MatType.CV_8UC1);
        using var stream = new OpenCvSharp.Cuda.Stream();

        // 2. Act
        using var cloned = original.Clone(stream);

        // 3. Wait for the copy to actually finish on the GPU
        stream.WaitForCompletion();

        // 4. Assert
        Assert.False(original.Empty());
    }

    [Fact]
    public void GpuMatND_SpecificIndex_Slice_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: 3D matrix (Dimension 0=5, Dimension 1=10, Dimension 2=20)
        // This is like a book with 5 pages, each page is 10x20.
        int[] sizes = { 5, 10, 20 };
        using var volume = new GpuMatND(sizes, MatType.CV_8UC1);

        // 2. Act: Extract the 3rd "page" (Index 2)
        // The 'indices' array satisfies the IndexArray requirement for the first (N-2) dimensions.
        int[] indices = { 2 };

        using var slice = volume.CreateGpuMatHeader(indices, Range.All, Range.All);

        // 3. Assert
        Assert.False(slice.Empty());
        Assert.Equal(10, slice.Rows); // Dim 1
        Assert.Equal(20, slice.Cols); // Dim 2


    }

    [Fact]
    public void GpuMatND_Download_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a 3D matrix (3 planes of 10x10)
        int[] sizes = { 3, 10, 10 };

        // Create it on the CPU first and fill it with 0 to ensure clean memory
        using var cpuInitial = new Mat(sizes, MatType.CV_8UC1, new Scalar(0));

        // Upload it to the GPU (We haven't explicitly added an upload from Mat to GpuMatND yet,
        // but we can just clear the planes using the header method we know works!)
        using var gpuVolume = new GpuMatND(sizes, MatType.CV_8UC1);

        // Fill the entire volume with 0 by clearing each plane
        for (int i = 0; i < sizes[0]; i++)
        {
            int[] clearIdx = { i };
            using var planeToClear = gpuVolume.CreateGpuMatHeader(clearIdx, Range.All, Range.All);
            planeToClear.SetTo(new Scalar(0));
        }

        // Get a 2D view of the middle plane (Index 1) and fill it with 255
        int[] indices = { 1 };
        using (var planeView = gpuVolume.CreateGpuMatHeader(indices, Range.All, Range.All))
        {
            planeView.SetTo(new Scalar(255));
        }

        // 2. Act: Download the entire 3D volume to a CPU Mat
        using var cpuVolume = new Mat();
        gpuVolume.Download(cpuVolume);

        // 3. Assert
        Assert.False(cpuVolume.Empty());
        Assert.Equal(3, cpuVolume.Dims); // Verify it's a 3D Mat
        Assert.Equal(3, cpuVolume.Size(0));
        Assert.Equal(10, cpuVolume.Size(1));
        Assert.Equal(10, cpuVolume.Size(2));

        // Verify content using standard Mat.At for N-Dimensions
        // In OpenCV, a 3D Mat uses an array of integers for indexing
        int[] idxPlane0 = { 0, 0, 0 }; // Plane 0, Row 0, Col 0
        int[] idxPlane1 = { 1, 0, 0 }; // Plane 1, Row 0, Col 0
        int[] idxPlane2 = { 2, 0, 0 }; // Plane 2, Row 0, Col 0

        // Plane 0 should be 0
        Assert.Equal(0, cpuVolume.At<byte>(idxPlane0));

        // Plane 1 should be 255
        Assert.Equal(255, cpuVolume.At<byte>(idxPlane1));

        // Plane 2 should be 0
        Assert.Equal(0, cpuVolume.At<byte>(idxPlane2));
    }

    [Fact]
    public void GpuMatND_Properties_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a 3D float matrix (4 bytes per pixel)
        int[] sizes = { 2, 2, 2 };
        using var mat = new GpuMatND(sizes, MatType.CV_32FC1);

        // 2. Assert
        Assert.Equal(4UL, mat.ElemSize);
        Assert.Equal(4UL, mat.ElemSize1);
        Assert.False(mat.External); // Created by OpenCV, not external memory
        Assert.True(mat.IsContinuous); // Newly created matrices are continuous
        Assert.False(mat.IsSubmatrix);
        Assert.NotEqual(IntPtr.Zero, mat.DevicePtr);

        // 3. Test Submatrix property
        int[] indices = { 0 };
        using var slice = mat.CreateGpuMatHeader(indices, Range.All, Range.All);
        // Since GpuMat doesn't expose IsSubmatrix easily, we check headers on the parent
    }

    [Fact]
    public void GpuMatND_Operator_Test()
    {
        VerifyCudaSupport();

        // 1. Test N-Dim Indexer (Sub-matrix / Shallow Copy)
        // Create 10x10x10 volume
        int[] sizes = { 10, 10, 10 };
        using var volume = new GpuMatND(sizes, MatType.CV_8UC1);

        // Extract a 5x5x5 sub-volume from the center
        using var subVolume = volume[new Range(2, 7), new Range(2, 7), new Range(2, 7)];
        Assert.False(subVolume.Empty());
        Assert.True(subVolume.IsSubmatrix);

        // 2. Test ToGpuMat (Extract 2D plane / Deep Copy)
        // Extract plane index 5, rows 0-10, cols 0-10
        int[] planeIdx = { 5 };
        using var deepCopyPlane = volume.ToGpuMat(planeIdx, Range.All, Range.All);

        Assert.False(deepCopyPlane.Empty());

        // 3. Test Explicit Cast (Effective 2D -> GpuMat)
        // Create a 1x10x10 GpuMatND (effectively a 2D image)
        int[] flatSizes = { 1, 10, 10 };
        using var effectively2D = new GpuMatND(flatSizes, MatType.CV_8UC1);

        using var casted = (GpuMat)effectively2D;
        Assert.Equal(10, casted.Rows);
        Assert.Equal(10, casted.Cols);
    }

    [Fact]
    public void GpuMatND_AssignFrom_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create two different matrices
        int[] sizesA = { 10, 10 };
        int[] sizesB = { 5, 5 };
        using var matA = new GpuMatND(sizesA, MatType.CV_8UC1);
        using var matB = new GpuMatND(sizesB, MatType.CV_8UC1);

        IntPtr originalDataA = matA.DevicePtr;
        IntPtr originalDataB = matB.DevicePtr;
        Assert.NotEqual(originalDataA, originalDataB);

        // 2. Act: Assign A to B
        // Now matB should point to matA's memory
        matB.AssignFrom(matA);

        // 3. Assert
        Assert.Equal(originalDataA, matB.DevicePtr);
        Assert.NotEqual(originalDataB, matB.DevicePtr);
    }

    [Fact]
    public void GpuMatND_UploadAndTotal_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a 3D CPU Mat (2x3x4)
        // Total elements = 24.
        int[] sizes = { 2, 3, 4 };
        using var cpuSrc = new Mat(sizes, MatType.CV_32FC1, new Scalar(1.0));

        using var gpuSrc = new GpuMatND();

        // 2. Act
        gpuSrc.Upload(cpuSrc);

        // 3. Assert
        Assert.Equal(24UL, gpuSrc.Total);
        // 24 elements * 4 bytes (float) = 96 bytes
        Assert.Equal(96UL, gpuSrc.TotalMemSize);
        Assert.Equal(MatType.CV_32FC1, gpuSrc.Type());

        // 4. Test Swap
        using var emptyGpu = new GpuMatND();
        gpuSrc.Swap(emptyGpu);

        Assert.True(gpuSrc.Empty());
        Assert.Equal(24UL, emptyGpu.Total);
    }

    [Fact]
    public void GpuMatND_2D_Metadata_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a 2D matrix (Rows: 100, Cols: 200)
        int[] inputSizes = { 100, 200 };
        using var mat = new GpuMatND(inputSizes, MatType.CV_8UC1);

        // 2. Act
        int[] actualSizes = mat.GetSize();
        ulong[] actualSteps = mat.GetStep();

        // 3. Assert Sizes
        Assert.Equal(2, actualSizes.Length);
        Assert.Equal(100, actualSizes[0]);
        Assert.Equal(200, actualSizes[1]);

        // 4. Assert Steps (Byte offsets)
        // For CV_8UC1 (1 byte per pixel):
        // Step[1] (Cols) is 1 byte
        // Step[0] (Rows) is 200 * 1 byte = 200 bytes
        Assert.Equal(2, actualSteps.Length);
        Assert.Equal((ulong)1, actualSteps[1]);
        Assert.Equal((ulong)200, actualSteps[0]);
    }

    [Fact]
    public void GpuMatND_3D_Metadata_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Create a 3D matrix (Planes: 5, Rows: 10, Cols: 20)
        // Use CV_32FC1 (4 bytes per pixel) to test multi-byte steps
        int[] inputSizes = { 5, 10, 20 };
        using var mat = new GpuMatND(inputSizes, MatType.CV_32FC1);

        // 2. Act
        int[] actualSizes = mat.GetSize();
        ulong[] actualSteps = mat.GetStep();

        // 3. Assert Sizes
        Assert.Equal(3, mat.Dims);
        Assert.Equal(inputSizes, actualSizes);

        // 4. Assert Steps (Byte offsets)
        // Last Dim (Cols): 4 bytes (Size of float)
        // Middle Dim (Rows): 20 (cols) * 4 bytes = 80 bytes
        // First Dim (Planes): 10 (rows) * 80 bytes = 800 bytes

        Assert.Equal(3, actualSteps.Length);
        Assert.Equal((ulong)4, actualSteps[2]);   // Column step
        Assert.Equal((ulong)80, actualSteps[1]);  // Row step
        Assert.Equal((ulong)800, actualSteps[0]); // Plane step
    }

    [Fact]
    public void GpuMatND_Empty_Metadata_Test()
    {
        VerifyCudaSupport();

        // 1. Arrange: Empty constructor
        using var mat = new GpuMatND();

        // 2. Act
        int[] sizes = mat.GetSize();
        //long[] steps = mat.GetStep();

        // 3. Assert: Should return empty arrays, not null
        Assert.NotNull(sizes);
        Assert.Empty(sizes);
        //Assert.NotNull(steps);
        //Assert.Empty(steps);
    }
}

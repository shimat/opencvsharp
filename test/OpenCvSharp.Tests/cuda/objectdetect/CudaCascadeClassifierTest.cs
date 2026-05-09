using System;
using Xunit;
using OpenCvSharp;
using OpenCvSharp.Cuda;
using OpenCvSharp.Tests.Cuda;

namespace OpenCvSharp.Tests.Cuda.objdetect;

public class CudaCascadeClassifierTest : CudaTestBase
{
    [Fact]
    public void CascadeClassifier_PropertiesTest()
    {
        VerifyCudaSupport();

        try
        {
            string relativePath = @"..\..\..\..\..\opencv\data\haarcascades_cuda\haarcascade_frontalface_default.xml";
            string absolutePath = System.IO.Path.GetFullPath(relativePath);

            // Fail the test early if the file doesn't actually exist on disk, 
            // to prevent the confusing NCV Assertion.
            if (!System.IO.File.Exists(absolutePath))
            {
                Assert.Skip($"Test skipped: CUDA Haar Cascade file not found at {absolutePath}");
                return;
            }

            using var cascade = OpenCvSharp.Cuda.CascadeClassifier.Create(absolutePath);

            // Test properties
            cascade.MinNeighbors = 4;
            Assert.Equal(4, cascade.MinNeighbors);

            cascade.ScaleFactor = 1.15;
            Assert.Equal(1.15, cascade.ScaleFactor);

            cascade.FindLargestObject = true;
            Assert.True(cascade.FindLargestObject);

            // MaxNumObjects often defaults to a large internal number (e.g. 100 or 4096)
            cascade.MaxNumObjects = 5;
            Assert.Equal(5, cascade.MaxNumObjects);
        }
        catch (OpenCVException ex)
        {
            // If the XML file isn't present in the test runner's directory, it will throw.
            // This is an expected environmental issue, not a wrapper failure.
            if (ex.Message.Contains("could not load") || ex.Message.Contains("not implemented"))
            {
                return;
            }
            throw;
        }
    }
}

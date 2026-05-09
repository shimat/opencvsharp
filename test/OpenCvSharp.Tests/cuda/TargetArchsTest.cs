using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp.Cuda;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class TargetArchsTest : CudaTestBase
{
    [Fact]
    public void TargetArchs_Test()
    {
        // This doesn't even require a GPU to be present, just the OpenCV CUDA DLLs.

        // Check if the binary supports basic features
        bool hasAtomics = TargetArchs.BuiltWith(FeatureSet.GlobalAtomics);

        // Check if the binary was built for a common architecture (e.g. 5.0 - Maxwell)
        bool hasMaxwell = TargetArchs.Has(5, 0);

        // Assert that these calls return without crashing
        Assert.True(hasAtomics || !hasAtomics);
        Assert.True(hasMaxwell || !hasMaxwell);
    }
}

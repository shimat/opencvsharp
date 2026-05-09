using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OpenCvSharp.Tests.Cuda.features2d;

public class CudaORBTest : CudaTestBase
{
    [Fact]
    public void ORB_PropertiesTest()
    {
        VerifyCudaSupport();

        using var orb = OpenCvSharp. Cuda.ORB.Create(nfeatures: 500, scaleFactor: 1.2f);

        // Initial
        Assert.Equal(500, orb.MaxFeatures);
        Assert.InRange(orb.ScaleFactor, 1.19, 1.21);

        // Modification
        orb.MaxFeatures = 1000;
        orb.NLevels = 4;
        orb.ScoreType = ORBScoreType.Fast;
        orb.BlurForDescriptor = true;

        Assert.Equal(1000, orb.MaxFeatures);
        Assert.Equal(4, orb.NLevels);
        Assert.Equal(ORBScoreType.Fast, orb.ScoreType);
        Assert.True(orb.BlurForDescriptor);
    }
}

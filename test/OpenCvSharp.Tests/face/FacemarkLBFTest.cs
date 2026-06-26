using OpenCvSharp.Face;
using Xunit;

namespace OpenCvSharp.Tests.Face;

// ReSharper disable once InconsistentNaming
public class FacemarkLBFTest : TestBase
{
    [Fact]
    public void CreateAndDispose()
    {
        using (var facemark = FacemarkLBF.Create())
        {
            GC.KeepAlive(facemark);
        }
    }

    [Fact]
    public void CreateAndDisposeWithParameter()
    {
        var parameter = new FacemarkLBF.Params();
        using (var facemark = FacemarkLBF.Create(parameter))
        {
            GC.KeepAlive(facemark);
        }
    }
        
    [Fact]
    public void ParameterDefaultsFromNative()
    {
        // Verifies the managed Params pulls the real OpenCV defaults through the
        // native getAll bridge (a wrong struct layout would surface as garbage here).
        var parameter = new FacemarkLBF.Params();
        Assert.Equal(68, parameter.NLandmarks);
        Assert.Equal(5, parameter.StagesN);
        Assert.Equal(6, parameter.TreeN);
        Assert.Equal(5, parameter.TreeDepth);
        Assert.True(parameter.Verbose);
        Assert.True(parameter.SaveModel);
        Assert.Equal(0.4, parameter.BaggingOverlap, 6);
        Assert.NotEmpty(parameter.FeatsM);
        Assert.NotEmpty(parameter.RadiusM);
        Assert.Equal([36, 37, 38, 39, 40, 41], parameter.Pupils0);
        Assert.Equal([42, 43, 44, 45, 46, 47], parameter.Pupils1);
    }

    [Fact]
    public void ParameterBaggingOverlap()
    {
        const double value = 3.14;

        var parameter = new FacemarkLBF.Params();
        {
            parameter.BaggingOverlap = value;
            Assert.Equal(value, parameter.BaggingOverlap);
        }
    }

    [Fact]
    public void ParameterCascadeFace()
    {
        const string value = "foo";

        var parameter = new FacemarkLBF.Params();
        {
            parameter.CascadeFace = value;
            Assert.Equal(value, parameter.CascadeFace);
        }
    }

    [Fact]
    // ReSharper disable once InconsistentNaming
    public void ParameterDetectROI()
    {
        var value = new Rect(1, 2, 3, 4);

        var parameter = new FacemarkLBF.Params();
        {
            parameter.DetectROI = value;
            Assert.Equal(value, parameter.DetectROI);
        }
    }

    [Fact]
    public void ParameterFeatsM()
    {
        int[] value = [9, 8, 7, 6, 5];

        var parameter = new FacemarkLBF.Params();
        {
            parameter.FeatsM = value;
            Assert.Equal(value, parameter.FeatsM);
        }
    }

    [Fact]
    public void ParameterInitShapeN()
    {
        const int value = 12345;

        var parameter = new FacemarkLBF.Params();
        {
            parameter.InitShapeN = value;
            Assert.Equal(value, parameter.InitShapeN);
        }
    }

    [Fact]
    public void ParameterModelFilename()
    {
        const string value = "foo";

        var parameter = new FacemarkLBF.Params();
        {
            parameter.ModelFilename = value;
            Assert.Equal(value, parameter.ModelFilename);
        }
    }

    [Fact]
    public void ParameterNLandmarks()
    {
        const int value = 12345;

        var parameter = new FacemarkLBF.Params();
        {
            parameter.NLandmarks = value;
            Assert.Equal(value, parameter.NLandmarks);
        }
    }

    [Fact]
    public void ParameterPupils0()
    {
        int[] value = [9, 8, 7, 6, 5];

        var parameter = new FacemarkLBF.Params();
        {
            parameter.Pupils0 = value;
            Assert.Equal(value, parameter.Pupils0);
        }
    }

    [Fact]
    public void ParameterPupils1()
    {
        int[] value = [9, 8, 7, 6, 5];

        var parameter = new FacemarkLBF.Params();
        {
            parameter.Pupils1 = value;
            Assert.Equal(value, parameter.Pupils1);
        }
    }

    [Fact]
    public void ParameterRadiusM()
    {
        double[] value = [1, 2, 3];

        var parameter = new FacemarkLBF.Params();
        {
            parameter.RadiusM = value;
            Assert.Equal(value, parameter.RadiusM);
        }
    }

    [Fact]
    public void ParameterSaveModel()
    {
        var parameter = new FacemarkLBF.Params();
        {
            parameter.SaveModel = true;
            Assert.True(parameter.SaveModel);
            parameter.SaveModel = false;
            Assert.False(parameter.SaveModel);
        }
    }

    [Fact]
    public void ParameterSeed()
    {
        const uint value = uint.MaxValue;

        var parameter = new FacemarkLBF.Params();
        {
            parameter.Seed = value;
            Assert.Equal(value, parameter.Seed);
        }
    }

    [Fact]
    public void ParameterShapeOffset()
    {
        const double value = 3.14;

        var parameter = new FacemarkLBF.Params();
        {
            parameter.ShapeOffset = value;
            Assert.Equal(value, parameter.ShapeOffset);
        }
    }

    [Fact]
    public void ParameterStagesN()
    {
        const int value = 12345;

        var parameter = new FacemarkLBF.Params();
        {
            parameter.StagesN = value;
            Assert.Equal(value, parameter.StagesN);
        }
    }

    [Fact]
    public void ParameterTreeDepth()
    {
        const int value = 12345;

        var parameter = new FacemarkLBF.Params();
        {
            parameter.TreeDepth = value;
            Assert.Equal(value, parameter.TreeDepth);
        }
    }

    [Fact]
    public void ParameterTreeN()
    {
        const int value = 12345;

        var parameter = new FacemarkLBF.Params();
        {
            parameter.TreeN = value;
            Assert.Equal(value, parameter.TreeN);
        }
    }

    [Fact]
    public void ParameterVerbose()
    {
        var parameter = new FacemarkLBF.Params();
        {
            parameter.Verbose = true;
            Assert.True(parameter.Verbose);
            parameter.Verbose = false;
            Assert.False(parameter.Verbose);
        }
    }
}

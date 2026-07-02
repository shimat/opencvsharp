using OpenCvSharp.Face;
using Xunit;

namespace OpenCvSharp.Tests.Face;

// ReSharper disable once InconsistentNaming
public class FacemarkAAMTest : TestBase
{
    //private const string CascadeFile = "_data/text/haarcascade_frontalface_default.xml";

    [Fact]
    public void CreateAndDispose()
    {
        using (var facemark = FacemarkAAM.Create())
        {
            GC.KeepAlive(facemark);
        }
    }

    [Fact]
    public void CreateAndDisposeWithParameter()
    {
        var parameter = new FacemarkAAM.Params();
        using (var facemark = FacemarkAAM.Create(parameter))
        {
            GC.KeepAlive(facemark);
        }
    }

    [Fact]
    public void ParameterDefaultsFromNative()
    {
        // Verifies the managed Params pulls the real OpenCV defaults through the
        // native getAll bridge (a wrong struct layout would surface as garbage here).
        var parameter = new FacemarkAAM.Params();
        Assert.True(parameter.M > 0);
        Assert.True(parameter.N > 0);
        Assert.True(parameter.NIter > 0);
        Assert.True(parameter.MaxM > 0);
        Assert.True(parameter.MaxN > 0);
        Assert.True(parameter.TextureMaxM > 0);
        Assert.True(parameter.Verbose);
        Assert.True(parameter.SaveModel);
        Assert.NotEmpty(parameter.Scales);
    }

    /*
    /// <summary>
    /// https://docs.opencv.org/trunk/d5/dd8/tutorial_facemark_aam.html
    /// </summary>
    [Fact]
    public void GetFaces()
    {
        var parameter = new FacemarkAAM.Params();
        {
            parameter.ModelFilename = CascadeFile;
            parameter.Scales = new float[] {2, 4};

            using (var facemark = FacemarkAAM.Create(parameter))
            using (var img = LoadImage("lenna.png"))
            {
                bool ret = facemark.GetFaces(img, out var faces);
                Assert.True(ret);
                Assert.NotEmpty(faces);

                if (Debugger.IsAttached)
                {
                    foreach (var face in faces)
                    {
                        img.Rectangle(face, Scalar.Red, 2);
                    }
                    Window.ShowImages(img);
                }
            }
        }
    }*/

    [Fact]
    public void ParameterModelFilename()
    {
        const string value = "foo";

        var parameter = new FacemarkAAM.Params();
        {
            parameter.ModelFilename = value;
            Assert.Equal(value, parameter.ModelFilename);
        }
    }

    [Fact]
    public void ParameterM()
    {
        const int value = 12345;

        var parameter = new FacemarkAAM.Params();
        {
            parameter.M = value;
            Assert.Equal(value, parameter.M);
        }
    }

    [Fact]
    public void ParameterN()
    {
        const int value = 12345;

        var parameter = new FacemarkAAM.Params();
        {
            parameter.N = value;
            Assert.Equal(value, parameter.N);
        }
    }

    [Fact]
    public void ParameterNIter()
    {
        const int value = 12345;

        var parameter = new FacemarkAAM.Params();
        {
            parameter.NIter = value;
            Assert.Equal(value, parameter.NIter);
        }
    }

    [Fact]
    public void ParameterScales()
    {
        float[] value = [1, 2, 3];

        var parameter = new FacemarkAAM.Params();
        {
            parameter.Scales = value;
            Assert.Equal(value, parameter.Scales);
        }
    }

    [Fact]
    public void ParameterSaveModel()
    {
        var parameter = new FacemarkAAM.Params();
        {
            parameter.SaveModel = true;
            Assert.True(parameter.SaveModel);
            parameter.SaveModel = false;
            Assert.False(parameter.SaveModel);
        }
    }

    [Fact]
    public void ParameterVerbose()
    {
        var parameter = new FacemarkAAM.Params();
        {
            parameter.Verbose = true;
            Assert.True(parameter.Verbose);
            parameter.Verbose = false;
            Assert.False(parameter.Verbose);
        }
    }
}

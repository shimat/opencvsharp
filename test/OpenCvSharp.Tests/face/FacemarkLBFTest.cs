using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenCvSharp.Face;
using Xunit;

namespace OpenCvSharp.Tests.Face
{
    // ReSharper disable once InconsistentNaming

    public class FacemarkLBFTest : TestBase
    {
        private const string CascadeFile = "_data/text/haarcascade_frontalface_default.xml";

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
            using (var parameter = new FacemarkLBF.Params())
            using (var facemark = FacemarkLBF.Create(parameter))
            {
                GC.KeepAlive(facemark);
            }
        }

        /*
        [Fact]
        public void GetFaces()
        {
            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.CascadeFace = CascadeFile;

                using (var facemark = FacemarkLBF.Create(parameter))
                using (var img = Image("lenna.png"))
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
        }
        */

        [Fact]
        public void ParameterBaggingOverlap()
        {
            const double value = 3.14;

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.BaggingOverlap = value;
                Assert.Equal(value, parameter.BaggingOverlap);
            }
        }

        [Fact]
        public void ParameterCascadeFace()
        {
            const string value = "foo";

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.CascadeFace = value;
                Assert.Equal(value, parameter.CascadeFace);
            }
        }

        [Fact]
        public void ParameterDetectROI()
        {
            var value = new Rect(1, 2, 3, 4);

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.DetectROI = value;
                Assert.Equal(value, parameter.DetectROI);
            }
        }

        [Fact]
        public void ParameterFeatsM()
        {
            int[] value = {9, 8, 7, 6, 5};

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.FeatsM = value;
                Assert.Equal(value, parameter.FeatsM);
            }
        }

        [Fact]
        public void ParameterInitShapeN()
        {
            const int value = 12345;

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.InitShapeN = value;
                Assert.Equal(value, parameter.InitShapeN);
            }
        }

        [Fact]
        public void ParameterModelFilename()
        {
            const string value = "foo";

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.ModelFilename = value;
                Assert.Equal(value, parameter.ModelFilename);
            }
        }

        [Fact]
        public void ParameterNLandmarks()
        {
            const int value = 12345;

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.NLandmarks = value;
                Assert.Equal(value, parameter.NLandmarks);
            }
        }

        [Fact]
        public void ParameterPupils0()
        {
            int[] value = { 9, 8, 7, 6, 5 };

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.Pupils0 = value;
                Assert.Equal(value, parameter.Pupils0);
            }
        }

        [Fact]
        public void ParameterPupils1()
        {
            int[] value = { 9, 8, 7, 6, 5 };

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.Pupils1 = value;
                Assert.Equal(value, parameter.Pupils1);
            }
        }

        [Fact]
        public void ParameterRadiusM()
        {
            double[] value = { 1, 2, 3 };

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.RadiusM = value;
                Assert.Equal(value, parameter.RadiusM);
            }
        }

        [Fact]
        public void ParameterSaveModel()
        {
            using (var parameter = new FacemarkLBF.Params())
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
            const uint value = UInt32.MaxValue;

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.Seed = value;
                Assert.Equal(value, parameter.Seed);
            }
        }

        [Fact]
        public void ParameterShapeOffset()
        {
            const double value = 3.14;

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.ShapeOffset = value;
                Assert.Equal(value, parameter.ShapeOffset);
            }
        }

        [Fact]
        public void ParameterStagesN()
        {
            const int value = 12345;

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.StagesN = value;
                Assert.Equal(value, parameter.StagesN);
            }
        }

        [Fact]
        public void ParameterTreeDepth()
        {
            const int value = 12345;

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.TreeDepth = value;
                Assert.Equal(value, parameter.TreeDepth);
            }
        }

        [Fact]
        public void ParameterTreeN()
        {
            const int value = 12345;

            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.TreeN = value;
                Assert.Equal(value, parameter.TreeN);
            }
        }

        [Fact]
        public void ParameterVerbose()
        {
            using (var parameter = new FacemarkLBF.Params())
            {
                parameter.Verbose = true;
                Assert.True(parameter.Verbose);
                parameter.Verbose = false;
                Assert.False(parameter.Verbose);
            }
        }
    }
}

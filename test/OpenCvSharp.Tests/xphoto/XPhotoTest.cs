using System;
using System.Diagnostics;
using System.Threading;
using OpenCvSharp.XPhoto;
using Xunit;
using Xunit.Sdk;

namespace OpenCvSharp.Tests.XPhoto
{
    // ReSharper disable InconsistentNaming

    public class XPhotoTest : TestBase
    {
        [Fact]
        public void ApplyChannelGains()
        {
            using (var src = Image("lenna.png"))
            using (var b = new Mat(src.Rows, src.Cols, src.Type()))
            using (var g = new Mat(src.Rows, src.Cols, src.Type()))
            using (var r = new Mat(src.Rows, src.Cols, src.Type()))
            {
                CvXPhoto.ApplyChannelGains(src, b, 2, 1, 1);
                CvXPhoto.ApplyChannelGains(src, g, 1, 2, 1);
                CvXPhoto.ApplyChannelGains(src, r, 1, 1, 2);

                if (Debugger.IsAttached)
                {
                    using (var combined = new Mat(src.Rows * 2, src.Cols * 2, src.Type()))
                    using (var roi1 = new Mat(combined, new Rect(0, 0, src.Cols, src.Rows)))
                    using (var roi2 = new Mat(combined, new Rect(src.Cols, 0, src.Cols, src.Rows)))
                    using (var roi3 = new Mat(combined, new Rect(0, src.Rows, src.Cols, src.Rows)))
                    using (var roi4 = new Mat(combined, new Rect(src.Cols, src.Rows, src.Cols, src.Rows)))
                    {
                        src.CopyTo(roi1);
                        b.CopyTo(roi2);
                        g.CopyTo(roi3);
                        r.CopyTo(roi4);
                        Window.ShowImages(combined);
                    }
                }
            }
        }

        [Fact]
        public void GrayworldWBBalanceWhite()
        {
            using (var wb = CvXPhoto.CreateGrayworldWB())
            using (var src = Image("lenna.png"))
            using (var dst = new Mat(src.Rows, src.Cols, src.Type()))
            {
                wb.BalanceWhite(src, dst);

                if (Debugger.IsAttached)
                {
                    using (var combined = new Mat(src.Rows, src.Cols * 2, src.Type()))
                    using (var roi1 = new Mat(combined, new Rect(0, 0, src.Cols, src.Rows)))
                    using (var roi2 = new Mat(combined, new Rect(src.Cols, 0, src.Cols, src.Rows)))
                    {
                        src.CopyTo(roi1);
                        dst.CopyTo(roi2);
                        Window.ShowImages(combined);
                    }
                }
            }
        }

        [Fact]
        public void GrayworldWBProperties()
        {
            using (var wb = CvXPhoto.CreateGrayworldWB())
            {
                var saturationThreshold = wb.SaturationThreshold;

                const float val = 100f;
                wb.SaturationThreshold = val;

                Assert.Equal(val, wb.SaturationThreshold);
                Assert.NotEqual(saturationThreshold, wb.SaturationThreshold);
            }
        }

        [Fact]
        public void Inpaint()
        {
            using (var src = Image("building.jpg"))
            using (var mask = Image("building_mask.bmp", ImreadModes.Grayscale))
            using (var dst = new Mat(src.Size(), src.Type()))
            {
                CvXPhoto.Inpaint(src, mask, dst, InpaintTypes.SHIFTMAP);
                ShowImagesWhenDebugMode(src);
                ShowImagesWhenDebugMode(dst);
            }
        }

        [Fact]
        public void LearningBasedWBBalanceWhite()
        {
            using (var wb = CvXPhoto.CreateLearningBasedWB(null))
            using (var src = Image("lenna.png"))
            using (var dst = new Mat(src.Rows, src.Cols, src.Type()))
            {
                wb.BalanceWhite(src, dst);

                if (Debugger.IsAttached)
                {
                    using (var combined = new Mat(src.Rows, src.Cols * 2, src.Type()))
                    using (var roi1 = new Mat(combined, new Rect(0, 0, src.Cols, src.Rows)))
                    using (var roi2 = new Mat(combined, new Rect(src.Cols, 0, src.Cols, src.Rows)))
                    {
                        src.CopyTo(roi1);
                        dst.CopyTo(roi2);
                        Window.ShowImages(combined);
                    }
                }
            }
        }

        [Fact]
        public void LearningBasedWBExtractSimpleFeatures()
        {
            using (var wb = LearningBasedWB.Create(null))
            using (var src = Image("lenna.png"))
            using (var dst = new Mat())
            {
                wb.ExtractSimpleFeatures(src, dst);

                unsafe
                {
                    // 1. Chromaticity of an average (R,G,B) tuple
                    // 2. Chromaticity of the brightest (R,G,B) tuple (while ignoring saturated pixels)
                    // 3. Chromaticity of the dominant (R,G,B) tuple (the one that has the highest value
                    //    in the RGB histogram)
                    // 4. Mode of the chromaticity palette, that is constructed by taking 300 most common
                    //    colors according to the RGB histogram and projecting them on the chromaticity plane.
                    //    Mode is the most high-density point of the palette, which is computed by a straightforward 
                    //    fixed-bandwidth kernel density estimator with a Epanechnikov kernel function.
                    Console.WriteLine(dst.DataPointer[0]);
                    Console.WriteLine(dst.DataPointer[1]);
                    Console.WriteLine(dst.DataPointer[2]);
                    Console.WriteLine(dst.DataPointer[3]);
                }
            }
        }

        [Fact]
        public void LearningBasedWBBalanceWhiteWithModel()
        {
            // About model file
            // http://docs.opencv.org/trunk/dc/dcb/tutorial_xphoto_training_white_balance.html
            using (var wb = CvXPhoto.CreateLearningBasedWB(""))
            using (var src = Image("lenna.png"))
            using (var dst = new Mat(src.Rows, src.Cols, src.Type()))
            {
                wb.BalanceWhite(src, dst);

                if (Debugger.IsAttached)
                {
                    using (var combined = new Mat(src.Rows, src.Cols * 2, src.Type()))
                    using (var roi1 = new Mat(combined, new Rect(0, 0, src.Cols, src.Rows)))
                    using (var roi2 = new Mat(combined, new Rect(src.Cols, 0, src.Cols, src.Rows)))
                    {
                        src.CopyTo(roi1);
                        dst.CopyTo(roi2);
                        Window.ShowImages(combined);
                    }
                }
            }
        }

        [Fact]
        public void LearningBasedWBProperties()
        {
            using (var wb = LearningBasedWB.Create(null))
            {
                var histBinNum = wb.HistBinNum;
                var rangeMaxVal = wb.RangeMaxVal;
                var saturationThreshold = wb.SaturationThreshold;

                const int ival = 100;
                const float fval = 100f;
                wb.HistBinNum = ival;
                wb.RangeMaxVal = ival;
                wb.SaturationThreshold = fval;

                Assert.Equal(ival, wb.HistBinNum);
                Assert.Equal(ival, wb.RangeMaxVal);
                Assert.Equal(fval, wb.SaturationThreshold);

                Assert.NotEqual(histBinNum, wb.HistBinNum);
                Assert.NotEqual(rangeMaxVal, wb.RangeMaxVal);
                Assert.NotEqual(saturationThreshold, wb.SaturationThreshold);
            }
        }

        [Fact]
        public void SimpleWBBalanceWhite()
        {
            using (var wb = CvXPhoto.CreateSimpleWB())
            using (var src = Image("lenna.png"))
            using (var dst = new Mat(src.Rows, src.Cols, src.Type()))
            {
                wb.BalanceWhite(src, dst);

                if (Debugger.IsAttached)
                {
                    using (var combined = new Mat(src.Rows, src.Cols * 2, src.Type()))
                    using (var roi1 = new Mat(combined, new Rect(0, 0, src.Cols, src.Rows)))
                    using (var roi2 = new Mat(combined, new Rect(src.Cols, 0, src.Cols, src.Rows)))
                    {
                        src.CopyTo(roi1);
                        dst.CopyTo(roi2);
                        Window.ShowImages(combined);
                    }
                }
            }
        }

        [Fact]
        public void SimpleWBProperties()
        {
            using (var wb = SimpleWB.Create())
            {
                var inputMax = wb.InputMax;
                var inputMin = wb.InputMin;
                var outputMax = wb.OutputMax;
                var outputMin = wb.OutputMin;
                var p = wb.P;

                const float val = 100f;
                wb.InputMax = val;
                wb.InputMin = val;
                wb.OutputMax = val;
                wb.OutputMin = val;
                wb.P = val;

                Assert.Equal(val, wb.InputMax);
                Assert.Equal(val, wb.InputMin);
                Assert.Equal(val, wb.OutputMax);
                Assert.Equal(val, wb.OutputMin);
                Assert.Equal(val, wb.P);

                Assert.NotEqual(inputMax, wb.InputMax);
                Assert.NotEqual(inputMin, wb.InputMin);
                Assert.NotEqual(outputMax, wb.OutputMax);
                Assert.NotEqual(outputMin, wb.OutputMin);
                Assert.NotEqual(p, wb.P);
            }
        }

        [Fact]
        public void DctDenoising()
        {
            using (var src = Image("lenna.png"))
            using (var dst = new Mat())
            {
                CvXPhoto.DctDenoising(src, dst, 1);

                if (Debugger.IsAttached)
                {
                    Window.ShowImages(src, dst);
                }
            }
        }

        [Fact]
        public void Bm3dDenoising()
        {
            using (var src = Image("lenna.png", ImreadModes.Grayscale))
            using (var dst = new Mat())
            {
                CvXPhoto.Bm3dDenoising(src, dst);

                if (Debugger.IsAttached)
                {
                    Window.ShowImages(src, dst);
                }
            }
        }
#if net46
        [ExplicitStaFact]
        public void Sample()
        {
            if (!Debugger.IsAttached)
                return;

            string[] files;
            using (var dialog = new System.Windows.Forms.OpenFileDialog
            {
                RestoreDirectory = true,
                Multiselect = true,
                Filter = "Image Files(*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"
            })
            {
                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                files = dialog.FileNames;
            }

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var dstDir = System.IO.Path.Combine(desktop, "WB");
            System.IO.Directory.CreateDirectory(dstDir);

            using (var simpleWB = SimpleWB.Create())
            using (var learningWB = LearningBasedWB.Create(""))
            using (var grayworldWB = GrayworldWB.Create())
            {
                foreach (var file in files)
                {
                    Console.WriteLine(System.IO.Path.GetFileNameWithoutExtension(file));

                    using (var src = new Mat(file))
                    using (var dstSimple = new Mat())
                    using (var dstLearning = new Mat())
                    using (var dstGrayworld = new Mat())
                    {
                        simpleWB.BalanceWhite(src, dstSimple);
                        learningWB.BalanceWhite(src, dstLearning);
                        grayworldWB.BalanceWhite(src, dstGrayworld);

                        using (var temp1 = new Mat())
                        using (var temp2 = new Mat())
                        using (var dst = new Mat())
                        {
                            Cv2.HConcat(src, dstSimple, temp1);
                            Cv2.HConcat(dstLearning, dstGrayworld, temp2);
                            Cv2.VConcat(temp1, temp2, dst);

                            /*
                            using (new Window("src", src))
                            using (new Window("dst", dst))
                            {
                                Cv2.WaitKey();
                            }*/
                            dst.SaveImage(System.IO.Path.Combine(dstDir, $"{System.IO.Path.GetFileNameWithoutExtension(file)}.png"));
                        }
                    }
                }
            }
        }
#endif
    }
}

using System;
using NUnit.Framework;
using OpenCvSharp.XPhoto;

namespace OpenCvSharp.Tests.XPhoto
{
    // ReSharper disable once InconsistentNaming

    [TestFixture]
    public class XPhotoTest : TestBase
    {

        [Test]
        public void ApplyChannelGains()
        {
            var wb = Cv2.CreateGrayworldWB();
            using (var src = Image("lenna.png"))
            using (var b = new Mat(src.Rows, src.Cols, src.Type()))
            using (var g = new Mat(src.Rows, src.Cols, src.Type()))
            using (var r = new Mat(src.Rows, src.Cols, src.Type()))
            {
                Cv2.ApplyChannelGains(src, b, 2, 1, 1);
                Cv2.ApplyChannelGains(src, g, 1, 2, 1);
                Cv2.ApplyChannelGains(src, r, 1, 1, 2);

                //using (var combined = new Mat(src.Rows * 2, src.Cols * 2, src.Type()))
                //using (var roi1 = new Mat(combined, new Rect(0, 0, src.Cols, src.Rows)))
                //using (var roi2 = new Mat(combined, new Rect(src.Cols, 0, src.Cols, src.Rows)))
                //using (var roi3 = new Mat(combined, new Rect(0, src.Rows, src.Cols, src.Rows)))
                //using (var roi4 = new Mat(combined, new Rect(src.Cols, src.Rows, src.Cols, src.Rows)))
                //{
                //    src.CopyTo(roi1);
                //    b.CopyTo(roi2);
                //    g.CopyTo(roi3);
                //    r.CopyTo(roi4);
                //    Window.ShowImages(combined);
                //}
            }
            wb.Dispose();
        }

        [Test]
        public void GrayworldWBBalanceWhite()
        {
            var wb = Cv2.CreateGrayworldWB();
            using (var src = Image("lenna.png"))
            using (var dst = new Mat(src.Rows, src.Cols, src.Type()))
            {
                wb.BalanceWhite(src, dst);

                //using (var combined = new Mat(src.Rows, src.Cols * 2, src.Type()))
                //using (var roi1 = new Mat(combined, new Rect(0, 0, src.Cols, src.Rows)))
                //using (var roi2 = new Mat(combined, new Rect(src.Cols, 0, src.Cols, src.Rows)))
                //{
                //    src.CopyTo(roi1);
                //    dst.CopyTo(roi2);
                //    Window.ShowImages(combined);
                //}
            }
            wb.Dispose();
        }

        [Test]
        public void GrayworldWBProperties()
        {
            var wb = Cv2.CreateGrayworldWB();

            var saturationThreshold = wb.SaturationThreshold;

            const float val = 100f;
            wb.SaturationThreshold = val;

            Assert.AreEqual(val, wb.SaturationThreshold);

            Assert.AreNotEqual(saturationThreshold, wb.SaturationThreshold);

            wb.Dispose();
        }

        [Test]
        public void Inpaint()
        {
            using (var src = Image("building.jpg"))
            using (var mask = Image("building_mask.bmp", ImreadModes.GrayScale))
            using (var dst = new Mat(src.Size(), src.Type()))
            {
                Cv2.Inpaint(src, mask, dst, InpaintTypes.ShiftMap);
                //Window.ShowImages(src);
                //Window.ShowImages(dst);
            }
        }

        [Test]
        public void LearningBasedWBBalanceWhite()
        {
            var wb = Cv2.CreateLearningBasedWB(null);
            using (var src = Image("lenna.png"))
            using (var dst = new Mat(src.Rows, src.Cols, src.Type()))
            {
                wb.BalanceWhite(src, dst);

                //using (var combined = new Mat(src.Rows, src.Cols * 2, src.Type()))
                //using (var roi1 = new Mat(combined, new Rect(0, 0, src.Cols, src.Rows)))
                //using (var roi2 = new Mat(combined, new Rect(src.Cols, 0, src.Cols, src.Rows)))
                //{
                //    src.CopyTo(roi1);
                //    dst.CopyTo(roi2);
                //    Window.ShowImages(combined);
                //}
            }
            wb.Dispose();
        }

        [Test]
        public void LearningBasedWBExtractSimpleFeatures()
        {
            var wb = Cv2.CreateLearningBasedWB(null);
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
            wb.Dispose();
        }

        [Test]
        public void LearningBasedWBBalanceWhiteWithModel()
        {
            // About model file
            // http://docs.opencv.org/trunk/dc/dcb/tutorial_xphoto_training_white_balance.html
            var wb = Cv2.CreateLearningBasedWB("");
            using (var src = Image("lenna.png"))
            using (var dst = new Mat(src.Rows, src.Cols, src.Type()))
            {
                wb.BalanceWhite(src, dst);

                //using (var combined = new Mat(src.Rows, src.Cols * 2, src.Type()))
                //using (var roi1 = new Mat(combined, new Rect(0, 0, src.Cols, src.Rows)))
                //using (var roi2 = new Mat(combined, new Rect(src.Cols, 0, src.Cols, src.Rows)))
                //{
                //    src.CopyTo(roi1);
                //    dst.CopyTo(roi2);
                //    Window.ShowImages(combined);
                //}
            }
            wb.Dispose();
        }

        [Test]
        public void LearningBasedWBProperties()
        {
            var wb = Cv2.CreateLearningBasedWB(null);

            var histBinNum = wb.HistBinNum;
            var rangeMaxVal = wb.RangeMaxVal;
            var saturationThreshold = wb.SaturationThreshold;

            const int ival = 100;
            const float fval = 100f;
            wb.HistBinNum = ival;
            wb.RangeMaxVal = ival;
            wb.SaturationThreshold = fval;

            Assert.AreEqual(ival, wb.HistBinNum);
            Assert.AreEqual(ival, wb.RangeMaxVal);
            Assert.AreEqual(fval, wb.SaturationThreshold);

            Assert.AreNotEqual(histBinNum, wb.HistBinNum);
            Assert.AreNotEqual(rangeMaxVal, wb.RangeMaxVal);
            Assert.AreNotEqual(saturationThreshold, wb.SaturationThreshold);

            wb.Dispose();
        }

        [Test]
        public void SimpleWBBalanceWhite()
        {
            var wb = Cv2.CreateSimpleWB();
            using (var src = Image("lenna.png"))
            using (var dst = new Mat(src.Rows, src.Cols, src.Type()))
            {
                wb.BalanceWhite(src, dst);

                //using (var combined = new Mat(src.Rows, src.Cols * 2, src.Type()))
                //using (var roi1 = new Mat(combined, new Rect(0, 0, src.Cols, src.Rows)))
                //using (var roi2 = new Mat(combined, new Rect(src.Cols, 0, src.Cols, src.Rows)))
                //{
                //    src.CopyTo(roi1);
                //    dst.CopyTo(roi2);
                //    Window.ShowImages(combined);
                //}
            }
            wb.Dispose();
        }

        [Test]
        public void SimpleWBProperties()
        {
            var wb = Cv2.CreateSimpleWB();

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

            Assert.AreEqual(val, wb.InputMax);
            Assert.AreEqual(val, wb.InputMin);
            Assert.AreEqual(val, wb.OutputMax);
            Assert.AreEqual(val, wb.OutputMin);
            Assert.AreEqual(val, wb.P);

            Assert.AreNotEqual(inputMax, wb.InputMax);
            Assert.AreNotEqual(inputMin, wb.InputMin);
            Assert.AreNotEqual(outputMax, wb.OutputMax);
            Assert.AreNotEqual(outputMin, wb.OutputMin);
            Assert.AreNotEqual(p, wb.P);

            wb.Dispose();
        }

    }
}

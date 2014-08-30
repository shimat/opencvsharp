using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// Draws image histogram
    /// </summary>
    /// <remarks>
    /// http://opencv.jp/sample/histogram.html#hist
    /// </remarks>
    class Histogram
    {        
        public Histogram()
        {
            // cvCalcHist

            const int histSize = 64;
            float[] range0 = { 0, 256 };
            float[][] ranges = { range0 };

            using (IplImage srcImg = new IplImage(FilePath.Image.Lenna, LoadMode.GrayScale))
            using (IplImage dstImg = srcImg.Clone())
            using (IplImage histImg = new IplImage(new CvSize(400, 400), BitDepth.U8, 1))
            using (CvHistogram hist = new CvHistogram(new int[] { histSize }, HistogramFormat.Array, ranges, true))
            {
                using (CvWindow windowImage = new CvWindow("image", WindowMode.AutoSize))
                using (CvWindow windowHist = new CvWindow("histogram", WindowMode.AutoSize))
                {
                    CvTrackbar ctBrightness = null;
                    CvTrackbar ctContrast = null;
                    CvTrackbarCallback callback = delegate(int pos)
                    {
                        int brightness = ctBrightness.Pos - 100;
                        int contrast = ctContrast.Pos - 100;
                        // perform LUT
                        byte[] lut = CalcLut(contrast, brightness);
                        srcImg.LUT(dstImg, lut);
                        // draws histogram
                        CalcHist(dstImg, hist);
                        DrawHist(histImg, hist, histSize);

                        windowImage.ShowImage(dstImg);
                        windowHist.ShowImage(histImg);
                        dstImg.Zero();
                        histImg.Zero();
                    };

                    ctBrightness = windowImage.CreateTrackbar("brightness", 100, 200, callback);
                    ctContrast = windowImage.CreateTrackbar("contrast", 100, 200, callback);
                    // initial action
                    callback(0);

                    Cv.WaitKey(0);
                }
            }
        }

        /// <summary>
        /// contrastとbrightnessの値からLUTの値を計算し、byte配列で返す
        /// </summary>
        /// <param name="contrast"></param>
        /// <param name="brightness"></param>
        /// <returns></returns>
        private static byte[] CalcLut(int contrast, int brightness)
        {
            byte[] lut = new byte[256];
            /*
             * The algorithm is by Werner D. Streidt
             * (http://visca.com/ffactory/archives/5-99/msg00021.html)
             */
            if (contrast > 0)
            {
                double delta = 127.0 * contrast / 100;
                double a = 255.0 / (255.0 - delta * 2);
                double b = a * (brightness - delta);
                for (int i = 0; i < 256; i++)
                {
                    int v = Cv.Round(a * i + b);
                    if (v < 0)
                        v = 0;
                    if (v > 255)
                        v = 255;
                    lut[i] = (byte)v;
                }
            }
            else
            {
                double delta = -128.0 * contrast / 100;
                double a = (256.0 - delta * 2) / 255.0;
                double b = a * brightness + delta;
                for (int i = 0; i < 256; i++)
                {
                    int v = Cv.Round(a * i + b);
                    if (v < 0)
                        v = 0;
                    if (v > 255)
                        v = 255;
                    lut[i] = (byte)v;
                }
            }
            return lut;
        }
        /// <summary>
        /// calculate histogram
        /// </summary>
        /// <param name="img"></param>
        /// <param name="hist"></param>
        private static void CalcHist(IplImage img, CvHistogram hist)
        {
            hist.Calc(img);
            float minValue, maxValue;
            hist.GetMinMaxValue(out minValue, out maxValue);
            Cv.Scale(hist.Bins, hist.Bins, ((double)img.Height) / maxValue, 0);
        }

        /// <summary>
        /// draws histogram
        /// </summary>
        /// <param name="img"></param>
        /// <param name="hist"></param>
        /// <param name="histSize"></param>
        private static void DrawHist(IplImage img, CvHistogram hist, int histSize)
        {
            img.Set(CvColor.White);
            int binW = Cv.Round((double)img.Width / histSize);
            for (int i = 0; i < histSize; i++)
            {
                img.Rectangle(
                    new CvPoint(i * binW, img.Height),
                    new CvPoint((i + 1) * binW, img.Height - Cv.Round(hist.Bins[i])),
                    CvColor.Black, -1, LineType.AntiAlias, 0
                );
            }
        }
    }
}

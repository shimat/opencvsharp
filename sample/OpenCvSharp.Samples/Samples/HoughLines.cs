using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// ハフ変換による直線検出
    /// </summary>
    /// <remarks>http://opencv.jp/sample/special_transforms.html#hough_line</remarks>
    class HoughLines
    {
        public HoughLines()
        {
            SampleCpp();
            //SampleC();            
        }

        /// <summary>
        /// sample of new C++ style wrapper
        /// </summary>
        private void SampleCpp()
        {
            // (1)画像の読み込み 
            using (Mat imgGray = new Mat(Const.ImageGoryokaku, LoadMode.GrayScale))
            using (Mat imgStd = new Mat(Const.ImageGoryokaku, LoadMode.Color))
            using (Mat imgProb = imgStd.Clone())
            {
                // ハフ変換のための前処理 
                CvCpp.Canny(imgGray, imgGray, 50, 200, ApertureSize.Size3, false);

                // (3)標準的ハフ変換による線の検出と検出した線の描画
                CvLineSegmentPolar[] segStd = CvCpp.HoughLines(imgGray, 1, Math.PI / 180, 50, 0, 0);
                int limit = Math.Min(segStd.Length, 10);
                for (int i = 0; i < limit; i++ )
                {
                    float rho = segStd[i].Rho;
                    float theta = segStd[i].Theta;

                    double a = Math.Cos(theta);
                    double b = Math.Sin(theta);
                    double x0 = a * rho;
                    double y0 = b * rho;
                    CvPoint pt1 = new CvPoint { X = Cv.Round(x0 + 1000 * (-b)), Y = Cv.Round(y0 + 1000 * (a)) };
                    CvPoint pt2 = new CvPoint { X = Cv.Round(x0 - 1000 * (-b)), Y = Cv.Round(y0 - 1000 * (a)) };
                    imgStd.Line(pt1, pt2, CvColor.Red, 3, LineType.AntiAlias, 0);
                }

                // (4)確率的ハフ変換による線分の検出と検出した線分の描画
                CvLineSegmentPoint[] segProb = CvCpp.HoughLinesP(imgGray, 1, Math.PI / 180, 50, 50, 10);
                foreach (CvLineSegmentPoint s in segProb)
                {
                    imgProb.Line(s.P1, s.P2, CvColor.Red, 3, LineType.AntiAlias, 0);
                }


                // (5)検出結果表示用のウィンドウを確保し表示する
                using (new CvWindow("Hough_line_standard", WindowMode.AutoSize, imgStd.ToIplImage()))
                using (new CvWindow("Hough_line_probabilistic", WindowMode.AutoSize, imgProb.ToIplImage()))
                {
                    CvWindow.WaitKey(0);
                }
            }
        }

        /// <summary>
        /// sample of C style wrapper 
        /// </summary>
        private void SampleC()
        {
            // cvHoughLines2
            // 標準的ハフ変換と確率的ハフ変換を指定して線（線分）の検出を行なう．サンプルコード内の各パラメータ値は処理例の画像に対してチューニングされている．

            // (1)画像の読み込み 
            using (IplImage srcImgGray = new IplImage(Const.ImageGoryokaku, LoadMode.GrayScale))
            using (IplImage srcImgStd = new IplImage(Const.ImageGoryokaku, LoadMode.Color))
            using (IplImage srcImgProb = srcImgStd.Clone())
            {
                // (2)ハフ変換のための前処理 
                Cv.Canny(srcImgGray, srcImgGray, 50, 200, ApertureSize.Size3);
                using (CvMemStorage storage = new CvMemStorage())
                {
                    // (3)標準的ハフ変換による線の検出と検出した線の描画
                    CvSeq lines = srcImgGray.HoughLines2(storage, HoughLinesMethod.Standard, 1, Math.PI / 180, 50, 0, 0);
                    // wrapper style
                    //CvLineSegmentPolar[] lines = src_img_gray.HoughLinesStandard(1, Math.PI / 180, 50, 0, 0);

                    int limit = Math.Min(lines.Total, 10);
                    for (int i = 0; i < limit; i++)
                    {
                        // native code style
                        /*
                        unsafe
                        {
                            float* line = (float*)lines.GetElem<IntPtr>(i).Value.ToPointer();
                            float rho = line[0];
                            float theta = line[1];
                        }
                        //*/

                        // wrapper style
                        CvLineSegmentPolar elem = lines.GetSeqElem<CvLineSegmentPolar>(i).Value;
                        float rho = elem.Rho;
                        float theta = elem.Theta;

                        double a = Math.Cos(theta);
                        double b = Math.Sin(theta);
                        double x0 = a * rho;
                        double y0 = b * rho;
                        CvPoint pt1 = new CvPoint { X = Cv.Round(x0 + 1000 * (-b)), Y = Cv.Round(y0 + 1000 * (a)) };
                        CvPoint pt2 = new CvPoint { X = Cv.Round(x0 - 1000 * (-b)), Y = Cv.Round(y0 - 1000 * (a)) };
                        srcImgStd.Line(pt1, pt2, CvColor.Red, 3, LineType.AntiAlias, 0);
                    }

                    // (4)確率的ハフ変換による線分の検出と検出した線分の描画
                    lines = srcImgGray.HoughLines2(storage, HoughLinesMethod.Probabilistic, 1, Math.PI / 180, 50, 50, 10);
                    // wrapper style
                    //CvLineSegmentPoint[] lines = src_img_gray.HoughLinesProbabilistic(1, Math.PI / 180, 50, 0, 0);

                    for (int i = 0; i < lines.Total; i++)
                    {
                        // native code style
                        /*
                        unsafe
                        {
                            CvPoint* point = (CvPoint*)lines.GetElem<IntPtr>(i).Value.ToPointer();
                            src_img_prob.Line(point[0], point[1], CvColor.Red, 3, LineType.AntiAlias, 0);
                        }
                        //*/

                        // wrapper style
                        CvLineSegmentPoint elem = lines.GetSeqElem<CvLineSegmentPoint>(i).Value;
                        srcImgProb.Line(elem.P1, elem.P2, CvColor.Red, 3, LineType.AntiAlias, 0);
                    }
                }

                // (5)検出結果表示用のウィンドウを確保し表示する
                using (new CvWindow("Hough_line_standard", WindowMode.AutoSize, srcImgStd))
                using (new CvWindow("Hough_line_probabilistic", WindowMode.AutoSize, srcImgProb))
                {
                    CvWindow.WaitKey(0);
                }
            }
        }
    }
}

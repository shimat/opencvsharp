//#define CHECK_MEMORY_LEAK

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 顔の検出
    /// </summary>
    /// <remarks>http://opencv.jp/sample/object_detection.html#face_detection</remarks>
    class FaceDetect
    {
        public FaceDetect()
        {
            CheckMemoryLeak();

            // CvHaarClassifierCascade, cvHaarDetectObjects
            // 顔を検出するためにHaar分類器のカスケードを用いる

            CvColor[] colors = new CvColor[]{
                new CvColor(0,0,255),
                new CvColor(0,128,255),
                new CvColor(0,255,255),
                new CvColor(0,255,0),
                new CvColor(255,128,0),
                new CvColor(255,255,0),
                new CvColor(255,0,0),
                new CvColor(255,0,255),
            };

            const double Scale = 1.14;
            const double ScaleFactor = 1.0850;
            const int MinNeighbors = 2;

            using (IplImage img = new IplImage(Const.ImageYalta, LoadMode.Color))
            using (IplImage smallImg = new IplImage(new CvSize(Cv.Round(img.Width / Scale), Cv.Round(img.Height / Scale)), BitDepth.U8, 1))
            {
                // 顔検出用の画像の生成
                using (IplImage gray = new IplImage(img.Size, BitDepth.U8, 1))
                {
                    Cv.CvtColor(img, gray, ColorConversion.BgrToGray);
                    Cv.Resize(gray, smallImg, Interpolation.Linear);
                    Cv.EqualizeHist(smallImg, smallImg);
                }

                //using (CvHaarClassifierCascade cascade = Cv.Load<CvHaarClassifierCascade>(Const.XmlHaarcascade))  // どっちでも可
                using (CvHaarClassifierCascade cascade = CvHaarClassifierCascade.FromFile(Const.XmlHaarcascade))    // 
                using (CvMemStorage storage = new CvMemStorage())
                {
                    storage.Clear();

                    // 顔の検出
                    Stopwatch watch = Stopwatch.StartNew();
                    CvSeq<CvAvgComp> faces = Cv.HaarDetectObjects(smallImg, cascade, storage, ScaleFactor, MinNeighbors, 0, new CvSize(30, 30));
                    watch.Stop();
                    Console.WriteLine("detection time = {0}ms\n", watch.ElapsedMilliseconds);

                    // 検出した箇所にまるをつける
                    for (int i = 0; i < faces.Total; i++)
                    {
                        CvRect r = faces[i].Value.Rect;
                        CvPoint center = new CvPoint
                        {
                            X = Cv.Round((r.X + r.Width * 0.5) * Scale),
                            Y = Cv.Round((r.Y + r.Height * 0.5) * Scale)
                        };
                        int radius = Cv.Round((r.Width + r.Height) * 0.25 * Scale);
                        img.Circle(center, radius, colors[i % 8], 3, LineType.AntiAlias, 0);
                    }
                }

                // ウィンドウに表示
                CvWindow.ShowImages(img);
            }
        }

        [Conditional("CHECK_MEMORY_LEAK")]
        private void CheckMemoryLeak()
        {            
            while(true)
            {
                Console.WriteLine("{0} Kbytes", GC.GetTotalMemory(false) / 1024);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        for (int i = 0; i < 128; i++)
                        {
                            using (CvHaarClassifierCascade cascade = CvHaarClassifierCascade.FromFile(Const.XmlHaarcascade))
                            {                                
                            }
                            //using (CvMat mat = new CvMat(1, 1024, MatrixType.U8C1))
                            //{                                
                            //}
                        }
                        GC.Collect();
                        break;
                    case ConsoleKey.Escape:
                        goto END_LOOP;
                }
                
            }
        END_LOOP: ;
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.MachineLearning;
using OpenCvSharp.Blob;
using OpenCvSharp.UserInterface;
using OpenCvSharp.CPlusPlus;

namespace OpenCvSharpSamples
{
    /// <summary>
    /// 
    /// </summary>
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// 
        /// 以下のサンプルの大多数は、OpenCV付属のサンプルやOpenCV日本語版リファレンスのサンプルから拝借しC#風に書き換えたものです。
        /// </summary>                  
        /// <remarks>Please uncomment some samples optionally.</remarks>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IplImage img = new IplImage(@"C:\stegano.png");
            IplImage imgBin = new IplImage(img.Size, BitDepth.U8, 3);
            IplImage imgBinBig = new IplImage(img.Width * 6, img.Height * 6, BitDepth.U8, 3);

            IplImage imgB = new IplImage(img.Size, BitDepth.U8, 1);
            IplImage imgG = new IplImage(img.Size, BitDepth.U8, 1);
            IplImage imgR = new IplImage(img.Size, BitDepth.U8, 1);
            IplImage imgBBin = new IplImage(img.Size, BitDepth.U8, 1);
            IplImage imgGBin = new IplImage(img.Size, BitDepth.U8, 1);
            IplImage imgRBin = new IplImage(img.Size, BitDepth.U8, 1);
            IplImage imgRBinBig = new IplImage(img.Width * 6, img.Height * 6, BitDepth.U8, 1);
            IplImage imgGBinBig = new IplImage(img.Width * 6, img.Height * 6, BitDepth.U8, 1);
            IplImage imgBBinBig = new IplImage(img.Width * 6, img.Height * 6, BitDepth.U8, 1);
            IplImage imgBRBinBig = new IplImage(img.Width * 6, img.Height * 6, BitDepth.U8, 1);
            IplImage imgGRBinBig = new IplImage(img.Width * 6, img.Height * 6, BitDepth.U8, 1);
            IplImage imgBGBinBig = new IplImage(img.Width * 6, img.Height * 6, BitDepth.U8, 1);
            Cv.Split(img, imgB, imgG, imgR, null);

            using (CvWindow windowAll = new CvWindow("all"))
            using (CvWindow windowB = new CvWindow("B"))
            using (CvWindow windowG = new CvWindow("G"))
            using (CvWindow windowR = new CvWindow("R"))
            using (CvWindow windowBR = new CvWindow("BR"))
            using (CvWindow windowGR = new CvWindow("GR"))
            using (CvWindow windowBG = new CvWindow("BG"))
            {
                CvTrackbarCallback callback = (pos) =>
                {
                    Cv.Threshold(img, imgBin, pos, 255, ThresholdType.Binary);
                    Cv.Threshold(imgB, imgBBin, pos, 255, ThresholdType.Binary);
                    Cv.Threshold(imgG, imgGBin, pos, 255, ThresholdType.Binary);
                    Cv.Threshold(imgR, imgRBin, pos, 255, ThresholdType.Binary);
                    Cv.Resize(imgBin, imgBinBig, Interpolation.NearestNeighbor);
                    Cv.Resize(imgBBin, imgBBinBig, Interpolation.NearestNeighbor);
                    Cv.Resize(imgGBin, imgGBinBig, Interpolation.NearestNeighbor);
                    Cv.Resize(imgRBin, imgRBinBig, Interpolation.NearestNeighbor);
                    Cv.Or(imgBBinBig, imgRBinBig, imgBRBinBig);
                    Cv.Or(imgGBinBig, imgRBinBig, imgGRBinBig);
                    Cv.Or(imgBBinBig, imgGBinBig, imgBGBinBig);
                    windowAll.ShowImage(imgBinBig);
                    windowB.ShowImage(imgBBinBig);
                    windowG.ShowImage(imgGBinBig);
                    windowR.ShowImage(imgRBinBig);
                    windowBR.ShowImage(imgBRBinBig);
                    windowGR.ShowImage(imgGRBinBig);
                    windowBG.ShowImage(imgBGBinBig);
                };
                callback(128);
                windowAll.CreateTrackbar("t", 128, 255, callback);

                Cv.WaitKey();
            }
            



            return;


            IplImage imgAnd = new IplImage(img.Size, BitDepth.U8, 1);
            imgAnd.Zero();
            Cv.And(imgB, imgG, imgAnd);
            Cv.And(imgAnd, imgR, imgAnd);

            CvWindow.ShowImages(imgBin, imgB, imgG, imgR, imgAnd);

            //new Affine();                      // 画像のアフィン変換  

            //new BgSubtractorMOG();               // BackgroundSubtractorMOG

            //new BinarizationMethods();         // Various Binarization Methods

            //new BlobOld();                        // cvblob test (original C++ implementation)
            //new Blob();                           // cvblob test (C# implementation)

            //new BoundingRect();                // 点列を包含する矩形
            
            //new CalibrateCamera();             // カメラキャリブレーション

            //new CalibrateStereoCamera();             // カメラキャリブレーション

            //new CaptureAVI();                  // AVIファイルのキャプチャ

            //new CaptureByVideoInputSharp();    // Captures using VideoInputSharp

            //new CaptureCamera();               // カメラのキャプチャ

            //new Contour();                     // 輪郭領域の面積と輪郭の長さ

            //new ContourScanner();              // CvContourScanner Sample

            //new ConvertToBitmap();             // System.Drawing.Bitmapへの変換

            //new ConvertToBitmapSource();       // System.Windows.Media.Imaging.BitmapSourceへの変換

            //new ConvertToIplImage();           // Converts from Bitmap/WriteableBitmap to IplImage

            //new ConvertToWriteableBitmap();    // System.Windows.Media.Imaging.WriteableBitmapへの変換

            //new ConvexHull();                  // Building convex hull for ra sequence or array of points

            new ConvexityDefect();             // Convexity Defect

            //new CopyMakeBorder();              // 境界線の作成 

            //new CornerDetect();                // コーナーの検出

            //new CppTest();                     // C++ interface sample

           // new CvWindowExTest();              // Pure C# implementation of CvWindow

            //new Delaunay();                    // Planar Subdivisions

            //new DFT();                         // Discrete Fourier Transform

            //new DistTransform();               // 距離変換とその可視化

            //new DrawToHdc();                   // Draws IplImage to Handle of Device Context(HDC)

            //new DTree();                       // samples/c/mushroom.c

            //new Edge();                        // エッジ検出

            // todo: does not work
            //new EM();                          // EMアルゴリズム

            //new FaceDetect();                  // 顔の検出

            //new FAST();                        // cv::FAST

            //new FileStorage();                 // データのファイルストレージへの書き込み・読み込み

            //new Filter2D();                    // ユーザが定義したカーネルによるフィルタリング

            //new FindContours();                // 輪郭の検出と描画

            //new FlannTest();                   // FLANN

            //new GammaCorrection();             // Gamma correction

            // todo
            //new GpuTest();                     // opencv2/gpu 
            
            //new Histogram();                   // ヒストグラムの描画

            //new FitLine();                     // cvFitLine sample

            //new HOG();                         // HOG sample (samples/c/peopledetect.c)

            //new HoughCircles();                // ハフ変換による円検出

            //new HoughLines();                  // ハフ変換による直線検出

            //new Image2Stream();                // Image <-> byte[]/Stream

            //new Inpaint();                     // 不要オブジェクトの除去

            //new Kalman();                      // カルマンフィルタ

            //new LatentSVM();                   // LatentSVM sample

            //new LetterRecog();                 // samples/c/letter_recog.cpp

            //new LineIterator();                // CvLineIterator sample            

            //new LSH();                         // Locality Sensitive Hashing

            //new KMeans();                      // クラスタリングによる減色処理

            //new MatTest();                     // 行列演算のテスト

            //new MDS();                         // Multidimensional Scaling (多次元尺度構成法)

            //new Moments();                     // 画像のモーメント

            //new Morphology();                  // モルフォロジー変換

            // notice: this does not work because of OpenCV binary's bug
            //new MSERSample();                  // Maximally Stable Extremal Regions

            //new OpticalFlowBM();               // Block Matchingによるオプティカルフローの計算

            //new OpticalFlowHS();               // Horn & Schunck アルゴリズムによるオプティカルフローの計算

            //new OpticalFlowLK();               // Lucas & Kanade アルゴリズムによるオプティカルフローの計算            

            //new Perspective();                 // 画像の透視投影変換

            //new PictureBoxIplSample();         // PictureBoxIplSample sample

            //new PixelAccess();                 // ピクセルデータへの直接アクセス

            //new PixelSampling();               // ピクセルサンプリング

            //new PolarTransForm();              // Log-polar 変換

            //new PseudoColor();                 // Converts gray scale image to pseudo-color images

            //new PyrDownUp();                   // 画像ピラミッドの作成

            //new PyrMeanShiftFiltering();       // 平均値シフト法による画像のセグメント化

            //new PyrSegmentation();             // 画像ピラミッドを用いた画像の領域分割

            //new QtTest();                      // Qt highgui test

            //new Resize();                      // 画像のサイズ変更

            //new SaveImage();                   // Saving image using the format-specific save parameters

            //new SeqPartition();                // Partitioning 2d point set.

            //new SeqTest();                     // Test of CvSeq

            //new Serialization();               // Binary Serialization

            //new SkinDetector();                // CvAdaptiveSkinDetector sample

            //new Solve();                       // 連立方程式を解く

            //new Snake();                       // 輪郭検出

            //new Squares();                     // samples/c/squares.c

            //new StarDetectorSample();          // Retrieves keypoints using the StarDetector algorithm

            //new StereoCorrespondence();        // ステレオマッチング

            //notice: you need to build OpenCV with SURF 
            //new SURFSample();                  // SURFによる対応点検出

            //new SVM();                         // SVM

            //new Text();                        // テキストの描画

            //new Threshold();                   // 2値化

            //new TreeNodeIterator();            // 輪郭座標の取得

            //new Undistort();                   // 歪み補正

            //new VideoWriter();                 // 動画としてファイルへ書き出す

            //new Watershed();                   // Watershedアルゴリズムによる画像の領域分割
        }

    }
}

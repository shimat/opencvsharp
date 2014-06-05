using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.Blob;
using OpenCvSharp.UserInterface;
using OpenCvSharp.CPlusPlus;

namespace CStyleSamplesCS
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

            //new Affine();                      // Affine transformation

            //new BinarizationMethods();         // Various Binarization Methods

            new Blob();                        // cvblob test (C# implementation)

            //new BoundingRect();                // 点列を包含する矩形
            
            //new CalibrateCamera();             // Camera calibration

            //new CalibrateStereoCamera();       // Stereo camera calibration

            //new CaptureAVI();                  // Capturing from AVI file

            //new CaptureByVideoInputSharp();    // Captures using VideoInputSharp

            //new CaptureCamera();               // Capturing from camera device

            //new Contour();                     // 輪郭領域の面積と輪郭の長さ

            //new ContourScanner();              // CvContourScanner Sample

            //new ConvertToBitmap();             // System.Drawing.Bitmapへの変換

            //new ConvertToBitmapSource();       // System.Windows.Media.Imaging.BitmapSourceへの変換

            //new ConvertToIplImage();           // Converts from Bitmap/WriteableBitmap to IplImage

            //new ConvertToWriteableBitmap();    // System.Windows.Media.Imaging.WriteableBitmapへの変換

            //new ConvexHull();                  // Building convex hull for ra sequence or array of points

            //new ConvexityDefect();             // Convexity Defect

            //new CopyMakeBorder();              // 境界線の作成 

            //new CornerDetect();                // コーナーの検出

            //new CppTest();                     // C++ interface sample

           // new CvWindowExTest();              // Pure C# implementation of CvWindow

            //new Delaunay();                    // Planar Subdivisions

            //new DFT();                         // Discrete Fourier Transform

            //new DistTransform();               // 距離変換とその可視化

            //new DrawToHdc();                   // Draws IplImage to Handle of Device Context(HDC)

            //new Edge();                        // エッジ検出

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

            //new HoughCircles();                // ハフ変換による円検出

            //new HoughLines();                  // ハフ変換による直線検出

            //new Image2Stream();                // Image <-> byte[]/Stream

            //new Inpaint();                     // 不要オブジェクトの除去

            //new Kalman();                      // カルマンフィルタ

            //new LatentSVM();                   // LatentSVM sample

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

            //new Text();                        // テキストの描画

            //new Threshold();                   // 2値化

            //new TreeNodeIterator();            // 輪郭座標の取得

            //new Undistort();                   // 歪み補正

            //new VideoWriter();                 // 動画としてファイルへ書き出す

            //new Watershed();                   // Watershedアルゴリズムによる画像の領域分割
        }

    }
}

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

namespace OpenCvSharp.Test
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

            //new Test.Affine();                      // 画像のアフィン変換  

            //new Test.BgSubtractorMOG();               // BackgroundSubtractorMOG

            //new Test.BinarizationMethods();         // Various Binarization Methods

            //new Test.Blob();                        // cvblob test

            //new Test.BoundingRect();                // 点列を包含する矩形
            
            //new Test.CalibrateCamera();             // カメラキャリブレーション

            //new Test.CalibrateStereoCamera();             // カメラキャリブレーション

            new Test.CaptureAVI();                  // AVIファイルのキャプチャ

            //new Test.CaptureByVideoInputSharp();    // Captures using VideoInputSharp

            //new Test.CaptureCamera();               // カメラのキャプチャ

            //new Test.Contour();                     // 輪郭領域の面積と輪郭の長さ

            //new Test.ContourScanner();              // CvContourScanner Sample

            //new Test.ConvertToBitmap();             // System.Drawing.Bitmapへの変換

            //new Test.ConvertToBitmapSource();       // System.Windows.Media.Imaging.BitmapSourceへの変換

            //new Test.ConvertToIplImage();           // Converts from Bitmap/WriteableBitmap to IplImage

            //new Test.ConvertToWriteableBitmap();    // System.Windows.Media.Imaging.WriteableBitmapへの変換

            //new Test.ConvexHull();                  // Building convex hull for ra sequence or array of points

            //new Test.ConvexityDefect();             // Convexity Defect

            //new Test.CopyMakeBorder();              // 境界線の作成 

            //new Test.CornerDetect();                // コーナーの検出

            //new Test.CppTest();                     // C++ interface sample

           // new Test.CvWindowExTest();              // Pure C# implementation of CvWindow

            //new Test.Delaunay();                    // Planar Subdivisions

            //new Test.DFT();                         // Discrete Fourier Transform

            //new Test.DistTransform();               // 距離変換とその可視化

            //new Test.DrawToHdc();                   // Draws IplImage to Handle of Device Context(HDC)

            //new Test.DTree();                       // samples/c/mushroom.c

            //new Test.Edge();                        // エッジ検出

            // todo: does not work
            //new Test.EM();                          // EMアルゴリズム

            //new Test.FaceDetect();                  // 顔の検出

            //new Test.FAST();                        // cv::FAST

            //new Test.FileStorage();                 // データのファイルストレージへの書き込み・読み込み

            //new Test.Filter2D();                    // ユーザが定義したカーネルによるフィルタリング

            //new Test.FindContours();                // 輪郭の検出と描画

            //new Test.FlannTest();                   // FLANN

            //new Test.GammaCorrection();             // Gamma correction

            // todo
            //new Test.GpuTest();                     // opencv2/gpu 
            
            //new Test.Histogram();                   // ヒストグラムの描画

            //new Test.FitLine();                     // cvFitLine sample

            //new Test.HOG();                         // HOG sample (samples/c/peopledetect.c)

            //new Test.HoughCircles();                // ハフ変換による円検出

            //new Test.HoughLines();                  // ハフ変換による直線検出

            //new Test.Image2Stream();                // Image <-> byte[]/Stream

            //new Test.Inpaint();                     // 不要オブジェクトの除去

            //new Test.Kalman();                      // カルマンフィルタ

            //new Test.LatentSVM();                   // LatentSVM sample

            //new Test.LetterRecog();                 // samples/c/letter_recog.cpp

            //new Test.LineIterator();                // CvLineIterator sample            

            //new Test.LSH();                         // Locality Sensitive Hashing

            //new Test.KMeans();                      // クラスタリングによる減色処理

            //new Test.MatTest();                     // 行列演算のテスト

            //new Test.MDS();                         // Multidimensional Scaling (多次元尺度構成法)

            //new Test.Moments();                     // 画像のモーメント

            //new Test.Morphology();                  // モルフォロジー変換

            // notice: this does not work because of OpenCV binary's bug
            //new Test.MSERSample();                  // Maximally Stable Extremal Regions

            //new Test.OpticalFlowBM();               // Block Matchingによるオプティカルフローの計算

            //new Test.OpticalFlowHS();               // Horn & Schunck アルゴリズムによるオプティカルフローの計算

            //new Test.OpticalFlowLK();               // Lucas & Kanade アルゴリズムによるオプティカルフローの計算            

            //new Test.Perspective();                 // 画像の透視投影変換

            //new Test.PictureBoxIplSample();         // PictureBoxIplSample sample

            //new Test.PixelAccess();                 // ピクセルデータへの直接アクセス

            //new Test.PixelSampling();               // ピクセルサンプリング

            //new Test.PolarTransForm();              // Log-polar 変換

            //new Test.PseudoColor();                 // Converts gray scale image to pseudo-color images

            //new Test.PyrDownUp();                   // 画像ピラミッドの作成

            //new Test.PyrMeanShiftFiltering();       // 平均値シフト法による画像のセグメント化

            //new Test.PyrSegmentation();             // 画像ピラミッドを用いた画像の領域分割

            //new Test.QtTest();                      // Qt highgui test

            //new Test.Resize();                      // 画像のサイズ変更

            //new Test.SaveImage();                   // Saving image using the format-specific save parameters

            //new Test.SeqPartition();                // Partitioning 2d point set.

            //new Test.SeqTest();                     // Test of CvSeq

            //new Test.Serialization();               // Binary Serialization

            //new Test.SkinDetector();                // CvAdaptiveSkinDetector sample

            //new Test.Solve();                       // 連立方程式を解く

            //new Test.Snake();                       // 輪郭検出

            //new Test.Squares();                     // samples/c/squares.c

            //new Test.StarDetectorSample();          // Retrieves keypoints using the StarDetector algorithm

            //new Test.StereoCorrespondence();        // ステレオマッチング

            //notice: you need to build OpenCV with SURF 
            //new Test.SURFSample();                  // SURFによる対応点検出

            //new Test.SVM();                         // SVM

            //new Test.Text();                        // テキストの描画

            //new Test.Threshold();                   // 2値化

            //new Test.TreeNodeIterator();            // 輪郭座標の取得

            //new Test.Undistort();                   // 歪み補正

            //new Test.VideoWriter();                 // 動画としてファイルへ書き出す

            //new Test.Watershed();                   // Watershedアルゴリズムによる画像の領域分割
        }

    }
}

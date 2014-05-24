Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms

Imports OpenCvSharp
Imports OpenCvSharp.Blob
Imports OpenCvSharp.UserInterface
Imports OpenCvSharp.CPlusPlus

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' 
    ''' </summary>
    '


    Friend NotInheritable Class Program

        Private Sub New()


        End Sub

        ''' <summary>
        ''' This is the main entry point for the 'application.
        '''
        ''' The majority of the sample of below, 
        ''' It's the one that was rewritten in C # style borrowed from a sample of Japanese version of OpenCV reference samples and comes with OpenCV.               
        '''
        ''' <remarks>Please uncomment some samples optionally.</remarks>
        <STAThread> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)

        'Affine.Start()                      ' 画像のアフィン変換  

            'BgSubtractorMOG.Start()               ' BackgroundSubtractorMOG

            ' BinarizationMethods.Start()         ' Various Binarization Methods

            ' BlobOld.Start()                        ' cvblob test (original C++ implementation)
            ' Blob.Start()                           ' cvblob test (C# implementation)

            ' BoundingRect.Start()                ' 点列を包含する矩形

            ' CalibrateCamera.Start()             ' カメラキャリブレーション

            ' CalibrateStereoCamera.Start()             ' カメラキャリブレーション

            ' CaptureAVI.Start()                  ' AVIファイルのキャプチャ

            ' CaptureByVideoInputSharp.Start()    ' Captures using VideoInputSharp

            ' CaptureCamera.Start()               ' カメラのキャプチャ

            ' Contour.Start()                     ' 輪郭領域の面積と輪郭の長さ

            'ContourScanner.Start()

            ' ConvertToBitmap.Start()             ' System.Drawing.Bitmapへの変換

            ' ConvertToBitmapSource.Start()       ' System.Windows.Media.Imaging.BitmapSourceへの変換

            ' ConvertToIplImage.Start()           ' Converts from Bitmap/WriteableBitmap to IplImage

            ' ConvertToWriteableBitmap.Start()    ' System.Windows.Media.Imaging.WriteableBitmapへの変換

            'ConvexHull.Start()                  ' Building convex hull for ra sequence or array of points

            ConvexityDefect.Start()            ' Convexity Defect

            ' CopyMakeBorder.Start()              ' 境界線の作成 

            ' CornerDetect.Start()                ' コーナーの検出

            ' new CvWindowExTest.Start()              ' Pure C# implementation of CvWindow

            ' Delaunay.Start()                    ' Planar Subdivisions

            ' DFT.Start()                         ' Discrete Fourier Transform

            ' DistTransform.Start()               ' 距離変換とその可視化

            ' DrawToHdc.Start()                   ' Draws IplImage to Handle of Device Context(HDC)

            ' DTree.Start()                       ' samples/c/mushroom.c

            'Edge.Start()


            ' todo: does not work
            ' EM.Start()                          ' EMアルゴリズム

            ' FaceDetect.Start()                  ' 顔の検出

        ' FileStorage.Start()                 ' データのファイルストレージへの書き込み・読み込み

            ' Filter2D.Start()                    ' ユーザが定義したカーネルによるフィルタリング

            ' FindContours.Start()                ' 輪郭の検出と描画

            ' GammaCorrection.Start()             ' Gamma correction

            ' todo
            ' GpuTest.Start()                     ' opencv2/gpu 

            ' Histogram.Start()                   ' ヒストグラムの描画

            ' FitLine.Start()                     ' cvFitLine sample

            ' HoughCircles.Start()                ' ハフ変換による円検出

            ' HoughLines.Start()                  ' ハフ変換による直線検出

            ' Image2Stream.Start()                ' Image <-> byte[]/Stream

            ' Inpaint.Start()                     ' 不要オブジェクトの除去

            ' Kalman.Start()                      ' カルマンフィルタ

            ' LatentSVM.Start()                   ' LatentSVM sample

            ' LetterRecog.Start()                 ' samples/c/letter_recog.cpp

            ' LineIterator.Start()                ' CvLineIterator sample            

            ' LSH.Start()                         ' Locality Sensitive Hashing

            ' KMeans.Start()                      ' クラスタリングによる減色処理

            ' MatTest.Start()                     ' 行列演算のテスト

            ' MDS.Start()                         ' Multidimensional Scaling (多次元尺度構成法)

            ' Moments.Start()                     ' 画像のモーメント

            ' Morphology.Start()                  ' モルフォロジー変換

            ' notice: this does not work because of OpenCV binary's bug
            ' MSERSample.Start()                  ' Maximally Stable Extremal Regions

            ' OpticalFlowBM.Start()               ' Block Matchingによるオプティカルフローの計算

            ' OpticalFlowHS.Start()               ' Horn & Schunck アルゴリズムによるオプティカルフローの計算

            ' OpticalFlowLK.Start()               ' Lucas & Kanade アルゴリズムによるオプティカルフローの計算            

            ' Perspective.Start()                 ' 画像の透視投影変換

            ' PictureBoxIplSample.Start()         ' PictureBoxIplSample sample

            ' PixelAccess.Start()                 ' ピクセルデータへの直接アクセス

            ' PixelSampling.Start()               ' ピクセルサンプリング

            ' PolarTransForm.Start()              ' Log-polar 変換

            ' PseudoColor.Start()                 ' Converts gray scale image to pseudo-color images

            ' PyrDownUp.Start()                   ' 画像ピラミッドの作成

            ' PyrMeanShiftFiltering.Start()       ' 平均値シフト法による画像のセグメント化

            ' PyrSegmentation.Start()             ' 画像ピラミッドを用いた画像の領域分割

            ' QtTest.Start()                      ' Qt highgui test

            ' Resize.Start()                      ' 画像のサイズ変更

            ' SaveImage.Start()                   ' Saving image using the format-specific save parameters

            ' SeqPartition.Start()                ' Partitioning 2d point set.

            ' SeqTest.Start()                     ' Test of CvSeq

            ' Serialization.Start()               ' Binary Serialization

            ' SkinDetector.Start()                ' CvAdaptiveSkinDetector sample

            ' Solve.Start()                       ' 連立方程式を解く

            ' Snake.Start()                       ' 輪郭検出

            ' Squares.Start()                     ' samples/c/squares.c

            ' StarDetectorSample.Start()          ' Retrieves keypoints using the StarDetector algorithm

            ' StereoCorrespondence.Start()        ' ステレオマッチング

            'notice: you need to build OpenCV with SURF 
            'new SURFSample.Start()                  ' SURFによる対応点検出

            'new SVM.Start()                         ' SVM

            'new Text.Start()                        ' テキストの描画

            'new Threshold.Start()                   ' 2値化

            'new TreeNodeIterator.Start()            ' 輪郭座標の取得

            'new Undistort.Start()                   ' 歪み補正

            'new VideoWriter.Start()                 ' 動画としてファイルへ書き出す

            'new Watershed.Start()                   ' Watershedアルゴリズムによる画像の領域分割
        End Sub

    End Class
' End Namespace

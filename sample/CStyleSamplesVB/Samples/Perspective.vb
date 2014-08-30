Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 画像の透視投影変換
''' </summary>
''' <remarks>http://opencv.jp/sample/sampling_and_geometricaltransforms.html#perspective</remarks>
    Friend Module Perspective
        Public Sub Start()
            ' cvGetPerspectiveTransform + cvWarpPerspective
            ' 画像上の４点対応より透視投影変換行列を計算し，その行列を用いて画像全体の透視投影変換を行う．

            ' (1)画像の読み込み，出力用画像領域の確保を行なう
        Using srcImg As New IplImage(FilePath.Image.Lenna, LoadMode.AnyDepth Or LoadMode.AnyColor)
            Using dstImg As IplImage = srcImg.Clone()
                ' (2)四角形の変換前と変換後の対応する頂点をそれぞれセットし
                '    cvWarpPerspectiveを用いて透視投影変換行列を求める  
                Dim srcPnt(3) As CvPoint2D32f
                Dim dstPnt(3) As CvPoint2D32f
                srcPnt(0) = New CvPoint2D32f(150.0F, 150.0F)
                srcPnt(1) = New CvPoint2D32f(150.0F, 300.0F)
                srcPnt(2) = New CvPoint2D32f(350.0F, 300.0F)
                srcPnt(3) = New CvPoint2D32f(350.0F, 150.0F)
                dstPnt(0) = New CvPoint2D32f(200.0F, 200.0F)
                dstPnt(1) = New CvPoint2D32f(150.0F, 300.0F)
                dstPnt(2) = New CvPoint2D32f(350.0F, 300.0F)
                dstPnt(3) = New CvPoint2D32f(300.0F, 200.0F)
                Using mapMatrix As CvMat = Cv.GetPerspectiveTransform(srcPnt, dstPnt)
                    ' (3)指定されたアフィン行列により，cvWarpAffineを用いて画像を回転させる
                    Cv.WarpPerspective(srcImg, dstImg, mapMatrix, Interpolation.Linear Or Interpolation.FillOutliers, CvScalar.ScalarAll(100))
                    ' (4)結果を表示する
                    Using TempCvWindow As CvWindow = New CvWindow("src", srcImg)
                        Using TempCvWindowDst As CvWindow = New CvWindow("dst", dstImg)
                            Cv.WaitKey(0)
                        End Using
                    End Using
                End Using
            End Using
        End Using
        End Sub
    End Module
' End Namespace

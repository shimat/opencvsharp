Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports SampleBase

''' <summary>
''' 画像のアフィン変換
''' </summary>
''' <remarks>
''' http://opencv.jp/sample/sampling_and_geometricaltransforms.html#affine_1
''' </remarks>
Friend Module Affine
    Public Sub Start()

        ' cvGetAffineTransform + cvWarpAffine
        ' 画像上の３点対応よりアフィン変換行列を計算し，その行列を用いて画像全体のアフィン変換を行う．

        ' (1)画像の読み込み，出力用画像領域の確保を行なう
        Using srcImg As New IplImage(FilePath.Image.Goryokaku, LoadMode.AnyDepth Or LoadMode.AnyColor)
            Using dstImg As IplImage = srcImg.Clone()

                ' (2)三角形の回転前と回転後の対応する頂点をそれぞれセットし  
                '    cvGetAffineTransformを用いてアフィン行列を求める  
                Dim srcPnt(2) As CvPoint2D32f
                Dim dstPnt(2) As CvPoint2D32f
                srcPnt(0) = New CvPoint2D32f(200.0F, 200.0F)
                srcPnt(1) = New CvPoint2D32f(250.0F, 200.0F)
                srcPnt(2) = New CvPoint2D32f(200.0F, 100.0F)
                dstPnt(0) = New CvPoint2D32f(300.0F, 100.0F)
                dstPnt(1) = New CvPoint2D32f(300.0F, 50.0F)
                dstPnt(2) = New CvPoint2D32f(200.0F, 100.0F)
                Using mapMatrix As CvMat = Cv.GetAffineTransform(srcPnt, dstPnt)
                    ' (3)指定されたアフィン行列により，cvWarpAffineを用いて画像を回転させる
                    Cv.WarpAffine(srcImg, dstImg, mapMatrix, Interpolation.Linear Or Interpolation.FillOutliers, CvScalar.ScalarAll(0))
                    ' (4)結果を表示する
                    Using New CvWindow("src", srcImg)
                        Using New CvWindow("dst", dstImg)
                            Cv.WaitKey(0)
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Module
'' End Namespace
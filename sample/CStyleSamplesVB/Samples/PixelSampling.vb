Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' ピクセルサンプリング
''' </summary>
''' <remarks>http://opencv.jp/sample/sampling_and_geometricaltransforms.html#getrectsubpix</remarks>
Friend Module PixelSampling
    Public Sub Start()
        ' 並進移動のためのピクセルサンプリング cvGetRectSubPix

        ' (1) 画像の読み込み，出力用画像領域の確保を行なう 
        Using srcImg As New IplImage(FilePath.Image.Lenna, LoadMode.AnyDepth Or LoadMode.AnyColor)
            Using dstImg As IplImage = srcImg.Clone()
                ' (2)dst_imgの画像中心になるsrc_img中の位置centerを指定する
                Dim center As CvPoint2D32f = New CvPoint2D32f With {.X = srcImg.Width - 1, .Y = srcImg.Height - 1}
                ' (3)centerが画像中心になるように，GetRectSubPixを用いて画像全体をシフトさせる
                Cv.GetRectSubPix(srcImg, dstImg, center)
                ' (4)結果を表示する
                Using wSrc As New CvWindow("src")
                    Using wDst As New CvWindow("dst")
                        wSrc.Image = srcImg
                        wDst.Image = dstImg
                        Cv.WaitKey(0)
                    End Using
                End Using
            End Using
        End Using


        ' 回転移動のためのピクセルサンプリング cvGetQuadrangleSubPix

        Const angle As Integer = 45
        ' (1)画像の読み込み，出力用画像領域の確保を行なう
        Using srcImg As New IplImage(FilePath.Image.Lenna, LoadMode.AnyDepth Or LoadMode.AnyColor)
            Using dstImg As IplImage = srcImg.Clone()
                ' (2)回転のための行列（アフィン行列）要素を設定し，CvMat行列Mを初期化する
                Dim m(5) As Single
                m(0) = CSng(Math.Cos(angle * Cv.PI / 180.0))
                m(1) = CSng(-Math.Sin(angle * Cv.PI / 180.0))
                m(2) = srcImg.Width * 0.5F
                m(3) = -m(1)
                m(4) = m(0)
                m(5) = srcImg.Height * 0.5F
                Using mat As New CvMat(2, 3, MatrixType.F32C1, m)
                    ' (3)指定された回転行列により，GetQuadrangleSubPixを用いて画像全体を回転させる
                    Cv.GetQuadrangleSubPix(srcImg, dstImg, mat)
                    ' (4)結果を表示する
                    Using wSrc As New CvWindow("src")
                        Using wDst As New CvWindow("dst")
                            wSrc.Image = srcImg
                            wDst.Image = dstImg
                            Cv.WaitKey(0)
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Module
' End Namespace

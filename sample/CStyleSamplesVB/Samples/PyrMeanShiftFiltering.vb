Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 平均値シフト法による画像のセグメント化
''' </summary>
''' <remarks>http://opencv.jp/sample/segmentation_and_connection.html#meanshiftsegm</remarks>
    Friend Module PyrMeanShiftFiltering
        Public Sub Start()
            ' cvPyrMeanShiftFiltering
            ' 平均値シフト法による画像のセグメント化を行う

            Const level As Integer = 2

            ' (1)画像の読み込み
        Using srcImg As New IplImage(FilePath.Image.Goryokaku, LoadMode.AnyDepth Or LoadMode.AnyColor)
            If srcImg.NChannels <> 3 Then
                Throw New Exception()
            End If
            If srcImg.Depth <> BitDepth.U8 Then
                Throw New Exception()
            End If

            ' (2)領域分割のためにROIをセットする
            Dim roi As CvRect = New CvRect With {.X = 0, .Y = 0, .Width = srcImg.Width And -(1 << level), .Height = srcImg.Height And -(1 << level)}
            srcImg.ROI = roi

            ' (3)分割結果画像出力用の画像領域を確保し，領域分割を実行
            Using dstImg As IplImage = srcImg.Clone()
                Cv.PyrMeanShiftFiltering(srcImg, dstImg, 30.0, 30.0, level, New CvTermCriteria(5, 1))
                ' (4)入力画像と分割結果画像の表示
                Using wSrc As New CvWindow("Source", srcImg)
                    Using wDst As New CvWindow("MeanShift", dstImg)
                        CvWindow.WaitKey()
                    End Using
                End Using
            End Using
        End Using

        End Sub
    End Module
' End Namespace

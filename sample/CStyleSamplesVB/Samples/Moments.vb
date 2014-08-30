Imports System
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 画像のモーメント
''' </summary>
''' <remarks>http://opencv.jp/sample/moment.html</remarks>
    Friend Module Moments
        Public Sub Start()
            ' (1)画像を読み込む．3チャンネル画像の場合はCOIがセットされていなければならない
        Using srcImg As New IplImage(FilePath.Image.Lenna, LoadMode.AnyColor Or LoadMode.AnyDepth)
            If srcImg.NChannels = 3 AndAlso srcImg.COI = 0 Then
                srcImg.COI = 1
            End If
            ' (2)入力画像の３次までの画像モーメントを計算する
            Dim moments As New CvMoments(srcImg, False)
            srcImg.COI = 0

            ' (3)モーメントやHuモーメント不変量を，得られたCvMoments構造体の値を使って計算する．
            Dim spatialMoment As Double = moments.GetSpatialMoment(0, 0)
            Dim centralMoment As Double = moments.GetCentralMoment(0, 0)
            Dim normCMoment As Double = moments.GetNormalizedCentralMoment(0, 0)
            Dim huMoments As New CvHuMoments(moments)

            ' (4)得られたモーメントやHuモーメント不変量を文字として画像に描画
            Using font As New CvFont(FontFace.HersheySimplex, 1.0, 1.0, 0, 2, LineType.Link8)
                Dim text(9) As String
                text(0) = String.Format("spatial={0:F3}", spatialMoment)
                text(1) = String.Format("central={0:F3}", centralMoment)
                text(2) = String.Format("norm={0:F3}", spatialMoment)
                text(3) = String.Format("hu1={0:F10}", huMoments.Hu1)
                text(4) = String.Format("hu2={0:F10}", huMoments.Hu2)
                text(5) = String.Format("hu3={0:F10}", huMoments.Hu3)
                text(6) = String.Format("hu4={0:F10}", huMoments.Hu4)
                text(7) = String.Format("hu5={0:F10}", huMoments.Hu5)
                text(8) = String.Format("hu6={0:F10}", huMoments.Hu6)
                text(9) = String.Format("hu7={0:F10}", huMoments.Hu7)

                Dim textSize As CvSize = font.GetTextSize(text(0))
                For i As Integer = 0 To 9
                    srcImg.PutText(text(i), New CvPoint(10, (textSize.Height + 3) * (i + 1)), font, CvColor.Black)
                Next i
            End Using

            ' (5)入力画像とモーメント計算結果を表示，キーが押されたときに終了
            Using window As New CvWindow("Image", WindowMode.AutoSize)
                window.ShowImage(srcImg)
                Cv.WaitKey(0)
            End Using
        End Using

        End Sub
    End Module
' End Namespace

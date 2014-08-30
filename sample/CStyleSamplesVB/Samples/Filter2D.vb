Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' ユーザ定義フィルタ
''' </summary>
''' <remarks>
''' http://opencv.jp/sample/filter_and_color_conversion.html#filter2d
''' </remarks>
Friend Module Filter2D
    Public Sub Start()
        ' cvFilter2D
        ' ユーザが定義したカーネルによるフィルタリング

        ' (1)画像の読み込み
        Using srcImg As New IplImage(FilePath.Image.Fruits, LoadMode.AnyDepth Or LoadMode.AnyColor)
            Using dstImg As New IplImage(srcImg.Size, srcImg.Depth, srcImg.NChannels)
                ' (2)カーネルの正規化と，フィルタ処理
                Dim data() As Single = {2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
                Dim kernel As New CvMat(1, 21, MatrixType.F32C1, data)

                Cv.Normalize(kernel, kernel, 1.0, 0, NormType.L1)
                Cv.Filter2D(srcImg, dstImg, kernel, New CvPoint(0, 0))

                ' (3)結果を表示する
                Using window As New CvWindow("Filter2D", dstImg)
                    Cv.WaitKey(0)
                End Using
            End Using
        End Using

    End Sub
End Module
' End Namespace

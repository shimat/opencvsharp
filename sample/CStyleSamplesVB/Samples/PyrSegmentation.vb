Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 画像ピラミッドを用いた画像の領域分割
''' </summary>
''' <remarks>http://opencv.jp/sample/segmentation_and_connection.html#pyrsegm</remarks>
Friend Module PyrSegmentation
    Public Sub Start()
        ' cvPyrSegmentation
        ' レベルを指定して画像ピラミッドを作成し，その情報を用いて画像のセグメント化を行なう．

        Const threshold1 As Double = 255.0
        Const threshold2 As Double = 50.0

        ' (1)画像の読み込み
        Using srcImg As New IplImage(FilePath.Image.Goryokaku, LoadMode.AnyDepth Or LoadMode.AnyColor)
            ' level1から4それぞれでやってみる
            Dim dstImg(3) As IplImage
            For level As Integer = 0 To dstImg.Length - 1
                ' (2)領域分割のためにROIをセットする
                Dim roi As New CvRect() With {.X = 0, .Y = 0, .Width = srcImg.Width And -(1 << (level + 1)), .Height = srcImg.Height And -(1 << (level + 1))}
                srcImg.ROI = roi
                ' (3)分割結果画像出力用の画像領域を確保し，領域分割を実行
                dstImg(level) = srcImg.Clone()
                Cv.PyrSegmentation(srcImg, dstImg(level), level + 1, threshold1, threshold2)
            Next level

            ' (4)入力画像と分割結果画像の表示
            Dim wSrc As New CvWindow("src", srcImg)
            Dim wDst(dstImg.Length - 1) As CvWindow
            For i As Integer = 0 To dstImg.Length - 1
                wDst(i) = New CvWindow("dst" & i, dstImg(i))
            Next i
            CvWindow.WaitKey()
            CvWindow.DestroyAllWindows()

            For Each item As IplImage In dstImg
                item.Dispose()
            Next item
        End Using

    End Sub
End Module
' End Namespace

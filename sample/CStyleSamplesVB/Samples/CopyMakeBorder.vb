Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 境界線の作成
''' </summary>
''' <remarks>
''' http://opencv.jp/sample/filter_and_color_conversion.html#makeborder
''' </remarks>
Friend Module CopyMakeBorder
    Public Sub Start()
        ' cvCopyMakeBorder
        ' 画像のコピーと境界の作成

        Const offset As Integer = 30

        ' (1)入力画像の読み込み
        Using src As IplImage = Cv.LoadImage(FilePath.Image.Lenna, LoadMode.AnyDepth Or LoadMode.AnyColor)
            ' (2)出力画像の領域の確保
            Dim dstWidth As Integer = src.Width + offset * 2
            Dim dstHeight As Integer = src.Height + offset * 2
            Using dstReplicate As IplImage = Cv.CreateImage(New CvSize(dstWidth, dstHeight), src.Depth, src.NChannels)
                Using dstConstant As IplImage = Cv.CreateImage(New CvSize(dstWidth, dstHeight), src.Depth, src.NChannels)
                    ' (3)境界線の作成
                    Cv.CopyMakeBorder(src, dstReplicate, New CvPoint(offset, offset), BorderType.Replicate)
                    Cv.CopyMakeBorder(src, dstConstant, New CvPoint(offset, offset), BorderType.Constant, CvColor.Red)

                    ' (4)結果を表示する
                    Cv.NamedWindow("Border Replicate", WindowMode.AutoSize)
                    Cv.NamedWindow("Border Constant", WindowMode.AutoSize)
                    Cv.ShowImage("Border Replicate", dstReplicate)
                    Cv.ShowImage("Border Constant", dstConstant)
                    Cv.WaitKey(0)
                    Cv.DestroyAllWindows()
                End Using
            End Using
        End Using
    End Sub
End Module
' End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 距離変換とその可視化
''' </summary>
''' <remarks>
''' http://opencv.jp/sample/special_transforms.html#disttrans
''' </remarks>
Friend Module DistTransform
    Public Sub Start()
        ' cvDistTransform
        ' 入力画像に対して距離変換を行ない，結果を0-255に正規化し可視化する

        ' (1)画像を読み込み
        Using src As New IplImage(FilePath.Image.Lenna, LoadMode.GrayScale)
            If src.Depth <> BitDepth.U8 Then
                Throw New Exception("Invalid Depth")
            End If
            ' (2)処理結果の距離画像出力用の画像領域と表示ウィンドウを確保
            Using dst As New IplImage(src.Size, BitDepth.F32, 1)
                Using dstNorm As New IplImage(src.Size, BitDepth.U8, 1)
                    ' (3)距離画像を計算し，表示用に結果を0-255に正規化する
                    Cv.DistTransform(src, dst, DistanceType.L2, 3, Nothing, Nothing)
                    Cv.Normalize(dst, dstNorm, 0.0, 255.0, NormType.MinMax, Nothing)

                    ' (4)距離画像を表示，キーが押されたときに終了
                    Using TempCvWindowSrc As CvWindow = New CvWindow("Source", WindowMode.AutoSize, src)
                        Using TempCvWindowRes As CvWindow = New CvWindow("Distance Image", WindowMode.AutoSize, dstNorm)
                            CvWindow.WaitKey(0)
                        End Using
                    End Using
                End Using
            End Using
        End Using

    End Sub
End Module
' End Namespace

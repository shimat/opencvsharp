Imports System
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 画像のサイズ変更
''' </summary>
Friend Module Resize
    Public Sub Start()
        ' cvResize
        ' 指定した出力画像サイズに合うように、入力画像のサイズを変更し出力する．

        ' (1)画像を読み込む
        Using src As New IplImage(FilePath.Image.Square5, LoadMode.AnyColor Or LoadMode.AnyDepth)
            ' (2)出力用画像領域の確保を行なう
            Dim size As New CvSize(src.Width * 2, src.Height * 2)
            Using dstNN As New IplImage(size, src.Depth, src.NChannels)
                Using dstCubic As New IplImage(size, src.Depth, src.NChannels)
                    Using dstLinear As New IplImage(size, src.Depth, src.NChannels)
                        Using dstLanczos As New IplImage(size, src.Depth, src.NChannels)
                            ' (3)画像のサイズ変更を行う
                            Cv.Resize(src, dstNN, Interpolation.NearestNeighbor)
                            Cv.Resize(src, dstCubic, Interpolation.Cubic)
                            Cv.Resize(src, dstLinear, Interpolation.Linear)
                            Cv.Resize(src, dstLanczos, Interpolation.Lanczos4)

                            ' (4)結果を表示する
                            Using New CvWindow("src", src)
                                Using New CvWindow("dst NearestNeighbor", dstNN)
                                    Using New CvWindow("dst Cubic", dstCubic)
                                        Using New CvWindow("dst Linear", dstLinear)
                                            Using New CvWindow("dst Lanczos4", dstLanczos)
                                                Cv.WaitKey()
                                            End Using
                                        End Using
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Module
' End Namespace

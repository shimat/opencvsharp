Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 画像ピラミッドの作成
''' </summary>
''' <remarks>http://opencv.jp/sample/pyramid.html#pyramid</remarks>
Friend Module PyrDownUp
    Public Sub Start()
        Using srcImg As New IplImage(FilePath.Image.Lenna, LoadMode.AnyDepth Or LoadMode.AnyColor)
            Using dstImg1 As New IplImage(srcImg.Width \ 2, srcImg.Height \ 2, srcImg.Depth, srcImg.NChannels)
                Using dstImg2 As New IplImage(srcImg.Width * 2, srcImg.Height * 2, srcImg.Depth, srcImg.NChannels)
                    ' (1)入力画像に対する画像ピラミッドを構成
                    Cv.PyrDown(srcImg, dstImg1, CvFilter.Gaussian5x5)
                    Cv.PyrUp(srcImg, dstImg2, CvFilter.Gaussian5x5)

                    ' (2)表示
                    Using TempCvWindow As CvWindow = New CvWindow("Original", srcImg)
                        Using TempCvWindowDown As CvWindow = New CvWindow("PyrDown", dstImg1)
                            Using TempCvWindowUp As CvWindow = New CvWindow("PyrUp", dstImg2)
                                Cv.WaitKey(0)
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Module
' End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' ハフ変換による円検出
''' </summary>
    Friend Module HoughCircles
        Public Sub Start()
        Using imgSrc As New IplImage(FilePath.Image.Walkman, LoadMode.Color)
            Using imgGray As New IplImage(imgSrc.Size, BitDepth.U8, 1)
                Using imgHough As IplImage = imgSrc.Clone()
                    Cv.CvtColor(imgSrc, imgGray, ColorConversion.BgrToGray)
                    Cv.Smooth(imgGray, imgGray, SmoothType.Gaussian, 9)
                    'Cv.Canny(imgGray, imgGray, 75, 150, ApertureSize.Size3);

                    Using storage As New CvMemStorage()
                        Dim seq As CvSeq(Of CvCircleSegment) = imgGray.HoughCircles(storage, HoughCirclesMethod.Gradient, 1, 100, 150, 55, 0, 0)
                        For Each item As CvCircleSegment In seq
                            imgHough.Circle(item.Center, CInt(Math.Truncate(item.Radius)), CvColor.Red, 3)
                        Next item
                    End Using

                    ' (5)検出結果表示用のウィンドウを確保し表示する
                    Using TempCvWindow As CvWindow = New CvWindow("gray", WindowMode.AutoSize, imgGray)
                        Using TempCvWindowHough As CvWindow = New CvWindow("Hough circles", WindowMode.AutoSize, imgHough)
                            CvWindow.WaitKey(0)
                        End Using
                    End Using
                End Using
            End Using
        End Using
        End Sub
    End Module
' End Namespace

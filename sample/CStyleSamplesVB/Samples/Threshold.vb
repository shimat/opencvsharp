Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 2値化
''' </summary>
    Friend Module Threshold
        Public Sub Start()
        Using src As New IplImage(FilePath.Image.Lenna, LoadMode.Color)
            Using srcGray As New IplImage(src.Size, BitDepth.U8, 1)
                Using dst As New IplImage(src.Size, BitDepth.U8, 1)
                    Using window As New CvWindow("SampleThreshold")
                        src.CvtColor(srcGray, ColorConversion.BgrToGray)
                        srcGray.Smooth(srcGray, SmoothType.Gaussian, 5)
                        Dim threshold As Integer = 90
                        window.CreateTrackbar("threshold", threshold, 255, Sub(pos As Integer)
                                                                               srcGray.Threshold(dst, pos, 255, ThresholdType.Binary)
                                                                               window.Image = dst
                                                                           End Sub)
                        srcGray.Threshold(dst, threshold, 255, ThresholdType.Binary)
                        window.Image = dst
                        CvWindow.WaitKey()
                    End Using
                End Using
            End Using
        End Using
        End Sub
    End Module
' End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' CvAdaptiveSkinDetector sample
''' </summary>
    Friend Module SkinDetector
        ''' <summary>
        ''' 
        ''' </summary>
        Public Sub Start()
        Using imgSrc As New IplImage(FilePath.Image.Balloon, LoadMode.Color)
            Using imgHueMask As New IplImage(imgSrc.Size, BitDepth.U8, 1)
                Using imgDst As IplImage = imgSrc.Clone()
                    Dim detector As New CvAdaptiveSkinDetector(1, MorphingMethod.None)
                    detector.Process(imgSrc, imgHueMask)
                    DisplaySkinPoints(imgHueMask, imgDst, CvColor.Green)

                    Using windowSrc As New CvWindow("src", imgSrc)
                        Using windowDst As New CvWindow("skin", imgDst)
                            Cv.WaitKey(0)
                        End Using
                    End Using
                End Using
            End Using
        End Using
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="imgHueMask"></param>
        ''' <param name="imgRgbDst"></param>
        ''' <param name="color"></param>
        Private Sub DisplaySkinPoints(ByVal imgHueMask As IplImage, ByVal imgRgbDst As IplImage, ByVal color As CvColor)
            If imgHueMask.Size <> imgRgbDst.Size Then
                Throw New ArgumentException()
            End If

            For y As Integer = 0 To imgHueMask.Height - 1
                For x As Integer = 0 To imgHueMask.Width - 1
                    Dim value As Byte = CByte(imgHueMask(y, x).Val0)
                    If value <> 0 Then
                        imgRgbDst(y, x) = color
                    End If
                Next x
            Next y
        End Sub
    End Module
' End Namespace

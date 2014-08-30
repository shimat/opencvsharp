Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Gamma correction
''' </summary>
    Friend Module GammaCorrection
        ''' <summary>
        ''' constructor
        ''' </summary>
        Public Sub Start()
        Using imgSrc As New IplImage(FilePath.Image.Lenna, LoadMode.AnyDepth Or LoadMode.AnyColor)
            Using imgDst0_25 As IplImage = imgSrc.Clone()
                Using imgDst0_5 As IplImage = imgSrc.Clone()
                    Using imgDst2 As IplImage = imgSrc.Clone()
                        CorrectGamma(imgSrc, imgDst0_25, 0.25)
                        CorrectGamma(imgSrc, imgDst0_5, 0.5)
                        CorrectGamma(imgSrc, imgDst2, 2.0)

                        Using New CvWindow("src", imgSrc)
                            Using New CvWindow("gamma = 0.25", imgDst0_25)
                                Using New CvWindow("gamma = 0.5", imgDst0_5)
                                    Using New CvWindow("gamma = 2.0", imgDst2)
                                        Cv.WaitKey(0)
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
        End Sub

        ''' <summary>
        ''' Corrects gamma
        ''' </summary>
        ''' <param name="src"></param>
        ''' <param name="dst"></param>
        ''' <param name="gamma"></param>
        Public Sub CorrectGamma(ByVal src As CvArr, ByVal dst As CvArr, ByVal gamma As Double)
            Dim lut(255) As Byte
            For i As Integer = 0 To lut.Length - 1
                lut(i) = CByte(Math.Pow(i / 255.0, 1.0 / gamma) * 255.0)
            Next i

            Cv.LUT(src, dst, lut)
        End Sub
    End Module
' End Namespace

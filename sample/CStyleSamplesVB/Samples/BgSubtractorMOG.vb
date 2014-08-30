Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 
''' </summary>
Friend Module BgSubtractorMOG
    Public Sub Start()
        Using capture As New CvCapture(FilePath.Movie.Hara) ' specify your movie file
            Using mog As New BackgroundSubtractorMOG()
                Using windowSrc As New CvWindow("src")
                    Using windowDst As New CvWindow("dst")
                        Dim imgFrame As IplImage
                        Using imgFg As New Mat(capture.FrameWidth, capture.FrameHeight, MatrixType.U8C1)
                            'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
                            'ORIGINAL LINE: while ((imgFrame = capture.QueryFrame()) != null)
                            imgFrame = capture.QueryFrame()
                            Do While imgFrame IsNot Nothing
                                mog.Run(New Mat(imgFrame, False), imgFg, 0.01)

                                windowSrc.Image = imgFrame
                                windowDst.Image = imgFg.ToIplImage()
                                Cv.WaitKey(50)
                                imgFrame = capture.QueryFrame()
                            Loop
                        End Using

                    End Using
                End Using
            End Using
        End Using
    End Sub
End Module
' End Namespace
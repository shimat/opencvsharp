Imports System
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' CvContourScanner Sample
''' </summary>
Friend Module ContourScanner
    Public Sub Start()
        ' create IplImages
        Using src As New IplImage(FilePath.Image.Lenna, LoadMode.Color)
            Using gray As New IplImage(src.Size, BitDepth.U8, 1)
                Using canny As New IplImage(src.Size, BitDepth.U8, 1)
                    Using result As IplImage = src.Clone()
                        ' detect edges
                        Cv.CvtColor(src, gray, ColorConversion.BgrToGray)
                        Cv.Canny(gray, canny, 50, 200)

                        ' find all contours
                        Using storage As New CvMemStorage()
                            ' find contours by CvContourScanner
                            Using scanner As New CvContourScanner(canny, storage, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple)
                                For Each c As CvSeq(Of CvPoint) In scanner
                                    result.DrawContours(c, CvColor.Red, CvColor.Green, 0, 3, LineType.AntiAlias)
                                Next c
                            End Using
                        End Using

                        ' show canny and result
                        Using New CvWindow("ContourScanner canny", canny)
                            Using New CvWindow("ContourScanner result", result)
                                Cv.WaitKey()
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Module
' End Namespace

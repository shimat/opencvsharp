Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Saving image using the format-specific save parameters
''' </summary>
Friend Module SaveImage
    Public Sub Start()
        Using img As New IplImage(FilePath.Image.Depth16Bit, LoadMode.Color)
            ' JPEG quality test
            img.SaveImage("q000.jpg", New JpegEncodingParam(0))
            img.SaveImage("q025.jpg", New JpegEncodingParam(25))
            img.SaveImage("q050.jpg", New JpegEncodingParam(50))
            img.SaveImage("q075.jpg", New JpegEncodingParam(75))
            img.SaveImage("q100.jpg", New JpegEncodingParam(100))

            Using q000 As New IplImage("q000.jpg", LoadMode.Color)
                Using q025 As New IplImage("q025.jpg", LoadMode.Color)
                    Using q050 As New IplImage("q050.jpg", LoadMode.Color)
                        Using q075 As New IplImage("q075.jpg", LoadMode.Color)
                            Using q100 As New IplImage("q100.jpg", LoadMode.Color)
                                Using w000 As New CvWindow("quality 0", q000)
                                    Using w025 As New CvWindow("quality 25", q025)
                                        Using w050 As New CvWindow("quality 50", q050)
                                            Using w075 As New CvWindow("quality 75", q075)
                                                Using w100 As New CvWindow("quality 100", q100)
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
        End Using
    End Sub
End Module
' End Namespace

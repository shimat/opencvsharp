Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 
''' </summary>
Friend Module Image2Stream
    Public Sub Start()
        ' Stream -> IplImage
        Using stream As New FileStream(FilePath.Image.Lenna, FileMode.Open)
            Using img As IplImage = IplImage.FromStream(stream, LoadMode.Color)
                CvWindow.ShowImages(img)

                ' IplImage -> Stream
                Using ms As New MemoryStream()
                    img.ToStream(ms, ".tiff")
                    ms.ToString()
                End Using
            End Using
        End Using

        ' Stream -> CvMat
        Using stream As New FileStream(FilePath.Image.Lenna, FileMode.Open)
            Using mat As CvMat = CvMat.FromStream(stream, LoadMode.Color)
                mat.ToString()

                ' CvMat -> Stream
                Using ms As New MemoryStream()
                    mat.ToStream(ms, ".bmp")
                    ms.ToString()
                End Using
            End Using
        End Using
    End Sub
End Module
' End Namespace

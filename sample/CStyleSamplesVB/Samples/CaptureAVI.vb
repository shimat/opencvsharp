'
' * (C) 2008-2013 Schima
' * This code is licenced under the LGPL.
' 

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' AVIファイルのキャプチャ
''' </summary>
Friend Module CaptureAVI
    Public Sub Start()
        Using cap As CvCapture = CvCapture.FromFile(FilePath.Movie.Hara)
            Using w As New CvWindow("SampleCapture")
                Dim interval As Integer = CInt(Math.Truncate(1000 / cap.Fps))
                Do
                    Dim image As IplImage = cap.QueryFrame()
                    If image Is Nothing Then
                        Exit Do
                    End If
                    w.Image = image
                    If Cv.WaitKey(interval) > 0 Then
                        Exit Do
                    End If
                Loop
            End Using
        End Using
    End Sub
End Module
' End Namespace

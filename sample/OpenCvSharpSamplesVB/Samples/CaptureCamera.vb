Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' カメラのキャプチャ
    ''' </summary>
    Friend Module CaptureCamera
        Public Sub Start()
            Using cap As CvCapture = CvCapture.FromCamera(0) ' device type + camera index
                Using w As New CvWindow("SampleCapture")
                    Do While CvWindow.WaitKey(10) < 0
                        w.Image = cap.QueryFrame()
                    Loop
                End Using
            End Using
        End Sub
    End Module
' End Namespace

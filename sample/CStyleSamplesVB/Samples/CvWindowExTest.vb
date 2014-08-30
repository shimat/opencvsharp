Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.UserInterface

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Pure C# implementation of CvWindow
''' </summary>
Friend Module CvWindowExTest
    Private image As IplImage
    Private window As CvWindowEx

    Public Sub Start()
        image = New IplImage(FilePath.Image.Lenna)

        window = New CvWindowEx(image)
        Using window
            window.Text = "CvWindowEx Test"
            window.CreateTrackbar("foo", 127, 255, AddressOf OnTrack)
            OnTrack(127)
            CvWindowEx.WaitKey()
        End Using
    End Sub

    Private Sub OnTrack(ByVal pos As Integer)
        Using tmp As IplImage = image.Clone()
            Cv.Threshold(image, tmp, pos, 255, ThresholdType.Binary)
            window.ShowImage(tmp)
        End Using
    End Sub
End Module
' End Namespace

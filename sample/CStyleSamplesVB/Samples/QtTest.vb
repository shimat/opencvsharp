Imports System
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Qt highgui test
''' </summary>
    Friend Module QtTest
        Public Sub Start()
            Using window As New CvWindow("window", WindowMode.ExpandedGui)
            Using img As New IplImage(FilePath.Image.Lenna, LoadMode.Color)
                If CvWindow.HasQt Then
                    ' cvAddText
                    Dim font As CvFont = New CvFontQt("MS UI Gothic", 48, CvColor.Red, FontWeight.Bold, FontStyle.Italic)
                    img.AddText("Hello Qt!!", New CvPoint(50, img.Height - 50), font)

                    ' cvDisplayOverlay, cvDisplayStatusBar
                    window.DisplayOverlay("overlay text", 2000)
                    window.DisplayStatusBar("statusbar text", 3000)

                    ' cvCreateButton
                    Dim buttonCallback As CvButtonCallback = Sub(state As Integer, userdata As Object) Console.WriteLine("Button state:{0} userdata:{1} ({2})", state, userdata, userdata.GetType())
                    Cv.CreateButton("button1", buttonCallback, "my userstate", ButtonType.Checkbox, 0)
                    Cv.CreateButton("button2", buttonCallback, 12345.6789, ButtonType.Checkbox, 0)

                    ' cvSaveWindowParameters
                    'window.SaveWindowParameters();
                End If

                window.ShowImage(img)

                ' cvCreateTrackbar2
                Dim trackbarCallback As CvTrackbarCallback2 = Sub(pos As Integer, userdata As Object) Console.WriteLine("Trackbar pos:{0} userdata:{1} ({2})", pos, userdata, userdata.GetType())
                window.CreateTrackbar2("trackbar1", 128, 256, trackbarCallback, "foobar")

                Cv.WaitKey()
            End Using
            End Using
        End Sub
    End Module
' End Namespace

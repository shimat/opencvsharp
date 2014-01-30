Imports OpenCvSharp

Public Class HelloWorld : Implements ISample

    Public Sub Run() Implements ISample.Run

        Using img As New IplImage("Data\\Image\\lenna.png")
            CvWindow.ShowImages(img)
        End Using

    End Sub

End Class

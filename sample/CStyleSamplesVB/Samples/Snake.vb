Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 輪郭検出
''' </summary>
''' <remarks>http://opencv.jp/sample/object_tracking.html#snake</remarks>
Friend Module Snake
    Public Sub Start()
        Using src As New IplImage(FilePath.Image.Cake, LoadMode.GrayScale), _
             dst As New IplImage(src.Size, BitDepth.U8, 3)
            Dim contour(99) As CvPoint
            Dim center As New CvPoint(src.Width \ 2, src.Height \ 2)
            For i As Integer = 0 To contour.Length - 1
                contour(i).X = CInt(Math.Truncate(center.X * Math.Cos(2 * Math.PI * i \ contour.Length) + center.X))
                contour(i).Y = CInt(Math.Truncate(center.Y * Math.Sin(2 * Math.PI * i \ contour.Length) + center.Y))
            Next i
            Form1.TextBox1.AppendText("Press any key to snake")
            Form1.TextBox1.AppendText(Environment.NewLine & "Esc - quit")
            Using w As New CvWindow()
                Do
                    src.SnakeImage(contour, 0.45F, 0.35F, 0.2F, New CvSize(15, 15), New CvTermCriteria(1), True)
                    src.CvtColor(dst, ColorConversion.GrayToRgb)
                    For i As Integer = 0 To contour.Length - 2
                        dst.Line(contour(i), contour(i + 1), New CvColor(255, 0, 0), 2)
                    Next i
                    dst.Line(contour(contour.Length - 1), contour(0), New CvColor(255, 0, 0), 2)
                    w.Image = dst
                    Dim key As Integer = CvWindow.WaitKey()
                    If key = 27 Then
                        Exit Do
                    End If
                Loop
            End Using
        End Using
    End Sub
End Module
' End Namespace

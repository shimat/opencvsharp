Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' for Binarizer
Imports OpenCvSharp.Extensions

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Various Binarization Methods
''' </summary>
    Friend Module BinarizationMethods
        Public Sub Start()
        Using imgSrc As New IplImage(FilePath.Image.Binarization, LoadMode.GrayScale), _
             imgGauss As IplImage = imgSrc.Clone(), _
         imgNiblack As New IplImage(imgSrc.Size, BitDepth.U8, 1), _
         imgSauvola As New IplImage(imgSrc.Size, BitDepth.U8, 1), _
         imgBernsen As New IplImage(imgSrc.Size, BitDepth.U8, 1)
            'Cv.Smooth(imgSrc, imgGauss, SmoothType.Gaussian, 9);
            'Cv.EqualizeHist(imgGauss, imgGauss);
            Dim K As Double = 0
            Dim Size As Integer = 0
            Dim sw As Stopwatch = Stopwatch.StartNew()
            Size = 31
            K = 0.2
            Binarizer.NiblackFast(imgGauss, imgNiblack, Size, K)
            Form1.TextBox1.AppendText("Niblack : " & sw.ElapsedMilliseconds.ToString & " ms")
            sw.Reset()
            sw.Start()
            Size = 31
            K = 0.9
            Const R As Double = 32
            Binarizer.SauvolaFast(imgGauss, imgSauvola, Size, K, R)
            Form1.TextBox1.AppendText(Environment.NewLine & "Sauvola: " & sw.ElapsedMilliseconds.ToString & " ms")
            sw.Reset()
            sw.Start()
            Size = 31
            Const ContrastMin As Byte = 15
            Const BgThreshold As Byte = 127
            Binarizer.Bernsen(imgGauss, imgBernsen, Size, ContrastMin, BgThreshold)
            Form1.TextBox1.AppendText(Environment.NewLine & "Bernsen : " & sw.ElapsedMilliseconds.ToString & " ms")

            Using New CvWindow("src", imgSrc)
                Using New CvWindow("niblack", imgNiblack)
                    Using New CvWindow("sauvola", imgSauvola)
                        Using New CvWindow("bernsen", imgBernsen)
                            Cv.WaitKey()
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
    End Module
' End Namespace

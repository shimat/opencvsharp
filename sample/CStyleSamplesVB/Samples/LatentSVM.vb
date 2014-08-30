Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' LatentSVM
''' </summary>
Friend Module LatentSVM
    Public Sub Start()
        Using detector As New CvLatentSvmDetector(FilePath.Text.LatentSvmCat)
            Using imageSrc As New IplImage(FilePath.Image.Cat, LoadMode.Color)
                Using imageDst As IplImage = imageSrc.Clone()
                    Using storage As New CvMemStorage()
                        Form1.TextBox1.AppendText(String.Format("Running LatentSVM..."))
                        Dim watch As Stopwatch = Stopwatch.StartNew()

                        Dim result As CvSeq(Of CvObjectDetection) = detector.DetectObjects(imageSrc, storage, 0.5F, 2)

                        watch.Stop()
                        Form1.TextBox1.AppendText(Environment.NewLine & String.Format("Elapsed time: {0}ms", watch.ElapsedMilliseconds))

                        For Each detection As CvObjectDetection In result
                            Dim boundingBox As CvRect = detection.Rect
                            imageDst.Rectangle(New CvPoint(boundingBox.X, boundingBox.Y), New CvPoint(boundingBox.X + boundingBox.Width, boundingBox.Y + boundingBox.Height), CvColor.Red, 3)
                        Next detection

                        Using TempCvWindow As CvWindow = New CvWindow("LatentSVM result", imageDst)
                            Cv.WaitKey()
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Module
' End Namespace

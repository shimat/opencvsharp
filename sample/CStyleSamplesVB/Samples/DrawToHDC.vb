Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports OpenCvSharp
Imports OpenCvSharp.Extensions

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Draws from IplImage to HDC
''' </summary>
    Friend Module DrawToHDC
        Public Sub Start()
            Dim roi As New CvRect(320, 260, 100, 100) ' region of roosevelt's face

        Using src As New IplImage(FilePath.Image.Yalta, LoadMode.Color), _
             dst As New IplImage(roi.Size, BitDepth.U8, 3)
            src.ROI = roi

            Using bitmap As New Bitmap(roi.Width, roi.Height, PixelFormat.Format32bppArgb), _
                     g As Graphics = Graphics.FromImage(bitmap)
                'BitmapConverter.DrawToGraphics(src, g, new CvRect(new CvPoint(0, 0), roi.Size));
                Dim hdc As IntPtr = g.GetHdc()
                BitmapConverter.DrawToHdc(src, hdc, New CvRect(New CvPoint(0, 0), roi.Size))
                g.ReleaseHdc(hdc)

                g.DrawString("Roosevelt", New Font(FontFamily.GenericSerif, 12), Brushes.Red, 20, 0)
                g.DrawEllipse(New Pen(Color.Red, 4), New Rectangle(20, 20, roi.Width \ 2, roi.Height \ 2))

                dst.CopyFrom(bitmap)
            End Using

            src.ResetROI()

            Using TempCvWindow As CvWindow = New CvWindow("src", src), _
                 TempCvWindowDst As CvWindow = New CvWindow("dst", dst)
                Cv.WaitKey()
            End Using
        End Using
    End Sub
    End Module
' End Namespace

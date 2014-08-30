Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Threading
Imports OpenCvSharp
Imports OpenCvSharp.Extensions

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' System.Windows.Media.Imaging.WriteableBitmapへの変換
''' </summary>
Friend Module ConvertToWriteableBitmap
    Public Sub Start()
        Dim wb As WriteableBitmap = Nothing

        ' OpenCVによる画像処理 (Threshold)
        Using src As New IplImage(FilePath.Image.Lenna, LoadMode.GrayScale)
            Using dst As New IplImage(src.Size, BitDepth.U8, 1)
                src.Smooth(src, SmoothType.Gaussian, 5)
                src.Threshold(dst, 0, 255, ThresholdType.Otsu)
                ' IplImage -> WriteableBitmap
                wb = dst.ToWriteableBitmap(PixelFormats.BlackWhite)
                'wb = WriteableBitmapConverter.ToWriteableBitmap(dst, PixelFormats.BlackWhite);
            End Using
        End Using

        ' WPFのWindowに表示してみる
        Dim image As Image = New Image With {.Source = wb}
        Dim window As Window = New Window With {.Title = "from IplImage to WriteableBitmap", .Width = wb.PixelWidth, .Height = wb.PixelHeight, .Content = image}

        Dim app As New Application()
        app.Run(window)
    End Sub
End Module
' End Namespace

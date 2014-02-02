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

Namespace OpenCvSharpSamples
	''' <summary>
	''' System.Windows.Media.Imaging.BitmapSourceへの変換
	''' </summary>
    Friend Module ConvertToBitmapSource
        Public Sub Start()
            Dim bs As BitmapSource = Nothing

            ' OpenCVによる画像処理 (Threshold)
            Using src As New IplImage([Const].ImageLenna, LoadMode.GrayScale)
                Using dst As New IplImage(src.Size, BitDepth.U8, 1)
                    src.Smooth(src, SmoothType.Gaussian, 5)
                    src.Threshold(dst, 0, 255, ThresholdType.Otsu)
                    ' IplImage -> BitmapSource
                    bs = dst.ToBitmapSource()
                    'bs = BitmapSourceConverter.ToBitmapSource(dst);
                End Using
            End Using

            ' WPFのWindowに表示してみる
            Dim image As Image = New Image With {.Source = bs}
            Dim window As Window = New Window With {.Title = "from IplImage to BitmapSource", .Width = bs.PixelWidth, .Height = bs.PixelHeight, .Content = image}

            Dim app As New Application()
            app.Run(window)
        End Sub
    End Module
End Namespace

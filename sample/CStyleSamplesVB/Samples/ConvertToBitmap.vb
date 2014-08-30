Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports OpenCvSharp
Imports OpenCvSharp.Extensions

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' System.Drawing.Bitmapへの変換
''' </summary>
Friend Module ConvertToBitmap
    Public Sub Start()
        Dim bitmap As Bitmap = Nothing

        ' OpenCVによる画像処理 (Threshold)
        Using src As New IplImage(FilePath.Image.Lenna, LoadMode.GrayScale)
            Using dst As New IplImage(src.Size, BitDepth.U8, 1)
                src.Smooth(src, SmoothType.Gaussian, 5)
                src.Threshold(dst, 0, 255, ThresholdType.Otsu)
                ' IplImage -> Bitmap
                bitmap = dst.ToBitmap()
                'bitmap = BitmapConverter.ToBitmap(dst);
            End Using
        End Using

        ' WindowsFormに表示してみる
        Dim form As Form = New Form With {.Text = "from IplImage to Bitmap", .ClientSize = bitmap.Size}
        Dim pictureBox As PictureBox = New PictureBox With {.Dock = DockStyle.Fill, .SizeMode = PictureBoxSizeMode.StretchImage, .Image = bitmap}
        '            
        '            Imageプロパティに設定するのはもしかするとちょっと微妙、できればこのように
        '            pictureBox.Paint += delegate(object sender, PaintEventArgs e) {
        '                e.Graphics.DrawImage(bitmap, new Rectangle(new Point(0, 0), form.ClientSize));
        '            };
        '            
        form.Controls.Add(pictureBox)
        form.ShowDialog()

        form.Dispose()
        bitmap.Dispose()
    End Sub

End Module
' End Namespace

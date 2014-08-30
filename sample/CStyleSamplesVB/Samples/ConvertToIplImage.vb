Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports OpenCvSharp
Imports OpenCvSharp.Extensions


' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Conversion from Bitmap/WriteableBitmap to IplImage
''' </summary>
Friend Module ConvertToIplImage
    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub Start()
        TestBitmap()
        TestWriteableBitmap()
        TestWriteableBitmapBgr32()
    End Sub

    ''' <summary>
    ''' Bitmap -> IplImage
    ''' </summary>
    Private Sub TestBitmap()
        Using bitmap As New Bitmap(FilePath.Image.Fruits)
            Dim ipl As New IplImage(bitmap.Width, bitmap.Height, BitDepth.U8, 3)

            'ipl = bitmap.ToIplImage();
            ipl.CopyFrom(bitmap)

            Using TempCvWindow As CvWindow = New CvWindow("from Bitmap to IplImage", ipl)
                Cv.WaitKey()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' WriteableBitmap -> IplImage
    ''' </summary>
    Private Sub TestWriteableBitmap()
        ' Load 16-bit image to WriteableBitmap
        Dim decoder As New PngBitmapDecoder(New Uri(FilePath.Image.Depth16Bit, UriKind.Relative), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
        Dim bs As BitmapSource = decoder.Frames(0)
        Dim wb As New WriteableBitmap(bs)

        ' Convert wb into IplImage
        Dim ipl As IplImage = wb.ToIplImage()
        'IplImage ipl32 = new IplImage(wb.PixelWidth, wb.PixelHeight, BitDepth.U16, 1);
        'WriteableBitmapConverter.ToIplImage(wb, ipl32);

        ' Print pixel values
        For i As Integer = 0 To ipl.Height - 1
            Form1.TextBox1.AppendText(Environment.NewLine & String.Format("x:{0} y:{1} v:{2}", i, i, ipl(i, 128)))
        Next i

        ' Show 16-bit IplImage
        Using TempCvWindow As CvWindow = New CvWindow("from WriteableBitmap to IplImage", ipl)
            Cv.WaitKey()
        End Using
    End Sub

    ''' <summary>
    ''' WriteableBitmap (Format = Bgr32) -> IplImage
    ''' </summary>
    Private Sub TestWriteableBitmapBgr32()
        ' loads color image
        Dim decoder As New PngBitmapDecoder(New Uri(FilePath.Image.Lenna, UriKind.Relative), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
        Dim bs As BitmapSource = decoder.Frames(0)

        ' converts pixelformat from Bgr24 to Bgr32 (for this test)
        Dim fcb As New FormatConvertedBitmap()
        fcb.BeginInit()
        fcb.Source = bs
        fcb.DestinationFormat = PixelFormats.Gray8
        fcb.EndInit()

        ' creates WriteableBitmap
        Dim wb As New WriteableBitmap(fcb)

        ' shows wb 
        '            
        '            var image = new System.Windows.Controls.Image { Source = wb };
        '            var window = new System.Windows.Window
        '            {
        '                Title = string.Format("wb (Format:{0})", wb.Format),
        '                Width = wb.PixelWidth,
        '                Height = wb.PixelHeight,
        '                Content = image
        '            };
        '            var app = new System.Windows.Application();
        '            app.Run(window);
        '            //

        ' convert wb into IplImage
        Dim ipl As IplImage = wb.ToIplImage()
        'IplImage ipl32 = new IplImage(wb.PixelWidth, wb.PixelHeight, BitDepth.U16, 1);
        'WriteableBitmapConverter.ToIplImage(wb, ipl32);

        Using TempCvWindow As CvWindow = New CvWindow("from WriteableBitmap(Bgr32) to IplImage", ipl)
            Cv.WaitKey()
        End Using
    End Sub
End Module
' End Namespace

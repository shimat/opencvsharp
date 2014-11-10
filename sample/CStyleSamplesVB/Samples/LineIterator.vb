Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' CvLineIterator sample
''' </summary>
''' <remarks>http://opencv.jp/opencv-1.1.0/document/opencvref_cxcore_point.html#decl_cvInitLineIterator</remarks>
    Friend Module LineIterator
        Public Sub Start()
        Using image As New IplImage(FilePath.Image.Lenna, LoadMode.Color)
            Dim pt1 As New CvPoint(30, 100)
            Dim pt2 As New CvPoint(500, 400)

            Dim result As CvScalar
            result = SumLinePixelsNative(image, pt1, pt2) ' native style
            result = SumLinePixelsManaged(image, pt1, pt2) ' wrapper style
            Form1.TextBox1.AppendText(result.ToString())

            Cv.Line(image, pt1, pt2, CvColor.Red, 3, LineType.Link8)

            Using TempCvWindow As CvWindow = New CvWindow("line", image)
                Cv.WaitKey()
            End Using
        End Using
        End Sub

        ''' <summary>
        ''' Calculate sum of line pixels (native style)
        ''' </summary>
        ''' <param name="image"></param>
        ''' <param name="pt1"></param>
        ''' <param name="pt2"></param>
        ''' <returns></returns>
        Private Function SumLinePixelsNative(ByVal image As IplImage, ByVal pt1 As CvPoint, ByVal pt2 As CvPoint) As CvScalar
            Dim [iterator] As CvLineIterator
            Dim blue_sum As Integer = 0, green_sum As Integer = 0, red_sum As Integer = 0
        Dim count As Integer = Cv.InitLineIterator(image, pt1, pt2, [iterator], PixelConnectivity.Connectivity8, False)

            For i As Integer = 0 To count - 1
                blue_sum += Marshal.ReadByte([iterator].Ptr, 0) 'blue_sum += iterator.ptr[0];
                green_sum += Marshal.ReadByte([iterator].Ptr, 1) 'green_sum += iterator.ptr[1];
                red_sum += Marshal.ReadByte([iterator].Ptr, 2) 'red_sum += iterator.ptr[2];

                Cv.NEXT_LINE_POINT([iterator])

                PrintCoordinate(image, [iterator])
            Next i
            Return New CvScalar(blue_sum, green_sum, red_sum)
        End Function

        ''' <summary>
        ''' Calculate sum of line pixels (wrapper style)
        ''' </summary>
        ''' <param name="image"></param>
        ''' <param name="pt1"></param>
        ''' <param name="pt2"></param>
        ''' <returns></returns>
        Private Function SumLinePixelsManaged(ByVal image As IplImage, ByVal pt1 As CvPoint, ByVal pt2 As CvPoint) As CvScalar
            Dim blue_sum As Double = 0, green_sum As Double = 0, red_sum As Double = 0
        Dim [iterator] As New CvLineIterator(image, pt1, pt2, PixelConnectivity.Connectivity8, False)

            For Each pixel As CvScalar In [iterator]
                blue_sum += pixel.Val0 'blue_sum += iterator.ptr[0];
                green_sum += pixel.Val1 'green_sum += iterator.ptr[1];
                red_sum += pixel.Val2 'red_sum += iterator.ptr[2];

                PrintCoordinate(image, [iterator])
            Next pixel
            Return New CvScalar(blue_sum, green_sum, red_sum)
        End Function

        ''' <summary>
        ''' Print current pixel's coordinate
        ''' </summary>
        ''' <param name="image"></param>
        ''' <param name="iterator"></param>
        Private Sub PrintCoordinate(ByVal image As IplImage, ByVal [iterator] As CvLineIterator)
            ' ROIは設定されていないと仮定している．もし設定されている場合には考慮する必要がある．
            Dim offset As Integer = [iterator].Ptr.ToInt32() - image.ImageData.ToInt32()
            Dim y As Integer = CType((offset / image.WidthStep), Integer)
            Dim x As Integer = CType(((offset - y * image.WidthStep) / (3 * Len(New Byte))), Integer) ' Pixel size
            Form1.TextBox1.AppendText(Environment.NewLine & String.Format("(x:{0}, y:{1})", x, y))
        End Sub
    End Module
' End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Maximally Stable Extremal Regions
''' </summary>
Friend Module MSERSample
    Public Sub Start()
        Using imgSrc As New IplImage(FilePath.Image.Distortion, LoadMode.Color), _
             imgGray As New IplImage(imgSrc.Size, BitDepth.U8, 1), _
         imgDst As IplImage = imgSrc.Clone()
            Cv.CvtColor(imgSrc, imgGray, ColorConversion.BgrToGray)

            'CStyleMSER(imgGray, imgRender);  // C style
            CppStyleMSER(imgGray, imgDst) ' C++ style

            Using TempCvWindow As CvWindow = New CvWindow("MSER src", imgSrc), _
                 TempCvWindowGray As CvWindow = New CvWindow("MSER gray", imgGray), _
                 TempCvWindowDst As CvWindow = New CvWindow("MSER dst", imgDst)
                Cv.WaitKey()
            End Using
        End Using

    End Sub

    ''' <summary>
    ''' Extracts MSER by C-style code (cvExtractMSER)
    ''' </summary>
    ''' <param name="imgGray"></param>
    ''' <param name="imgRender"></param>
    Private Sub CStyleMSER(ByVal imgGray As IplImage, ByVal imgDst As IplImage)
        Using storage As New CvMemStorage()
            Dim contours() As CvContour
            Dim param As New CvMSERParams()
            Cv.ExtractMSER(imgGray, Nothing, contours, storage, param)

            For Each c As CvContour In contours
                Dim color As CvColor = CvColor.Random()
                For i As Integer = 0 To c.Total - 1
                    imgDst.Circle(c(i).Value, 1, color)
                Next i
            Next c
        End Using
    End Sub

    ''' <summary>
    ''' Extracts MSER by C++-style code (cv::MSER)
    ''' </summary>
    ''' <param name="imgGray"></param>
    ''' <param name="imgDst"></param>
    Private Sub CppStyleMSER(ByVal imgGray As IplImage, ByVal imgDst As IplImage)
        Dim mser As New MSER()
        Dim contours()() As Point = mser.Run(New Mat(imgGray, False), Nothing) ' operator()
        For Each p As Point() In contours
            Dim color As CvColor = CvColor.Random()
            For i As Integer = 0 To p.Length - 1
                imgDst.Circle(p(i), 1, color)
            Next i
        Next p
    End Sub
End Module
' End Namespace

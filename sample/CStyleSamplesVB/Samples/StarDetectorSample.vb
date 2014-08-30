Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Retrieves keypoints using the StarDetector algorithm.
''' </summary>
Friend Module StarDetectorSample
    Public Sub Start()
        Using img As New IplImage(FilePath.Image.Lenna, LoadMode.GrayScale), _
                 cimg As New IplImage(img.Size, BitDepth.U8, 3)
            Cv.CvtColor(img, cimg, ColorConversion.GrayToBgr)

            CStyleStarDetector(img, cimg)

            Using TempCvWindow As CvWindow = New CvWindow("img", img), _
                 TempCvWindowFeatures As CvWindow = New CvWindow("features", cimg)
                Cv.WaitKey()

            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Extracts keypoints by C-style code (cvGetStarKeypoints)
    ''' </summary>
    ''' <param name="img"></param>
    ''' <param name="cimg"></param>
    Private Sub CStyleStarDetector(ByVal img As IplImage, ByVal cimg As IplImage)
        Using storage As New CvMemStorage(0)
            Dim param As New CvStarDetectorParams(45)
            Dim keypoints As CvSeq(Of CvStarKeypoint) = Cv.GetStarKeypoints(img, storage, param)

            If keypoints IsNot Nothing Then
                For i As Integer = 0 To keypoints.Total - 1
                    Dim kpt As CvStarKeypoint = keypoints(i).Value
                    Dim r As Integer = kpt.Size / 2
                    'Cv.Circle(cimg, kpt.Pt, r, new CvColor(0, 255, 0));
                    'Cv.Line(cimg, new CvPoint(kpt.Pt.X + r, kpt.Pt.Y + r), new CvPoint(kpt.Pt.X - r, kpt.Pt.Y - r), new CvColor(0, 255, 0));
                    'Cv.Line(cimg, new CvPoint(kpt.Pt.X - r, kpt.Pt.Y + r), new CvPoint(kpt.Pt.X + r, kpt.Pt.Y - r), new CvColor(0, 255, 0));
                    cimg.DrawMarker(kpt.Pt.X, kpt.Pt.Y, CvColor.Green, MarkerStyle.CircleAndTiltedCross, kpt.Size)
                Next i
            End If
        End Using
    End Sub

End Module
' End Namespace

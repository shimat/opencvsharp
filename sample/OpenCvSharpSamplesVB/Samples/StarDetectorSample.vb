Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' Retrieves keypoints using the StarDetector algorithm.
    ''' </summary>
    Friend Module StarDetectorSample
        Public Sub Start()
            Using img As New IplImage([Const].ImageLenna, LoadMode.GrayScale)
                Using cimg As New IplImage(img.Size, BitDepth.U8, 3)
                    Cv.CvtColor(img, cimg, ColorConversion.GrayToBgr)

                    'CStyleStarDetector(img, cimg);      // C-style
                    CppStyleStarDetector(img, cimg) ' C++-style

                    Using TempCvWindow As CvWindow = New CvWindow("img", img)
                        Using TempCvWindowFeatures As CvWindow = New CvWindow("features", cimg)
                            Cv.WaitKey()
                        End Using
                    End Using
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

        ''' <summary>
        ''' Extracts keypoints by C++-style code (cv::StarDetector)
        ''' </summary>
        ''' <param name="img"></param>
        ''' <param name="cimg"></param>
        Private Sub CppStyleStarDetector(ByVal img As IplImage, ByVal cimg As IplImage)
            Dim src As New Mat(img, False)
            Dim dst As New Mat(cimg, False)
            Dim detector As New StarDetector(45)
            Dim keypoints() As KeyPoint = detector.GetKeyPoints(src)

            If keypoints IsNot Nothing Then
                For Each kpt As KeyPoint In keypoints
                    Dim r As Single = kpt.Size / 2
                    CvCpp.Circle(dst, kpt.Pt, CInt(Math.Truncate(r)), New CvColor(0, 255, 0), 1, LineType.Link8, 0)
                    CvCpp.Line(dst, New CvPoint2D32f(kpt.Pt.X + r, kpt.Pt.Y + r), New CvPoint2D32f(kpt.Pt.X - r, kpt.Pt.Y - r), New CvColor(0, 255, 0), 1, LineType.Link8, 0)
                    CvCpp.Line(dst, New CvPoint2D32f(kpt.Pt.X - r, kpt.Pt.Y + r), New CvPoint2D32f(kpt.Pt.X + r, kpt.Pt.Y - r), New CvColor(0, 255, 0), 1, LineType.Link8, 0)
                Next kpt
            End If

        End Sub
    End Module
' End Namespace

Imports System
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

            CppStyleStarDetector(img, cimg) ' C++-style

            Using New CvWindow("img", img)
                Using New CvWindow("features", cimg)
                    Cv.WaitKey()
                End Using
            End Using
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
        Dim keypoints() As KeyPoint = detector.Run(src)

        If keypoints IsNot Nothing Then
            For Each kpt As KeyPoint In keypoints
                Dim r As Single = kpt.Size / 2
                Dim a = kpt.Pt

                Cv2.Circle(dst, kpt.Pt, CInt(Math.Truncate(r)), New Scalar(0, 255, 0), 1, LineType.Link8, 0)
                Cv2.Line(dst, New Point(kpt.Pt.X + r, kpt.Pt.Y + r), New Point(kpt.Pt.X - r, kpt.Pt.Y - r), New Scalar(0, 255, 0), 1, LineType.Link8, 0)
                Cv2.Line(dst, New Point(kpt.Pt.X - r, kpt.Pt.Y + r), New Point(kpt.Pt.X + r, kpt.Pt.Y - r), New Scalar(0, 255, 0), 1, LineType.Link8, 0)
            Next kpt
        End If

    End Sub
End Module
' End Namespace

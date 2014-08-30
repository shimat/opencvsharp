Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus
Imports SampleBase

''' <summary>
''' cv::FAST
''' </summary>
Friend Module FASTSample
    Public Sub Start()
        Using imgSrc As New Mat(FilePath.Image.Lenna, LoadMode.Color), _
            imgGray As New Mat(imgSrc.Size, MatrixType.U8C1), _
            imgDst As Mat = imgSrc.Clone()
            Cv2.CvtColor(imgSrc, imgGray, ColorConversion.BgrToGray, 0)

            Dim keypoints() As KeyPoint
            Cv2.FAST(imgGray, keypoints, 50, True)

            For Each kp As KeyPoint In keypoints
                imgDst.Circle(kp.Pt, 3, CvColor.Red, -1, LineType.AntiAlias, 0)
            Next kp

            Cv2.ImShow("FAST", imgDst)
            Cv2.WaitKey(0)
            Cv2.DestroyAllWindows()
        End Using
    End Sub
End Module
' End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' cv::FAST
    ''' </summary>
    Friend Module FAST
        Public Sub Start()
            Dim img As New IplImage([Const].ImageLenna, LoadMode.Color)
            Using imgSrc As New Mat(img)
                'using (Mat imgSrc = new Mat(Const.ImageLenna, LoadMode.Color))
                Using imgGray As New Mat(imgSrc.Size, MatrixType.U8C1)
                    Using imgDst As Mat = imgSrc.Clone()
                        CvCpp.CvtColor(imgSrc, imgGray, ColorConversion.BgrToGray, 0)

                        Dim keypoints() As KeyPoint
                        CvCpp.FAST(imgGray, keypoints, 50, True)

                        For Each kp As KeyPoint In keypoints
                            imgDst.Circle(kp.Pt, 3, CvColor.Red, -1, LineType.AntiAlias, 0)
                        Next kp

                        CvCpp.ImShow("FAST", imgDst)
                        CvCpp.WaitKey(0)
                        Cv.DestroyAllWindows()
                    End Using
                End Using
            End Using
        End Sub
    End Module
' End Namespace

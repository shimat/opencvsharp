Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' コーナーの検出
''' </summary>
''' <remarks>
''' http://opencv.jp/sample/gradient_edge_corner.html#goodfeatures
''' </remarks>
Friend Module CornerDetect
    Public Sub Start()
        ' cvGoodFeaturesToTrack, cvFindCornerSubPix
        ' 画像中のコーナー（特徴点）検出

        Dim cornerCount As Integer = 150

        Using dstImg1 As New IplImage(FilePath.Image.Lenna, LoadMode.AnyColor Or LoadMode.AnyDepth)
            Using dstImg2 As IplImage = dstImg1.Clone()
                Using srcImgGray As New IplImage(FilePath.Image.Lenna, LoadMode.GrayScale)
                    Using eigImg As New IplImage(srcImgGray.GetSize(), BitDepth.F32, 1)
                        Using tempImg As New IplImage(srcImgGray.GetSize(), BitDepth.F32, 1)
                            Dim corners() As CvPoint2D32f
                            ' (1)cvCornerMinEigenValを利用したコーナー検出
                            Cv.GoodFeaturesToTrack(srcImgGray, eigImg, tempImg, corners, cornerCount, 0.1, 15)
                            Cv.FindCornerSubPix(srcImgGray, corners, cornerCount, New CvSize(3, 3), New CvSize(-1, -1), New CvTermCriteria(20, 0.03))
                            ' (2)コーナーの描画
                            Dim i As Integer = 0
                            Do While i < cornerCount
                                Cv.Circle(dstImg1, corners(i), 3, New CvColor(255, 0, 0), 2)
                                i += 1
                            Loop
                            ' (3)cvCornerHarrisを利用したコーナー検出
                            cornerCount = 150
                            Cv.GoodFeaturesToTrack(srcImgGray, eigImg, tempImg, corners, cornerCount, 0.1, 15, Nothing, 3, True, 0.01)
                            Cv.FindCornerSubPix(srcImgGray, corners, cornerCount, New CvSize(3, 3), New CvSize(-1, -1), New CvTermCriteria(20, 0.03))
                            ' (4)コーナーの描画
                            For j As Integer = 0 To cornerCount - 1
                                Cv.Circle(dstImg2, corners(i), 3, New CvColor(0, 0, 255), 2)
                            Next j
                            ' (5)画像の表示 
                            Using TempCvWindowEigen As CvWindow = New CvWindow("EigenVal", WindowMode.AutoSize, dstImg1)
                                Using TempCvWindowHarris As CvWindow = New CvWindow("Harris", WindowMode.AutoSize, dstImg2)
                                    Cv.WaitKey(0)
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Module
' End Namespace

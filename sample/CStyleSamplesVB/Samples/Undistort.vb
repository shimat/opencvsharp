Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 歪み補正
''' </summary>
''' <remarks>http://opencv.jp/sample/camera_calibration.html#undistortion</remarks>
Friend Module Undistort
    Public Sub Start()
        ' cvUndistort2
        ' キャリブレーションデータを利用して，歪みを補正する

        ' (1)補正対象となる画像の読み込み
        Using srcImg As New IplImage(FilePath.Image.Distortion, LoadMode.Color)
            Using dstImg As IplImage = srcImg.Clone()

                ' (2)パラメータファイルの読み込み
                Dim intrinsic, distortion As CvMat
                Using fs As New CvFileStorage(FilePath.Text.Camera, Nothing, FileStorageMode.Read)
                    Dim param As CvFileNode = fs.GetFileNodeByName(Nothing, "intrinsic")
                    intrinsic = fs.Read(Of CvMat)(param)
                    param = fs.GetFileNodeByName(Nothing, "distortion")
                    distortion = fs.Read(Of CvMat)(param)
                End Using

                ' (3)歪み補正
                Cv.Undistort2(srcImg, dstImg, intrinsic, distortion)

                ' (4)画像を表示，キーが押されたときに終了
                Using w1 As New CvWindow("Distortion", WindowMode.AutoSize, srcImg)
                    Using w2 As New CvWindow("Undistortion", WindowMode.AutoSize, dstImg)
                        CvWindow.WaitKey(0)
                    End Using
                End Using

                intrinsic.Dispose()
                distortion.Dispose()
            End Using
        End Using
    End Sub
End Module
' End Namespace

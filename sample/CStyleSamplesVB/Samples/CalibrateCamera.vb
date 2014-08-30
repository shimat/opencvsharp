Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' カメラキャリブレーション
''' </summary>
''' <remarks>
''' http://opencv.jp/sample/camera_calibration.html#calibration
''' </remarks>
Friend Module CalibrateCamera
    Public Sub Start()
        Const ImageNum As Integer = 3 ' 画像数
        Const PatRow As Integer = 7 ' パターンの行数
        Const PatCol As Integer = 10 ' パターンの列数
        Const PatSize As Integer = PatRow * PatCol
        Const AllPoints As Integer = ImageNum * PatSize
        Const ChessSize As Single = 24.0F ' パターン1マスの1辺サイズ[mm]

        ' (1)キャリブレーション画像の読み込み
        Dim srcImg(ImageNum - 1) As IplImage
        For i As Integer = 0 To ImageNum - 1
            srcImg(i) = New IplImage(String.Format(FilePath.Image.Calibration, i), LoadMode.Color)
        Next i

        ' (2)3次元空間座標の設定
        Dim objects(ImageNum - 1, PatRow - 1, PatCol - 1) As CvPoint3D32f
        For i As Integer = 0 To ImageNum - 1
            For j As Integer = 0 To PatRow - 1
                For k As Integer = 0 To PatCol - 1
                    objects(i, j, k) = New CvPoint3D32f With {.X = j * ChessSize, .Y = k * ChessSize, .Z = 0.0F}
                Next k
            Next j
        Next i
        Dim objectPoints As New CvMat(AllPoints, 3, MatrixType.F32C1, objects)

        ' (3)チェスボード（キャリブレーションパターン）のコーナー検出
        Dim patternSize As New CvSize(PatCol, PatRow)

        Dim foundNum As Integer = 0
        Dim allCorners As New List(Of CvPoint2D32f)(AllPoints)
        Dim pointCountsValue(ImageNum - 1) As Integer
        Using window As New CvWindow("Calibration", WindowMode.AutoSize)
            For i As Integer = 0 To ImageNum - 1
                Dim corners() As CvPoint2D32f
                Dim found As Boolean = Cv.FindChessboardCorners(srcImg(i), patternSize, corners)
                Debug.Print("{0:D2}...", i)
                If found Then
                    Debug.Print("ok")
                    foundNum += 1
                Else
                    Debug.Print("fail")
                End If
                ' (4)コーナー位置をサブピクセル精度に修正，描画                    
                Using srcGray As New IplImage(srcImg(i).Size, BitDepth.U8, 1)
                    Cv.CvtColor(srcImg(i), srcGray, ColorConversion.BgrToGray)
                    Cv.FindCornerSubPix(srcGray, corners, corners.Length, New CvSize(3, 3), New CvSize(-1, -1), New CvTermCriteria(20, 0.03))
                    Cv.DrawChessboardCorners(srcImg(i), patternSize, corners, found)
                    pointCountsValue(i) = corners.Length

                    window.ShowImage(srcImg(i))
                    Cv.WaitKey(0)
                End Using
                allCorners.AddRange(corners)
            Next i
            If foundNum <> ImageNum Then
                Debug.Assert(False)
            End If
        End Using

        Dim imagePoints As New CvMat(AllPoints, 1, MatrixType.F32C2, allCorners.ToArray())
        Dim pointCounts As New CvMat(ImageNum, 1, MatrixType.S32C1, pointCountsValue)

        ' (5)内部パラメータ，歪み係数の推定
        Dim intrinsic As New CvMat(3, 3, MatrixType.F64C1)
        Dim distortion As New CvMat(1, 4, MatrixType.F64C1)
        Dim rotation As New CvMat(ImageNum, 3, MatrixType.F64C1)
        Dim translation As New CvMat(ImageNum, 3, MatrixType.F64C1)

        Cv.CalibrateCamera2(objectPoints, imagePoints, pointCounts, srcImg(0).Size, intrinsic, distortion, rotation, translation, CalibrationFlag.Default)

        ' (6)外部パラメータの推定 (1枚目の画像に対して)
        Dim subImagePoints As CvMat = Nothing
        Dim subObjectPoints As CvMat = Nothing
        Cv.GetRows(imagePoints, subImagePoints, 0, PatSize)
        Cv.GetRows(objectPoints, subObjectPoints, 0, PatSize)
        Dim rotationExt As New CvMat(1, 3, MatrixType.F32C1)
        Dim translationExt As New CvMat(1, 3, MatrixType.F32C1)

        Cv.FindExtrinsicCameraParams2( _
            subObjectPoints, subImagePoints, intrinsic, distortion, rotationExt, translationExt, False)
        'Cv.FindExtrinsicCameraParams2_(subObjectPoints, subImagePoints, intrinsic, distortion, rotation_, translation_, false);

        ' (7)XMLファイルへの書き出し
        Using fs As New CvFileStorage("camera.xml", Nothing, OpenCvSharp.FileStorageMode.Write)
            fs.Write("intrinsic", intrinsic)
            fs.Write("rotation", rotationExt)
            fs.Write("translation", translationExt)
            fs.Write("distortion", distortion)
        End Using

        For Each img As IplImage In srcImg
            img.Dispose()
        Next img

        ' 書き込んだファイルを表示
        'Console.WriteLine(File.ReadAllText("camera.xml"))
        'Console.Read()
        Form1.Label1.Text = "camera.xml"
        Dim sr As StreamReader = File.OpenText("camera.xml")
        Form1.TextBox1.Text = sr.ReadToEnd()
        sr.Close()
    End Sub
End Module
' End Namespace

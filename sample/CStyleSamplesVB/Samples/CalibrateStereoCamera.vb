Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' 
    ''' </summary>
    Friend Module CalibrateStereoCamera
        Private Const ImageNum As Integer = 13
        Private Const MaxScale As Integer = 2
        Private ReadOnly BoardSize As New CvSize(9, 6)
        Private ReadOnly AllPoints As Integer = ImageNum * BoardSize.Width * BoardSize.Height
        Private Const SquareSize As Single = 1.0F

        Public Sub Start()
            ' target filenames
            Dim pair() As String = {"Data/Image/Calibration/left{0:D2}.jpg", "Data/Image/Calibration/right{0:D2}.jpg"}
            Dim fileNames(ImageNum - 1)() As String
            For i As Integer = 0 To ImageNum - 1
                fileNames(i) = New String(1) {String.Format(pair(0), i + 1), String.Format(pair(1), i + 1)}
            Next i

            ' FindChessboardCorners
            Dim imagePointsLeft(), imagePointsRight() As CvPoint2D32f
            Dim pointCountLeft(), pointCountRight() As Integer
            Dim goodImagelist() As Integer
            FindChessboardCorners(fileNames, imagePointsLeft, imagePointsRight, pointCountLeft, pointCountRight, goodImagelist)
            Dim nImages As Integer = goodImagelist.Length

            ' StereoCalibrate
            Dim objects(ImageNum - 1, BoardSize.Height - 1, BoardSize.Width - 1) As CvPoint3D32f
            For i As Integer = 0 To ImageNum - 1
                For j As Integer = 0 To BoardSize.Height - 1
                    For k As Integer = 0 To BoardSize.Width - 1
                        objects(i, j, k) = New CvPoint3D32f(j * SquareSize, k * SquareSize, 0.0F)
                    Next k
                Next j
            Next i
            Dim objectPoints As New CvMat(AllPoints, 3, MatrixType.F32C1, objects)

            Dim imagePoints1 As New CvMat(AllPoints, 1, MatrixType.F32C2, imagePointsLeft)
            Dim imagePoints2 As New CvMat(AllPoints, 1, MatrixType.F32C2, imagePointsRight)
            Dim pointCount1 As New CvMat(nImages, 1, MatrixType.S32C1, pointCountLeft)
            Dim pointCount2 As New CvMat(nImages, 1, MatrixType.S32C1, pointCountRight)

            Dim cameraMatrix1 As CvMat = CvMat.Identity(3, 3, MatrixType.F64C1)
            Dim cameraMatrix2 As CvMat = CvMat.Identity(3, 3, MatrixType.F64C1)
            Dim distCoeffs1 As New CvMat(1, 4, MatrixType.F64C1)
            Dim distCoeffs2 As New CvMat(1, 4, MatrixType.F64C1)
            Dim R As New CvMat(3, 3, MatrixType.F64C1)
            Dim T As New CvMat(3, 1, MatrixType.F64C1)

            Cv.StereoCalibrate(objectPoints, imagePoints1, imagePoints2, pointCount1, cameraMatrix1, distCoeffs1, cameraMatrix2, distCoeffs2, New CvSize(640, 480), R, T, Nothing, Nothing, New CvTermCriteria(100, 0.00001), CalibrationFlag.FixAspectRatio Or CalibrationFlag.ZeroTangentDist Or CalibrationFlag.SameFocalLength Or CalibrationFlag.RationalModel Or CalibrationFlag.FixK3 Or CalibrationFlag.FixK4 Or CalibrationFlag.FixK5)

            ' Rectify
            Dim R1 As New CvMat(3, 3, MatrixType.F64C1)
            Dim R2 As New CvMat(3, 3, MatrixType.F64C1)
            Dim P1 As New CvMat(3, 4, MatrixType.F64C1)
            Dim P2 As New CvMat(3, 4, MatrixType.F64C1)
            Dim Q As New CvMat(4, 4, MatrixType.F64C1)

            Cv.StereoRectify(cameraMatrix1, cameraMatrix2, distCoeffs1, distCoeffs2, New CvSize(640, 480), R, T, R1, R2, P1, P2, Q, StereoRectificationFlag.ZeroDisparity, 1, New CvSize(640, 480))

            Using mem As New CvMemStorage()
            Using fs As New CvFileStorage("extrinsic.yml", mem, OpenCvSharp.FileStorageMode.Write)
                fs.Write("R", R)
                fs.Write("T", T)
                fs.Write("R1", R1)
                fs.Write("R2", R2)
                fs.Write("P1", P1)
                fs.Write("P1", P1)
                fs.Write("Q", Q)
            End Using
            End Using
            Process.Start("notepad", "extrinsic.yml")

            Console.Read()
        End Sub


        Public Sub FindChessboardCorners(ByVal fileNames()() As String, <System.Runtime.InteropServices.Out()> ByRef imagePointsLeft() As CvPoint2D32f, <System.Runtime.InteropServices.Out()> ByRef imagePointsRight() As CvPoint2D32f, <System.Runtime.InteropServices.Out()> ByRef pointCountLeft() As Integer, <System.Runtime.InteropServices.Out()> ByRef pointCountRight() As Integer, <System.Runtime.InteropServices.Out()> ByRef goodImagelist() As Integer)
            Dim imagePointsLeft_ As New List(Of CvPoint2D32f)()
            Dim imagePointsRight_ As New List(Of CvPoint2D32f)()
            Dim pointCountLeft_ As New List(Of Integer)()
            Dim pointCountRight_ As New List(Of Integer)()
            Dim goodImagelist_ As New List(Of Integer)()

            Dim i, j As Integer
            For i = 0 To fileNames.Length - 1
                For j = 0 To 1
                    Dim img As New IplImage(fileNames(i)(j), LoadMode.GrayScale)

                    Dim found As Boolean = False
                    Dim corners() As CvPoint2D32f = Nothing
                    Dim corner_count As Integer = 0
                    For scale As Integer = 1 To MaxScale
                        Dim timg As IplImage
                        If scale = 1 Then
                            timg = img
                        Else
                            timg = New IplImage(img.Width * scale, img.Height * scale, img.Depth, img.NChannels)
                            Cv.Resize(img, timg, Interpolation.Linear)
                        End If
                        If timg IsNot img Then
                            timg.Dispose()
                        End If

                        found = Cv.FindChessboardCorners(timg, BoardSize, corners, corner_count, ChessboardFlag.AdaptiveThresh Or ChessboardFlag.NormalizeImage)
                        If found Then
                            If scale > 1 Then
                                For l As Integer = 0 To corners.Length - 1
                                    corners(i) *= 1.0 / scale
                                Next l
                            End If
                            Exit For
                        End If
                    Next scale
                    Form1.TextBox1.AppendText(Environment.NewLine & String.Format("."))
                    If found Then
                        Cv.FindCornerSubPix(img, corners, corner_count, New CvSize(11, 11), New CvSize(-1, -1), New CvTermCriteria(30, 0.01))
                    End If
                    If j = 0 Then
                        imagePointsLeft_.AddRange(corners)
                        pointCountLeft_.Add(corner_count)
                    Else
                        imagePointsRight_.AddRange(corners)
                        pointCountRight_.Add(corner_count)
                    End If
                Next j
                If j = 2 Then
                    goodImagelist_.Add(i)
                End If
            Next i

            imagePointsLeft = imagePointsLeft_.ToArray()
            imagePointsRight = imagePointsRight_.ToArray()
            pointCountLeft = pointCountLeft_.ToArray()
            pointCountRight = pointCountRight_.ToArray()
            goodImagelist = goodImagelist_.ToArray()
        End Sub

    End Module
' End Namespace

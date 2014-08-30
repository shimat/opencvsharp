Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' ブロックマッチングによるオプティカルフローの計算
''' </summary>
''' <remarks>http://opencv.jp/sample/optical_flow.html#optflowBM</remarks>
    Friend Module OpticalFlowBM
        Public Sub Start()
            ' cvCalcOpticalFlowBM
            ' ブロックマッチングによるオプティカルフローの計算

            Const BlockSize As Integer = 16
            Const ShiftSize As Integer = 8
            Const Range As Integer = 32

            'INSTANT VB NOTE: The variable blockSize was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
            Dim blockSize_Renamed As New CvSize(BlockSize, BlockSize)
            'INSTANT VB NOTE: The variable shiftSize was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
            Dim shiftSize_Renamed As New CvSize(ShiftSize, ShiftSize)
            Dim maxRange As New CvSize(Range, Range)
        Using srcPrev As IplImage = Cv.LoadImage(FilePath.Image.Penguin1, LoadMode.GrayScale)
            Using srcCurr As IplImage = Cv.LoadImage(FilePath.Image.Penguin2, LoadMode.GrayScale)
                Using dst As IplImage = Cv.LoadImage(FilePath.Image.Penguin2, LoadMode.Color)
                    ' (1)速度ベクトルを格納する構造体の確保  
                    Dim velSize As CvSize = New CvSize With {.Width = (srcPrev.Width - blockSize_Renamed.Width + shiftSize_Renamed.Width) \ shiftSize_Renamed.Width, .Height = (srcPrev.Height - blockSize_Renamed.Height + shiftSize_Renamed.Height) \ shiftSize_Renamed.Height}
                    Using velx As CvMat = Cv.CreateMat(velSize.Height, velSize.Width, MatrixType.F32C1)
                        Using vely As CvMat = Cv.CreateMat(velSize.Height, velSize.Width, MatrixType.F32C1)
                            '                    if (!CV_ARE_SIZES_EQ(srcA, srcB) ||
                            '                        !CV_ARE_SIZES_EQ(velx, vely) ||
                            '                        velx->width != velSize.width ||
                            '                        vely->height != velSize.height)
                            '                        CV_Error(CV_StsUnmatchedSizes, "");
                            If srcPrev.Size <> srcCurr.Size Then
                                Throw New Exception()
                            End If
                            If velx.Width <> vely.Width Then
                                Throw New Exception()
                            End If
                            If velx.Height <> vely.Height Then
                                Throw New Exception()
                            End If
                            If velx.Cols <> velSize.Width Then
                                Throw New Exception()
                            End If
                            If vely.Rows <> velSize.Height Then
                                Throw New Exception()
                            End If

                            Cv.SetZero(velx)
                            Cv.SetZero(vely)
                            ' (2)オプティカルフローの計算 
                            Cv.CalcOpticalFlowBM(srcPrev, srcCurr, blockSize_Renamed, shiftSize_Renamed, maxRange, False, velx, vely)
                            ' (3)計算されたフローを描画  
                            For r As Integer = 0 To velx.Rows - 1
                                For c As Integer = 0 To vely.Cols - 1
                                    Dim dx As Integer = CInt(Math.Truncate(Cv.GetReal2D(velx, r, c)))
                                    Dim dy As Integer = CInt(Math.Truncate(Cv.GetReal2D(vely, r, c)))
                                    'Console.WriteLine("i:{0} j:{1} dx:{2} dy:{3}", i, j, dx, dy);
                                    If dx <> 0 OrElse dy <> 0 Then
                                        Dim p1 As New CvPoint(c * ShiftSize, r * ShiftSize)
                                        Dim p2 As New CvPoint(c * ShiftSize + dx, r * ShiftSize + dy)
                                        Cv.Line(dst, p1, p2, CvColor.Red, 1, LineType.AntiAlias, 0)
                                    End If
                                Next c
                            Next r

                            Using windowPrev As New CvWindow("prev", srcPrev)
                                Using windowCurr As New CvWindow("curr", srcCurr)
                                    Using windowDst As New CvWindow("dst", dst)
                                        'using (CvWindow windowVelX = new CvWindow("velx", velx))
                                        'using (CvWindow windowVelY = new CvWindow("vely", vely))
                                        Cv.WaitKey(0)
                                    End Using
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

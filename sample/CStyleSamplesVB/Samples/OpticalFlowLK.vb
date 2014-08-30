Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Lucas & Kanade アルゴリズムによるオプティカルフローの計算
''' </summary>
''' <remarks>http://opencv.jp/sample/optical_flow.html#optflowHSLK</remarks>
    Friend Module OpticalFlowLK
        Public Sub Start()
        Using srcImg1 As IplImage = Cv.LoadImage(FilePath.Image.Penguin1, LoadMode.GrayScale)
            Using srcImg2 As IplImage = Cv.LoadImage(FilePath.Image.Penguin1b, LoadMode.GrayScale)
                Using dstImg As IplImage = Cv.LoadImage(FilePath.Image.Penguin1b, LoadMode.Color)
                    ' (1)速度ベクトルを格納する構造体の確保，等
                    Dim cols As Integer = srcImg1.Width
                    Dim rows As Integer = srcImg1.Height
                    Using velx As CvMat = Cv.CreateMat(rows, cols, MatrixType.F32C1)
                        Using vely As CvMat = Cv.CreateMat(rows, cols, MatrixType.F32C1)
                            Cv.SetZero(velx)
                            Cv.SetZero(vely)

                            ' (2)オプティカルフローを計算
                            Cv.CalcOpticalFlowLK(srcImg1, srcImg2, Cv.Size(15, 15), velx, vely)

                            ' (3)オプティカルフローを描画
                            For i As Integer = 0 To cols - 1 Step 5
                                For j As Integer = 0 To rows - 1 Step 5
                                    Dim dx As Integer = CInt(Math.Truncate(Cv.GetReal2D(velx, j, i)))
                                    Dim dy As Integer = CInt(Math.Truncate(Cv.GetReal2D(vely, j, i)))
                                    Cv.Line(dstImg, Cv.Point(i, j), Cv.Point(i + dx, j + dy), Cv.RGB(255, 0, 0), 1, Cv.AA, 0)
                                Next j
                            Next i

                            ' (4)オプティカルフローの表示
                            Cv.NamedWindow("ImageLK", WindowMode.AutoSize)
                            Cv.ShowImage("ImageLK", dstImg)
                            Cv.NamedWindow("velx", WindowMode.AutoSize)
                            Cv.ShowImage("velx", velx)
                            Cv.NamedWindow("vely", WindowMode.AutoSize)
                            Cv.ShowImage("vely", vely)
                            Cv.WaitKey(0)
                            Cv.DestroyAllWindows()
                        End Using
                    End Using
                End Using
            End Using
        End Using

        End Sub
    End Module
' End Namespace

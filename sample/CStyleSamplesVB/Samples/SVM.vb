Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.MachineLearning

' Namespace OpenCvSharpSamplesVB
''' <summary>
''' Support Vector Machine
''' </summary>
''' <remarks>http://opencv.jp/sample/svm.html#svm</remarks>
Friend Module SVM
    Public Sub Start()

        Const S As Integer = 1000
        Const SIZE As Integer = 400
        Dim rng As New CvRNG(CULng(Date.Now.Ticks))

        ' (1)画像領域の確保と初期化
        Using img As New IplImage(SIZE, SIZE, BitDepth.U8, 3)
            img.Zero()
            ' (2)学習データの生成
            Dim pts(S - 1) As CvPoint
            Dim res(S - 1) As Integer
            For i As Integer = 0 To S - 1
                pts(i).X = CInt(Math.Truncate(rng.RandInt() Mod SIZE))
                pts(i).Y = CInt(Math.Truncate(rng.RandInt() Mod SIZE))
                If pts(i).Y > 50 * Math.Cos(pts(i).X * Cv.PI / 100) + 200 Then
                    img.Line(New CvPoint(pts(i).X - 2, pts(i).Y - 2), New CvPoint(pts(i).X + 2, pts(i).Y + 2), New CvColor(255, 0, 0))
                    img.Line(New CvPoint(pts(i).X + 2, pts(i).Y - 2), New CvPoint(pts(i).X - 2, pts(i).Y + 2), New CvColor(255, 0, 0))
                    res(i) = 1
                Else
                    If pts(i).X > 200 Then
                        img.Line(New CvPoint(pts(i).X - 2, pts(i).Y - 2), New CvPoint(pts(i).X + 2, pts(i).Y + 2), New CvColor(0, 255, 0))
                        img.Line(New CvPoint(pts(i).X + 2, pts(i).Y - 2), New CvPoint(pts(i).X - 2, pts(i).Y + 2), New CvColor(0, 255, 0))
                        res(i) = 2
                    Else
                        img.Line(New CvPoint(pts(i).X - 2, pts(i).Y - 2), New CvPoint(pts(i).X + 2, pts(i).Y + 2), New CvColor(0, 0, 255))
                        img.Line(New CvPoint(pts(i).X + 2, pts(i).Y - 2), New CvPoint(pts(i).X - 2, pts(i).Y + 2), New CvColor(0, 0, 255))
                        res(i) = 3
                    End If
                End If
            Next i

            ' (3)学習データの表示
            Cv.NamedWindow("SVM", WindowMode.AutoSize)
            Cv.ShowImage("SVM", img)
            Cv.WaitKey(0)

            ' (4)学習パラメータの生成
            Dim data((S * 2) - 1) As Single
            For i As Integer = 0 To S - 1
                data(i * 2) = (CSng(pts(i).X)) / SIZE
                data(i * 2 + 1) = (CSng(pts(i).Y)) / SIZE
            Next i

            ' (5)SVMの学習
            Using svm As New CvSVM()
                Dim data_mat As New CvMat(S, 2, MatrixType.F32C1, data)
                Dim res_mat As New CvMat(S, 1, MatrixType.S32C1, res)
                Dim criteria As New CvTermCriteria(1000, Single.Epsilon)
                Dim param As New CvSVMParams(SVMType.CSvc, SVMKernelType.Rbf, 10.0, 8.0, 1.0, 10.0, 0.5, 0.1, Nothing, criteria)
                svm.Train(data_mat, res_mat, Nothing, Nothing, param)

                ' (6)学習結果の描画
                For i As Integer = 0 To SIZE - 1
                    For j As Integer = 0 To SIZE - 1
                        Dim a() As Single = {CSng(j) / SIZE, CSng(i) / SIZE}
                        Dim m As New CvMat(1, 2, MatrixType.F32C1, a)
                        Dim ret As Single = svm.Predict(m)
                        Dim color As New CvColor()
                        Select Case CInt(Math.Truncate(ret))
                            Case 1
                                color = New CvColor(100, 0, 0)
                            Case 2
                                color = New CvColor(0, 100, 0)
                            Case 3
                                color = New CvColor(0, 0, 100)
                        End Select
                        img(i, j) = color
                    Next j
                Next i

                ' (7)トレーニングデータの再描画
                For i As Integer = 0 To S - 1
                    Dim color As New CvColor()
                    Select Case res(i)
                        Case 1
                            color = New CvColor(255, 0, 0)
                        Case 2
                            color = New CvColor(0, 255, 0)
                        Case 3
                            color = New CvColor(0, 0, 255)
                    End Select
                    img.Line(New CvPoint(pts(i).X - 2, pts(i).Y - 2), New CvPoint(pts(i).X + 2, pts(i).Y + 2), color)
                    img.Line(New CvPoint(pts(i).X + 2, pts(i).Y - 2), New CvPoint(pts(i).X - 2, pts(i).Y + 2), color)
                Next i

                ' (8)サポートベクターの描画
                Dim sv_num As Integer = svm.GetSupportVectorCount()
                For i As Integer = 0 To sv_num - 1
                    Dim support = svm.GetSupportVector(i)
                    img.Circle(New CvPoint(CInt(Math.Truncate(support(0) * SIZE)), CInt(Math.Truncate(support(1) * SIZE))), 5, New CvColor(200, 200, 200))
                Next i

                ' (9)画像の表示
                Cv.NamedWindow("SVM", WindowMode.AutoSize)
                Cv.ShowImage("SVM", img)
                Cv.WaitKey(0)
                Cv.DestroyWindow("SVM")
            End Using
        End Using

    End Sub
End Module
' End Namespace

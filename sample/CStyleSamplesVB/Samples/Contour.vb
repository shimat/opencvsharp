Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' 輪郭領域の面積と輪郭の長さ
    ''' </summary>
    ''' <remarks>
    ''' http://opencv.jp/sample/contour_processing.html#contour_area
    ''' </remarks>
    Friend Module Contour
        Public Sub Start()
            ' cvContourArea, cvArcLength
            ' 輪郭によって区切られた領域の面積と，輪郭の長さを求める

            Const SIZE As Integer = 500

            ' (1)画像を確保し初期化する
            Using storage As New CvMemStorage()
                Using img As New IplImage(SIZE, SIZE, BitDepth.U8, 3)
                    img.Zero()
                    ' (2)点列を生成する 
                    Dim points As New CvSeq(Of CvPoint)(SeqType.PolyLine, storage)
                    Dim rng As New CvRNG(CULng(Date.Now.Ticks))
                    Dim scale As Double = rng.RandReal() + 0.5
                    Dim pt0 As CvPoint = New CvPoint With {.X = CInt(Math.Truncate(Math.Cos(0) * SIZE / 4 * scale + SIZE \ 2)), .Y = CInt(Math.Truncate(Math.Sin(0) * SIZE / 4 * scale + SIZE \ 2))}
                    img.Circle(pt0, 2, CvColor.Green)
                    points.Push(pt0)
                    For i As Integer = 1 To 19
                        scale = rng.RandReal() + 0.5
                        Dim pt1 As CvPoint = New CvPoint With {.X = CInt(Math.Truncate(Math.Cos(i * 2 * Math.PI / 20) * SIZE / 4 * scale + SIZE \ 2)), .Y = CInt(Math.Truncate(Math.Sin(i * 2 * Math.PI / 20) * SIZE / 4 * scale + SIZE \ 2))}
                        img.Line(pt0, pt1, CvColor.Green, 2)
                        pt0.X = pt1.X
                        pt0.Y = pt1.Y
                        img.Circle(pt0, 3, CvColor.Green, Cv.FILLED)
                        points.Push(pt0)
                    Next i
                    img.Line(pt0, points.GetSeqElem(0).Value, CvColor.Green, 2)
                    ' (3)包含矩形，面積，長さを求める
                    Dim rect As CvRect = points.BoundingRect(False)
                    Dim area As Double = points.ContourArea()
                    Dim length As Double = points.ArcLength(CvSlice.WholeSeq, 1)
                    ' (4)結果を画像に書き込む
                    img.Rectangle(New CvPoint(rect.X, rect.Y), New CvPoint(rect.X + rect.Width, rect.Y + rect.Height), CvColor.Red, 2)
                    Dim text_area As String = String.Format("Area:   wrect={0}, contour={1}", rect.Width * rect.Height, area)
                    Dim text_length As String = String.Format("Length: rect={0}, contour={1}", 2 * (rect.Width + rect.Height), length)
                    Using font As New CvFont(FontFace.HersheySimplex, 0.7, 0.7, 0, 1, LineType.AntiAlias)
                        img.PutText(text_area, New CvPoint(10, img.Height - 30), font, CvColor.White)
                        img.PutText(text_length, New CvPoint(10, img.Height - 10), font, CvColor.White)
                    End Using
                    ' (5)画像を表示，キーが押されたときに終了 
                    Using window As New CvWindow("BoundingRect", WindowMode.AutoSize)
                        window.Image = img
                        CvWindow.WaitKey(0)
                    End Using
                End Using
            End Using
        End Sub
    End Module
' End Namespace

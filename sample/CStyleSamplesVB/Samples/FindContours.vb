Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
''' <summary>
''' 輪郭の検出と描画
''' </summary>
Friend Module FindContours
    Public Sub Start()
        ' cvFindContoursm cvDrawContours
        ' 画像中から輪郭を検出し，-1~+1までのレベルにある輪郭を描画する

        Const SIZE As Integer = 500

        Using img As New IplImage(SIZE, SIZE, BitDepth.U8, 1)
            ' 画像の初期化
            img.Zero()
            For i As Integer = 0 To 5
                Dim dx As Integer = (i Mod 2) * 250 - 30
                Dim dy As Integer = (i \ 2) * 150
                If i = 0 Then
                    For j As Integer = 0 To 10
                        Dim angle As Double = (j + 5) * Cv.PI / 21
                        Dim p1 As New CvPoint(Cv.Round(dx + 100 + j * 10 - 80 * Math.Cos(angle)), Cv.Round(dy + 100 - 90 * Math.Sin(angle)))
                        Dim p2 As New CvPoint(Cv.Round(dx + 100 + j * 10 - 30 * Math.Cos(angle)), Cv.Round(dy + 100 - 30 * Math.Sin(angle)))
                        Cv.Line(img, p1, p2, CvColor.White, 1, LineType.AntiAlias, 0)
                    Next j
                End If
                Cv.Ellipse(img, New CvPoint(dx + 150, dy + 100), New CvSize(100, 70), 0, 0, 360, CvColor.White, -1, LineType.AntiAlias, 0)
                Cv.Ellipse(img, New CvPoint(dx + 115, dy + 70), New CvSize(30, 20), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0)
                Cv.Ellipse(img, New CvPoint(dx + 185, dy + 70), New CvSize(30, 20), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0)
                Cv.Ellipse(img, New CvPoint(dx + 115, dy + 70), New CvSize(15, 15), 0, 0, 360, CvColor.White, -1, LineType.AntiAlias, 0)
                Cv.Ellipse(img, New CvPoint(dx + 185, dy + 70), New CvSize(15, 15), 0, 0, 360, CvColor.White, -1, LineType.AntiAlias, 0)
                Cv.Ellipse(img, New CvPoint(dx + 115, dy + 70), New CvSize(5, 5), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0)
                Cv.Ellipse(img, New CvPoint(dx + 185, dy + 70), New CvSize(5, 5), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0)
                Cv.Ellipse(img, New CvPoint(dx + 150, dy + 100), New CvSize(10, 5), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0)
                Cv.Ellipse(img, New CvPoint(dx + 150, dy + 150), New CvSize(40, 10), 0, 0, 360, CvColor.Black, -1, LineType.AntiAlias, 0)
                Cv.Ellipse(img, New CvPoint(dx + 27, dy + 100), New CvSize(20, 35), 0, 0, 360, CvColor.White, -1, LineType.AntiAlias, 0)
                Cv.Ellipse(img, New CvPoint(dx + 273, dy + 100), New CvSize(20, 35), 0, 0, 360, CvColor.White, -1, LineType.AntiAlias, 0)
            Next i

            ' 輪郭の検出
            Dim contours As CvSeq(Of CvPoint) = Nothing
            Dim storage As New CvMemStorage()
            ' native style
            Cv.FindContours(img, storage, contours, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple)
            contours = Cv.ApproxPoly(contours, CvContour.SizeOf, storage, ApproxPolyMethod.DP, 3, True)

            ' wrapper style
            'img.FindContours(storage, out contours, ContourRetrieval.Tree, ContourChain.ApproxSimple);
            'contours = contours.ApproxPoly(storage, ApproxPolyMethod.DP, 3, true);

            ' ウィンドウに表示
            Using windowImage As New CvWindow("image", img), _
             windowContours As New CvWindow("contours")
                Dim onTrackbar As CvTrackbarCallback = Sub(pos As Integer)
                                                           Dim cnt_img As New IplImage(SIZE, SIZE, BitDepth.U8, 3)
                                                           Dim _contours As CvSeq(Of CvPoint) = contours
                                                           Dim levels As Integer = pos - 3
                                                           If levels <= 0 Then ' get to the nearest face to make it look more funny
                                                               '_contours = _contours.HNext.HNext.HNext;
                                                           End If
                                                           cnt_img.Zero()
                                                           Cv.DrawContours(cnt_img, _contours, CvColor.Red, CvColor.Green, levels, 3, LineType.AntiAlias)
                                                           windowContours.ShowImage(cnt_img)
                                                           cnt_img.Dispose()
                                                       End Sub
                windowContours.CreateTrackbar("levels+3", 3, 7, onTrackbar)
                onTrackbar(3)

                Cv.WaitKey()
            End Using
        End Using

    End Sub
End Module
' End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' 点列を包含する矩形 
    ''' </summary>
    ''' <remarks>
    ''' http://opencv.jp/sample/contour_processing.html#bounding
    ''' </remarks>
    Friend Module BoundingRect
        Public Sub Start()
            ' cvBoundingRect 
            ' 点列を包含する矩形を求める

            ' (1)画像とメモリストレージを確保し初期化する
            ' (メモリストレージは、CvSeqを使わないのであれば不要)
            Using img As New IplImage(640, 480, BitDepth.U8, 3)
                Using storage As New CvMemStorage(0)
                    img.Zero()
                    Dim rng As New CvRNG(Date.Now)
                    ' (2)点列を生成する
                    '''*
                    ' お手軽な方法 (普通の配列を使う)
                    Dim points(49) As CvPoint
                    For i As Integer = 0 To 49
                        points(i) = New CvPoint() With {.X = CInt(Math.Truncate(rng.RandInt() Mod (img.Width \ 2) + img.Width \ 4)), .Y = CInt(Math.Truncate(rng.RandInt() Mod (img.Height \ 2) + img.Height \ 4))}
                        img.Circle(points(i), 3, New CvColor(0, 255, 0), Cv.FILLED)
                    Next i
                    '*/
                    '                
                    '                // サンプルに準拠した方法 (CvSeqを使う)
                    '                CvSeq points = new CvSeq(SeqType.EltypePoint, CvSeq.SizeOf, CvPoint.SizeOf, storage);
                    '                for (int i = 0; i < 50; i++) {
                    '                    CvPoint pt = new CvPoint();
                    '                    pt.X = (int)(rng.RandInt() % (img.Width / 2) + img.Width / 4);
                    '                    pt.Y = (int)(rng.RandInt() % (img.Height / 2) + img.Height / 4);
                    '                    points.Push(pt);
                    '                    img.Circle(pt, 3, new CvColor(0, 255, 0), Cv.FILLED);
                    '                }
                    '                //
                    ' (3)点列を包含する矩形を求めて描画する
                    Dim rect As CvRect = Cv.BoundingRect(points)
                    img.Rectangle(New CvPoint(rect.X, rect.Y), New CvPoint(rect.X + rect.Width, rect.Y + rect.Height), New CvColor(255, 0, 0), 2)
                    ' (4)画像の表示，キーが押されたときに終了 
                    Using w As New CvWindow("BoundingRect", WindowMode.AutoSize, img)
                        CvWindow.WaitKey(0)
                    End Using
                End Using
            End Using
        End Sub
    End Module
' End Namespace

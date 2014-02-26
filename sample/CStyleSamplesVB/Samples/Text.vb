Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' Drawing Text
    ''' </summary>
    ''' <remarks>http://opencv.jp/sample/text.html#draw_text</remarks>
    Friend Module Text
        Public Sub Start()

            Dim font_face As New List(Of FontFace)(CType(System.Enum.GetValues(GetType(FontFace)), FontFace()))
            font_face.Remove(FontFace.Italic)

            ' (1)画像を確保し初期化する
            Using img As IplImage = Cv.CreateImage(New CvSize(450, 600), BitDepth.U8, 3)
                Cv.Zero(img)
                ' (2)フォント構造体を初期化する
                Dim font((font_face.Count * 2) - 1) As CvFont
                For i As Integer = 0 To font.Length - 1 Step 2
                    font(i) = New CvFont(font_face(i \ 2), 1.0, 1.0)
                    font(i + 1) = New CvFont(font_face(i \ 2) Or FontFace.Italic, 1.0, 1.0)
                Next i
                ' (3)フォントを指定して，テキストを描画する
                For i As Integer = 0 To font.Length - 1
                    Dim rcolor As CvColor = CvColor.Random()
                    Cv.PutText(img, "OpenCV sample code", New CvPoint(15, (i + 1) * 30), font(i), rcolor)
                Next i
                ' (4)画像の表示，キーが押されたときに終了
                Using w As New CvWindow(img)
                    CvWindow.WaitKey(0)
                End Using
            End Using
        End Sub
    End Module
' End Namespace

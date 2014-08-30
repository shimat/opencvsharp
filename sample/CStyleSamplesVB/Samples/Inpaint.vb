Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 不要オブジェクトの除去
''' </summary>
''' <remarks>http://opencv.jp/sample/special_transforms.html#inpaint</remarks>
    Friend Module Inpaint
        Public Sub Start()
            ' cvInpaint
            ' 画像の不要な文字列部分に対するマスク画像を指定して文字列を除去する

            Form1.TextBox1.AppendText("Hot keys: ")
            Form1.TextBox1.AppendText(Environment.NewLine & vbTab & "ESC - quit the program")
            Form1.TextBox1.AppendText(Environment.NewLine & vbTab & "r - restore the original image")
            Form1.TextBox1.AppendText(Environment.NewLine & vbTab & "i or ENTER - run inpainting algorithm")
            Form1.TextBox1.AppendText(Environment.NewLine & vbTab & vbTab & "(before running it, paint something on the image)")
            Form1.TextBox1.AppendText(Environment.NewLine & vbTab & "s - save the original image, mask image, original+mask image and inpainted image to desktop.")

            ' 原画像の読み込み
        Using img0 As New IplImage(FilePath.Image.Fruits, LoadMode.AnyDepth Or LoadMode.AnyColor)
            ' お絵かき用の画像を確保（マスク）
            Using img As IplImage = img0.Clone()
                Using inpaintMask As New IplImage(img0.Size, BitDepth.U8, 1)
                    ' Inpaintの出力先画像を確保
                    Using inpainted As IplImage = img0.Clone()
                        inpainted.Zero()
                        inpaintMask.Zero()

                        Using wImage As New CvWindow("image", WindowMode.AutoSize, img)

                            ' マウスイベントの処理
                            Dim prevPt As New CvPoint(-1, -1)
                            AddHandler wImage.OnMouseCallback, Sub(ev As MouseEvent, x As Integer, y As Integer, flags As MouseEvent)
                                                                   If ev = MouseEvent.LButtonUp OrElse (flags And MouseEvent.FlagLButton) = 0 Then
                                                                       prevPt = New CvPoint(-1, -1)
                                                                   ElseIf ev = MouseEvent.LButtonDown Then
                                                                       prevPt = New CvPoint(x, y)
                                                                   ElseIf ev = MouseEvent.MouseMove AndAlso (flags And MouseEvent.FlagLButton) <> 0 Then
                                                                       Dim pt As New CvPoint(x, y)
                                                                       If prevPt.X < 0 Then
                                                                           prevPt = pt
                                                                       End If
                                                                       inpaintMask.Line(prevPt, pt, CvColor.White, 5, LineType.AntiAlias, 0)
                                                                       img.Line(prevPt, pt, CvColor.White, 5, LineType.AntiAlias, 0)
                                                                       prevPt = pt
                                                                       wImage.ShowImage(img)
                                                                   End If
                                                               End Sub

                            Do
                                Select Case ChrW(CvWindow.WaitKey(0))
                                    Case ChrW(27) ' ESCキーで終了
                                        CvWindow.DestroyAllWindows()
                                        Return
                                    Case "r"c ' 原画像を復元
                                        inpaintMask.Zero()
                                        img0.Copy(img)
                                        wImage.ShowImage(img)
                                    Case "i"c, ControlChars.Cr ' Inpaintの実行
                                        Dim wInpaint As New CvWindow("inpainted image", WindowMode.AutoSize)
                                        img.Inpaint(inpaintMask, inpainted, 3, InpaintMethod.Telea)
                                        wInpaint.ShowImage(inpainted)
                                    Case "s"c ' 画像の保存
                                        Dim desktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                                        img0.SaveImage(Path.Combine(desktop, "original.png"))
                                        inpaintMask.SaveImage(Path.Combine(desktop, "mask.png"))
                                        img.SaveImage(Path.Combine(desktop, "original+mask.png"))
                                        inpainted.SaveImage(Path.Combine(desktop, "inpainted.png"))
                                End Select
                            Loop

                        End Using

                    End Using
                End Using
            End Using
        End Using

        End Sub
    End Module
' End Namespace

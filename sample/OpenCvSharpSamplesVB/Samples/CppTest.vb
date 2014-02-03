Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' OpenCV2.0の C++ interface っぽい新インターフェイスの実験場
    ''' </summary>
    Friend Module CppTest
        Public Sub Start()
            'PixelAccess();

            Using mat As New Mat([Const].ImageLenna, LoadMode.Color)
                'CvSize s;
                'CvPoint p;
                'mat.LocateROI(out s, out p);

                ' CvMatへの変換
                Dim m As CvMat = mat.ToCvMat()
                Form1.TextBox1.AppendText(Environment.NewLine & String.Format(m.ToString))

                ' 行を一部分切り出し
                Dim row As Mat = mat.RowRange(100, 200)

                ' IplImageへ変換し、highguiにより描画
                Dim img As IplImage = row.ToIplImage()
                Using TempCvWindow As CvWindow = New CvWindow("highgui", img)
                    Cv.WaitKey()
                End Using

                ' Bitmapに変換して、WindowsFormで描画する
                Using bitmap As Bitmap = mat.ToBitmap()
                    Using form As New Form() With {.Text = "WindowsForms", .ClientSize = New System.Drawing.Size(bitmap.Width, bitmap.Height)}
                        Using pb As New PictureBox() With {.Image = bitmap, .Dock = DockStyle.Fill}
                            form.Controls.Add(pb)
                            Application.Run(form)
                        End Using
                    End Using
                End Using

                ' cv::imshowによる表示
                CvCpp.NamedWindow("imshow", WindowMode.AutoSize)
                CvCpp.ImShow("imshow", mat)
                CvCpp.WaitKey(0)
                Cv.DestroyAllWindows()
            End Using
        End Sub

        Private Sub PixelAccess()
            Using mat As New Mat(128, 128, MatrixType.U8C1)
                For y As Integer = 0 To mat.Rows - 1
                    For x As Integer = 0 To mat.Cols - 1
                        mat.Set(Of Byte)(y, x, CByte(y + x))
                    Next x
                Next y
                Using TempCvWindow As CvWindow = New CvWindow("PixelAccess", mat.ToIplImage())
                    Cv.WaitKey()
                End Using
            End Using
        End Sub
    End Module
' End Namespace

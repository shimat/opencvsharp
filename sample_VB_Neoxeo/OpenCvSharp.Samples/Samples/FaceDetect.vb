'#define CHECK_MEMORY_LEAK

Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

Namespace OpenCvSharpSamples
	''' <summary>
	''' 顔の検出
	''' </summary>
	''' <remarks>http://opencv.jp/sample/object_detection.html#face_detection</remarks>
    Friend Module FaceDetect
        Public Sub Start()
            CheckMemoryLeak()

            ' CvHaarClassifierCascade, cvHaarDetectObjects
            ' 顔を検出するためにHaar分類器のカスケードを用いる

            Dim colors() As CvColor = { _
                New CvColor(0, 0, 255), _
                New CvColor(0, 128, 255), _
                New CvColor(0, 255, 255), _
                New CvColor(0, 255, 0), _
                New CvColor(255, 128, 0), _
                New CvColor(255, 255, 0), _
                New CvColor(255, 0, 0), _
                New CvColor(255, 0, 255) _
            }

            Const Scale As Double = 1.14
            Const ScaleFactor As Double = 1.085
            Const MinNeighbors As Integer = 2

            Using img As New IplImage([Const].ImageYalta, LoadMode.Color)
                Using smallImg As New IplImage(New CvSize(Cv.Round(img.Width / Scale), Cv.Round(img.Height / Scale)), BitDepth.U8, 1)
                    ' 顔検出用の画像の生成
                    Using gray As New IplImage(img.Size, BitDepth.U8, 1)
                        Cv.CvtColor(img, gray, ColorConversion.BgrToGray)
                        Cv.Resize(gray, smallImg, Interpolation.Linear)
                        Cv.EqualizeHist(smallImg, smallImg)
                    End Using

                    'using (CvHaarClassifierCascade cascade = Cv.Load<CvHaarClassifierCascade>(Const.XmlHaarcascade))  // どっちでも可
                    Using cascade As CvHaarClassifierCascade = CvHaarClassifierCascade.FromFile([Const].XmlHaarcascade)
                        Using storage As New CvMemStorage()
                            storage.Clear()

                            ' 顔の検出
                            Dim watch As Stopwatch = Stopwatch.StartNew()
                            Dim faces As CvSeq(Of CvAvgComp) = Cv.HaarDetectObjects(smallImg, cascade, storage, ScaleFactor, MinNeighbors, 0, New CvSize(30, 30))
                            watch.Stop()
                            Form1.TextBox1.AppendText(Environment.NewLine & String.Format("detection time = {0}ms" & vbLf, watch.ElapsedMilliseconds))

                            ' 検出した箇所にまるをつける
                            For i As Integer = 0 To faces.Total - 1
                                Dim r As CvRect = faces(i).Value.Rect
                                Dim center As CvPoint = New CvPoint With {.X = Cv.Round((r.X + r.Width * 0.5) * Scale), .Y = Cv.Round((r.Y + r.Height * 0.5) * Scale)}
                                Dim radius As Integer = Cv.Round((r.Width + r.Height) * 0.25 * Scale)
                                img.Circle(center, radius, colors(i Mod 8), 3, LineType.AntiAlias, 0)
                            Next i
                        End Using
                    End Using

                    ' ウィンドウに表示
                    CvWindow.ShowImages(img)
                End Using
            End Using
        End Sub

        <Conditional("CHECK_MEMORY_LEAK")> _
        Private Sub CheckMemoryLeak()
            Do
                Form1.TextBox1.AppendText(Environment.NewLine & String.Format("{0} Kbytes", GC.GetTotalMemory(False) \ 1024))
                Console.WriteLine("{0} Kbytes", GC.GetTotalMemory(False) \ 1024)
                Dim keyInfo As ConsoleKeyInfo = Console.ReadKey()
                Select Case keyInfo.Key
                    Case ConsoleKey.Enter
                        For i As Integer = 0 To 127
                            Using cascade As CvHaarClassifierCascade = CvHaarClassifierCascade.FromFile([Const].XmlHaarcascade)
                            End Using
                            'using (CvMat mat = new CvMat(1, 1024, MatrixType.U8C1))
                            '{                                
                            '}
                        Next i
                        GC.Collect()
                    Case ConsoleKey.Escape
                        GoTo END_LOOP
                End Select

            Loop
END_LOOP:

        End Sub

    End Module
End Namespace

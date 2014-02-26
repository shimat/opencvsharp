Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' 動画としてファイルへ書き出す
    ''' </summary>
    ''' <remarks>http://opencv.jp/sample/video_io.html#cap_write</remarks>
    Friend Module VideoWriter
        Public Sub Start()
            ' (1)カメラに対するキャプチャ構造体を作成する
            Using capture As CvCapture = CvCapture.FromCamera(0)
                ' (2)キャプチャサイズを取得する(この設定は，利用するカメラに依存する)
                Dim width As Integer = capture.FrameWidth
                Dim height As Integer = capture.FrameHeight
                Dim fps As Double = 15 'capture.Fps;
                ' (3)ビデオライタ構造体を作成する
                Using writer As New CvVideoWriter("cap.avi", FourCC.Prompt, fps, New CvSize(width, height))
                    Using font As New CvFont(FontFace.HersheyComplex, 0.7, 0.7)
                        Using window As New CvWindow("Capture", WindowMode.AutoSize)
                            ' (4)カメラから画像をキャプチャし，ファイルに書き出す
                            Dim frames As Integer = 0
                            Do
                                Dim frame As IplImage = capture.QueryFrame()
                                Dim str As String = String.Format("{0}[frame]", frames)
                                frame.PutText(str, New CvPoint(10, 20), font, New CvColor(0, 255, 100))
                                writer.WriteFrame(frame)
                                window.ShowImage(frame)

                                Dim key As Integer = CvWindow.WaitKey(CInt(Math.Truncate(1000 / fps)))
                                If ChrW(key) = ChrW(&H1B) Then
                                    Exit Do
                                End If
                                frames += 1
                            Loop
                        End Using
                    End Using
                End Using
            End Using

        End Sub
    End Module
' End Namespace

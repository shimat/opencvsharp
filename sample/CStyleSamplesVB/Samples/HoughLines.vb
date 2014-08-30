Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' ハフ変換による直線検出
''' </summary>
''' <remarks>http://opencv.jp/sample/special_transforms.html#hough_line</remarks>
Friend Module HoughLines
    Public Sub Start()

        ' (1)画像の読み込み 
        Using srcImgGray As New IplImage(FilePath.Image.Goryokaku, LoadMode.GrayScale), _
             srcImgStd As New IplImage(FilePath.Image.Goryokaku, LoadMode.Color), _
             srcImgProb As IplImage = srcImgStd.Clone()
            ' (2)ハフ変換のための前処理 
            Cv.Canny(srcImgGray, srcImgGray, 50, 200, ApertureSize.Size3)
            Using storage As New CvMemStorage()
                ' (3)標準的ハフ変換による線の検出と検出した線の描画
                Dim lines As CvSeq = srcImgGray.HoughLines2(storage, HoughLinesMethod.Standard, 1, Math.PI / 180, 50, 0, 0)
                ' wrapper style
                'CvLineSegmentPolar[] lines = src_img_gray.HoughLinesStandard(1, Math.PI / 180, 50, 0, 0);

                Dim limit As Integer = Math.Min(lines.Total, 10)
                For i As Integer = 0 To limit - 1
                    ' native code style
                    '                        
                    '                        unsafe
                    '                        {
                    '                            float* line = (float*)lines.GetElem<IntPtr>(i).Value.ToPointer();
                    '                            float rho = line[0];
                    '                            float theta = line[1];
                    '                        }
                    '                        //

                    ' wrapper style
                    Dim elem As CvLineSegmentPolar = lines.GetSeqElem(Of CvLineSegmentPolar)(i).Value
                    Dim rho As Single = elem.Rho
                    Dim theta As Single = elem.Theta

                    Dim a As Double = Math.Cos(theta)
                    Dim b As Double = Math.Sin(theta)
                    Dim x0 As Double = a * rho
                    Dim y0 As Double = b * rho
                    Dim pt1 As CvPoint = New CvPoint With {.X = Cv.Round(x0 + 1000 * (-b)), .Y = Cv.Round(y0 + 1000 * (a))}
                    Dim pt2 As CvPoint = New CvPoint With {.X = Cv.Round(x0 - 1000 * (-b)), .Y = Cv.Round(y0 - 1000 * (a))}
                    srcImgStd.Line(pt1, pt2, CvColor.Red, 3, LineType.AntiAlias, 0)
                Next i

                ' (4)確率的ハフ変換による線分の検出と検出した線分の描画
                lines = srcImgGray.HoughLines2(storage, HoughLinesMethod.Probabilistic, 1, Math.PI / 180, 50, 50, 10)
                ' wrapper style
                'CvLineSegmentPoint[] lines = src_img_gray.HoughLinesProbabilistic(1, Math.PI / 180, 50, 0, 0);

                For i As Integer = 0 To lines.Total - 1
                    ' native code style
                    '                        
                    '                        unsafe
                    '                        {
                    '                            CvPoint* point = (CvPoint*)lines.GetElem<IntPtr>(i).Value.ToPointer();
                    '                            src_img_prob.Line(point[0], point[1], CvColor.Red, 3, LineType.AntiAlias, 0);
                    '                        }
                    '                        //

                    ' wrapper style
                    Dim elem As CvLineSegmentPoint = lines.GetSeqElem(Of CvLineSegmentPoint)(i).Value
                    srcImgProb.Line(elem.P1, elem.P2, CvColor.Red, 3, LineType.AntiAlias, 0)
                Next i
            End Using

            ' (5)検出結果表示用のウィンドウを確保し表示する
            Using TempCvWindow As CvWindow = New CvWindow("Hough_line_standard", WindowMode.AutoSize, srcImgStd), _
                 TempCvWindowProb As CvWindow = New CvWindow("Hough_line_probabilistic", WindowMode.AutoSize, srcImgProb)
                CvWindow.WaitKey(0)

            End Using
        End Using
    End Sub
End Module
' End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' ヒストグラムの描画
''' </summary>
''' <remarks>
''' http://opencv.jp/sample/histogram.html#hist
''' </remarks>
Friend Module Histogram
    Public Sub Start()
        ' cvCalcHist
        ' コントラストや明度をいろいろ変えられるサンプル

        Const histSize As Integer = 64
        Dim range0() As Single = {0, 256}
        Dim ranges()() As Single = {range0}

        ' 画像の読み込み
        Using srcImg As New IplImage(FilePath.Image.Lenna, LoadMode.GrayScale)
            Using dstImg As IplImage = srcImg.Clone()
                Using histImg As New IplImage(New CvSize(400, 400), BitDepth.U8, 1)
                    Using hist As New CvHistogram(New Integer() {histSize}, HistogramFormat.Array, ranges, True)
                        Using windowImage As New CvWindow("image", WindowMode.AutoSize)
                            Using windowHist As New CvWindow("histogram", WindowMode.AutoSize)
                                ' トラックバーが動かされた時の処理
                                Dim ctBrightness As CvTrackbar = Nothing
                                Dim ctContrast As CvTrackbar = Nothing
                                Dim callback As CvTrackbarCallback = Sub(pos As Integer)
                                                                         Dim brightness As Integer = ctBrightness.Pos - 100
                                                                         Dim contrast As Integer = ctContrast.Pos - 100
                                                                         ' LUTの適用
                                                                         Dim lut() As Byte = CalcLut(contrast, brightness)
                                                                         srcImg.LUT(dstImg, lut)
                                                                         ' ヒストグラムの描画
                                                                         CalcHist(dstImg, hist)
                                                                         DrawHist(histImg, hist, histSize)
                                                                         ' ウィンドウに表示
                                                                         windowImage.ShowImage(dstImg)
                                                                         windowHist.ShowImage(histImg)
                                                                         dstImg.Zero()
                                                                         histImg.Zero()
                                                                     End Sub

                                ' トラックバーの作成
                                ' (OpenCVでは現在位置にポインタを渡すことでトラックバーの位置の変化が取得できるが、
                                ' .NETではGCによりポインタが移動してしまうので廃止した。別の方法でうまく取得すべし。)
                                ctBrightness = windowImage.CreateTrackbar("brightness", 100, 200, callback)
                                ctContrast = windowImage.CreateTrackbar("contrast", 100, 200, callback)
                                ' 初回描画
                                callback(0)

                                ' キー入力待ち
                                Cv.WaitKey(0)
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' contrastとbrightnessの値からLUTの値を計算し、byte配列で返す
    ''' </summary>
    ''' <param name="contrast"></param>
    ''' <param name="brightness"></param>
    ''' <returns></returns>
    Private Function CalcLut(ByVal contrast As Integer, ByVal brightness As Integer) As Byte()
        Dim lut(255) As Byte
        '            
        '             * The algorithm is by Werner D. Streidt
        '             * (http://visca.com/ffactory/archives/5-99/msg00021.html)
        '             
        If contrast > 0 Then
            Dim delta As Double = 127.0 * contrast \ 100
            Dim a As Double = 255.0 / (255.0 - delta * 2)
            Dim b As Double = a * (brightness - delta)
            For i As Integer = 0 To 255
                Dim v As Integer = Cv.Round(a * i + b)
                If v < 0 Then
                    v = 0
                End If
                If v > 255 Then
                    v = 255
                End If
                lut(i) = CByte(v)
            Next i
        Else
            Dim delta As Double = -128.0 * contrast \ 100
            Dim a As Double = (256.0 - delta * 2) / 255.0
            Dim b As Double = a * brightness + delta
            For i As Integer = 0 To 255
                Dim v As Integer = Cv.Round(a * i + b)
                If v < 0 Then
                    v = 0
                End If
                If v > 255 Then
                    v = 255
                End If
                lut(i) = CByte(v)
            Next i
        End If
        Return lut
    End Function
    ''' <summary>
    ''' ヒストグラムの計算
    ''' </summary>
    ''' <param name="img"></param>
    ''' <param name="hist"></param>
    Private Sub CalcHist(ByVal img As IplImage, ByVal hist As CvHistogram)
        hist.Calc(img)
        Dim minValue, maxValue As Single
        hist.GetMinMaxValue(minValue, maxValue)
        Cv.Scale(hist.Bins, hist.Bins, (CDbl(img.Height)) / maxValue, 0)
    End Sub
    ''' <summary>
    ''' ヒストグラムの描画
    ''' </summary>
    ''' <param name="img"></param>
    ''' <param name="hist"></param>
    ''' <param name="histSize"></param>
    Private Sub DrawHist(ByVal img As IplImage, ByVal hist As CvHistogram, ByVal histSize As Integer)
        img.Set(CvColor.White)
        Dim binW As Integer = Cv.Round(CDbl(img.Width) / histSize)
        For i As Integer = 0 To histSize - 1
            img.Rectangle(New CvPoint(i * binW, img.Height), New CvPoint((i + 1) * binW, img.Height - Cv.Round(hist.Bins(i))), CvColor.Black, -1, LineType.AntiAlias, 0)
        Next i
    End Sub
End Module
' End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 離散フーリエ変換
''' </summary>
''' <remarks>
''' http://opencv.jp/sample/discrete_transforms.html#dft
''' </remarks>
Friend Module DFT
    Public Sub Start()
        Using srcImg As IplImage = Cv.LoadImage(FilePath.Image.Goryokaku, LoadMode.GrayScale)
            Using srcImgGauss As IplImage = srcImg.Clone()
                RunDFT(srcImg)
                Cv.Smooth(srcImg, srcImgGauss, SmoothType.Gaussian, 11)
                RunDFT(srcImgGauss)
                Cv.Smooth(srcImg, srcImgGauss, SmoothType.Gaussian, 31)
                RunDFT(srcImgGauss)
                Cv.Smooth(srcImg, srcImgGauss, SmoothType.Gaussian, 101)
                RunDFT(srcImgGauss)
            End Using
        End Using
    End Sub

    Private Sub RunDFT(ByVal srcImg As IplImage)
        ' cvDFT
        ' 離散フーリエ変換を用いて，振幅画像を生成する．

        'using (IplImage srcImg = Cv.LoadImage(Const.ImageGoryokaku, LoadMode.GrayScale))
        Using realInput As IplImage = Cv.CreateImage(srcImg.Size, BitDepth.F64, 1), _
             imaginaryInput As IplImage = Cv.CreateImage(srcImg.Size, BitDepth.F64, 1), _
         complexInput As IplImage = Cv.CreateImage(srcImg.Size, BitDepth.F64, 2)
            ' (1)入力画像を実数配列にコピーし，虚数配列とマージして複素数平面を構成
            Cv.Scale(srcImg, realInput, 1.0, 0.0)
            Cv.Zero(imaginaryInput)
            Cv.Merge(realInput, imaginaryInput, Nothing, Nothing, complexInput)
            ' (2)DFT用の最適サイズを計算し，そのサイズで行列を確保する
            Dim dftM As Integer = Cv.GetOptimalDFTSize(srcImg.Height - 1)
            Dim dftN As Integer = Cv.GetOptimalDFTSize(srcImg.Width - 1)
            Using dft_A As CvMat = Cv.CreateMat(dftM, dftN, MatrixType.F64C2), _
                imageRe As New IplImage(New CvSize(dftN, dftM), BitDepth.F64, 1), _
                imageIm As New IplImage(New CvSize(dftN, dftM), BitDepth.F64, 1)
                ' (3)複素数平面をdft_Aにコピーし，残りの行列右側部分を0で埋める
                Dim tmp As CvMat
                Cv.GetSubRect(dft_A, tmp, New CvRect(0, 0, srcImg.Width, srcImg.Height))
                Cv.Copy(complexInput, tmp, Nothing)
                If dft_A.Cols > srcImg.Width Then
                    Cv.GetSubRect(dft_A, tmp, New CvRect(srcImg.Width, 0, dft_A.Cols - srcImg.Width, srcImg.Height))
                    Cv.Zero(tmp)
                End If
                ' (4)離散フーリエ変換を行い，その結果を実数部分と虚数部分に分解
                Cv.DFT(dft_A, dft_A, DFTFlag.Forward, complexInput.Height)
                Cv.Split(dft_A, imageRe, imageIm, Nothing, Nothing)
                ' (5)スペクトルの振幅を計算 Mag = sqrt(Re^2 + Im^2)
                Cv.Pow(imageRe, imageRe, 2.0)
                Cv.Pow(imageIm, imageIm, 2.0)
                Cv.Add(imageRe, imageIm, imageRe, Nothing)
                Cv.Pow(imageRe, imageRe, 0.5)
                ' (6)振幅の対数をとる log(1 + Mag)  
                Cv.AddS(imageRe, CvScalar.ScalarAll(1.0), imageRe, Nothing)
                Cv.Log(imageRe, imageRe)
                ' (7)原点（直流成分）が画像の中心にくるように，画像の象限を入れ替える
                ShiftDFT(imageRe, imageRe)
                ' (8)振幅画像のピクセル値が0.0-1.0に分布するようにスケーリング
                'INSTANT VB NOTE: The variable M was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
                Dim m, M_Renamed As Double
                Cv.MinMaxLoc(imageRe, m, M_Renamed)
                Cv.Scale(imageRe, imageRe, 1.0 / (M_Renamed - m), 1.0 * (-m) / (M_Renamed - m))
                Using TempCvWindow As CvWindow = New CvWindow("Image", WindowMode.AutoSize, srcImg), _
                    TempCvWindowMagnitude As CvWindow = New CvWindow("Magnitude", WindowMode.AutoSize, imageRe)
                    Cv.WaitKey(0)
                End Using
            End Using
        End Using

    End Sub

    ''' <summary>
    ''' 原点（直流成分）が画像の中心にくるように，画像の象限を入れ替える関数.
    ''' srcArr, dstArr は同じサイズ，タイプの配列.
    ''' </summary>
    ''' <param name="srcArr"></param>
    ''' <param name="dstArr"></param>
    Private Sub ShiftDFT(ByVal srcArr As CvArr, ByVal dstArr As CvArr)
        Dim size As CvSize = Cv.GetSize(srcArr)
        Dim dstSize As CvSize = Cv.GetSize(dstArr)
        If dstSize.Width <> size.Width OrElse dstSize.Height <> size.Height Then
            Throw New ApplicationException("Source and Destination arrays must have equal sizes")
        End If
        ' (9)インプレースモード用のテンポラリバッファ
        Dim tmp As CvMat = Nothing
        If srcArr Is dstArr Then
            tmp = Cv.CreateMat(size.Height \ 2, size.Width \ 2, Cv.GetElemType(srcArr))
        End If
        Dim cx As Integer = size.Width \ 2 ' 画像中心
        Dim cy As Integer = size.Height \ 2

        ' (10)1〜4象限を表す配列と，そのコピー先
        Dim q1stub, q2stub As CvMat
        Dim q3stub, q4stub As CvMat
        Dim d1stub, d2stub As CvMat
        Dim d3stub, d4stub As CvMat
        Dim q1 As CvMat = Cv.GetSubRect(srcArr, q1stub, New CvRect(0, 0, cx, cy))
        Dim q2 As CvMat = Cv.GetSubRect(srcArr, q2stub, New CvRect(cx, 0, cx, cy))
        Dim q3 As CvMat = Cv.GetSubRect(srcArr, q3stub, New CvRect(cx, cy, cx, cy))
        Dim q4 As CvMat = Cv.GetSubRect(srcArr, q4stub, New CvRect(0, cy, cx, cy))
        Dim d1 As CvMat = Cv.GetSubRect(srcArr, d1stub, New CvRect(0, 0, cx, cy))
        Dim d2 As CvMat = Cv.GetSubRect(srcArr, d2stub, New CvRect(cx, 0, cx, cy))
        Dim d3 As CvMat = Cv.GetSubRect(srcArr, d3stub, New CvRect(cx, cy, cx, cy))
        Dim d4 As CvMat = Cv.GetSubRect(srcArr, d4stub, New CvRect(0, cy, cx, cy))
        ' (11)実際の象限の入れ替え
        If srcArr IsNot dstArr Then
            If Not Cv.ARE_TYPES_EQ(q1, d1) Then
                Throw New ApplicationException("Source and Destination arrays must have the same format")
            End If
            Cv.Copy(q3, d1, Nothing)
            Cv.Copy(q4, d2, Nothing)
            Cv.Copy(q1, d3, Nothing)
            Cv.Copy(q2, d4, Nothing)
        Else
            Cv.Copy(q3, tmp, Nothing)
            Cv.Copy(q1, q3, Nothing)
            Cv.Copy(tmp, q1, Nothing)
            Cv.Copy(q4, tmp, Nothing)
            Cv.Copy(q2, q4, Nothing)
            Cv.Copy(tmp, q2, Nothing)
        End If
        If tmp IsNot Nothing Then
            tmp.Dispose()
        End If
    End Sub
End Module
' End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' モルフォロジー変換
    ''' </summary>
    ''' <remarks>http://opencv.jp/sample/morphology.html#morphology</remarks>
    Friend Module Morphology
        Public Sub Start()
            ' cvMorphologyEx
            ' 構造要素を指定して，様々なモルフォロジー演算を行なう

            '(1)画像の読み込み，演算結果画像領域の確保を行なう
            Using srcImg As New IplImage([Const].ImageLenna, LoadMode.AnyDepth Or LoadMode.AnyColor)
                Using dstImgDilate As IplImage = srcImg.Clone()
                    Using dstImgErode As IplImage = srcImg.Clone()
                        Using dstImgOpening As IplImage = srcImg.Clone()
                            Using dstImgClosing As IplImage = srcImg.Clone()
                                Using dstImgGradient As IplImage = srcImg.Clone()
                                    Using dstImgTophat As IplImage = srcImg.Clone()
                                        Using dstImgBlackhat As IplImage = srcImg.Clone()
                                            Using tmpImg As IplImage = srcImg.Clone()
                                                '(2)構造要素を生成する 
                                                Dim element As IplConvKernel = Cv.CreateStructuringElementEx(9, 9, 4, 4, ElementShape.Rect, Nothing)
                                                '(3)各種のモルフォロジー演算を実行する 
                                                Cv.Dilate(srcImg, dstImgDilate, element, 1)
                                                Cv.Erode(srcImg, dstImgErode, element, 1)
                                                Cv.MorphologyEx(srcImg, dstImgOpening, tmpImg, element, MorphologyOperation.Open, 1)
                                                Cv.MorphologyEx(srcImg, dstImgClosing, tmpImg, element, MorphologyOperation.Close, 1)
                                                Cv.MorphologyEx(srcImg, dstImgGradient, tmpImg, element, MorphologyOperation.Gradient, 1)
                                                Cv.MorphologyEx(srcImg, dstImgTophat, tmpImg, element, MorphologyOperation.TopHat, 1)
                                                Cv.MorphologyEx(srcImg, dstImgBlackhat, tmpImg, element, MorphologyOperation.BlackHat, 1)

                                                '(4)モルフォロジー演算結果を表示する 
                                                Using TempCvWindow As CvWindow = New CvWindow("src", srcImg)
                                                    Using TempCvWindowDil As CvWindow = New CvWindow("dilate", dstImgDilate)
                                                        Using TempCvWindowEro As CvWindow = New CvWindow("erode", dstImgErode)
                                                            Using TempCvWindowOpe As CvWindow = New CvWindow("opening", dstImgOpening)
                                                                Using TempCvWindowClo As CvWindow = New CvWindow("closing", dstImgClosing)
                                                                    Using TempCvWindowGra As CvWindow = New CvWindow("gradient", dstImgGradient)
                                                                        Using TempCvWindowTop As CvWindow = New CvWindow("tophat", dstImgTophat)
                                                                            Using TempCvWindowBla As CvWindow = New CvWindow("blackhat", dstImgBlackhat)
                                                                                Cv.WaitKey(0)
                                                                            End Using
                                                                        End Using
                                                                    End Using
                                                                End Using
                                                            End Using
                                                        End Using
                                                    End Using
                                                End Using
                                            End Using
                                        End Using
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Sub
    End Module
' End Namespace

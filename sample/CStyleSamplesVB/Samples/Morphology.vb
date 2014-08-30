Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' モルフォロジー変換
''' </summary>
''' <remarks>http://opencv.jp/sample/morphology.html#morphology</remarks>
Friend Module Morphology
    Public Sub Start()
        ' cvMorphologyEx

        '(1)画像の読み込み，演算結果画像領域の確保を行なう
        Using srcImg As New IplImage(FilePath.Image.Lenna, LoadMode.AnyDepth Or LoadMode.AnyColor)
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
                                            Using New CvWindow("src", srcImg)
                                                Using New CvWindow("dilate", dstImgDilate)
                                                    Using New CvWindow("erode", dstImgErode)
                                                        Using New CvWindow("opening", dstImgOpening)
                                                            Using New CvWindow("closing", dstImgClosing)
                                                                Using New CvWindow("gradient", dstImgGradient)
                                                                    Using New CvWindow("tophat", dstImgTophat)
                                                                        Using New CvWindow("blackhat", dstImgBlackhat)
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

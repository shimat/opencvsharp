Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' エッジ検出
''' </summary>
    Friend Module Edge
        Public Sub Start()
        Using src As New IplImage(FilePath.Image.Lenna, LoadMode.Color)
            Using gray As New IplImage(src.Size, BitDepth.U8, 1)
                Using temp As New IplImage(src.Size, BitDepth.S16, 1)
                    Using dstSobel As New IplImage(src.Size, BitDepth.U8, 1)
                        Using dstLaplace As New IplImage(src.Size, BitDepth.U8, 1)
                            Using dstCanny As New IplImage(src.Size, BitDepth.U8, 1)
                                'src.CvtColor(gray, ColorConversion.RgbToGray);
                                src.CvtColor(gray, ColorConversion.BgrToGray)

                                ' Sobel
                                Cv.Sobel(gray, temp, 1, 0, ApertureSize.Size3)
                                Cv.ConvertScaleAbs(temp, dstSobel)

                                ' Laplace
                                Cv.Laplace(gray, temp)
                                Cv.ConvertScaleAbs(temp, dstLaplace)

                                ' Canny
                                Cv.Canny(gray, dstCanny, 50, 200, ApertureSize.Size3)

                                Using TempCvWindowSrc As CvWindow = New CvWindow("src", src)
                                    Using TempCvWindowSobel As CvWindow = New CvWindow("sobel", dstSobel)
                                        Using TempCvWindowLaplace As CvWindow = New CvWindow("laplace", dstLaplace)
                                            Using TempCvWindowCanny As CvWindow = New CvWindow("canny", dstCanny)
                                                CvWindow.WaitKey()
                                            End Using
                                        End Using
                                    End Using
                                End Using

                                dstSobel.SaveImage("sobel.png")
                                dstLaplace.SaveImage("laplace.png")
                                dstCanny.SaveImage("canny.png")
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
        End Sub
    End Module
' End Namespace

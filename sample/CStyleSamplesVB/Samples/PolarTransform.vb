Imports System
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' samples/c/polar_transform.c
''' </summary>
    Friend Module PolarTransform
        Public Sub Start()
        Using imgSrc As IplImage = Cv.LoadImage(FilePath.Image.Fruits, LoadMode.Color)
            Using imgLog As IplImage = Cv.CreateImage(Cv.Size(256, 256), BitDepth.U8, 3)
                Using imgLinear As IplImage = Cv.CreateImage(Cv.Size(256, 256), BitDepth.U8, 3)
                    Using imgRecovered1 As IplImage = Cv.CreateImage(Cv.GetSize(imgSrc), BitDepth.U8, 3)
                        Using imgRecovered2 As IplImage = Cv.CreateImage(Cv.GetSize(imgSrc), BitDepth.U8, 3)
                            Cv.LogPolar(imgSrc, imgLog, Cv.Point2D32f(imgSrc.Width / 2.0F, imgSrc.Height / 2.0F), 40, Interpolation.Linear Or Interpolation.FillOutliers)
                            Cv.LogPolar(imgLog, imgRecovered1, Cv.Point2D32f(imgSrc.Width / 2.0F, imgSrc.Height / 2.0F), 40, Interpolation.Linear Or Interpolation.FillOutliers Or Interpolation.InverseMap)

                            Cv.LinearPolar(imgSrc, imgLinear, Cv.Point2D32f(imgSrc.Width / 2.0F, imgSrc.Height / 2.0F), imgLinear.Width, Interpolation.Linear Or Interpolation.FillOutliers)
                            Cv.LinearPolar(imgLinear, imgRecovered2, Cv.Point2D32f(imgSrc.Width / 2.0F, imgSrc.Height / 2.0F), imgLinear.Width, Interpolation.InverseMap Or Interpolation.Linear Or Interpolation.FillOutliers)

                            Cv.NamedWindow("log-polar")
                            Cv.ShowImage("log-polar", imgLog)
                            Cv.NamedWindow("inverse log-polar")
                            Cv.ShowImage("inverse log-polar", imgRecovered1)
                            Cv.NamedWindow("linear-polar")
                            Cv.ShowImage("linear-polar", imgLinear)
                            Cv.NamedWindow("inverse linear-polar")
                            Cv.ShowImage("inverse linear-polar", imgRecovered2)
                            Cv.WaitKey()
                            Cv.DestroyAllWindows()
                        End Using
                    End Using
                End Using
            End Using
        End Using

        End Sub
    End Module
' End Namespace

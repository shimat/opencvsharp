Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' cvFitLine sample
    ''' </summary>
    Friend Module FitLine
        Public Sub Start()
            Dim imageSize As New CvSize(500, 500)

            ' cvFitLine
            Dim points() As CvPoint2D32f = GetRandomPoints(20, imageSize)
            Dim line As CvLine2D = Cv.FitLine2D(points, DistanceType.L2, 0, 0.01, 0.01)

            Using img As New IplImage(imageSize, BitDepth.U8, 3)
                img.Zero()

                ' draw line
                Dim pt1, pt2 As CvPoint
                line.FitSize(img.Width, img.Height, pt1, pt2)
                img.Line(pt1, pt2, CvColor.Green, 1, LineType.Link8)

                ' draw points and distances
                Using font As New CvFont(FontFace.HersheySimplex, 0.33, 0.33)
                    For Each p As CvPoint2D32f In points
                        Dim d As Double = line.Distance(p)

                        img.Circle(p, 2, CvColor.White, -1, LineType.AntiAlias)
                        img.PutText(String.Format("{0:F1}", d), New CvPoint(CInt(Math.Truncate(p.X + 3)), CInt(Math.Truncate(p.Y + 3))), font, CvColor.Green)
                    Next p
                End Using

                CvWindow.ShowImages(img)
            End Using
        End Sub


        Private Function GetRandomPoints(ByVal count As Integer, ByVal imageSize As CvSize) As CvPoint2D32f()
            Dim rand As New Random()
            Dim points(count - 1) As CvPoint2D32f
            Dim a As Double = rand.NextDouble() + 0.5
            For i As Integer = 0 To points.Length - 1
                Dim x As Double = rand.Next(imageSize.Width)
                Dim y As Double = (x * a) + (rand.Next(100) - 50)
                points(i) = New CvPoint2D32f(x, y)
            Next i
            Return points
        End Function
    End Module
' End Namespace

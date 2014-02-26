Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' Building convex hull for a sequence or array of points
    ''' </summary>
    ''' <remarks>
    ''' http://opencv.jp/opencv-1.1.0/document/opencvref_cv_geometry.html#decl_cvConvexHull2
    ''' </remarks>
    Friend Module ConvexHull
        Public Sub Start()
            Using img As IplImage = Cv.CreateImage(New CvSize(500, 500), BitDepth.U8, 3)
                Using window As New CvWindow("hull")
                    Dim rand As New Random()

                    Do
                        Dim count As Integer = rand.Next() Mod 100 + 1

                        ' create sequence of random points
                        Dim ptseq(count - 1) As CvPoint
                        For i As Integer = 0 To ptseq.Length - 1
                            ptseq(i) = New CvPoint With {.X = rand.Next() Mod (img.Width \ 2) + img.Width \ 4, .Y = rand.Next() Mod (img.Height \ 2) + img.Height \ 4}
                        Next i

                        ' draw points
                        Cv.Zero(img)
                        For Each pt As CvPoint In ptseq
                            Cv.Circle(img, pt, 2, New CvColor(255, 0, 0), -1)
                        Next pt

                        ' find hull
                        Dim hull() As CvPoint
                        Cv.ConvexHull2(ptseq, hull, ConvexHullOrientation.Clockwise)

                        ' draw hull
                        Dim pt0 As CvPoint = hull.Last()
                        For Each pt As CvPoint In hull
                            Cv.Line(img, pt0, pt, CvColor.Green)
                            pt0 = pt
                        Next pt


                        window.ShowImage(img)

                        If Cv.WaitKey(0) = 27 Then ' 'ESC'
                            Exit Do
                        End If
                    Loop

                End Using
            End Using
        End Sub
    End Module
' End Namespace

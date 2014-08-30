Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' samples/c/squares.c
''' </summary>
Friend Module Squares
    Private Const Thresh As Integer = 50
    Private Const WindowName As String = "Square Detection Demo"
    Private ReadOnly Names() As String = {
        FilePath.Image.Square1,
        FilePath.Image.Square2,
        FilePath.Image.Square3,
        FilePath.Image.Square4,
        FilePath.Image.Square5,
        FilePath.Image.Square6}

    Public Sub Start()
        ' create memory storage that will contain all the dynamic data
        Dim storage As New CvMemStorage(0)

        For i As Integer = 0 To Names.Length - 1
            ' load i-th image
            Using img As New IplImage(Names(i), LoadMode.Color)
                ' create window and a trackbar (slider) with parent "image" and set callback
                ' (the slider regulates upper threshold, passed to Canny edge detector) 
                Cv.NamedWindow(WindowName, WindowMode.AutoSize)

                ' find and draw the squares
                DrawSquares(img, FindSquares4(img, storage))
            End Using

            ' clear memory storage - reset free space position
            storage.Clear()

            ' wait for key.
            ' Also the function cvWaitKey takes care of event processing
            Dim c As Integer = Cv.WaitKey(0)
            If ChrW(c) = ChrW(27) Then
                Exit For
            End If
        Next i

        Cv.DestroyWindow(WindowName)
    End Sub

    ''' <summary>
    ''' helper function:
    ''' finds a cosine of Angle between vectors
    ''' from pt0->pt1 and from pt0->pt2 
    ''' </summary>
    ''' <param name="pt1"></param>
    ''' <param name="pt2"></param>
    ''' <param name="pt0"></param>
    ''' <returns></returns>
    Private Function Angle(ByVal pt1 As CvPoint, ByVal pt2 As CvPoint, ByVal pt0 As CvPoint) As Double
        Dim dx1 As Double = pt1.X - pt0.X
        Dim dy1 As Double = pt1.Y - pt0.Y
        Dim dx2 As Double = pt2.X - pt0.X
        Dim dy2 As Double = pt2.Y - pt0.Y
        Return (dx1 * dx2 + dy1 * dy2) / Math.Sqrt((dx1 * dx1 + dy1 * dy1) * (dx2 * dx2 + dy2 * dy2) + 0.0000000001)
    End Function

    ''' <summary>
    ''' returns sequence of squares detected on the image.
    ''' the sequence is stored in the specified memory storage
    ''' </summary>
    ''' <param name="img"></param>
    ''' <param name="storage"></param>
    ''' <returns></returns>
    Private Function FindSquares4(ByVal img As IplImage, ByVal storage As CvMemStorage) As CvPoint()
        Const N As Integer = 11

        Dim sz As New CvSize(img.Width And -2, img.Height And -2)
        Dim timg As IplImage = img.Clone() ' make a copy of input image
        Dim gray As New IplImage(sz, BitDepth.U8, 1)
        Dim pyr As New IplImage(sz.Width \ 2, sz.Height \ 2, BitDepth.U8, 3)
        ' create empty sequence that will contain points -
        ' 4 points per square (the square's vertices)
        Dim squares As New CvSeq(Of CvPoint)(SeqType.Zero, CvSeq.SizeOf, storage)

        ' select the maximum ROI in the image
        ' with the width and height divisible by 2
        timg.ROI = New CvRect(0, 0, sz.Width, sz.Height)

        ' down-Scale and upscale the image to filter out the noise
        Cv.PyrDown(timg, pyr, CvFilter.Gaussian5x5)
        Cv.PyrUp(pyr, timg, CvFilter.Gaussian5x5)
        Dim tgray As New IplImage(sz, BitDepth.U8, 1)

        ' find squares in every color plane of the image
        For c As Integer = 0 To 2
            ' extract the c-th color plane
            timg.COI = c + 1
            Cv.Copy(timg, tgray, Nothing)

            ' try several threshold levels
            For l As Integer = 0 To N - 1
                ' hack: use Canny instead of zero threshold level.
                ' Canny helps to catch squares with gradient shading   
                If l = 0 Then
                    ' apply Canny. Take the upper threshold from slider
                    ' and set the lower to 0 (which forces edges merging) 
                    Cv.Canny(tgray, gray, 0, Thresh, ApertureSize.Size5)
                    ' dilate canny output to remove potential
                    ' holes between edge segments 
                    Cv.Dilate(gray, gray, Nothing, 1)
                Else
                    ' apply threshold if l!=0:
                    '     tgray(x,y) = gray(x,y) < (l+1)*255/N ? 255 : 0
                    Cv.Threshold(tgray, gray, (l + 1) * 255.0 / N, 255, ThresholdType.Binary)
                End If

                ' find contours and store them all as a list
                Dim contours As CvSeq(Of CvPoint)
                Cv.FindContours(gray, storage, contours, CvContour.SizeOf, ContourRetrieval.List, ContourChain.ApproxSimple, New CvPoint(0, 0))

                ' test each contour
                Do While contours IsNot Nothing
                    ' approximate contour with accuracy proportional
                    ' to the contour perimeter
                    Dim result As CvSeq(Of CvPoint) = Cv.ApproxPoly(contours, CvContour.SizeOf, storage, ApproxPolyMethod.DP, contours.ContourPerimeter() * 0.02, False)
                    ' square contours should have 4 vertices after approximation
                    ' relatively large area (to filter out noisy contours)
                    ' and be convex.
                    ' Note: absolute value of an area is used because
                    ' area may be positive or negative - in accordance with the
                    ' contour orientation
                    If result.Total = 4 AndAlso Math.Abs(result.ContourArea(CvSlice.WholeSeq)) > 1000 AndAlso result.CheckContourConvexity() Then
                        Dim s As Double = 0

                        For i As Integer = 0 To 4
                            ' find minimum Angle between joint
                            ' edges (maximum of cosine)
                            If i >= 2 Then
                                Dim t As Double = Math.Abs(Angle(result(i).Value, result(i - 2).Value, result(i - 1).Value))
                                s = If(s > t, s, t)
                            End If
                        Next i

                        ' if cosines of all angles are small
                        ' (all angles are ~90 degree) then write quandrange
                        ' vertices to resultant sequence 
                        If s < 0.3 Then
                            For i As Integer = 0 To 3
                                'Console.WriteLine(result[i]);
                                squares.Push(result(i).Value)
                            Next i
                        End If
                    End If

                    ' take the next contour
                    contours = contours.HNext
                Loop
            Next l
        Next c

        ' release all the temporary images
        gray.Dispose()
        pyr.Dispose()
        tgray.Dispose()
        timg.Dispose()

        Return squares.ToArray()
    End Function


    ''' <summary>
    ''' the function draws all the squares in the image
    ''' </summary>
    ''' <param name="img"></param>
    ''' <param name="squares"></param>
    Private Sub DrawSquares(ByVal img As IplImage, ByVal squares() As CvPoint)
        Using cpy As IplImage = img.Clone()
            ' read 4 sequence elements at a time (all vertices of a square)
            For i As Integer = 0 To squares.Length - 1 Step 4
                Dim pt(3) As CvPoint

                ' read 4 vertices
                pt(0) = squares(i + 0)
                pt(1) = squares(i + 1)
                pt(2) = squares(i + 2)
                pt(3) = squares(i + 3)

                ' draw the square as a closed polyline 
                Cv.PolyLine(cpy, New CvPoint()() {pt}, True, CvColor.Green, 3, LineType.AntiAlias, 0)
            Next i

            ' show the resultant image
            Cv.ShowImage(WindowName, cpy)
        End Using
    End Sub
End Module
' End Namespace

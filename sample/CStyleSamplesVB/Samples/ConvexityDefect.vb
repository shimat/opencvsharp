Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.Blob

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' cvConvextyDefects sample
''' </summary>
Friend Module ConvexityDefect
    Public Sub Start()
        Using imgSrc As New IplImage(FilePath.Image.Hand, LoadMode.Color), _
             imgHSV As New IplImage(imgSrc.Size, BitDepth.U8, 3), _
         imgH As New IplImage(imgSrc.Size, BitDepth.U8, 1), _
             imgS As New IplImage(imgSrc.Size, BitDepth.U8, 1), _
             imgV As New IplImage(imgSrc.Size, BitDepth.U8, 1), _
            imgBackProjection As New IplImage(imgSrc.Size, BitDepth.U8, 1), _
            imgFlesh As New IplImage(imgSrc.Size, BitDepth.U8, 1), _
            imgHull As New IplImage(imgSrc.Size, BitDepth.U8, 1), _
            imgDefect As New IplImage(imgSrc.Size, BitDepth.U8, 3), _
            imgContour As New IplImage(imgSrc.Size, BitDepth.U8, 3), _
            storage As New CvMemStorage()
            ' RGB -> HSV
            Cv.CvtColor(imgSrc, imgHSV, ColorConversion.BgrToHsv)
            Cv.CvtPixToPlane(imgHSV, imgH, imgS, imgV, Nothing)
            Dim hsvPlanes() As IplImage = {imgH, imgS, imgV}

            RetrieveFleshRegion(imgSrc, hsvPlanes, imgBackProjection)
            ' Get max area blob
            FilterByMaximalBlob(imgBackProjection, imgFlesh)
            Interpolate(imgFlesh)

            ' find contours
            Dim contours As CvSeq(Of CvPoint) = FindContours(imgFlesh, storage)
            If contours IsNot Nothing Then
                Cv.DrawContours(imgContour, contours, CvColor.Red, CvColor.Green, 0, 3, LineType.AntiAlias)

                ' ConvexHull
                Dim hull() As Integer
                Cv.ConvexHull2(contours, hull, ConvexHullOrientation.Clockwise)
                Cv.Copy(imgFlesh, imgHull)
                DrawConvexHull(contours, hull, imgHull)

                ' ConvexityDefects
                Cv.Copy(imgContour, imgDefect)
                Dim defect As CvSeq(Of CvConvexityDefect) = Cv.ConvexityDefects(contours, hull)
                DrawDefects(imgDefect, defect)
            End If

            Using TempCvWindow As CvWindow = New CvWindow("src", imgSrc), _
                     TempCvWindowBack As CvWindow = New CvWindow("back projection", imgBackProjection), _
                 TempCvWindowHull As CvWindow = New CvWindow("hull", imgHull), _
                 TempCvWindowDefect As CvWindow = New CvWindow("defect", imgDefect)
                Cv.WaitKey()
            End Using

        End Using
    End Sub

    ''' <summary>
    ''' バックプロジェクションにより肌色領域を求める
    ''' </summary>
    ''' <param name="imgSrc"></param>
    ''' <param name="hsvPlanes"></param>
    ''' <param name="imgRender"></param>
    Private Sub RetrieveFleshRegion(ByVal imgSrc As IplImage, ByVal hsvPlanes() As IplImage, ByVal imgDst As IplImage)
        Dim histSize() As Integer = {30, 32}
        Dim hRanges() As Single = {0.0F, 20.0F}
        Dim sRanges() As Single = {50.0F, 255.0F}
        Dim ranges()() As Single = {hRanges, sRanges}

        imgDst.Zero()
        Using hist As New CvHistogram(histSize, HistogramFormat.Array, ranges, True)
            hist.Calc(hsvPlanes, False, Nothing)
            Dim minValue, maxValue As Single
            hist.GetMinMaxValue(minValue, maxValue)
            hist.Normalize(imgSrc.Width * imgSrc.Height * 255 / maxValue)
            hist.CalcBackProject(hsvPlanes, imgDst)
        End Using
    End Sub

    ''' <summary>
    ''' ラベリングにより最大の面積の領域を残す
    ''' </summary>
    ''' <param name="imgSrc"></param>
    ''' <param name="imgRender"></param>
    Private Sub FilterByMaximalBlob(ByVal imgSrc As IplImage, ByVal imgDst As IplImage)
        Dim blobs As New CvBlobs()

        imgDst.Zero()
        blobs.Label(imgSrc)
        Dim max As CvBlob = blobs.GreaterBlob()
        If max Is Nothing Then
            Return
        End If
        blobs.FilterByArea(max.Area, max.Area)
        blobs.FilterLabels(imgDst)
    End Sub

    ''' <summary>
    ''' 欠損領域を補完する
    ''' </summary>
    ''' <param name="img"></param>
    Private Sub Interpolate(ByVal img As IplImage)
        Cv.Dilate(img, img, Nothing, 2)
        Cv.Erode(img, img, Nothing, 2)
    End Sub
    ''' <summary>
    ''' 輪郭を得る
    ''' </summary>
    ''' <param name="img"></param>
    ''' <param name="storage"></param>
    ''' <returns></returns>
    Private Function FindContours(ByVal img As IplImage, ByVal storage As CvMemStorage) As CvSeq(Of CvPoint)
        ' 輪郭抽出
        Dim contours As CvSeq(Of CvPoint)
        Using imgClone As IplImage = img.Clone()
            Cv.FindContours(imgClone, storage, contours)
            If contours Is Nothing Then
                Return Nothing
            End If
            contours = Cv.ApproxPoly(contours, CvContour.SizeOf, storage, ApproxPolyMethod.DP, 3, True)
        End Using
        ' 一番長そうな輪郭のみを得る
        Dim max As CvSeq(Of CvPoint) = contours
        Dim c As CvSeq(Of CvPoint) = contours
        Do While c IsNot Nothing
            If max.Total < c.Total Then
                max = c
            End If
            c = c.HNext
        Loop
        Return max
    End Function

    ''' <summary>
    ''' ConvexHullの描画
    ''' </summary>
    ''' <param name="contours"></param>
    ''' <param name="hull"></param>
    ''' <param name="img"></param>
    Private Sub DrawConvexHull(ByVal contours As CvSeq(Of CvPoint), ByVal hull() As Integer, ByVal img As IplImage)
        Dim pt0 As CvPoint = contours(hull.Last()).Value
        For Each idx As Integer In hull
            Dim pt As CvPoint = contours(idx).Value
            Cv.Line(img, pt0, pt, New CvColor(255, 255, 255))
            pt0 = pt
        Next idx
    End Sub
    ''' <summary>
    ''' ConvexityDefectsの描画
    ''' </summary>
    ''' <param name="img"></param>
    ''' <param name="defect"></param>
    Private Sub DrawDefects(ByVal img As IplImage, ByVal defect As CvSeq(Of CvConvexityDefect))
        Dim count As Integer = 0
        For Each item As CvConvexityDefect In defect
            Dim p1 As CvPoint = item.Start, p2 As CvPoint = item.End
            Dim dist As Double = GetDistance(p1, p2)
            Dim mid As CvPoint2D64f = GetMidpoint(p1, p2)
            img.DrawLine(p1, p2, CvColor.White, 3)
            img.DrawCircle(item.DepthPoint, 10, CvColor.Green, -1)
            img.DrawLine(mid, item.DepthPoint, CvColor.White, 1)
            Form1.TextBox1.AppendText(Environment.NewLine & String.Format("No:{0} Depth:{1} Dist:{2}", count, item.Depth, dist))
            count += 1
        Next item
    End Sub
    ''' <summary>
    ''' 2点間の距離を得る
    ''' </summary>
    ''' <param name="p1"></param>
    ''' <param name="p2"></param>
    ''' <returns></returns>
    Private Function GetDistance(ByVal p1 As CvPoint, ByVal p2 As CvPoint) As Double
        Return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2))
    End Function
    ''' <summary>
    ''' 2点の中点を得る
    ''' </summary>
    ''' <param name="p1"></param>
    ''' <param name="p2"></param>
    ''' <returns></returns>
    Private Function GetMidpoint(ByVal p1 As CvPoint, ByVal p2 As CvPoint) As CvPoint2D64f
        Return New CvPoint2D64f With {.X = (p1.X + p2.X) / 2.0, .Y = (p1.Y + p2.Y) / 2.0}
    End Function
End Module
' End Namespace

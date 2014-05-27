Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

' Namespace OpenCvSharpSamplesVB
''' <summary>
''' cv::flann
''' </summary>
Friend Module FlannSample
    Public Sub Start()
        Console.WriteLine(Environment.NewLine & String.Format(("===== FlannTest =====")))

        ' creates data set
        Using features As New Mat(10000, 2, MatType.CV_32FC1)
            Dim rand As New Random()
            For i As Integer = 0 To features.Rows - 1
                features.Set(Of Single)(i, 0, rand.Next(10000))
                features.Set(Of Single)(i, 1, rand.Next(10000))
            Next i

            ' query
            Dim queryPoint As New Point2f(7777, 7777)
            Dim queries As New Mat(1, 2, MatType.CV_32FC1)
            queries.Set(Of Single)(0, 0, queryPoint.X)
            queries.Set(Of Single)(0, 1, queryPoint.Y)
            Console.WriteLine(Environment.NewLine & String.Format("query:({0}, {1})", queryPoint.X, queryPoint.Y))
            Console.WriteLine(Environment.NewLine & String.Format("-----"))

            ' knnSearch
            Using nnIndex As New Flann.Index(features, New Flann.KDTreeIndexParams(4))
                Dim knn As Integer = 1
                Dim indices() As Integer
                Dim dists() As Single
                nnIndex.KnnSearch(queries, indices, dists, knn, New Flann.SearchParams(32))

                For i As Integer = 0 To knn - 1
                    Dim index As Integer = indices(i)
                    Dim dist As Single = dists(i)
                    Dim pt As New Point2f(features.Get(Of Single)(index, 0), features.Get(Of Single)(index, 1))
                    Console.WriteLine(Environment.NewLine & String.Format("No.{0}" & vbTab, i))
                    Console.WriteLine(Environment.NewLine & String.Format("index:{0}", index))
                    Console.WriteLine(Environment.NewLine & String.Format(" distance:{0}", dist))
                    Console.WriteLine(Environment.NewLine & String.Format(" data:({0}, {1})", pt.X, pt.Y))
                    Console.WriteLine(Environment.NewLine & " ")
                Next i
                'Console.Read()
            End Using
        End Using
    End Sub
End Module
' End Namespace

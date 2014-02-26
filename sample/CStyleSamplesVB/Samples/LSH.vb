Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' Locality Sensitive Hashing
    ''' </summary>
    ''' <remarks>
    ''' http://moscoso.org/pub/video/opencv/svn/opencvlibrary/trunk/opencv/tests/python/lsh_tests.py
    ''' </remarks>
    Friend Module LSH
        Public Sub Start()
            Const D As Integer = 64
            Const N As Integer = 10000
            Const K As Integer = 1

            ' constructs a LSH table
            Using lsh As CvLSH = Cv.CreateMemoryLSH(D, N)
                ' creates test data
                Dim rand As New Random()
                Dim data As CvMat = CreateRandomData(N, D, rand)
                Dim queryPoints As CvMat = CreateQueryPoints(data, rand)

                ' adds vectors to the LSH
                Cv.LSHAdd(lsh, data)

                ' queries the LSH n times for at most k nearest points
                Dim indices As New CvMat(N, K, MatrixType.S32C1)
                Dim dist As New CvMat(N, K, MatrixType.F64C1)
                Cv.LSHQuery(lsh, queryPoints, indices, dist, K, 100)

                ' calculates percent of correct results
                Dim correct As Integer = 0
                For i As Integer = 0 To (N * K) - 1
                    'Console.WriteLine(indices[i]);
                    If indices(i) = i Then
                        correct += 1
                    End If
                Next i
                Dim percent As Double = CDbl(correct) / (N * K) * 100
                Form1.TextBox1.AppendText(Environment.NewLine & String.Format("correct: {0}%", percent))
            End Using

            Console.ReadLine()
        End Sub

        Private Function CreateRandomData(ByVal n As Integer, ByVal d As Integer, ByVal rand As Random) As CvMat
            Dim data As New CvMat(n, d, MatrixType.F64C1)
            For i As Integer = 0 To n - 1
                For j As Integer = 0 To d - 1
                    data(i, j) = rand.NextDouble() * 2 - 1
                Next j
            Next i
            Return data
        End Function

        Private Function CreateQueryPoints(ByVal data As CvMat, ByVal rand As Random) As CvMat
            Const R As Double = 0.4
            Dim n As Integer = data.Rows
            Dim d As Integer = data.Cols
            Dim query As New CvMat(n, d, MatrixType.F64C1)

            For i As Integer = 0 To n - 1
                Dim ra() As Double = CreateRandomArray(d, rand)
                Dim sqsum As Double = Math.Sqrt(ra.Sum(Function(elem) elem * elem))

                For j As Integer = 0 To d - 1
                    Dim add As Double = (rand.NextDouble() * R * ra(j)) / sqsum
                    query(i, j) = data(i, j) + add
                Next j
            Next i
            Return query
        End Function

        Private Function CreateRandomArray(ByVal length As Integer, ByVal rand As Random) As Double()
            Dim arr(length - 1) As Double
            For i As Integer = 0 To length - 1
                arr(i) = rand.NextDouble()
            Next i
            Return arr
        End Function
    End Module
' End Namespace

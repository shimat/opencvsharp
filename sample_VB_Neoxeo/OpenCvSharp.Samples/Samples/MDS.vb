Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

Namespace OpenCvSharpSamples
	''' <summary>
	''' Multidimensional Scaling (多次元尺度構成法)
	''' </summary>
	Friend Class MDS
		''' <summary>
		''' Distance among 10 American cities
		''' </summary>
		''' <example>
		''' * The linear distance between Atlanta and Chicago is 587km.
		''' </example>
		Private Shared ReadOnly CityDistance(,) As Double = { {0, 587, 1212, 701, 1936, 604, 748, 2139, 2182, 543}, {587, 0, 920, 940, 1745, 1188, 713, 1858, 1737, 597}, {1212, 920, 0, 879, 831, 1726, 1631, 949, 1021, 1494}, {701, 940, 879, 0, 1734, 968, 1420, 1645, 1891, 1220}, {1936, 1745, 831, 1734, 0, 2339, 2451, 347, 959, 2300}, {604, 1188, 1726, 968, 2339, 0, 1092, 2594, 2734, 923}, {748, 713, 1631, 1420, 2451, 1092, 0, 2571, 2408, 205}, {2139, 1858, 949, 1645, 347, 2594, 2571, 0, 678, 2442}, {2182, 1737, 1021, 1891, 959, 2734, 2408, 678, 0, 2329}, {543, 597, 1494, 1220, 2300, 923, 205, 2442, 2329, 0} }
		''' <summary>
		''' City names
		''' </summary>
		Private Shared ReadOnly CityNames() As String = { "Atlanta","Chicago","Denver","Houston","Los Angeles","Miami","New York","San Francisco","Seattle","Washington D.C." }


		''' <summary>
		''' Classical Multidimensional Scaling
		''' </summary>
		Public Sub New()
			' creates distance matrix
			Dim size As Integer = CityDistance.GetLength(0)
			Dim t As New CvMat(size, size, MatrixType.F64C1, CityDistance)
			' adds Torgerson's additive constant to t
			t += Torgerson(t)
			' squares all elements of t
			t.Mul(t, t)

			' centering matrix G
			Dim g As CvMat = CenteringMatrix(size)
			' calculates inner product matrix B
			Dim b As CvMat = g * t * g.T() * -0.5
			' calculates eigenvalues and eigenvectors of B
			Dim vectors As New CvMat(size, size, MatrixType.F64C1)
			Dim values As New CvMat(size, 1, MatrixType.F64C1)
			Cv.EigenVV(b, vectors, values)

			For r As Integer = 0 To values.Rows - 1
				If values(r) < 0 Then
					values(r) = 0
				End If
			Next r

			' multiplies sqrt(eigenvalue) by eigenvector
			Dim result As CvMat = vectors.GetRows(0, 2)
			For r As Integer = 0 To result.Rows - 1
				For c As Integer = 0 To result.Cols - 1
					result(r, c) *= Math.Sqrt(values(r))
				Next c
			Next r

			' scaling
			Cv.Normalize(result, result, 0, 800, NormType.MinMax)

			'Console.WriteLine(vectors);
			'Console.WriteLine(values);
			'Console.WriteLine(result);

			' opens a window
			Using img As New IplImage(800, 600, BitDepth.U8, 3)
			Using font As New CvFont(FontFace.HersheySimplex, 0.5F, 0.5F)
			Using window As New CvWindow("City Location Estimation")
				img.Zero()
				For c As Integer = 0 To size - 1
					Dim x As Double = result(0, c)
					Dim y As Double = result(1, c)
					x = x * 0.7 + img.Width * 0.1
					y = y * 0.7 + img.Height * 0.1
					img.Circle(CInt(Math.Truncate(x)), CInt(Math.Truncate(y)), 5, CvColor.Red, -1)
					img.PutText(CityNames(c), New CvPoint(CInt(Math.Truncate(x))+5, CInt(Math.Truncate(y))+10), font, CvColor.White)
				Next c
				window.Image = img
				Cv.WaitKey()
			End Using
			End Using
			End Using
		End Sub

		''' <summary>
		''' Returns Torgerson's additive constant
		''' </summary>
		''' <param name="mat"></param>
		''' <returns></returns>
		Private Function Torgerson(ByVal mat As CvMat) As Double
			If mat Is Nothing Then
				Throw New ArgumentNullException()
			ElseIf mat.Rows <> mat.Cols Then
				Throw New ArgumentException()
			End If

			Dim n As Integer = mat.Rows
			' Additive constant in case of negative value
			Dim min, max As Double
			(-mat).MinMaxLoc(min, max)
			Dim c2 As Double = max
			' Additive constant from triangular inequality
			Dim c1 As Double = 0
			For i As Integer = 0 To n - 1
				For j As Integer = 0 To n - 1
					For k As Integer = 0 To n - 1
						Dim v As Double = mat(i, k) - mat(i, j) - mat(j, k)
						If v > c1 Then
							c1 = v
						End If
					Next k
				Next j
			Next i
			Return Math.Max(Math.Max(c1, c2), 0)
		End Function

		''' <summary>
		''' Returns centering matrix
		''' </summary>
		''' <param name="n">Size of matrix</param>
		''' <returns></returns>
		Private Function CenteringMatrix(ByVal n As Integer) As CvMat
			Return (CvMat.Identity(n, n, MatrixType.F64C1) - New CvMat(n, n, MatrixType.F64C1, 1.0 / n))
		End Function
	End Class
End Namespace
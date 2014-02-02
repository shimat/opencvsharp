Imports System
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

Namespace OpenCvSharpSamples
	''' <summary>
	''' SURF(Speeded Up Robust Features)による対応点検出        
	''' </summary>
	''' <remarks>samples/c/find_obj.cpp から改変</remarks>
	Friend Class SURFSample
		Public Sub New()
			' cvExtractSURF
			' SURFで対応点検出            


			' call cv::initModule_nonfree() before using SURF/SIFT.
			CvCpp.InitModule_NonFree()


			Using obj As IplImage = Cv.LoadImage([Const].ImageSurfBox, LoadMode.GrayScale)
			Using image As IplImage = Cv.LoadImage([Const].ImageSurfBoxinscene, LoadMode.GrayScale)
			Using objColor As IplImage = Cv.CreateImage(obj.Size, BitDepth.U8, 3)
			Using correspond As IplImage = Cv.CreateImage(New CvSize(image.Width, obj.Height + image.Height), BitDepth.U8, 1)
				Cv.CvtColor(obj, objColor, ColorConversion.GrayToBgr)

				Cv.SetImageROI(correspond, New CvRect(0, 0, obj.Width, obj.Height))
				Cv.Copy(obj, correspond)
				Cv.SetImageROI(correspond, New CvRect(0, obj.Height, correspond.Width, correspond.Height))
				Cv.Copy(image, correspond)
				Cv.ResetImageROI(correspond)

				' SURFの処理
				Dim objectKeypoints(), imageKeypoints() As CvSURFPoint
				Dim objectDescriptors()(), imageDescriptors()() As Single
				Dim watch As Stopwatch = Stopwatch.StartNew()
					Dim param As New CvSURFParams(500, True)
					Cv.ExtractSURF(obj, Nothing, objectKeypoints, objectDescriptors, param)
					Console.WriteLine("Object Descriptors: {0}", objectDescriptors.Length)
					Cv.ExtractSURF(image, Nothing, imageKeypoints, imageDescriptors, param)
					Console.WriteLine("Image Descriptors: {0}", imageDescriptors.Length)
				watch.Stop()
				Console.WriteLine("Extraction time = {0}ms", watch.ElapsedMilliseconds)
				watch.Reset()
				watch.Start()

				' シーン画像にある局所画像の領域を線で囲む
				Dim srcCorners() As CvPoint = { _
					New CvPoint(0, 0), _
					New CvPoint(obj.Width, 0), _
					New CvPoint(obj.Width, obj.Height), _
					New CvPoint(0, obj.Height) _
				}
				Dim dstCorners() As CvPoint = LocatePlanarObject(objectKeypoints, objectDescriptors, imageKeypoints, imageDescriptors, srcCorners)
				If dstCorners IsNot Nothing Then
					For i As Integer = 0 To 3
						Dim r1 As CvPoint = dstCorners(i Mod 4)
						Dim r2 As CvPoint = dstCorners((i + 1) Mod 4)
						Cv.Line(correspond, New CvPoint(r1.X, r1.Y + obj.Height), New CvPoint(r2.X, r2.Y + obj.Height), CvColor.White)
					Next i
				End If

				' 対応点同士を線で引く
				Dim ptPairs() As Integer = FindPairs(objectKeypoints, objectDescriptors, imageKeypoints, imageDescriptors)
				For i As Integer = 0 To ptPairs.Length - 1 Step 2
					Dim r1 As CvSURFPoint = objectKeypoints(ptPairs(i))
					Dim r2 As CvSURFPoint = imageKeypoints(ptPairs(i + 1))
					Cv.Line(correspond, r1.Pt, New CvPoint(Cv.Round(r2.Pt.X), Cv.Round(r2.Pt.Y + obj.Height)), CvColor.White)
				Next i

				' 特徴点の場所に円を描く
				For i As Integer = 0 To objectKeypoints.Length - 1
					Dim r As CvSURFPoint = objectKeypoints(i)
					Dim center As New CvPoint(Cv.Round(r.Pt.X), Cv.Round(r.Pt.Y))
					Dim radius As Integer = Cv.Round(r.Size*(1.2/9.0)*2)
					Cv.Circle(objColor, center, radius, CvColor.Red, 1, LineType.AntiAlias, 0)
				Next i
				watch.Stop()
				Console.WriteLine("Drawing time = {0}ms", watch.ElapsedMilliseconds)

				' ウィンドウに表示
				Using windowObject As New CvWindow("Object", WindowMode.AutoSize)
				Using windowCorrespond As New CvWindow("Object Correspond", WindowMode.AutoSize)
					windowObject.ShowImage(correspond)
					windowCorrespond.ShowImage(objColor)
					Cv.WaitKey(0)
				End Using
				End Using
			End Using
			End Using
			End Using
			End Using
		End Sub

		''' <summary>
		''' 
		''' </summary>
		''' <param name="d1">Cではconst float*</param>
		''' <param name="d2">Cではconst float*</param>
		''' <param name="best"></param>
		''' <returns></returns>
		Private Shared Function CompareSurfDescriptors(ByVal d1() As Single, ByVal d2() As Single, ByVal best As Double) As Double
			Debug.Assert(d1.Length Mod 4 = 0)
			Debug.Assert(d1.Length = d2.Length)

			Dim totalCost As Double = 0

			For i As Integer = 0 To d1.Length - 1 Step 4
				Dim t0 As Double = d1(i) - d2(i)
				Dim t1 As Double = d1(i + 1) - d2(i + 1)
				Dim t2 As Double = d1(i + 2) - d2(i + 2)
				Dim t3 As Double = d1(i + 3) - d2(i + 3)
				totalCost += t0*t0 + t1*t1 + t2*t2 + t3*t3
				If totalCost > best Then
					Exit For
				End If
			Next i

			Return totalCost
		End Function

		''' <summary>
		''' 
		''' </summary>
		''' <param name="vec">Cではconst float*</param>
		''' <param name="laplacian"></param>
		''' <param name="modelKeypoints"></param>
		''' <param name="modelDescriptors"></param>
		''' <returns></returns>
		Private Shared Function NaiveNearestNeighbor(ByVal vec() As Single, ByVal laplacian As Integer, ByVal modelKeypoints() As CvSURFPoint, ByVal modelDescriptors()() As Single) As Integer
			Dim neighbor As Integer = -1
			Dim dist1 As Double = 1e6, dist2 As Double = 1e6

			For i As Integer = 0 To modelDescriptors.Length - 1
				' const CvSURFPoint* kp = (const CvSURFPoint*)kreader.ptr;
				Dim kp As CvSURFPoint = modelKeypoints(i)

				If laplacian <> kp.Laplacian Then
					Continue For
				End If

				Dim d As Double = CompareSurfDescriptors(vec, modelDescriptors(i), dist2)
				If d < dist1 Then
					dist2 = dist1
					dist1 = d
					neighbor = i
				ElseIf d < dist2 Then
					dist2 = d
				End If
			Next i
			If dist1 < 0.6*dist2 Then
				Return neighbor
			Else
				Return -1
			End If
		End Function

		''' <summary>
		''' 
		''' </summary>
		''' <param name="objectKeypoints"></param>
		''' <param name="objectDescriptors"></param>
		''' <param name="imageKeypoints"></param>
		''' <param name="imageDescriptors"></param>
		''' <returns></returns>
		Private Shared Function FindPairs(ByVal objectKeypoints() As CvSURFPoint, ByVal objectDescriptors()() As Single, ByVal imageKeypoints() As CvSURFPoint, ByVal imageDescriptors()() As Single) As Integer()
			Dim ptPairs As New List(Of Integer)()

			For i As Integer = 0 To objectDescriptors.Length - 1
				Dim kp As CvSURFPoint = objectKeypoints(i)
				Dim nearestNeighbor As Integer = NaiveNearestNeighbor(objectDescriptors(i), kp.Laplacian, imageKeypoints, imageDescriptors)
				If nearestNeighbor >= 0 Then
					ptPairs.Add(i)
					ptPairs.Add(nearestNeighbor)
				End If
			Next i
			Return ptPairs.ToArray()
		End Function

		''' <summary>
		''' a rough implementation for object location
		''' </summary>
		''' <param name="objectKeypoints"></param>
		''' <param name="objectDescriptors"></param>
		''' <param name="imageKeypoints"></param>
		''' <param name="imageDescriptors"></param>
		''' <param name="srcCorners"></param>
		''' <returns></returns>
		Private Shared Function LocatePlanarObject(ByVal objectKeypoints() As CvSURFPoint, ByVal objectDescriptors()() As Single, ByVal imageKeypoints() As CvSURFPoint, ByVal imageDescriptors()() As Single, ByVal srcCorners() As CvPoint) As CvPoint()
			Dim h As New CvMat(3, 3, MatrixType.F64C1)
			Dim ptpairs() As Integer = FindPairs(objectKeypoints, objectDescriptors, imageKeypoints, imageDescriptors)
			Dim n As Integer = ptpairs.Length\2
			If n < 4 Then
				Return Nothing
			End If

			Dim pt1(n - 1) As CvPoint2D32f
			Dim pt2(n - 1) As CvPoint2D32f
			For i As Integer = 0 To n - 1
				pt1(i) = objectKeypoints(ptpairs(i*2)).Pt
				pt2(i) = imageKeypoints(ptpairs(i*2 + 1)).Pt
			Next i

			Dim pt1Mat As New CvMat(1, n, MatrixType.F32C2, pt1)
			Dim pt2Mat As New CvMat(1, n, MatrixType.F32C2, pt2)
			If Cv.FindHomography(pt1Mat, pt2Mat, h, HomographyMethod.Ransac, 5) = 0 Then
				Return Nothing
			End If

			Dim dstCorners(3) As CvPoint
			For i As Integer = 0 To 3
				Dim x As Double = srcCorners(i).X
				Dim y As Double = srcCorners(i).Y
				Dim Z As Double = 1.0/(h(6)*x + h(7)*y + h(8))
'INSTANT VB NOTE: The variable X was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
				Dim X_Renamed As Double = (h(0)*x + h(1)*y + h(2))*Z
'INSTANT VB NOTE: The variable Y was renamed since Visual Basic will not allow local variables with the same name as parameters or other local variables:
				Dim Y_Renamed As Double = (h(3)*x + h(4)*y + h(5))*Z
				dstCorners(i) = New CvPoint(Cv.Round(X_Renamed), Cv.Round(Y_Renamed))
			Next i

			Return dstCorners
		End Function

	End Class
End Namespace

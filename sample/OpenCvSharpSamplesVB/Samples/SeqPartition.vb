Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.UserInterface

Namespace OpenCvSharpSamples
	''' <summary>
	''' Partitioning 2d point set.
	''' </summary>
	''' <remarks>http://opencv.jp/opencv-1.1.0/document/opencvref_cxcore_misc.html#decl_cvSeqPartition</remarks>
	Friend Class SeqPartition
		Private Const Width As Integer = 500
		Private Const Height As Integer = 500
		Private Const Count As Integer = 1000

		Private pointSeq As CvSeq(Of CvPoint)
		Private canvas As IplImage
		Private colors() As CvScalar
		Private window As CvWindowEx
		Private threshold As Integer

		''' <summary>
		''' 
		''' </summary>
		Public Sub New()
			Dim storage As New CvMemStorage(0)
			pointSeq = New CvSeq(Of CvPoint)(SeqType.EltypeS32C2, CvSeq.SizeOf, storage)
			Dim rand As New Random()
			canvas = New IplImage(Width, Height, BitDepth.U8, 3)

			colors = New CvScalar(Count - 1){}
			For i As Integer = 0 To Count - 1
				Dim pt As CvPoint = New CvPoint With {.X = rand.Next(Width), .Y = rand.Next(Height)}
				pointSeq.Push(pt)
				Dim icolor As Integer = rand.Next() Or &H404040
				colors(i) = Cv.RGB(icolor And 255, (icolor >> 8) And 255, (icolor >> 16) And 255)
			Next i

			window = New CvWindowEx() With {.Text = "points"}
			Using window
				window.CreateTrackbar("threshold", 10, 50, AddressOf OnTrack)
				OnTrack(10)
				CvWindowEx.WaitKey()
			End Using
		End Sub

		''' <summary>
		''' 
		''' </summary>
		''' <param name="pos"></param>
		Private Sub OnTrack(ByVal pos As Integer)
			Dim labels As CvSeq
			Dim watch As Stopwatch = Stopwatch.StartNew()
			threshold = pos * pos
			Dim classCount As Integer = Cv.SeqPartition(pointSeq, Nothing, labels, AddressOf CmpFuncPtr)
			watch.Stop()
			Console.WriteLine("{0:D4} classes", classCount)
			Console.WriteLine("Partition time : {0} msec", watch.ElapsedMilliseconds)
			Cv.Zero(canvas)

			For i As Integer = 0 To labels.Total - 1
				Dim pt As CvPoint = pointSeq.GetSeqElem(i).Value
				Dim color As CvScalar = colors(labels.GetSeqElem(Of Integer)(i).Value)
				Cv.Circle(canvas, pt, 1, color, -1)
			Next i

			window.ShowImage(canvas)
		End Sub

'INSTANT VB TODO TASK: There is no equivalent to the 'unsafe' modifier in VB:
'ORIGINAL LINE: private unsafe int CmpFuncPtr(IntPtr _a, IntPtr _b)
		Private Function CmpFuncPtr(ByVal _a As IntPtr, ByVal _b As IntPtr) As Integer
			Dim a As CvPoint = *CType(_a, CvPoint)
			Dim b As CvPoint = *CType(_b, CvPoint)
			Return If(((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y)) <= threshold, 1, 0)
		End Function

		Private Function CmpFuncManaged(ByVal a As CvPoint, ByVal b As CvPoint) As Integer
			Return If(((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y)) <= threshold, 1, 0)
		End Function
	End Class

End Namespace

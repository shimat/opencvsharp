Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports OpenCvSharp

Namespace OpenCvSharpSamples
	''' <summary>
	''' ドロネー
	''' </summary>
	''' <remarks>samples/c/delaunay.c から改変</remarks>
	Friend Class Delaunay
		Public Sub New()
			Dim rect As New CvRect(0, 0, 600, 600)
			Dim activeFacetColor As New CvColor(255, 0, 0)
			Dim delaunayColor As New CvColor(0, 0, 0)
			Dim voronoiColor As New CvColor(0, 180, 0)
			Dim bkgndColor As New CvColor(255, 255, 255)
			Dim rand As New Random()

			Using storage As New CvMemStorage(0)
			Using img As New IplImage(rect.Size, BitDepth.U8, 3)
			Using window As New CvWindow("delaunay")
				img.Set(bkgndColor)
				Dim subdiv As New CvSubdiv2D(rect, storage)
				For i As Integer = 0 To 199
					Dim fp As CvPoint2D32f = New CvPoint2D32f With {.X = CSng(rand.Next(5, rect.Width - 10)), .Y = CSng(rand.Next(5, rect.Height - 10))}
					LocatePoint(subdiv, fp, img, activeFacetColor)
					window.Image = img

					If CvWindow.WaitKey(100) >= 0 Then
						Exit For
					End If
					subdiv.Insert(fp)
					subdiv.CalcVoronoi2D()
					img.Set(bkgndColor)
					DrawSubdiv(img, subdiv, delaunayColor, voronoiColor)
					window.Image = img
					If CvWindow.WaitKey(100) >= 0 Then
						Exit For
					End If
				Next i
				img.Set(bkgndColor)
				PaintVoronoi(subdiv, img)
				window.Image = img

				CvWindow.WaitKey(0)
			End Using
			End Using
			End Using
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="subdiv"></param>
		''' <param name="fp"></param>
		''' <param name="img"></param>
		''' <param name="active_color"></param>
		Private Sub LocatePoint(ByVal subdiv As CvSubdiv2D, ByVal fp As CvPoint2D32f, ByVal img As IplImage, ByVal active_color As CvScalar)
			Dim e As CvSubdiv2DEdge
			Dim e0 As CvSubdiv2DEdge = 0

			subdiv.Locate(fp, e0)

			If e0 <> 0 Then
				e = e0
				Do
					'Console.WriteLine(e);
					DrawSubdivEdge(img, e, active_color)
					e = e.GetEdge(CvNextEdgeType.NextAroundLeft)
				Loop While e IsNot e0
			End If

			DrawSubdivPoint(img, fp, active_color)
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="img"></param>
		''' <param name="subdiv"></param>
		''' <param name="delaunay_color"></param>
		''' <param name="voronoi_color"></param>
		Private Sub DrawSubdiv(ByVal img As IplImage, ByVal subdiv As CvSubdiv2D, ByVal delaunay_color As CvColor, ByVal voronoi_color As CvColor)
			Dim reader As New CvSeqReader()
			Dim total As Integer = subdiv.Edges.Total
			Dim elem_size As Integer = subdiv.Edges.ElemSize

			subdiv.Edges.StartRead(reader, False)

			For i As Integer = 0 To total - 1
				'CvQuadEdge2D edge = (CvQuadEdge2D)reader.CvPtr;
				Dim edge As CvQuadEdge2D = CvQuadEdge2D.FromSeqReader(reader)

				If Cv.IS_SET_ELEM(edge) Then
					DrawSubdivEdge(img, CType(edge, CvSubdiv2DEdge) + 1, voronoi_color)
					DrawSubdivEdge(img, CType(edge, CvSubdiv2DEdge), delaunay_color)
				End If

				'reader.NextSeqElem(elem_size);
				Cv.NEXT_SEQ_ELEM(elem_size, reader)
			Next i
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="img"></param>
		''' <param name="edge"></param>
		''' <param name="color"></param>
		Private Sub DrawSubdivEdge(ByVal img As IplImage, ByVal edge As CvSubdiv2DEdge, ByVal color As CvScalar)
			Dim org_pt As CvSubdiv2DPoint = edge.Org()
			Dim dst_pt As CvSubdiv2DPoint = edge.Dst()

			If org_pt IsNot Nothing AndAlso dst_pt IsNot Nothing Then
				Dim org As CvPoint2D32f = org_pt.Pt
				Dim dst As CvPoint2D32f = dst_pt.Pt

				Dim iorg As New CvPoint(Cv.Round(org.X), Cv.Round(org.Y))
				Dim idst As New CvPoint(Cv.Round(dst.X), Cv.Round(dst.Y))

				'Console.WriteLine("{0} / {1}", iorg, idst);
				img.Line(iorg, idst, color, 1, LineType.AntiAlias, 0)
			End If
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="subdiv"></param>
		''' <param name="img"></param>
		Private Sub PaintVoronoi(ByVal subdiv As CvSubdiv2D, ByVal img As IplImage)
			Dim reader As New CvSeqReader()
			Dim total As Integer = subdiv.Edges.Total
			Dim elem_size As Integer = subdiv.Edges.ElemSize

			subdiv.CalcVoronoi2D()

			subdiv.Edges.StartRead(reader, False)

			For i As Integer = 0 To total - 1
				Dim edge As CvQuadEdge2D = CvQuadEdge2D.FromSeqReader(reader)
				'CvQuadEdge2D edge = CvQuadEdge2D.FromPtr(reader.Ptr);

				If Cv.IS_SET_ELEM(edge) Then
					Dim e As CvSubdiv2DEdge = edge.ToCvSubdiv2DEdge()
					' left
					DrawSubdivFacet(img, e.RotateEdge(RotateEdgeFlag.Rotate))
					' right
					DrawSubdivFacet(img, e.RotateEdge(RotateEdgeFlag.ReverseRotate))
				End If
				reader.NextSeqElem(elem_size)
				'Cv.NEXT_SEQ_ELEM(elem_size, reader);
			Next i
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="img"></param>
		''' <param name="edge"></param>
		Private Sub DrawSubdivFacet(ByVal img As IplImage, ByVal edge As CvSubdiv2DEdge)
			Dim t As CvSubdiv2DEdge = edge
			Dim count As Integer = 0

			' count number of edges in facet
			Do
				count += 1
				t = t.GetEdge(CvNextEdgeType.NextAroundLeft)
			Loop While t IsNot edge

			Dim buf(count - 1) As CvPoint

			' gather points
			t = edge
			Dim i As Integer
			For i = 0 To count - 1
				Dim pt As CvSubdiv2DPoint = t.Org()
				If pt Is Nothing Then
					Exit For
				End If
				buf(i) = pt.Pt
				t = t.GetEdge(CvNextEdgeType.NextAroundLeft)
			Next i

			If i = count Then
				Dim rand As New Random()
				Dim pt As CvSubdiv2DPoint = edge.RotateEdge(RotateEdgeFlag.Rotate).Dst()
				img.FillConvexPoly(buf, CvColor.Random(), LineType.AntiAlias, 0)
				img.PolyLine(New CvPoint()() { buf }, True, CvColor.Black, 1, LineType.AntiAlias, 0)
				DrawSubdivPoint(img, pt.Pt, CvColor.Black)
			End If
		End Sub
		''' <summary>
		''' 
		''' </summary>
		''' <param name="img"></param>
		''' <param name="fp"></param>
		''' <param name="color"></param>
		Private Sub DrawSubdivPoint(ByVal img As IplImage, ByVal fp As CvPoint2D32f, ByVal color As CvColor)
			img.Circle(fp, 3, color, Cv.FILLED, LineType.AntiAlias, 0)
		End Sub
	End Class
End Namespace

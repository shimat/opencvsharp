Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.Blob
' for blob

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' c# implementation of cvblob/test/test.cpp.
''' cvblob : http://code.google.com/p/cvblob/
''' </summary>
Friend Module Blob
    Public Sub Start()
        Using imgSrc As New IplImage(FilePath.Image.Shapes, LoadMode.Color)
            Using imgBinary As New IplImage(imgSrc.Size, BitDepth.U8, 1)
                Using imgLabel As New IplImage(imgSrc.Size, BitDepth.F32, 1)
                    Using imgRender As New IplImage(imgSrc.Size, BitDepth.U8, 3)
                        Using imgContour As New IplImage(imgSrc.Size, BitDepth.U8, 3)
                            Using imgPolygon As New IplImage(imgSrc.Size, BitDepth.U8, 3)
                                Cv.CvtColor(imgSrc, imgBinary, ColorConversion.BgrToGray)
                                Cv.Threshold(imgBinary, imgBinary, 100, 255, ThresholdType.Binary)

                                Dim blobs As New CvBlobs()
                                blobs.Label(imgBinary)

                                For Each item As KeyValuePair(Of Integer, CvBlob) In blobs
                                    Dim b As CvBlob = item.Value

                                    Form1.TextBox1.AppendText(Environment.NewLine & String.Format("{0} | Centroid:{1} Area:{2}", item.Key, b.Centroid, b.Area))

                                    Dim cc As CvContourChainCode = b.Contour
                                    cc.Render(imgContour)

                                    Dim polygon As CvContourPolygon = cc.ConvertToPolygon()
                                    For Each p As CvPoint In polygon
                                        imgPolygon.Circle(p, 1, CvColor.Red, -1)
                                    Next p
                                Next item

                                blobs.RenderBlobs(imgSrc, imgRender)

                                Using New CvWindow("render", imgRender)
                                    Using New CvWindow("contour", imgContour)
                                        Using New CvWindow("polygon vertices", imgPolygon)
                                            Cv.WaitKey(0)
                                        End Using
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Module
' End Namespace

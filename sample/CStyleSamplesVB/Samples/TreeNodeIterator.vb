Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' 輪郭の検出を行い，木構造を持つ輪郭データから座標を取り出す.
''' </summary>
''' <remarks>http://opencv.jp/sample/tree.html#contour_treenode</remarks>
Friend Module TreeNodeIterator
    Public Sub Start()
        Using storage As New CvMemStorage(0)
            Using srcImg As New IplImage(FilePath.Image.Lenna, LoadMode.Color)
                Using srcImgGray As New IplImage(srcImg.Size, BitDepth.U8, 1)
                    Using tmpImg As New IplImage(srcImg.Size, BitDepth.U8, 1)
                        Cv.CvtColor(srcImg, srcImgGray, ColorConversion.BgrToGray)

                        ' (1)画像の二値化と輪郭の検出
                        Cv.Threshold(srcImgGray, tmpImg, 120, 255, ThresholdType.Binary)
                        Dim contours As CvSeq(Of CvPoint)
                        Cv.FindContours(tmpImg, storage, contours, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple)
                        ' 輪郭シーケンスから座標を取得 
                        Using fs As New CvFileStorage("contours.yaml", Nothing, FileStorageMode.Write)
                            ' (2)ツリーノードイテレータの初期化
                            Dim it As New CvTreeNodeIterator(Of CvSeq(Of CvPoint))(contours, 1)
                            ' (3)各ノード（輪郭）を走査
                            'CvSeq<CvPoint> contour;
                            'while ((contour = it.NextTreeNode()) != null)
                            For Each contour As CvSeq(Of CvPoint) In it
                                fs.StartWriteStruct("contour", NodeType.Seq)
                                ' (4)輪郭を構成する頂点座標を取得
                                Dim tmp As CvPoint = contour(-1).Value
                                For i As Integer = 0 To contour.Total - 1
                                    Dim point As CvPoint = contour(i).Value
                                    srcImg.Line(tmp, point, CvColor.Blue, 2)
                                    fs.StartWriteStruct(Nothing, NodeType.Map Or NodeType.Flow)
                                    fs.WriteInt("x", point.X)
                                    fs.WriteInt("y", point.Y)
                                    fs.EndWriteStruct()
                                    tmp = point
                                Next i
                                fs.EndWriteStruct()
                            Next contour
                        End Using

                        'Console.WriteLine(File.ReadAllText("contours.yaml"))

                        Form1.Label1.Text = "contours.yaml"
                        Dim sr As StreamReader = File.OpenText("contours.yaml")
                        Form1.TextBox1.Text = sr.ReadToEnd()
                        sr.Close()

                        Using TempCvWindow As CvWindow = New CvWindow("Contours", srcImg)
                            Cv.WaitKey(0)
                        End Using
                    End Using
                End Using
            End Using
        End Using
    End Sub
End Module
' End Namespace

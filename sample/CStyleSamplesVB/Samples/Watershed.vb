Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Watershedアルゴリズムによる画像の領域分割
''' </summary>
''' <remarks>http://opencv.jp/sample/segmentation_and_connection.html#watershed</remarks>
    Friend Module Watershed
        Public Sub Start()
            ' cvWatershed
            ' マウスで円形のマーカー（シード領域）の中心を指定し，複数のマーカーを設定する．
            ' このマーカを画像のgradientに沿って広げて行き，gradientの高い部分に出来る境界を元に領域を分割する．
            ' 領域は，最初に指定したマーカーの数に分割される． 

            ' (2)画像の読み込み，マーカー画像の初期化，結果表示用画像領域の確保を行なう
        Using srcImg As New IplImage(FilePath.Image.Goryokaku, LoadMode.AnyDepth Or LoadMode.AnyColor)
            Using dstImg As IplImage = srcImg.Clone()
                Using dspImg As IplImage = srcImg.Clone()
                    Using markers As New IplImage(srcImg.Size, BitDepth.S32, 1)
                        markers.Zero()

                        ' (3)入力画像を表示しシードコンポーネント指定のためのマウスイベントを登録する
                        Using wImage As New CvWindow("image", WindowMode.AutoSize)
                            wImage.Image = srcImg
                            ' クリックにより中心を指定し，円形のシード領域を設定する   
                            Dim seedNum As Integer = 0
                            AddHandler wImage.OnMouseCallback, Sub(ev As MouseEvent, x As Integer, y As Integer, flags As MouseEvent)
                                                                   If ev = MouseEvent.LButtonDown Then
                                                                       seedNum += 1
                                                                       Dim pt As New CvPoint(x, y)
                                                                       markers.Circle(pt, 20, CvScalar.ScalarAll(seedNum), Cv.FILLED, LineType.Link8, 0)
                                                                       dspImg.Circle(pt, 20, CvColor.White, 3, LineType.Link8, 0)
                                                                       wImage.Image = dspImg
                                                                   End If
                                                               End Sub
                            CvWindow.WaitKey()
                        End Using

                        ' (4)watershed分割を実行する  
                        Cv.Watershed(srcImg, markers)

                        ' (5)実行結果の画像中のwatershed境界（ピクセル値=-1）を結果表示用画像上に表示する
                        For i As Integer = 0 To markers.Height - 1
                            For j As Integer = 0 To markers.Width - 1
                                Dim idx As Integer = CInt(Math.Truncate(markers.Get2D(i, j).Val0))
                                If idx = -1 Then
                                    dstImg.Set2D(i, j, CvColor.Red)
                                End If
                            Next j
                        Next i
                        Using wDst As New CvWindow("watershed transform", WindowMode.AutoSize)
                            wDst.Image = dstImg
                            CvWindow.WaitKey()
                        End Using
                    End Using
                End Using
            End Using
        End Using

        End Sub
    End Module
' End Namespace

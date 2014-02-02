Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

Namespace OpenCvSharpSamples
	''' <summary>
	''' ステレオマッチング
	''' </summary>
    Friend Module StereoCorrespondence
        Public Sub Start()
            ' cvFindStereoCorrespondenceBM + cvFindStereoCorrespondenceGC
            ' ブロックマッチング, グラフカットの両アルゴリズムによるステレオマッチング

            ' 入力画像の読み込み
            Using imgLeft As New IplImage([Const].ImageTsukubaLeft, LoadMode.GrayScale)
                Using imgRight As New IplImage([Const].ImageTsukubaRight, LoadMode.GrayScale)
                    ' 視差画像, 出力画像の領域を確保
                    Using dispBM As New IplImage(imgLeft.Size, BitDepth.S16, 1)
                        Using dispLeft As New IplImage(imgLeft.Size, BitDepth.S16, 1)
                            Using dispRight As New IplImage(imgLeft.Size, BitDepth.S16, 1)
                                Using dstBM As New IplImage(imgLeft.Size, BitDepth.U8, 1)
                                    Using dstGC As New IplImage(imgLeft.Size, BitDepth.U8, 1)
                                        Using dstAux As New IplImage(imgLeft.Size, BitDepth.U8, 1)
                                            Using dstSGBM As New Mat()
                                                ' 距離計測とスケーリング  
                                                Dim sad As Integer = 3
                                                Using stateBM As New CvStereoBMState(StereoBMPreset.Basic, 16)
                                                    Using stateGC As New CvStereoGCState(16, 2)
                                                        Using sgbm As New StereoSGBM() With {.MinDisparity = 0, .NumberOfDisparities = 32, .PreFilterCap = 63, .SADWindowSize = sad, .P1 = 8 * imgLeft.NChannels * sad * sad, .P2 = 32 * imgLeft.NChannels * sad * sad, .UniquenessRatio = 10, .SpeckleWindowSize = 100, .SpeckleRange = 32, .Disp12MaxDiff = 1, .FullDP = False}
                                                            Cv.FindStereoCorrespondenceBM(imgLeft, imgRight, dispBM, stateBM) ' stateBM.FindStereoCorrespondence(imgLeft, imgRight, dispBM);
                                                            Cv.FindStereoCorrespondenceGC(imgLeft, imgRight, dispLeft, dispRight, stateGC, False) ' stateGC.FindStereoCorrespondence(imgLeft, imgRight, dispLeft, dispRight, false);
                                                            Cv.FindStereoCorrespondence(imgLeft, imgRight, DisparityMode.Birchfield, dstAux, 50, 25, 5, 12, 15, 25)
                                                            sgbm.FindCorrespondence(New Mat(imgLeft), New Mat(imgRight), dstSGBM)

                                                            Cv.ConvertScale(dispBM, dstBM, 1)
                                                            Cv.ConvertScale(dispLeft, dstGC, -16)
                                                            Cv.ConvertScale(dstAux, dstAux, 16)
                                                            dstSGBM.ConvertTo(dstSGBM, dstSGBM.Type, 32, 0)

                                                            Using TempCvWindow As CvWindow = New CvWindow("Stereo Correspondence (BM)", dstBM)
                                                                Using TempCvWindowGC As CvWindow = New CvWindow("Stereo Correspondence (GC)", dstGC)
                                                                    Using TempCvWindowCvaux As CvWindow = New CvWindow("Stereo Correspondence (cvaux)", dstAux)
                                                                        Using TempCvWindowSGBM As CvWindow = New CvWindow("Stereo Correspondence (SGBM)", dstSGBM.ToIplImage())
                                                                            Cv.WaitKey()
                                                                        End Using
                                                                    End Using
                                                                End Using
                                                            End Using
                                                        End Using
                                                    End Using
                                                End Using
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
End Namespace

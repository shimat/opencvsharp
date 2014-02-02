Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

Namespace OpenCvSharpSamples
	''' <summary>
	''' クラスタリングによる減色処理
	''' </summary>
	''' <remarks>http://opencv.jp/sample/misc.html#color-sub</remarks>
	Friend Class KMeans
		Public Sub New()
			' cvKMeans2
			' k-means法によるクラスタリングを利用して，非常に単純な減色を行う

			' クラスタ数。この値を変えると色数が変わる
			Const maxClusters As Integer = 32

			' (1)画像を読み込む  
			Using srcImg As IplImage = Cv.LoadImage([Const].ImageLenna, LoadMode.Color)
			Using dstImg As IplImage = Cv.CloneImage(srcImg)
				Dim size As Integer = srcImg.Width * srcImg.Height
				Using color As CvMat = Cv.CreateMat(maxClusters, 1, MatrixType.F32C3)
				Using count As CvMat = Cv.CreateMat(maxClusters, 1, MatrixType.S32C1)
				Using clusters As CvMat = Cv.CreateMat(size, 1, MatrixType.S32C1)
				Using points As CvMat = Cv.CreateMat(size, 1, MatrixType.F32C3)
					' (2)ピクセルの値を行列へ代入
					' unsafeコードを用いて、C/C++と同様にポインタで要素にアクセスする。
					' ポインタがないVB.NETの場合は、Marshal.Copyでマネージ配列に移し替えてからアクセスし、再びMarshal.Copyで戻せばできる？
					' (またはMarshal.WriteInt32とか)
'INSTANT VB TODO TASK: There is no equivalent to an 'unsafe' block in VB:
'					unsafe
						' 以下のように、ポインタ変数に移し替えてからアクセスした方が良いと思われる
						Single* pMat = CSng(points.Data) ' 行列の要素へのポインタ
						Byte* pImg = CByte(srcImg.ImageData) ' 画像の画素へのポインタ
						For i As Integer = 0 To size - 1
							pMat(i * 3 + 0) = pImg(i * 3 + 0)
							pMat(i * 3 + 1) = pImg(i * 3 + 1)
							pMat(i * 3 + 2) = pImg(i * 3 + 2)
						Next i
'INSTANT VB NOTE: End of the original C# 'unsafe' block.
					' (3)クラスタリング
					Cv.KMeans2(points, maxClusters, clusters, New CvTermCriteria(10, 1.0))
					' (4)各クラスタの平均値を計算
					Cv.SetZero(color)
					Cv.SetZero(count)
'INSTANT VB TODO TASK: There is no equivalent to an 'unsafe' block in VB:
'					unsafe
						' ポインタそのままで取得できるプロパティもある
						Integer* pClu = clusters.DataInt32 ' cluster の要素へのポインタ
						Integer* pCnt = count.DataInt32 ' count の要素へのポインタ
						Single* pClr = color.DataSingle ' color の要素へのポインタ
						Single* pPnt = points.DataSingle ' points の要素へのポインタ
						For i As Integer = 0 To size - 1
							Dim idx As Integer = pClu(i) ' clusters->data.i[i]
							pCnt(idx) += 1
							Dim j As Integer = pCnt(idx)
							pClr(idx * 3 + 0) = pClr(idx * 3 + 0) * (j - 1) \ j + pPnt(i * 3 + 0) / j
							pClr(idx * 3 + 1) = pClr(idx * 3 + 1) * (j - 1) \ j + pPnt(i * 3 + 1) / j
							pClr(idx * 3 + 2) = pClr(idx * 3 + 2) * (j - 1) \ j + pPnt(i * 3 + 2) / j
						Next i
'INSTANT VB NOTE: End of the original C# 'unsafe' block.
					' (5)クラスタ毎に色を描画
'INSTANT VB TODO TASK: There is no equivalent to an 'unsafe' block in VB:
'					unsafe
						Integer* pClu = clusters.DataInt32 ' cluster の要素へのポインタ
						Single* pClr = color.DataSingle ' color の要素へのポインタ
						Byte* pDst = CByte(dstImg.ImageData) ' dst の画素へのポインタ
						For i As Integer = 0 To size - 1
							Dim idx As Integer = pClu(i)
							pDst(i * 3 + 0) = CByte(pClr(idx * 3 + 0))
							pDst(i * 3 + 1) = CByte(pClr(idx * 3 + 1))
							pDst(i * 3 + 2) = CByte(pClr(idx * 3 + 2))
						Next i
'INSTANT VB NOTE: End of the original C# 'unsafe' block.
				End Using
				End Using
				End Using
				End Using
				' (6)画像を表示，キーが押されたときに終了
				Using TempCvWindow As CvWindow = New CvWindow("src", WindowMode.AutoSize, srcImg)
				Using TempCvWindow As CvWindow = New CvWindow("low-color", WindowMode.AutoSize, dstImg)
					Cv.WaitKey(0)
				End Using
				End Using
			End Using
			End Using
		End Sub
	End Class
End Namespace

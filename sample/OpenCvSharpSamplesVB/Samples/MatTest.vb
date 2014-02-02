Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' 行列演算のテスト
    ''' </summary>  
    Friend Module MatTest
        Public Sub Start()
            ' 行列aとbを初期化
            ' aはオーソドックスに1次元配列で元データを指定
            Dim _a() As Double = {1, 2, 3, 4, 5, 6, 7, 8, 9}
            ' bは二次元配列で指定してみる. 1チャンネルの行列ならこちらの方が楽.
            Dim _b(,) As Double = {{1, 4, 7}, {2, 5, 8}, {3, 6, 9}}
            ' 色(RGB3チャンネル)の配列
            Dim _c(,) As CvColor = {{CvColor.Red, CvColor.Green, CvColor.Blue}, {CvColor.Brown, CvColor.Cyan, CvColor.Pink}, {CvColor.Magenta, CvColor.Navy, CvColor.Violet}}

            Using a As New CvMat(3, 3, MatrixType.F64C1, _a) ' 元データが1次元配列の場合
                Using b As CvMat = CvMat.FromArray(_b) ' 元データが2次元配列の場合
                    Using c As CvMat = CvMat.FromArray(_c, MatrixType.U8C3) ' 多チャンネル配列の場合
                        ' aとbの値を表示
                        Form1.TextBox1.AppendText(String.Format("a : " & vbLf & "{0}", a))
                        Form1.TextBox1.AppendText(Environment.NewLine & String.Format("b : " & vbLf & "{0}", b))

                        ' 行列の掛け算
                        Form1.TextBox1.AppendText(Environment.NewLine & String.Format("A * B : " & vbLf & "{0}", a * b))

                        ' 加算、減算
                        Form1.TextBox1.AppendText(Environment.NewLine & String.Format("a + b : " & vbLf & "{0}", a + b))
                        Form1.TextBox1.AppendText(Environment.NewLine & String.Format("a - b : " & vbLf & "{0}", a - b))

                        ' 論理演算
                        Form1.TextBox1.AppendText(Environment.NewLine & String.Format("a & b : " & vbLf & "{0}", a And b))
                        Form1.TextBox1.AppendText(Environment.NewLine & String.Format("a | b : " & vbLf & "{0}", a Or b))
                        Form1.TextBox1.AppendText(Environment.NewLine & String.Format("~a : " & vbLf & "{0}", (Not a)))
                    End Using
                End Using
            End Using
            ' CvMatは大してメモリを食うことはないと思われるので、
            ' いちいちusingせずGCにまかせてもいいかも。

            Form1.TextBox1.AppendText(Environment.NewLine & String.Format("press any key to quit"))
            Console.Read()
        End Sub
    End Module
' End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' 連立方程式を解く
    ''' </summary>
    Friend Module Solve
        Public Sub Start()
            '  x +  y +  z = 6
            ' 2x - 3y + 4z = 8
            ' 4x + 4y - 4z = 0

            Dim A() As Double = {1, 1, 1, 2, -3, 4, 4, 4, -4}
            Dim B() As Double = {6, 8, 0}

            Dim matA As New CvMat(3, 3, MatrixType.F64C1, A)
            Dim matB As New CvMat(3, 1, MatrixType.F64C1, B)

            ' X = inv(A) * B
            Dim matAInv As CvMat = matA.Clone()
            matA.Inv(matAInv)

            Dim matX As CvMat = matAInv * matB

            Form1.TextBox1.AppendText(Environment.NewLine & String.Format("X = {0}", matX(0).Val0))
            Form1.TextBox1.AppendText(Environment.NewLine & String.Format("Y = {0}", matX(1).Val0))
            Form1.TextBox1.AppendText(Environment.NewLine & String.Format("Z = {0}", matX(2).Val0))
            Console.Read()
        End Sub
    End Module
' End Namespace

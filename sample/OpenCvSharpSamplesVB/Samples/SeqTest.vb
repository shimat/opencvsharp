Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' CvSeqのテスト
    ''' </summary>
    Friend Module SeqTest
        'INSTANT VB TODO TASK: There is no equivalent to the 'unsafe' modifier in VB:
        'ORIGINAL LINE: public unsafe SeqTest()
        Public Sub Start()
            Using storage As New CvMemStorage(0)
                Dim rand As New Random()
                Dim seq As New CvSeq(Of Integer)(SeqType.EltypeS32C1, storage)
                ' push
                For i As Integer = 0 To 9
                    Dim push As Integer = seq.Push(rand.Next(100)) 'seq.Push(i);
                    Form1.TextBox1.AppendText(Environment.NewLine & String.Format("{0} is pushed", push))
                Next i
                Form1.TextBox1.AppendText(Environment.NewLine & String.Format("----------"))

                ' enumerate
                Form1.TextBox1.AppendText(Environment.NewLine & String.Format("contents of seq"))
                For Each item As Integer In seq
                    Form1.TextBox1.AppendText(Environment.NewLine & String.Format("{0} ", item))
                Next item
                Form1.TextBox1.AppendText(Environment.NewLine & " ")

                ' sort
                Dim func As CvCmpFunc(Of Integer) = Function(a As Integer, b As Integer) a.CompareTo(b)
                seq.Sort(func)

                ' convert to array
                Dim array() As Integer = seq.ToArray()
                Form1.TextBox1.AppendText(Environment.NewLine & String.Format("contents of sorted seq"))
                For Each item As Integer In array
                    Form1.TextBox1.AppendText(Environment.NewLine & String.Format("{0} ", item))
                Next item
                Form1.TextBox1.AppendText(Environment.NewLine & " ")
                Form1.TextBox1.AppendText(Environment.NewLine & String.Format("----------"))

                ' pop
                For i As Integer = 0 To 9
                    Dim pop As Integer = seq.Pop()
                    Form1.TextBox1.AppendText(Environment.NewLine & String.Format("{0} is popped", pop))
                Next i
                'Console.ReadKey()
            End Using
        End Sub
    End Module
' End Namespace

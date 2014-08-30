Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' Binary Serialization
''' </summary>
    Friend Module Serialization
        Public Sub Start()
            Const FileName As String = "serialization.dat"

        Dim imgWrite As New IplImage(FilePath.Image.Fruits, LoadMode.Color)
            Dim imgRead As IplImage

            Using fs As New FileStream(FileName, FileMode.Create)
                Dim bf As New BinaryFormatter()
                bf.Serialize(fs, imgWrite)
            End Using

            Dim info As New FileInfo(FileName)
            Form1.TextBox1.AppendText(Environment.NewLine & String.Format("{0} filesize:{1}bytes", info.Name, info.Length))

            Using fs As New FileStream(FileName, FileMode.Open)
                Dim bf As New BinaryFormatter()
                imgRead = DirectCast(bf.Deserialize(fs), IplImage)
            End Using

            Form1.TextBox1.AppendText(Environment.NewLine & String.Format("Source:      width:{0} height:{1} depth:{2} channels:{3} imagesize:{4}", imgWrite.Width, imgWrite.Height, imgWrite.Depth, imgWrite.NChannels, imgWrite.ImageSize))
            Form1.TextBox1.AppendText(Environment.NewLine & String.Format("Deserialize: width:{0} height:{1} depth:{2} channels:{3} imagesize:{4}", imgRead.Width, imgRead.Height, imgRead.Depth, imgRead.NChannels, imgRead.ImageSize))

            Using TempCvWindow As CvWindow = New CvWindow("Source Image", imgWrite)
                Using TempCvWindowDes As CvWindow = New CvWindow("Deserialized Image", imgRead)
                    Cv.WaitKey()
                End Using
            End Using
        End Sub
    End Module
' End Namespace

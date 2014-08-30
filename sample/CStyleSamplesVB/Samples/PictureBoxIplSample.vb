Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports OpenCvSharp
Imports OpenCvSharp.UserInterface

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' PictureBoxIpl sample
''' </summary>
    Friend Module PictureBoxIplSample
        Public Sub Start()
        Using img As New IplImage(FilePath.Image.Fruits, LoadMode.Color)
            Using form As New Form() With {.ClientSize = New Size(img.Width, img.Height), .Text = "PictureBoxIpl Sample"}
                Using pbi As New PictureBoxIpl()
                    pbi.ImageIpl = img
                    pbi.ClientSize = form.ClientSize
                    form.Controls.Add(pbi)

                    Application.Run(form)
                End Using
            End Using
        End Using

        End Sub

    End Module
' End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' Converts gray scale image to pseudo-color images
    ''' </summary>
    Friend Module PseudoColor
        Public Sub Start()
            Using imgGray As New IplImage(500, 100, BitDepth.U8, 1)
                Using imgPseudo As New IplImage(imgGray.Size, BitDepth.U8, 3)
                    ' creates a beltlike grayscale image
                    FillGrayScaleValues(imgGray)

                    ' converts imgGray to Pseudo-color image
                    ConvertToPseudoColor(imgGray, imgPseudo)

                    Using TempCvWindow As CvWindow = New CvWindow("gray", imgGray)
                        Using TempCvWindowPseudo As CvWindow = New CvWindow("pseudo", imgPseudo)
                            Cv.WaitKey()
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Creates a beltlike grayscale image
        ''' </summary>
        ''' <param name="img"></param>
        Private Sub FillGrayScaleValues(ByVal img As IplImage)
            For y As Integer = 0 To img.Height - 1
                For x As Integer = 0 To img.Width - 1
                    Dim value As Byte = CByte(255.0 / img.Width * x)
                    img(y, x) = value
                Next x
            Next y
        End Sub

        ''' <summary>
        ''' Converts imgGray to Pseudo-color image
        ''' </summary>
        ''' <param name="src"></param>
        ''' <param name="dst"></param>
        Private Sub ConvertToPseudoColor(ByVal src As IplImage, ByVal dst As IplImage)
            ' creates lookup table
            Dim lutData() As CvColor = CreateLutData()

            Using src3ch As New IplImage(src.Size, BitDepth.U8, 3)
                Using lut As New CvMat(256, 1, MatrixType.U8C3, lutData)
                    ' converts 1-channel image to 3-channel image
                    Cv.Merge(src, src, src, Nothing, src3ch)
                    ' applies lut to grayscale image
                    Cv.LUT(src3ch, dst, lut)
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Creates lookup table
        ''' </summary>
        ''' <returns></returns>
        Private Function CreateLutData() As CvColor()
            Dim lutData(255) As CvColor
            For i As Integer = 0 To lutData.Length - 1
                Dim r, g, b As Double
                If i >= 0 AndAlso i <= 63 Then
                    r = 0
                    g = 255.0 / 63 * i
                    b = 255
                ElseIf i > 63 AndAlso i <= 127 Then
                    r = 0
                    g = 255
                    b = 255 - (255.0 / (127 - 63) * (i - 63))
                ElseIf i > 127 AndAlso i <= 191 Then
                    r = 255.0 / (191 - 127) * (i - 127)
                    g = 255
                    b = 0
                Else ' if (i > 191 && i < 256)
                    r = 255
                    g = 255 - (255.0 / (255 - 191) * (i - 191))
                    b = 0
                End If
                lutData(i) = New CvColor(CByte(r), CByte(g), CByte(b))
            Next i
            Return lutData
        End Function
    End Module
' End Namespace

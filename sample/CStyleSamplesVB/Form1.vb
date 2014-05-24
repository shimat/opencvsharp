Imports System.IO
Imports System.IO.Path
Imports System.Windows.Forms
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.VisualBasic.CallType

Imports OpenCvSharp
Imports OpenCvSharp.Blob
Imports OpenCvSharp.UserInterface
Imports OpenCvSharp.CPlusPlus



Public Class Form1
    Enum EnumSamples
        Affine
        BgSubtractorMOG
        BinarizationMethods
        Blob
        BlobOld
        BoundingRect
        CalibrateCamera
        CalibrateStereoCamera
        CaptureAVI
        ' CaptureByVideoInputSharp need to be corrected
        CaptureCamera
        Contour
        ContourScanner
        ConvertToBitmap
        ConvertToBitmapSource
        ConvertToIplImage
        ' ConvertToWriteableBitmap need to be corrected
        ConvexHull
        ConvexityDefect
        CopyMakeBorder
        CornerDetect
        CppTest
        CvWindowExTest
        ' Delaunay need to be corrected
        DFT
        DistTransform
        DrawToHDC
        ' DTree need to be corrected
        Edge
        ' EM need to be corrected
        FaceDetect
        ' FAST need to be corrected
        FileStorage
        Filter2D
        FindContours
        FitLine
        FlannTest
        GammaCorrection
        GpuTest
        Histogram
        ' HOG need to be corrected
        HoughCircles
        'HoughLines  need to be corrected
        Image2Stream
        Inpaint
        ' Kalman need to be corrected
        ' KMeans need to be corrected
        LatentSVM
        ' LetterRecog need to be corrected
        LineIterator
        LSH
        MatTest
        ' MDS need to be corrected
        Moments
        Morphology
        ' MSERSample need to be corrected
        OpticalFlowBM
        OpticalFlowHS
        OpticalFlowLK
        Perspective
        ' PictureBoxIplSample need to be corrected
        PixelAccess
        PixelSampling
        PolarTransform
        PseudoColor
        PyrDownUp
        PyrMeanShiftFiltering
        PyrSegmentation
        QtTest
        Resize
        SaveImage
        ' SeqPartition need to be corrected
        ' SeqTest need to be corrected
        Serialization
        SkinDetector
        ' Snake need to be corrected
        Solve
        ' Squares need to be corrected
        StarDetectorSample
        StereoCorrespondence
        ' SURFSample need to be corrected
        SVM
        Text
        Threshold
        TreeNodeIterator
        Undistort
        VideoWriter
        Watershed
    End Enum
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label1.Text = ""
        TextBox1.Clear()
        'OpenCvSharpSamplesVB.Affine.
        'OpenCvSharpSamplesVB.Affine.Start()
        'Exit Sub
        Dim method As System.Reflection.MethodInfo
        method = Type.GetType("OpenCvSharpSamplesVB." & ComboBox1.SelectedItem.ToString()).GetMethod("Start")
        method.Invoke(Me, Nothing)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = ""
        TextBox1.Clear()
        Dim enumType As Type = GetType(EnumSamples)
        Dim names() As String = [Enum].GetNames(enumType)
        Dim i As Integer

        For i = 0 To names.Length - 1
            ComboBox1.Items.Add(names(i))
        Next
    End Sub
End Class

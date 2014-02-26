Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text

Imports OpenCvSharp
Imports OpenCvSharp.CPlusPlus

Friend NotInheritable Class Program

    Shared Sub Main()
        FASTSample.Start()
        FlannSample.Start()
        HOGSample.Start()
        HoughLinesSample.Start()
        StarDetectorSample.Start()
    End Sub

End Class

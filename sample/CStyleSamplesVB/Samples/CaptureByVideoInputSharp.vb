Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports OpenCvSharp
Imports OpenCvSharp.Extensions
Imports VideoInputSharp

' Namespace OpenCvSharpSamplesVB
    ''' <summary>
    ''' Captures from camera by using VideoInputSharp (http://code.google.com/p/videoinputsharp/) 
    ''' </summary>
    Friend Module CaptureByVideoInputSharp
        Public Sub Start()
            Const DeviceID As Integer = 0
            Const CaptureFps As Integer = 30
            Const CaptureWidth As Integer = 640
            Const CaptureHeight As Integer = 480

            Using vi As New VideoInput()
                vi.SetIdealFramerate(DeviceID, CaptureFps)
                vi.SetupDevice(DeviceID, CaptureWidth, CaptureHeight)

                Dim width As Integer = vi.GetWidth(DeviceID)
                Dim height As Integer = vi.GetHeight(DeviceID)

            Using img As New IplImage(width, height, BitDepth.U8, 3), _
                 bitmap As New Bitmap(width, height, PixelFormat.Format24bppRgb), _
                 form As New Form() With {.Text = "VideoInputSharp sample", .ClientSize = New Size(width, height)}, _
                 pb As New PictureBox() With {.Dock = DockStyle.Fill, .Image = bitmap}
                If vi.IsFrameNew(DeviceID) Then
                    vi.GetPixels(DeviceID, img.ImageData, False, True)
                End If

                form.Controls.Add(pb)
                form.Show()

                Do While form.Created
                    If vi.IsFrameNew(DeviceID) Then
                        vi.GetPixels(DeviceID, img.ImageData, False, True)
                    End If
                    img.ToBitmap(bitmap)
                    pb.Refresh()
                    Application.DoEvents()
                Loop

                vi.StopDevice(DeviceID)
            End Using
        End Using
        '            
        '            const int DeviceID1 = 0;
        '            const int DeviceID2 = 1;
        '            const int DeviceID3 = 2;
        '            const int CaptureFps = 30;
        '            const int CaptureWidth = 640;
        '            const int CaptureHeight = 480;
        '            
        '            // lists all capture devices
        '            //ListDevices();
        '
        '            using (VideoInput vi = new VideoInput())
        '            {
        '                // initializes settings
        '                vi.SetIdealFramerate(DeviceID1, CaptureFps);
        '                vi.SetupDevice(DeviceID1, CaptureWidth, CaptureHeight);
        '                vi.SetupDevice(DeviceID2);
        '                vi.SetupDevice(DeviceID3);
        '
        '                using (IplImage img1 = new IplImage(vi.GetWidth(DeviceID1), vi.GetHeight(DeviceID1), BitDepth.U8, 3))
        '                using (IplImage img2 = new IplImage(vi.GetWidth(DeviceID2), vi.GetHeight(DeviceID2), BitDepth.U8, 3))
        '                using (IplImage img3 = new IplImage(vi.GetWidth(DeviceID3), vi.GetHeight(DeviceID3), BitDepth.U8, 3))
        '                using (CvWindow window1 = new CvWindow("Camera 1"))
        '                using (CvWindow window2 = new CvWindow("Camera 2"))
        '                using (CvWindow window3 = new CvWindow("Camera 3"))
        '                {
        '                    // to get the data from the device first check if the data is new
        '                    if (vi.IsFrameNew(DeviceID1))
        '                    {
        '                        vi.GetPixels(DeviceID1, img1.ImageData, false, true);
        '                    }
        '                    if (vi.IsFrameNew(DeviceID2))
        '                    {
        '                        vi.GetPixels(DeviceID2, img2.ImageData, false, true);
        '                    }
        '                    if (vi.IsFrameNew(DeviceID3))
        '                    {
        '                        vi.GetPixels(DeviceID3, img3.ImageData, false, true);
        '                    }
        '
        '                    // captures until the window is closed
        '                    while (true)
        '                    {
        '                        if (vi.IsFrameNew(DeviceID1))
        '                        {
        '                            vi.GetPixels(DeviceID1, img1.ImageData, false, true);
        '                        }
        '                        if (vi.IsFrameNew(DeviceID2))
        '                        {
        '                            vi.GetPixels(DeviceID2, img2.ImageData, false, true);
        '                        }
        '                        if (vi.IsFrameNew(DeviceID3))
        '                        {
        '                            vi.GetPixels(DeviceID3, img3.ImageData, false, true);
        '                        }
        '                        window1.Image = img1;
        '                        window2.Image = img2;
        '                        window3.Image = img3;
        '
        '                        if (Cv.WaitKey(1) > 0)
        '                            break;
        '                    }
        '
        '                    // stops capturing
        '                    vi.StopDevice(DeviceID1);
        '                    vi.StopDevice(DeviceID2);
        '                    vi.StopDevice(DeviceID3);
        '                }
        '            }
        '            //
        End Sub
    End Module
' End Namespace

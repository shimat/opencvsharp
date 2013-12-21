using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using OpenCvSharp;
using VideoInputSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Captures from camera by using VideoInputSharp (http://code.google.com/p/videoinputsharp/) 
    /// </summary>
    class CaptureByVideoInputSharp
    {
        public CaptureByVideoInputSharp()
        {
            const int DeviceID = 0;
            const int CaptureFps = 30;
            const int CaptureWidth = 640;
            const int CaptureHeight = 480;

            using (VideoInput vi = new VideoInput())
            {
                vi.SetIdealFramerate(DeviceID, CaptureFps);
                vi.SetupDevice(DeviceID, CaptureWidth, CaptureHeight);

                int width = vi.GetWidth(DeviceID);
                int height = vi.GetHeight(DeviceID);

                using (IplImage img = new IplImage(width, height, BitDepth.U8, 3))
                using (Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb))
                using (Form form = new Form() { Text = "VideoInputSharp sample", ClientSize = new Size(width, height) })
                using (PictureBox pb = new PictureBox() { Dock = DockStyle.Fill, Image = bitmap })
                {
                    if (vi.IsFrameNew(DeviceID))
                    {
                        vi.GetPixels(DeviceID, img.ImageData, false, true);
                    }

                    form.Controls.Add(pb);
                    form.Show();

                    while (form.Created)
                    {
                        if (vi.IsFrameNew(DeviceID))
                        {
                            vi.GetPixels(DeviceID, img.ImageData, false, true);
                        }
                        img.ToBitmap(bitmap);
                        pb.Refresh();
                        Application.DoEvents();
                    }

                    vi.StopDevice(DeviceID);
                }
            }
            /*
            const int DeviceID1 = 0;
            const int DeviceID2 = 1;
            const int DeviceID3 = 2;
            const int CaptureFps = 30;
            const int CaptureWidth = 640;
            const int CaptureHeight = 480;
            
            // lists all capture devices
            //ListDevices();

            using (VideoInput vi = new VideoInput())
            {
                // initializes settings
                vi.SetIdealFramerate(DeviceID1, CaptureFps);
                vi.SetupDevice(DeviceID1, CaptureWidth, CaptureHeight);
                vi.SetupDevice(DeviceID2);
                vi.SetupDevice(DeviceID3);

                using (IplImage img1 = new IplImage(vi.GetWidth(DeviceID1), vi.GetHeight(DeviceID1), BitDepth.U8, 3))
                using (IplImage img2 = new IplImage(vi.GetWidth(DeviceID2), vi.GetHeight(DeviceID2), BitDepth.U8, 3))
                using (IplImage img3 = new IplImage(vi.GetWidth(DeviceID3), vi.GetHeight(DeviceID3), BitDepth.U8, 3))
                using (CvWindow window1 = new CvWindow("Camera 1"))
                using (CvWindow window2 = new CvWindow("Camera 2"))
                using (CvWindow window3 = new CvWindow("Camera 3"))
                {
                    // to get the data from the device first check if the data is new
                    if (vi.IsFrameNew(DeviceID1))
                    {
                        vi.GetPixels(DeviceID1, img1.ImageData, false, true);
                    }
                    if (vi.IsFrameNew(DeviceID2))
                    {
                        vi.GetPixels(DeviceID2, img2.ImageData, false, true);
                    }
                    if (vi.IsFrameNew(DeviceID3))
                    {
                        vi.GetPixels(DeviceID3, img3.ImageData, false, true);
                    }

                    // captures until the window is closed
                    while (true)
                    {
                        if (vi.IsFrameNew(DeviceID1))
                        {
                            vi.GetPixels(DeviceID1, img1.ImageData, false, true);
                        }
                        if (vi.IsFrameNew(DeviceID2))
                        {
                            vi.GetPixels(DeviceID2, img2.ImageData, false, true);
                        }
                        if (vi.IsFrameNew(DeviceID3))
                        {
                            vi.GetPixels(DeviceID3, img3.ImageData, false, true);
                        }
                        window1.Image = img1;
                        window2.Image = img2;
                        window3.Image = img3;

                        if (Cv.WaitKey(1) > 0)
                            break;
                    }

                    // stops capturing
                    vi.StopDevice(DeviceID1);
                    vi.StopDevice(DeviceID2);
                    vi.StopDevice(DeviceID3);
                }
            }
            //*/
        }
    }
}
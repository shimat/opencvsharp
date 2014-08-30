using System;
using System.Runtime.InteropServices;
using OpenCvSharp;
using SampleBase;

namespace CStyleSamplesCS
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>http://opencv.jp/sample/basic_structures.html#access_pixels</remarks>
    class PixelAccess
    {        
        public PixelAccess()
        {
            using (IplImage img = new IplImage(FilePath.Image.Lenna, LoadMode.Color))
            {
                // easy method (slow)
                {
                    for (int y = 0; y < img.Height; y++)
                    {
                        for (int x = 0; x < img.Width; x++)
                        {
                            CvColor c = img[y, x];
                            img[y, x] = new CvColor
                            {
                                B = (byte)Math.Round(c.B * 0.7 + 10),
                                G = (byte)Math.Round(c.G * 1.0),
                                R = (byte)Math.Round(c.R * 0.0),
                            };
                        }
                    }
                }

                /*
                // fast operation
                unsafe
                {
                    byte* ptr = (byte*)img.ImageData;    // 画素データへのポインタ
                    for (int y = 0; y < img.Height; y++)
                    {
                        for (int x = 0; x < img.Width; x++)
                        {
                            int offset = (img.WidthStep * y) + (x * 3);
                            byte b = ptr[offset + 0];    // B
                            byte g = ptr[offset + 1];    // G
                            byte r = ptr[offset + 2];    // R
                            ptr[offset + 0] = (byte)Math.Round(b * 0.7 + 10);
                            ptr[offset + 1] = (byte)Math.Round(g * 1.0);
                            ptr[offset + 2] = (byte)Math.Round(r * 0.0);
                        }
                    }
                }
                //*/
                /*
                // pointer operation by managed code
                {
                    IntPtr ptr = img.ImageData;
                    for (int y = 0; y < img.Height; y++)
                    {
                        for (int x = 0; x < img.Width; x++)
                        {
                            int offset = (img.WidthStep * y) + (x * 3);
                            byte b = Marshal.ReadByte(ptr, offset + 0);    // B
                            byte g = Marshal.ReadByte(ptr, offset + 1);    // G
                            byte r = Marshal.ReadByte(ptr, offset + 2);    // R
                            Marshal.WriteByte(ptr, offset + 0, (byte)Math.Round(b * 0.7 + 10));
                            Marshal.WriteByte(ptr, offset + 1, (byte)Math.Round(g * 1.0));
                            Marshal.WriteByte(ptr, offset + 2, (byte)Math.Round(r * 0.0));
                        }
                    }
                }
                //*/
                //*/

                using (CvWindow w = new CvWindow("Image", WindowMode.AutoSize))
                {
                    w.Image = img;
                    Cv.WaitKey(0);
                }
            }
        }
    }
}

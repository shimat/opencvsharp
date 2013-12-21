using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// ピクセルデータへの直接アクセス
    /// </summary>
    /// <remarks>http://opencv.jp/sample/basic_structures.html#access_pixels</remarks>
    class PixelAccess
    {        
        public PixelAccess()
        {
            // IplImage
            // 8ビット3チャンネルカラー画像を読み込み，ピクセルデータを変更する

            // 画像の読み込み
            using (IplImage img = new IplImage(Const.ImageLenna, LoadMode.Color))
            {
                // (1)ピクセルデータ（R,G,B）を順次取得し，変更する
                ///*
                // 低速だけど簡単な方法
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
                //*/
                /*
                // ポインタを使った、多分高速な方法
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
                // unsafeではなくIntPtrで頑張る方法 (VB.NET向き)
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

                // (2)変更した結果の表示
                using (CvWindow w = new CvWindow("Image", WindowMode.AutoSize))
                {
                    w.Image = img;
                    Cv.WaitKey(0);
                }
            }
        }
    }
}

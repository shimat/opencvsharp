Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports OpenCvSharp

' Namespace OpenCvSharpSamplesVB
Imports SampleBase

''' <summary>
''' ピクセルデータへの直接アクセス
''' </summary>
''' <remarks>http://opencv.jp/sample/basic_structures.html#access_pixels</remarks>
Friend Module PixelAccess
    Public Sub Start()
        ' IplImage
        ' 8ビット3チャンネルカラー画像を読み込み，ピクセルデータを変更する

        ' 画像の読み込み
        Using img As New IplImage(FilePath.Image.Lenna, LoadMode.Color)
            ' (1)ピクセルデータ（R,G,B）を順次取得し，変更する
            '''*
            ' 低速だけど簡単な方法
            For y As Integer = 0 To img.Height - 1
                For x As Integer = 0 To img.Width - 1
                    Dim c As CvColor = img(y, x)
                    img(y, x) = New CvColor With {.B = CByte(Math.Round(c.B * 0.7 + 10)), .G = CByte(Math.Round(c.G * 1.0)), .R = CByte(Math.Round(c.R * 0.0))}
                Next x
            Next y
            '*/
            '                
            '                // ポインタを使った、多分高速な方法
            '                unsafe
            '                {
            '                    byte* ptr = (byte*)img.ImageData;    // 画素データへのポインタ
            '                    for (int y = 0; y < img.Height; y++)
            '                    {
            '                        for (int x = 0; x < img.Width; x++)
            '                        {
            '                            int offset = (img.WidthStep * y) + (x * 3);
            '                            byte b = ptr[offset + 0];    // B
            '                            byte g = ptr[offset + 1];    // G
            '                            byte r = ptr[offset + 2];    // R
            '                            ptr[offset + 0] = (byte)Math.Round(b * 0.7 + 10);
            '                            ptr[offset + 1] = (byte)Math.Round(g * 1.0);
            '                            ptr[offset + 2] = (byte)Math.Round(r * 0.0);
            '                        }
            '                    }
            '                }
            '                //
            '                
            '                // unsafeではなくIntPtrで頑張る方法 (VB.NET向き)
            '                {
            '                    IntPtr ptr = img.ImageData;
            '                    for (int y = 0; y < img.Height; y++)
            '                    {
            '                        for (int x = 0; x < img.Width; x++)
            '                        {
            '                            int offset = (img.WidthStep * y) + (x * 3);
            '                            byte b = Marshal.ReadByte(ptr, offset + 0);    // B
            '                            byte g = Marshal.ReadByte(ptr, offset + 1);    // G
            '                            byte r = Marshal.ReadByte(ptr, offset + 2);    // R
            '                            Marshal.WriteByte(ptr, offset + 0, (byte)Math.Round(b * 0.7 + 10));
            '                            Marshal.WriteByte(ptr, offset + 1, (byte)Math.Round(g * 1.0));
            '                            Marshal.WriteByte(ptr, offset + 2, (byte)Math.Round(r * 0.0));
            '                        }
            '                    }
            '                }
            '                //
            '*/

            ' (2)変更した結果の表示
            Using w As New CvWindow("Image", WindowMode.AutoSize)
                w.Image = img
                Cv.WaitKey(0)
            End Using
        End Using
    End Sub
End Module
' End Namespace

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenCvSharp.Tests.Img_alignment;

internal class ImageAlignmentTests
{
    private static Mat templateMatGray;

    /// <summary>
    /// 初始化模板，只需调用一次
    /// </summary>
    public static void InitTemplate(Bitmap templateBitmap)
    {
        templateMatGray = BitmapToMat(templateBitmap);
        Cv2.CvtColor(templateMatGray, templateMatGray, ColorConversionCodes.BGR2GRAY);
    }

    /// <summary>
    /// 每帧对齐到模板
    /// </summary>
    public static Bitmap AlignToTemplate(Bitmap srcBitmap)
    {
        if (srcBitmap == null || templateMatGray == null)
            return srcBitmap;

        Mat srcMat = BitmapToMat(srcBitmap);
        Mat srcGray = new Mat();
        Cv2.CvtColor(srcMat, srcGray, ColorConversionCodes.BGR2GRAY);

        // ORB 特征检测
        var orb = ORB.Create(500);
        KeyPoint[] kpTemplate, kpSrc;
        Mat desTemplate = new Mat();
        Mat desSrc = new Mat();
        orb.DetectAndCompute(templateMatGray, null, out kpTemplate, desTemplate);
        orb.DetectAndCompute(srcGray, null, out kpSrc, desSrc);

        // BFMatcher 特征匹配
        var bf = new BFMatcher(NormTypes.Hamming, crossCheck: true);
        var matches = bf.Match(desTemplate, desSrc);
        if (matches.Length < 4)
            return srcBitmap; // 匹配点太少，直接返回原图

        Array.Sort(matches, (a, b) => a.Distance.CompareTo(b.Distance));

        var ptsTemplate = new Point2f[matches.Length];
        var ptsSrc = new Point2f[matches.Length];
        for (int i = 0; i < matches.Length; i++)
        {
            ptsTemplate[i] = kpTemplate[matches[i].QueryIdx].Pt;
            ptsSrc[i] = kpSrc[matches[i].TrainIdx].Pt;
        }

        // 仿射矩阵
        Mat mask = new Mat();
        Mat M = Cv2.EstimateAffinePartial2D(InputArray.Create(ptsSrc), InputArray.Create(ptsTemplate), mask);
        if (M.Empty())
            return srcBitmap;

        Mat aligned = new Mat();
        Cv2.WarpAffine(srcMat, aligned, M, new Size(templateMatGray.Width, templateMatGray.Height));

        return MatToBitmap(aligned);
    }

    #region Bitmap <-> Mat (无需 Extensions)

    public static Mat BitmapToMat(Bitmap bitmap)
    {
        using (var ms = new System.IO.MemoryStream())
        {
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.ToArray();
            return Cv2.ImDecode(bytes, ImreadModes.Color); // 彩色
        }
    }

    public static Bitmap MatToBitmap(Mat mat)
    {
        if (mat == null || mat.Empty())
            return null;

        Bitmap bmp;

        if (mat.Channels() == 1)
        {
            // 灰度图
            bmp = new Bitmap(mat.Width, mat.Height, PixelFormat.Format8bppIndexed);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.WriteOnly, bmp.PixelFormat);

            // 创建缓冲区
            int length = mat.Width * mat.Height;
            byte[] buffer = new byte[length];
            Marshal.Copy(mat.Data, buffer, 0, length);

            // 拷贝到 Bitmap
            Marshal.Copy(buffer, 0, data.Scan0, length);
            bmp.UnlockBits(data);

            // 设置灰度调色板
            ColorPalette palette = bmp.Palette;
            for (int i = 0; i < 256; i++)
                palette.Entries[i] = Color.FromArgb(i, i, i);
            bmp.Palette = palette;
        }
        else if (mat.Channels() == 3)
        {
            // 彩色图 BGR -> RGB
            Mat rgbMat = new Mat();
            Cv2.CvtColor(mat, rgbMat, ColorConversionCodes.BGR2RGB);

            bmp = new Bitmap(rgbMat.Width, rgbMat.Height, PixelFormat.Format24bppRgb);
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.WriteOnly, bmp.PixelFormat);

            int length = rgbMat.Rows * int.Parse(rgbMat.Step().ToString());
            byte[] buffer = new byte[length];
            Marshal.Copy(rgbMat.Data, buffer, 0, length);
            Marshal.Copy(buffer, 0, data.Scan0, length);

            bmp.UnlockBits(data);
        }
        else
        {
            throw new NotSupportedException("Unsupported Mat format: channels=" + mat.Channels());
        }

        return new Bitmap(bmp); // 返回安全副本
    }

    #endregion
}


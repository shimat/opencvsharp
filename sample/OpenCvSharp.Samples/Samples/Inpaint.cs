using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 不要オブジェクトの除去
    /// </summary>
    /// <remarks>http://opencv.jp/sample/special_transforms.html#inpaint</remarks>
    class Inpaint
    {        
        public Inpaint()
        {
            // cvInpaint
            // 画像の不要な文字列部分に対するマスク画像を指定して文字列を除去する

            Console.WriteLine(
                "Hot keys: \n" +
                "\tESC - quit the program\n" +
                "\tr - restore the original image\n" +
                "\ti or ENTER - run inpainting algorithm\n" +
                "\t\t(before running it, paint something on the image)\n" +
                "\ts - save the original image, mask image, original+mask image and inpainted image to desktop."
            );

            // 原画像の読み込み
            using (IplImage img0 = new IplImage(Const.ImageFruits, LoadMode.AnyDepth | LoadMode.AnyColor))
            {
                // お絵かき用の画像を確保（マスク）
                using (IplImage img = img0.Clone())
                using (IplImage inpaintMask = new IplImage(img0.Size, BitDepth.U8, 1))
                // Inpaintの出力先画像を確保
                using (IplImage inpainted = img0.Clone())
                {
                    inpainted.Zero();
                    inpaintMask.Zero();

                    using (CvWindow wImage = new CvWindow("image", WindowMode.AutoSize, img))
                    {

                        // マウスイベントの処理
                        CvPoint prevPt = new CvPoint(-1, -1);
                        wImage.OnMouseCallback += delegate(MouseEvent ev, int x, int y, MouseEvent flags)
                        {
                            if (ev == MouseEvent.LButtonUp || (flags & MouseEvent.FlagLButton) == 0)
                            {
                                prevPt = new CvPoint(-1, -1);
                            }
                            else if (ev == MouseEvent.LButtonDown)
                            {
                                prevPt = new CvPoint(x, y);
                            }
                            else if (ev == MouseEvent.MouseMove && (flags & MouseEvent.FlagLButton) != 0)
                            {
                                CvPoint pt = new CvPoint(x, y);
                                if (prevPt.X < 0)
                                {
                                    prevPt = pt;
                                }
                                inpaintMask.Line(prevPt, pt, CvColor.White, 5, LineType.AntiAlias, 0);
                                img.Line(prevPt, pt, CvColor.White, 5, LineType.AntiAlias, 0);
                                prevPt = pt;
                                wImage.ShowImage(img);
                            }
                        };

                        for (; ; )
                        {
                            switch ((char)CvWindow.WaitKey(0))
                            {
                                case (char)27:    // ESCキーで終了
                                    CvWindow.DestroyAllWindows();
                                    return;
                                case 'r':   // 原画像を復元
                                    inpaintMask.Zero();
                                    img0.Copy(img);
                                    wImage.ShowImage(img);
                                    break;
                                case 'i':   // Inpaintの実行
                                case '\r':
                                    CvWindow wInpaint = new CvWindow("inpainted image", WindowMode.AutoSize);
                                    img.Inpaint(inpaintMask, inpainted, 3, InpaintMethod.Telea);
                                    wInpaint.ShowImage(inpainted);
                                    break;
                                case 's': // 画像の保存
                                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                                    img0.SaveImage(Path.Combine(desktop, "original.png"));
                                    inpaintMask.SaveImage(Path.Combine(desktop, "mask.png"));
                                    img.SaveImage(Path.Combine(desktop, "original+mask.png"));
                                    inpainted.SaveImage(Path.Combine(desktop, "inpainted.png"));
                                    break;
                            }
                        }

                    }

                }
            }

        }
    }
}

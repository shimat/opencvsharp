using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// テキストの描画
    /// </summary>
    /// <remarks>http://opencv.jp/sample/text.html#draw_text</remarks>
    class Text
    {        
        public Text()
        {
            // cvInitFont, cvPutText
            // フォントを初期化して，テキストを描画する

            List<FontFace> font_face = new List<FontFace>(
                (FontFace[])Enum.GetValues(typeof(FontFace))
            );
            font_face.Remove(FontFace.Italic);

            // (1)画像を確保し初期化する
            using (IplImage img = Cv.CreateImage(new CvSize(450, 600), BitDepth.U8, 3))
            {
                Cv.Zero(img);
                // (2)フォント構造体を初期化する
                CvFont[] font = new CvFont[font_face.Count * 2];
                for (int i = 0; i < font.Length; i += 2)
                {
                    font[i] = new CvFont(font_face[i / 2], 1.0, 1.0);
                    font[i + 1] = new CvFont(font_face[i / 2] | FontFace.Italic, 1.0, 1.0);
                }
                // (3)フォントを指定して，テキストを描画する
                for (int i = 0; i < font.Length; i++)
                {
                    CvColor rcolor = CvColor.Random();
                    Cv.PutText(img, "OpenCV sample code", new CvPoint(15, (i + 1) * 30), font[i], rcolor);
                }
                // (4)画像の表示，キーが押されたときに終了
                using (CvWindow w = new CvWindow(img))
                {
                    CvWindow.WaitKey(0);
                }
            }
        }
    }
}

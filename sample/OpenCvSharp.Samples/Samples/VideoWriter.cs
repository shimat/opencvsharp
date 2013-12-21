using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// 動画としてファイルへ書き出す
    /// </summary>
    /// <remarks>http://opencv.jp/sample/video_io.html#cap_write</remarks>
    class VideoWriter
    {
        public VideoWriter()
        {
            // (1)カメラに対するキャプチャ構造体を作成する
            using (CvCapture capture = CvCapture.FromCamera(0))
            {
                // (2)キャプチャサイズを取得する(この設定は，利用するカメラに依存する)
                int width = capture.FrameWidth;
                int height = capture.FrameHeight;
                double fps = 15;//capture.Fps;
                // (3)ビデオライタ構造体を作成する
                using (CvVideoWriter writer = new CvVideoWriter("cap.avi", FourCC.Prompt, fps, new CvSize(width, height)))
                using (CvFont font = new CvFont(FontFace.HersheyComplex, 0.7, 0.7))
                using (CvWindow window = new CvWindow("Capture", WindowMode.AutoSize))
                {
                    // (4)カメラから画像をキャプチャし，ファイルに書き出す
                    for (int frames = 0; ; frames++)
                    {
                        IplImage frame = capture.QueryFrame();
                        string str = string.Format("{0}[frame]", frames);
                        frame.PutText(str, new CvPoint(10, 20), font, new CvColor(0, 255, 100));
                        writer.WriteFrame(frame);
                        window.ShowImage(frame);

                        int key = CvWindow.WaitKey((int)(1000 / fps));
                        if (key == '\x1b')
                        {
                            break;
                        }
                    }
                }
            }

        }
    }
}

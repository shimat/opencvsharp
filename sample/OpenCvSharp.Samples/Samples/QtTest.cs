using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace OpenCvSharp.Test
{
    /// <summary>
    /// Qt highgui test
    /// </summary>
    class QtTest
    {
        public QtTest()
        {
            using (CvWindow window = new CvWindow("window", WindowMode.ExpandedGui))
            using (IplImage img = new IplImage(Const.ImageLenna, LoadMode.Color))
            {
                if (CvWindow.HasQt)
                {
                    // cvAddText
                    CvFont font = new CvFontQt("MS UI Gothic", 48, CvColor.Red, FontWeight.Bold, FontStyle.Italic);
                    img.AddText("Hello Qt!!", new CvPoint(50, img.Height - 50), font);                    

                    // cvDisplayOverlay, cvDisplayStatusBar
                    window.DisplayOverlay("overlay text", 2000);
                    window.DisplayStatusBar("statusbar text", 3000);

                    // cvCreateButton
                    CvButtonCallback buttonCallback = delegate(int state, object userdata)
                    {
                        Console.WriteLine("Button state:{0} userdata:{1} ({2})", state, userdata, userdata.GetType());
                    };
                    Cv.CreateButton("button1", buttonCallback, "my userstate", ButtonType.Checkbox, 0);
                    Cv.CreateButton("button2", buttonCallback, 12345.6789, ButtonType.Checkbox, 0);

                    // cvSaveWindowParameters
                    //window.SaveWindowParameters();
                }

                window.ShowImage(img);

                // cvCreateTrackbar2
                CvTrackbarCallback2 trackbarCallback = delegate(int pos, object userdata)
                {
                    Console.WriteLine("Trackbar pos:{0} userdata:{1} ({2})", pos, userdata, userdata.GetType());
                };
                window.CreateTrackbar2("trackbar1", 128, 256, trackbarCallback, "foobar");

                Cv.WaitKey();
            }
        }
    }
}
using System;
using System.Diagnostics;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using SampleBase;

namespace SamplesCS
{
    internal class BinarizerSample : ISample
    {
        public void Run()
        {
            using (var src = Cv2.ImRead(FilePath.Image.Binarization, ImreadModes.GrayScale))
            using (var niblack = new Mat())
            using (var sauvola = new Mat())
            using (var bernsen = new Mat())
            using (var nick = new Mat())
            {
                int kernelSize = 51;

                var sw = new Stopwatch();
                sw.Start();
                Binarizer.NiblackFast(src, niblack, kernelSize, -0.2);
                sw.Stop();
                Console.WriteLine($"NiblackFast {sw.ElapsedMilliseconds} ms");

                sw.Restart();
                Binarizer.SauvolaFast(src, sauvola, kernelSize, 0.1, 64);
                sw.Stop();
                Console.WriteLine($"SauvolaFast {sw.ElapsedMilliseconds} ms");

                sw.Restart();
                Binarizer.Bernsen(src, bernsen, kernelSize, 50, 200);
                sw.Stop();
                Console.WriteLine($"Bernsen {sw.ElapsedMilliseconds} ms");

                sw.Restart();
                Binarizer.Nick(src, nick, kernelSize, -0.14);
                sw.Stop();
                Console.WriteLine($"Nick {sw.ElapsedMilliseconds} ms");

                using (new Window("src", WindowMode.AutoSize, src))
                using (new Window("Niblack", WindowMode.AutoSize, niblack))
                using (new Window("Sauvola", WindowMode.AutoSize, sauvola))
                using (new Window("Bernsen", WindowMode.AutoSize, bernsen))
                using (new Window("Nick", WindowMode.AutoSize, nick))
                {
                    Cv2.WaitKey();
                }
            }
        }
    }
}

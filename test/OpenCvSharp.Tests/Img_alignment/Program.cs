using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCvSharp.Tests.Img_alignment;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("=== Image Alignment Demo ===");

        // 初始化模板
        Bitmap template = new Bitmap("template.jpg");
        ImageAlignmentTests.InitTemplate(template);

        // 模拟每帧输入（摄像头帧）
        Bitmap frame = new Bitmap("input.jpg");

        Bitmap aligned = ImageAlignmentTests.AlignToTemplate(frame);

        aligned.Save("aligned_output.jpg");
        Console.WriteLine("Aligned image saved!");
    }
}

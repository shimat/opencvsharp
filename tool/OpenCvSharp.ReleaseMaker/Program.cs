using System;

namespace OpenCvSharp.ReleaseMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
                return;

            var srcDir = args[0];
            var dstDir = args[1];
            var version = args[2];

            var packer = new Packer();
            packer.Pack(srcDir, dstDir, version);
        }
    }
}

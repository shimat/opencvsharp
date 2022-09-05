namespace OpenCvSharp.ReleaseMaker;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length != 3)
            return;

        var srcDir = args[0];
        var dstDir = args[1];
        var version = args[2];

        Packer.Pack(srcDir, dstDir, version);
    }
}

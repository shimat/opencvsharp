using System.Runtime.InteropServices;
using Android.App;
using Android.OS;
using Android.Util;
using OpenCvSharp;

namespace OpenCvSharp.AndroidSmoke;

[Activity(Label = "OpenCvSharp smoke", MainLauncher = true, Exported = true)]
public sealed class MainActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        try
        {
            using var input = new Mat(16, 16, MatType.CV_8UC3, new Scalar(0, 0, 255));
            using var blurred = new Mat();
            Cv2.GaussianBlur(input, blurred, new Size(3, 3), 0);

            if (!Cv2.ImEncode(".png", blurred, out var encoded))
                throw new InvalidOperationException("PNG encoding failed.");

            using var decoded = Cv2.ImDecode(encoded, ImreadModes.Color);
            if (decoded.Empty() || decoded.Rows != 16 || decoded.Cols != 16)
                throw new InvalidOperationException("PNG round trip produced an invalid Mat.");

            Log.Info("OpenCvSharpSmoke", $"PASS:{RuntimeInformation.ProcessArchitecture}");
        }
        catch (Exception error)
        {
            Log.Error("OpenCvSharpSmoke", $"FAIL:{error}");
        }

        Finish();
    }
}

// Pre-publish smoke test: exercises the actual .nupkg files about to be pushed to nuget.org,
// referenced the same way a real consumer would (PackageReference against a NuGet feed, not
// ProjectReference against source), to catch packaging mistakes (wrong RID asset placement,
// missing native library, broken dependency graph) that a source-level test can never see.
// Asserts and sets the process exit code instead of using a test framework, since the point is
// just "does a freshly `dotnet add package`-d app work at all", not exhaustive API coverage.
using System.Globalization;
using OpenCvSharp;

try
{
    var version = Cv2.GetVersionString();

    using var mat = new Mat(256, 256, MatType.CV_8UC1, Scalar.All(0));
    Cv2.Rectangle(mat, new Rect(40, 40, 120, 120), Scalar.All(255), thickness: -1);
    Cv2.Circle(mat, new Point(180, 180), 30, Scalar.All(200), thickness: -1);

    using var orb = ORB.Create(500);
    using var descriptors = new Mat();
    orb.DetectAndCompute(mat, default, out var keypoints, descriptors);

    foreach (var ext in new[] { ".jpg", ".png", ".tiff" })
    {
        var encoded = Cv2.ImEncode(ext, mat, out var buf);
        if (!encoded || buf.Length == 0)
            throw new InvalidOperationException($"ImEncode({ext}) failed or produced an empty buffer");

        using var decoded = Cv2.ImDecode(buf, ImreadModes.Unchanged);
        if (decoded.Empty() || decoded.Size() != mat.Size())
            throw new InvalidOperationException(
                $"ImDecode({ext}) round trip failed: empty={decoded.Empty()}, size={decoded.Size()}");
    }

    using var blob = Cv2.Dnn.BlobFromImage(mat, size: new Size(64, 64));
    if (blob.Empty())
        throw new InvalidOperationException("Cv2.Dnn.BlobFromImage produced an empty blob");

    var blobShape = string.Join('x', Enumerable.Range(0, blob.Dims).Select(blob.Size));

    Console.WriteLine(string.Format(
        CultureInfo.InvariantCulture,
        "ok: OpenCV {0}, ORB keypoints: {1}, dnn blob shape: {2}",
        version, keypoints.Length, blobShape));
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine("error: " + ex);
    return 1;
}

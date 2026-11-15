using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests.HighGui;

public partial class OpenGlTest
{
    private const uint ColorBufferBit = 0x4000;
    private const uint FrontBuffer = 0x0404;
    private const uint Viewport = 0x0BA2;
    private const uint Rgba = 0x1908;
    private const uint UnsignedByte = 0x1401;
    private const uint Version = 0x1F02;

    public static bool RunOpenGlTests => OperatingSystem.IsWindows() &&
        Environment.GetEnvironmentVariable("OPENCVSHARP_TEST_OPENGL") == "1";

    [Fact(Skip = "Requires an OpenGL-enabled Windows runtime and a desktop. Set OPENCVSHARP_TEST_OPENGL=1 to run.", SkipUnless = nameof(RunOpenGlTests))]
    public unsafe void HighGuiDrawsAndFreesWithTheRegisteredUserData()
    {
        const string windowName = "OpenCvSharp OpenGL callback test";
        var state = new CallbackState();
        var userData = (IntPtr)(&state);
        delegate* unmanaged[Cdecl]<IntPtr, void> drawCallback = &Draw;

        Cv2.NamedWindow(windowName, WindowFlags.OpenGL);
        try
        {
            Assert.Equal(1, Cv2.GetWindowProperty(windowName, WindowPropertyFlags.OpenGL));
            Cv2.SetOpenGlContext(windowName);
            var version = Marshal.PtrToStringAnsi(GlGetString(Version));
            Assert.False(string.IsNullOrEmpty(version));
            Console.WriteLine($"OpenGL version: {version}");

            Cv2.SetOpenGlDrawCallback(windowName, drawCallback, userData);
            Cv2.SetOpenGlFreeCallback(windowName, &Free);
            Assert.Equal((IntPtr)drawCallback, (IntPtr)Cv2.GetOpenGlDrawCallback(windowName));
            Assert.Equal(userData, Cv2.GetOpenGlUserData(windowName));

            Cv2.UpdateWindow(windowName);
            Cv2.WaitKey(100);
            Assert.True(state.DrawCount > 0);
            Assert.Equal((byte)255, state.Green);
            Assert.Equal(0, state.FreeCount);
        }
        finally
        {
            Cv2.DestroyWindow(windowName);
        }

        Assert.Equal(1, state.FreeCount);
    }

    [Fact(Skip = "Requires an OpenGL-enabled Windows runtime and a desktop. Set OPENCVSHARP_TEST_OPENGL=1 to run.", SkipUnless = nameof(RunOpenGlTests))]
    public void Viz3dRendersGeometryAndRemovesItFromTheScene()
    {
        const string windowName = "OpenCvSharp viz3d test";
        var red = new Vec3f(1, 0, 0);
        var green = new Vec3f(0, 1, 0);
        var white = new Vec3f(1, 1, 1);
        Cv2.NamedWindow(windowName, WindowFlags.OpenGL);
        try
        {
            Cv2.ResizeWindow(windowName, 240, 180);
            Viz3d.SetPerspective(windowName, 0.8f, 0.1f, 100);
            Viz3d.SetSky(windowName, default);
            Viz3d.SetGridVisible(windowName, false);
            int backgroundRedPixels = CountRedPixels(windowName);
            Viz3d.ShowBox(windowName, "box", new Vec3f(1, 1, 1), red);
            Viz3d.SetObjectPosition(windowName, "box", default);
            Viz3d.SetObjectRotation(windowName, "box", new Vec3f(0.1f, 0, 0));
            Assert.True(CountRedPixels(windowName) > backgroundRedPixels + 100);

            Viz3d.DestroyObject(windowName, "box");
            Assert.InRange(CountRedPixels(windowName), 0, backgroundRedPixels + 20);

            Viz3d.SetSun(windowName, new Vec3f(1, 1, 1), white, white);
            Viz3d.ShowPlane(windowName, "plane", new Vec2f(1, 2), white, Viz3dRenderMode.Wireframe);
            Viz3d.ShowSphere(windowName, "sphere", 1, green, Viz3dRenderMode.Shading, 1);
            using var vertices = Mat.FromArray(new float[,]
            {
                { 0, 0, 0, 0, 1, 0 },
                { 1, 0, 0, 0, 1, 0 },
                { 0, 1, 0, 0, 1, 0 }
            });
            using var indices = Mat.FromArray(new int[,] { { 0, 1, 2 } });
            using var line = vertices.RowRange(0, 2);
            Viz3d.ShowMesh(windowName, "mesh", vertices);
            Viz3d.ShowMesh(windowName, "indexed mesh", vertices, indices);
            Viz3d.ShowPoints(windowName, "points", vertices);
            Viz3d.ShowLines(windowName, "lines", line);

            using var trajectory = Mat.FromArray(new float[,]
            {
                { 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 0, 1 }
            });
            Viz3d.ShowCameraTrajectory(windowName, "trajectory", trajectory, 1.5f, 0.15f);

            using var intrinsics = Mat.Eye(3, 3, MatType.CV_64F).ToMat();
            using var rgbd = new Mat(2, 2, MatType.CV_32FC4, new Scalar(0, 255, 0, 1000));
            Viz3d.ShowRgbd(windowName, "depth", rgbd, intrinsics);

            using var attributes = new Mat(1, Cv2.GetGaussianSplatPlyPropNames().Length, MatType.CV_32F, Scalar.All(0));
            attributes.Set(0, 10, 1f);
            using var splats = new Mat();
            Cv2.DecodeGaussianSplats(attributes, splats);
            Viz3d.ShowGaussianSplats(windowName, "splats", splats);
            Cv2.WaitKey(100);
        }
        finally
        {
            Cv2.DestroyWindow(windowName);
        }
    }

    private static unsafe int CountRedPixels(string windowName)
    {
        Cv2.UpdateWindow(windowName);
        Cv2.WaitKey(100);
        Cv2.SetOpenGlContext(windowName);

        var viewport = stackalloc int[4];
        GlGetIntegers(Viewport, viewport);
        int width = viewport[2], height = viewport[3];
        Assert.True(width > 0 && height > 0);

        var pixels = new byte[checked(width * height * 4)];
        GlReadBuffer(FrontBuffer);
        fixed (byte* pixelsPtr = pixels)
            GlReadPixels(0, 0, width, height, Rgba, UnsignedByte, pixelsPtr);

        int count = 0;
        for (var offset = 0; offset < pixels.Length; offset += 4)
        {
            if (pixels[offset] > 200 && pixels[offset + 1] < 30 && pixels[offset + 2] < 30)
                count++;
        }
        return count;
    }

    private struct CallbackState
    {
        public int DrawCount;
        public int FreeCount;
        public byte Green;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe void Draw(IntPtr userData)
    {
        var state = (CallbackState*)userData;
        GlClearColor(0, 1, 0, 1);
        GlClear(ColorBufferBit);
        var pixel = stackalloc byte[4];
        GlReadPixels(0, 0, 1, 1, Rgba, UnsignedByte, pixel);
        state->Green = pixel[1];
        state->DrawCount++;
    }

    [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
    private static unsafe void Free(IntPtr userData) => ((CallbackState*)userData)->FreeCount++;

    [LibraryImport("opengl32.dll", EntryPoint = "glClearColor")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void GlClearColor(float red, float green, float blue, float alpha);

    [LibraryImport("opengl32.dll", EntryPoint = "glClear")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void GlClear(uint mask);

    [LibraryImport("opengl32.dll", EntryPoint = "glGetString")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial IntPtr GlGetString(uint name);

    [LibraryImport("opengl32.dll", EntryPoint = "glGetIntegerv")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static unsafe partial void GlGetIntegers(uint name, int* values);

    [LibraryImport("opengl32.dll", EntryPoint = "glReadBuffer")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void GlReadBuffer(uint buffer);

    [LibraryImport("opengl32.dll", EntryPoint = "glReadPixels")]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static unsafe partial void GlReadPixels(int x, int y, int width, int height, uint format, uint type, byte* pixels);
}

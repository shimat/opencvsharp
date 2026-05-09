using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OpenCvSharp.Tests.Cuda;

public class CudaOpenGLTest : CudaTestBase
{
    [Fact]
    public void SetGlDevice_Test()
    {
        VerifyCudaSupport();

        try
        {
            // Act
            Cv2.Cuda.SetGlDevice(0);
        }
        catch (OpenCVException ex)
        {
            // If we are in a headless environment (CI/CD), 
            // OpenCV might throw an exception saying no OpenGL context is available.
            // This is acceptable as it proves the P/Invoke binding reached the library.
            if (ex.Message.Contains("The library is compiled without OpenGL support") )
            {
                Assert.Skip("The library is compiled without OpenGL support");
            }
            throw; // Unexpected error
        }
    }
}

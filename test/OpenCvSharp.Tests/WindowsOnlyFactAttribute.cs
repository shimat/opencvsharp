using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests
{
    // ReSharper disable once UnusedMember.Global
    public class WindowsOnlyFactAttribute : FactAttribute
    {
        public WindowsOnlyFactAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Skip = "Only running in Windows.";
            }
        }
    }
}
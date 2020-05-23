using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests
{
    // ReSharper disable once UnusedMember.Global
    public class LinuxOnlyFactAttribute : FactAttribute
    {
        public LinuxOnlyFactAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Skip = "Only running in Linux.";
            }
        }
    }

    // ReSharper disable once UnusedMember.Global
    public class LinuxOnlyStaFactAttribute : StaFactAttribute
    {
        public LinuxOnlyStaFactAttribute()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Skip = "Only running in Linux.";
            }
        }
    }
}
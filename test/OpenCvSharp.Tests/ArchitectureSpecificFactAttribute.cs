using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests
{
    // ReSharper disable once UnusedMember.Global
    public class ArchitectureSpecificFactAttribute : FactAttribute
    {
        public ArchitectureSpecificFactAttribute(params Architecture[] architectures)
        {
            if (architectures.Contains(RuntimeInformation.ProcessArchitecture))
            {
                Skip = $"Only running in specific architectures ({string.Join(",", architectures)}).";
            }
        }
    }
}
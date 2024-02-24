using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests;

// ReSharper disable once UnusedMember.Global
public sealed class ArchitectureSpecificFactAttribute : FactAttribute
{
    public Architecture[] Architectures { get; }

    public ArchitectureSpecificFactAttribute(params Architecture[] architectures)
    {
        Architectures = architectures;

        if (architectures.Contains(RuntimeInformation.ProcessArchitecture))
        {
            Skip = $"Only running in specific architectures ({string.Join(",", architectures)}).";
        }
    }
}

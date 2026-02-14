using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Xunit;

namespace OpenCvSharp.Tests;

// ReSharper disable once UnusedMember.Global
public sealed class ArchitectureSpecificFactAttribute : FactAttribute
{
    public Architecture[] Architectures { get; }

    public ArchitectureSpecificFactAttribute(
        Architecture[] architectures,
        [CallerFilePath] string? sourceFilePath = null,
        [CallerLineNumber] int sourceLineNumber = -1)
        : base(sourceFilePath, sourceLineNumber)
    {
        Architectures = architectures;

        if (architectures.Contains(RuntimeInformation.ProcessArchitecture))
        {
            Skip = $"Only running in specific architectures ({string.Join(",", architectures)}).";
        }
    }
}

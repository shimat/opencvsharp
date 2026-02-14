using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xunit;

namespace OpenCvSharp.Tests;

// ReSharper disable once UnusedMember.Global
public sealed class ExplicitTheoryAttribute : TheoryAttribute
{
    public ExplicitTheoryAttribute(
        [CallerFilePath] string? sourceFilePath = null,
        [CallerLineNumber] int sourceLineNumber = -1)
        : base(sourceFilePath, sourceLineNumber)
    {
        if (!Debugger.IsAttached)
        {
            Skip = "Only running in interactive mode.";
        }
    }
}

public sealed class ExplicitStaTheoryAttribute : StaTheoryAttribute
{
    public ExplicitStaTheoryAttribute(
        [CallerFilePath] string? sourceFilePath = null,
        [CallerLineNumber] int sourceLineNumber = -1)
        : base(sourceFilePath, sourceLineNumber)
    {
        if (!Debugger.IsAttached)
        {
            Skip = "Only running in interactive mode.";
        }
    }
}

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Xunit;

namespace OpenCvSharp.Tests;

// ReSharper disable once UnusedMember.Global
public sealed class ExplicitFactAttribute : FactAttribute
{
    public ExplicitFactAttribute(
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

public sealed class ExplicitStaFactAttribute : StaFactAttribute
{
    public ExplicitStaFactAttribute(
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

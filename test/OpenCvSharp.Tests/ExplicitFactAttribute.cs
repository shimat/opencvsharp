using System.Diagnostics;
using Xunit;

namespace OpenCvSharp.Tests;

// ReSharper disable once UnusedMember.Global
public sealed class ExplicitFactAttribute : FactAttribute
{
    public ExplicitFactAttribute()
    {
        if (!Debugger.IsAttached)
        {
            Skip = "Only running in interactive mode.";
        }
    }
}

public sealed class ExplicitStaFactAttribute : StaFactAttribute
{
    public ExplicitStaFactAttribute()
    {
        if (!Debugger.IsAttached)
        {
            Skip = "Only running in interactive mode.";
        }
    }
}

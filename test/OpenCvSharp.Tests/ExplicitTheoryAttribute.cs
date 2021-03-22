using System.Diagnostics;
using Xunit;

namespace OpenCvSharp.Tests
{
    // ReSharper disable once UnusedMember.Global
    public sealed class ExplicitTheoryAttribute : TheoryAttribute
    {
        public ExplicitTheoryAttribute()
        {
            if (!Debugger.IsAttached)
            {
                Skip = "Only running in interactive mode.";
            }
        }
    }

    public sealed class ExplicitStaTheoryAttribute : StaTheoryAttribute
    {
        public ExplicitStaTheoryAttribute()
        {
            if (!Debugger.IsAttached)
            {
                Skip = "Only running in interactive mode.";
            }
        }
    }
}
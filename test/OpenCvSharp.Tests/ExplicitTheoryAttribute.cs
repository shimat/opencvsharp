using System.Diagnostics;
using Xunit;

namespace OpenCvSharp.Tests
{
    // ReSharper disable once UnusedMember.Global
    public class ExplicitTheoryAttribute : TheoryAttribute
    {
        public ExplicitTheoryAttribute()
        {
            if (!Debugger.IsAttached)
            {
                Skip = "Only running in interactive mode.";
            }
        }
    }

    public class ExplicitStaTheoryAttribute : StaTheoryAttribute
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
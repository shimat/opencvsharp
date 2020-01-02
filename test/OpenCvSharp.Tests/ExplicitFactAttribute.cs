using System.Diagnostics;
using Xunit;

namespace OpenCvSharp.Tests
{
    // ReSharper disable once UnusedMember.Global
    public class ExplicitFactAttribute : FactAttribute
    {
        public ExplicitFactAttribute()
        {
            if (!Debugger.IsAttached)
            {
                Skip = "Only running in interactive mode.";
            }
        }
    }

    public class ExplicitStaFactAttribute : StaFactAttribute
    {
        public ExplicitStaFactAttribute()
        {
            if (!Debugger.IsAttached)
            {
                Skip = "Only running in interactive mode.";
            }
        }
    }
}
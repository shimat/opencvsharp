using System.Diagnostics;
using Xunit;

namespace OpenCvSharp.Tests
{
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
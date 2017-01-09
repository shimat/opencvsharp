using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Common;
using NUnit.Framework;
using NUnitLite;

namespace OpenCvSharp.Tests
{
    public class Program
    {
        public static int Main(string[] args)
        {
            int result = new AutoRun(typeof(Program).GetTypeInfo().Assembly)
                .Execute(args, new ExtendedTextWrapper(Console.Out), Console.In);
            Console.WriteLine("Press any key to exit");
            Console.Read();
            return result;
        }
    }
}

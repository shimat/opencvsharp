using System;
using System.Reflection;

using System.Collections;
using System.Collections.Generic;
using System.IO;

using OpenCvSharp;

namespace ExceptionSafeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string innerClassAsString = InnerNativeClassGenerator.generateClass(typeof(NativeMethods));
            string outerClassAsString = OuterNativeClassGenerator.generateClass(typeof(NativeMethods));
            
            File.WriteAllText("../NativeMethods_generated.cs", outerClassAsString);
            File.WriteAllText("../NativeMethodsExc_generated.cs", innerClassAsString);
            Console.WriteLine("Generated");
        }
    }
}

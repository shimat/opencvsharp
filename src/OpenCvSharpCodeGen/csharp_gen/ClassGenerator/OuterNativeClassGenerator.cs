using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ExceptionSafeGenerator
{
    class OuterNativeClassGenerator
    {
        /// <summary>
        /// Generates the outer class
        /// </summary>
        static public string GenerateClass(Type classType)
        {
            AbstractMethodGenerator gen =  new OuterNativeMethodGenerator();
            return ClassGenerator.GenerateClass(classType, "NativeMethods", gen);
        }
    }
}



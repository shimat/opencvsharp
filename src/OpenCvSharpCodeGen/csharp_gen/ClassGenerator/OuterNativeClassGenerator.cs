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
        static public string generateClass(Type classType)
        {
            AbstractMethodGenerator gen =  new OuterNativeMethodGenerator();
            return ClassGenerator.generateClass(classType, "NativeMethods", gen);
        }
    }
}



using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ExceptionSafeGenerator
{
    static class ClassGenerator 
    {
        private const string INNER_CLASS_NAME = "NativeMethodsExc";
        
        /// <summary>
        /// Generates a class.
        /// </summary>
        /// <remarks>
        /// This class uses an AbstractMethodGenerator to generate the appropriate member functions.
        /// </remarks>
        static public string generateClass(Type classType, string className, AbstractMethodGenerator methodGen )
        {
            string header = $@"using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{{
    static partial class {className}
    {{
";
            string body = "";
            string footer = "\n}\n}";
            // Get all methodinfo of all methods
            MethodInfo[] methods = classType.GetMethods(); 
            int count = 0;
            foreach(MethodInfo info  in methods)
            {
                var includeMethod = false;
                foreach(var attr in System.Attribute.GetCustomAttributes(info))
                {
                    // Only include if it is function using p/invoke
                    if (attr is DllImportAttribute )
                    {
                        includeMethod = true;
                    }
                }
                if(includeMethod)
                {
                    body = body + methodGen.generateMethod(info);
                    ++count;
                }
            }
            Console.WriteLine($"{count} functions have been added.");
            return $"{header}{body}{footer}";
        }

    }
}



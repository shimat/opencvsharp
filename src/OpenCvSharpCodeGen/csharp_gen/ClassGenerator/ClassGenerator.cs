using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ExceptionSafeGenerator
{

    static class ClassGenerator 
    {

        private const string INNER_CLASS_NAME = "NativeMethodsExc";
        
        /// <summary>
        /// Generates the inner class (uses p/invoke)
        /// TODO: implement properly 
        /// </summary>
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
            //string [] ignoreFunctionNames  = ["LoadLibraries", "TryPInvoke", "IsWindows", "IsUnix"];
            // get all methodinfo of functions which are using pinvoke
            MethodInfo[] methods = classType.GetMethods(); 

            foreach(MethodInfo info  in methods)
            {
                var includeMethod = false;
                foreach(var attr in System.Attribute.GetCustomAttributes(info))
                {
                    if (attr is DllImportAttribute )
                    {
                        includeMethod = true;
                    }
                }
                if(includeMethod)
                {
                    body = body + methodGen.generateMethod(info);
                }
                    
            }
            return $"{header}{body}{footer}";
        }

    }
}



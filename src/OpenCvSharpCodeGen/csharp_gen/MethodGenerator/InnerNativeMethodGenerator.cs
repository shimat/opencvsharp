using System;
using System.Reflection;

namespace ExceptionSafeGenerator
{
    class InnerNativeMethodGenerator : AbstractMethodGenerator
    {
        /// <summary>
        /// Returns a string defining the exception safe Version of the function(s , some are overloaded)
        /// This are the functions defining the call using p/invoke
        /// This consists of: 
        ///   all names of function altered by postfix excSafe or similar
        ///     all functions return bool regardless what previous ret value
        ///     for "void" functions:
        ///         no alteration to signatures, except that they return bool
        ///     for "type*" function:
        ///         use "ref IntPtr" parameter at position 0  to store the pointer 
        ///     for "type" function:
        ///         add a "ref type" parameter at position 0 
        /// </summary>
        public override string  generateMethod(MethodInfo methodInfo)
        {
            string methodName = methodInfo.Name;
            string newMethodName = $"{methodName}{EXC_PREFIX}";
            FunctionStringBuilder builder = new FunctionStringBuilder(newMethodName);
            // seems always the same, TODO: check for possible exceptions
            string header = "[DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]\n";
            builder.attributes = header;
            builder.modifier = "public static extern";
            builder.returnValue = typeof(bool);
            Type returnValueType = methodInfo.ReturnType;
            string returnValueString = StringHelper.getValidType(returnValueType.ToString());
            // Depending on return value
            if(returnValueType != typeof(void))
            {
                /// if returnValueType is a pointer, always use IntPtr 
                if(returnValueType.IsPointer)
                {
                    builder.addParameter($"ref IntPtr ret");            
                }
                else
                {
                    builder.addParameter($"ref {returnValueString} ret");
                }
            }
            foreach(ParameterInfo paramInfo in methodInfo.GetParameters())
            {   
                builder.addParameter(paramInfo);
            } 
            return builder.build();
        }
    }
}

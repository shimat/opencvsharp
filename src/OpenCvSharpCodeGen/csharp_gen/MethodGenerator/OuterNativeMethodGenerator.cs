using System;
using System.Reflection;

using System.Collections;
using System.Collections.Generic;

namespace ExceptionSafeGenerator
{
    class OuterNativeMethodGenerator : AbstractMethodGenerator
    {

        private const string INNER_LAYER_CLASSNAME = "NativeMethodsExc";

        /// <summary>
        /// Returns a string defining the function(s) in class NativeMethods, which calls the correspondent inner function
        /// </summary>
        /// <remarks>
        /// Signature remains the same as in the template funcitons
        /// The generated function consists of the following:
        ///     -If necessary, initialize a parameter which stores the return value (only if not void)  
        ///         If ret value is a pointer, store it in reference to IntPtr
        ///         Else store it in a reference of its type
        ///     -A call to the generated function, with ref to the ret parameter at pos 0 in parameterlist if necessary
        ///     -Check if exception happened (a call to the excetpion handler)
        ///     -return the return value yielded from the first parameter if necessary. Cast to pointer type if necessary.
        /// 
        ///     for "void" functions:
        ///         no alteration to signatures, except that they return bool
        ///     for "type*" function:
        ///         use "ref IntPtr" parameter at position 0  to store the pointer 
        ///     for "type" function:
        ///         add a "ref type" parameter at position 0 
        /// </remarks>
        /// <example>
        /// <code>
        /// public static  System.IntPtr f( System.IntPtr a )
        /// {
	    ///     System.IntPtr ret = new System.IntPtr();
	    ///     bool isExc = NativeMethodsExc.f_excsafe(ref ret, a);
        ///     if(isExc)
		///         handleException();
	    ///     return ret;
        /// }
        /// </code>
        /// </example>
        public override string GenerateMethod(MethodInfo methodInfo)
        {
            string returnString = ""; 
            string methodName = methodInfo.Name;
            FunctionStringBuilder builder = new FunctionStringBuilder(methodName);
            builder.modifier = "public static ";
            builder.returnType = methodInfo.ReturnType;
            builder.body = GetBody(methodName, methodInfo.GetParameters(), methodInfo.ReturnType);
            foreach(ParameterInfo paramInfo in methodInfo.GetParameters())
            {   
                builder.AddParameter(paramInfo);
            } 
            returnString += builder.Build();
            return returnString;
        }

        /// <summary>
        /// Get the function body
        /// This consists of 
        /// </summary>
        private string GetBody(string methodName, ParameterInfo []param, Type returnValueType)
        {
            /// TODO: Find a better place for variables
            string RET_NAME = "isExc";
            string HANDLE_EXC_FUNCTION = "handleException";
            /// only needing the names
            /// TODO: Add handling of cases, if for example ref is in Signature, as it must be included on the calling side too
            List<string> paramNames = new List<string>(); 
            string refInit = "";
            string refReturn = "";
            // Depending on return value
            if(returnValueType != typeof(void))
            {
                paramNames.Add($"ref ret");
                /// check if returnValueType is a pointer, and use IntPtr to store the value
                if(returnValueType.IsPointer)
                {
                    string returnValueString = "IntPtr";
                    refInit = $"\t{returnValueString} ret = new {returnValueString}();\n";
                    string castType = Helper.GetValidType(returnValueType.ToString());
                    refReturn = $"\treturn ({castType})ret;\n";
                }
                else{
                    string returnValueString = Helper.GetValidType(returnValueType.ToString());
                    refInit = $"\t{returnValueString} ret = new {returnValueString}();\n";
                    refReturn = $"\treturn ret;\n";
                }
            }
            foreach(var p in param)
            {
                string name = Helper.GetValidName(p.Name);
                                
                // TODO: factor this out in helper class 
                string keywords = "";
                if(p.ParameterType.IsByRef && p.IsOut)
                {
                    keywords += " out ";
                }
                else if (p.ParameterType.IsByRef && ! p.IsOut)
                    keywords += " ref "; 

                paramNames.Add(keywords + name);
            }
            string newMethodName = $"{methodName}{EXC_PREFIX}";
            string parameter = Helper.CommaSeparated(paramNames);
            string callMethod = $"bool {RET_NAME} = {INNER_LAYER_CLASSNAME}.{newMethodName}({parameter});";
            string handleExcCall = $"\n\tif({RET_NAME})\n\t\t{HANDLE_EXC_FUNCTION}();\n";
            var body = $"\n{{\n{refInit}\t{callMethod}\n{handleExcCall}{refReturn}}}\n";
            return body;
        }
    }
}

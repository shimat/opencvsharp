using System;
using System.Collections;

namespace ExceptionSafeGenerator
{
    static class StringHelper
    {
        static public string commaSeparated(IEnumerable list)
        {
            string outString = "";
            foreach(var entry in list)
            {
                outString += $"{entry}, "; 
            }
            // remove last two chars ", "
            if(outString.Length > 2)
                outString = outString.Substring(0,outString.Length-2);
            return outString;
        }

        /// Escape the name
        /// TODO, do not do this explicetly
        static public string getValidName(string name)
        {
            string[] invalidNames = new string[] {"params"};
            foreach(string invalidName in invalidNames )
            {
                if (invalidName == name)
                {
                    return  "@" + name;
                }
            }
            return name;
        }

        static public string getValidType(string type)
        {
            if(type.EndsWith("&"))
            {
                type = type.Remove(type.Length -1);
            }
            // Replace + with .
            type = type.Replace("+", ".");
            return type;
        }
    }
}
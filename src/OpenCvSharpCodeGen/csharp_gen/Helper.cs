using System;
using System.Collections;

namespace ExceptionSafeGenerator
{
    static class Helper
    {
        static public string CommaSeparated(IEnumerable list)
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
        
        /// <summary>
        /// Escape the name if params
        /// TODO, do not do this explicitly
        /// </summary>
        static public string GetValidName(string name)
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

        /// <summary>
        /// Remove artifacts 
        /// </summary>
        static public string GetValidType(string type)
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
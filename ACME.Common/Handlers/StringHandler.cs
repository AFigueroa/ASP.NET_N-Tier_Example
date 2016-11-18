using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Common
{
    // Static classes make syntax concise. Their members must also be static.
    public static class StringHandler
    {
        /// <summary>
        /// Adds spaces to a provided source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        //An extension method has "this" in it's parameters. 
        //In this case, it's extending the string class
        public static string InsertSpaces(this string source)
        {
            string result = string.Empty;

            if (!String.IsNullOrWhiteSpace(source))
            {
                foreach(char letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter;
                }
                result = result.Trim();
            }

            return result;
        }
    }
}

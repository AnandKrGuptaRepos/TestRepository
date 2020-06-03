using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public static class MethodUpperLower
    {
        public static string UpperLower(this string strName)
        {
            if (strName.Length > 0)
            {
                char[] charArr = strName.ToCharArray();
                charArr[0] = char.IsUpper(charArr[0]) ? char.ToLower(charArr[0]) : char.ToUpper(charArr[0]);
                return new string(charArr);
                //return charArr.ToString();
            }
            return strName;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethod
{
   public static class MethodUpperLower
    {
        public static string UpperLower(this string strName)
        {
            if (strName.Length > 0)
            {
               char[] charArr= strName.ToCharArray();
                charArr[0] = char.IsUpper(charArr[0]) ? char.ToLower(charArr[0]) : char.ToUpper(charArr[0]);
                return new string(charArr);
                //return charArr.ToString();
            }
            return strName;
        }

    }
}

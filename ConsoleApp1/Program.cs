using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "anand";
            // string result = ExtensionMethod.MethodUpperLower.UpperLower(str);
            string result = str.UpperLower();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}

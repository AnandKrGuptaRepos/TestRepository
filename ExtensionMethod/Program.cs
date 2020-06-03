using System;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Anand";
            //string result = MethodUpperLower.UpperLower(str);
            string result = str.UpperLower();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}

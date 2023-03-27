using _24_3_Proj;
using System;

namespace _24_3_Proj
{
    internal class MainClass : AccessSpecifiers
    {
        static void Main(string[] args)
        {
            //MainClass specifiers = new MainClass(); ;
            AccessSpecifiers specifiers = new AccessSpecifiers();
            specifiers.Display("Hello there!");
            Console.WriteLine(specifiers.name);
        }
    }
}

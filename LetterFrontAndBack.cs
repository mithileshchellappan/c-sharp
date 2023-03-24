using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_3_Proj
{
    public class LetterFrontAndBack
    {
            static void Main(string[] args)
            {
                string str =Console.ReadLine();
            if (str.Length <= 1)
            {
                Console.WriteLine("Need more than 1 character");
                return;
            }
                Console.WriteLine("Original string: " + str);

                char lastChar = str[str.Length - 1];
                string newStr = lastChar + str + lastChar;

                Console.WriteLine("New string: " + newStr);
            }
    }
}



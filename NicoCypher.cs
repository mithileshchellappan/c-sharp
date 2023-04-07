using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_3_Proj
{
    internal class Program
    {
        //private static void Main(string[] args)
        //{
           
        //    string message = "mubashirhassan";
            
        //    string key = "crazy";

        //    NicoCypher nc = new NicoCypher(message, key);
        //    string encoded = nc.Encode();

        //    Console.WriteLine("Encoded message: " + encoded);
        //}
    }

    internal class NicoCypher
    {
        private readonly string message;
        private readonly List<int> key;

        public NicoCypher(string message, string key)
        {
            this.message = message;
            this.key = FindNumFromKey(key);
        }

        public string Encode()
        {
            List<string> splitStr = new List<string>();

            for (int i = 0; i < this.message.Length; i += 5)
            {
                string substring = this.message.Substring(i, Math.Min(5, this.message.Length - i));
                splitStr.Add(substring);
            }

            StringBuilder encodedMes = new StringBuilder();
            foreach (string str in splitStr)
            {
                for (int i = 0; i < this.key.Count; i++)
                {
                    int index = this.key[i];
                    if (index < str.Length)
                    {
                        encodedMes.Append(str[index]);
                    }
                    else
                    {
                        encodedMes.Append(" ");
                    }
                }
            }
            return encodedMes.ToString();
        }

        private List<int> FindNumFromKey(string key)
        {
            List<char> sortedKey = key.OrderBy(c => c).ToList();
            List<int> cypherKey = new List<int>();
            foreach (var item in sortedKey)
            {
                cypherKey.Add(key.IndexOf(item));
            }

            return cypherKey;
        }
    }
}

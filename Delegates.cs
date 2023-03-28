using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_3_Proj
{
    internal class Delegates
    {


        public delegate int DelegateForSum(int a, int b);
        public delegate T DelegateForGeneric<T>(T a, T b);
        public delegate T DelegateNoParams<T>();
        public static void Main(string[] args)
        {
            DelegateForSum delegateForSum = Sum;
            delegateForSum += Diff;

            //generic delegates
            DelegateForGeneric<int> dt = GenericTryFun1;
            DelegateForGeneric<string> dt1 = GenericTryFun2;

            //anonymus functions
            DelegateForGeneric<int> anonymusDelegate = new(delegate (int a, int b) { return a + b; });

            DelegateForGeneric<string> anonymusDelegate1 = new(delegate (string a, string b) { return a + b; });

            DelegateNoParams<string> anonymusDelegate2 = new(delegate () { return "none"; });


            foreach (DelegateForSum d in delegateForSum.GetInvocationList())
            {
                Console.WriteLine(d.Invoke(3, 4));
            }



        }



        public static void delegateInvoking(string name, int a, int b, DelegateForSum func)
        {
            //call back
            Console.WriteLine(name + " " + func(a, b));
        }


        private static int Diff(int a, int b)
        {
            return a - b;
        }
        private static int Sum(int a, int b)
        {
            return a + b;
        }

        private static int GenericTryFun1(int a, int b) { return a / b; }

        private static string GenericTryFun2(string a, string b) { return a + " " + b; }
    
}
}

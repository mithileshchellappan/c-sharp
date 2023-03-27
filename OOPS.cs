namespace OOPS
{
    internal class Program
    {
        enum days { Monday, Tuesday, Wednesday }
        static void Main(string[] args)
        {
            OverLoading("Mithilesh","PC",days.Tuesday);
            OverLoading("Mithilesh",33);

            

        }

        private static void OverLoading(string name,string lastName,days Day)
        {
            Console.WriteLine(typeof(days));
            Console.WriteLine();
        }

        private  static  void OverLoading(string name, int id)
        {
            Console.WriteLine("Hi" + name);
            Console.WriteLine("Your ID is:" + id);
        }
    }
}
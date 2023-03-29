using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_3_Proj
{
    internal class Lamda
    {

    
        class Student
        {
            public string Name { get; set; }
            public string Department { get; set; }

            public int Age { get; set; }

            public int Id { get; set; }

            public Student(string name, string department, int age, int id)
            {
                Name = name; Department = department; Age = age; Id = id;
            }

            public override string ToString()
            {
                return $"{Name} {Age} {Department} {Id} ";
            }


        }


        class Comparator : IComparer<int[]>
        {

            public int Compare(int[]? x, int[]? y)
            {
                if (x[0] == y[0])
                {
                    if (x[1] < y[1]) return -1;

                    if (x[1] == y[1]) return 0;

                    return 1;
                }

                else if (x[0] < y[0])
                {
                    return -1;
                }

                return 1;
            }
        }
        internal class LambdaExpressionsTry
        {
            delegate T GenericDelegate<T>(T a, T b);

            public static void FunctionAcceptingLambda(Func<int, bool> callback)
            {
                Console.WriteLine(callback(2));
            }
            public static void Main(string[] args)
            {
                GenericDelegate<int> lambaAdd = (num1, num2) => num1 + num2;
                Console.WriteLine(lambaAdd(2, 3));

                //lambda multicast
                var lambdaWODelegate = (int num1, int num2) => num1 + num2;

                lambdaWODelegate += (int num1, int num2) => num1 - num2;
                Console.WriteLine(lambdaWODelegate(2, 3));




                foreach (var i in lambdaWODelegate.GetInvocationList())
                {
                    Console.WriteLine(i.Method);
                    Console.WriteLine(i.DynamicInvoke(3, 4));
                }

                //lambda use cases

                List<int> someList = new() { 19, 5, 3, 2, 35, 10, 34, 60 };
                var square = (int num1) => num1 * num1;

                foreach (int i in someList)
                    Console.WriteLine(square(i));

                Console.WriteLine(someList.Aggregate((int num1, int num2) => num1 + num2));

                Console.WriteLine(someList.All((int a) => a > 10));

                //add all elements divisble by 5 in new list
                List<int> divisbleBy5 = someList.FindAll(a => a % 5 == 0);

                foreach (int i in divisbleBy5)
                    Console.Write(i + " ");
                Console.WriteLine();

                List<int> sortedlist = someList.OrderBy(a => a).ToList();

                Dictionary<int, int[]> myDict = new Dictionary<int, int[]>() {
                { 1,new int[]{ 2,6} },
                { 2 ,new int[]{ 2,4}},
                { 3,new int[]{ 3,2}},
                { 4,new int[]{ 3,1}},

            };

                foreach (var keyValue in myDict.OrderBy(x => -x.Value[0]).ThenBy(x => -x.Value[1]))
                {
                    Console.Write(keyValue.Key + " ");
                    foreach (int i in keyValue.Value) Console.Write(i + " ");
                    Console.WriteLine();
                }


                int[,] matrix = {
                { 2,3},
                {2,4 },
                { 3,3},
                {3,2 }
            };

                //lambda on custom data types
                List<Student> studentsList = new(){new Student("hello","CSE",24,101),
                new Student("helloOne", "IT", 22, 102),
                new Student("helloTwo", "EEE", 23, 103),
             new Student("helloThree", "ECE", 27, 105),
                new Student("helloFour", "EEE", 23, 107),
             new Student("helloFive", "CSE", 22, 109),
                new Student("helloSix", "CIVIL", 23, 1022),
             new Student("helloSeven", "ECE", 21, 1024),
                new Student("helloEight", "EEE", 25, 1032)};

                studentsList.Sort((s1, s2) => s1.Id.CompareTo(s2.Id));

                studentsList.ForEach(student => student.Id -= 10);

                foreach (Student student in studentsList.FindAll(student => student.Department.Equals("ECE") && student.Age < 25))
                {
                    Console.WriteLine(student);
                }

                //passing lambda to a function 

                Func<int, bool> callBackLambda = (int x) => x > 10;
                //first int corresponds to parameter and bool corresponds to the return type
                FunctionAcceptingLambda(callBackLambda);



            }


        }
    }
}


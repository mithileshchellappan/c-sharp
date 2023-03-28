using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_3_Proj
{
    internal class List
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
                return $"{Name} AGE:{Age} DEPT:{Department} ID:{Id} ";
            }


        }
        public static void Main(string[] args)
            {
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
            }
    }
}

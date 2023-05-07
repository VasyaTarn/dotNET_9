using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("LastName1", "Name1", "Surname1", "Street1", 11, 22, "City1", "+380111111111", "1.1.2011", 50, false));
            students.Add(new Student("LastName2", "Name4", "Surname2", "Street2", 22, 33, "City2", "+380222222222", "2.2.2022", 20, false));
            students.Add(new Student("LastName3", "Name2", "Surname3", "Street3", 33, 44, "City3", "+380333333333", "3.3.2033", 80, true));
            Student stud4 = new Student("LastName4", "Name3", "Surname4", "Street4", 44, 55, "City4", "+380444444444", "4.4.2044", 70, true);
            Group grp = new Group(students, "Grp1", "Spec1", 123);
            grp.PrintInfo();
            grp.AddStud(stud4);
            Console.WriteLine();

            //var s1 = new Student("LastName1", "Name1", "Surname1", "Street1", 11, 22, "City1", "+380111111111", "1.1.2011", 50, false);
            //var s2 = new Student("LastName2", "Name4", "Surname2", "Street2", 22, 33, "City2", "+380222222222", "2.2.2022", 20, false);
            //var s3 = new Student("LastName3", "Name2", "Surname3", "Street3", 33, 44, "City3", "+380333333333", "3.3.2033", 80, true);

            Console.WriteLine("Sort:");
            students.Sort();
            for (int i = 0; i < students.Count; i++)
            {
                students[i].PrintStudentInfo();
            }

            Console.WriteLine();

            foreach (Student item in grp)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine();

            grp.Sort(students, delegate (Student o1, Student o2)
            {
                Student left = o1 as Student;
                Student right = o2 as Student;
                return ((Student)o1).CompareTo(((Student)o2)) > 0;
            });
            Console.WriteLine("Sort(delegate): ");
            foreach (Student item in grp)
            {
                Console.WriteLine(item.AvrgGrade);
            }
            //SortedDictionary<Student, string> students = new SortedDictionary<Student, string>();

            //students.Add(new Student("LastName1", "Name1", "Surname1", "Street1", 11, 22, "City1", "+380111111111", "1.1.2011", 50, false), "01");
            //students.Add(new Student("LastName2", "Name4", "Surname2", "Street2", 22, 33, "City2", "+380222222222", "2.2.2022", 20, false), "02");
            //students.Add(new Student("LastName3", "Name2", "Surname3", "Street3", 33, 44, "City3", "+380333333333", "3.3.2033", 80, true), "03");

            //foreach (var item in students)
            //{
            //    Console.WriteLine($"Key:{item.Key.Name} | Value:{item.Value}");
            //}
        }
    }
}

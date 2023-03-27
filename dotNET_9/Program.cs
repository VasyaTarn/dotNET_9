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
            students.Add(new Student("LastName1", "Name1", "Surname1", "Street1", 11, 22, "City1", "+380111111111", "1.1.2011", 40, false));
            students.Add(new Student("LastName2", "Name2", "Surname2", "Street2", 22, 33, "City2", "+380222222222", "2.2.2022", 50, false));
            students.Add(new Student("LastName3", "Name3", "Surname3", "Street3", 33, 44, "City3", "+380333333333", "3.3.2033", 60, true));
            Student stud4 = new Student("LastName4", "Name4", "Surname4", "Street4", 44, 55, "City4", "+380444444444", "4.4.2044", 70, true);
            Group grp = new Group(students, "Grp1", "Spec1", 123);
            grp.PrintInfo();
            grp.AddStud(stud4);
            Console.WriteLine();
            grp.PrintInfo();
            grp.RemoveStud(students[0]);
            Console.WriteLine();
            grp.PrintInfo();
            grp.KickNotPasssed();
            Console.WriteLine();
            grp.PrintInfo();
            grp.KickWorst();
            Console.WriteLine();
            grp.PrintInfo();
        }
    }
}

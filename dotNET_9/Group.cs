using System;
using System.Collections.Generic;
using System.Linq;

namespace dotNET_9
{
    class Group
    {
        private List<Student> studs;
        private string name;
        private string specialization;
        private int courseNumber;

        public Group()
        {
            int len = new Random().Next(1, 10);
            studs = new List<Student>();

            for(int i = 0; i < len; i++)
            {
                studs.Add(new Student());
            }

            name = "RandomGroupName";
            specialization = "RandomSpecialization";
            courseNumber = 777;
        }

        public Group(List<Student> studs, string name, string specialization, int courseNumber)
        {
            if(studs.Count == 0)
            {
                throw new Exception("The list of students must be greater than zero");
            }
            else
            {
                this.studs = studs;
            }

            this.name = name;
            this.specialization = specialization;
            this.courseNumber = courseNumber;
        }

        public Group(Group grp)
        {
            if (grp.studs.Count == 0)
            {
                throw new Exception("The list of students must be greater than zero");
            }
            else
            {
                studs = grp.studs;
            }

            name = grp.name;
            specialization = grp.specialization;
            courseNumber = grp.courseNumber;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Group name:{name}");
            Console.WriteLine($"Group specialization:{specialization}");
            Console.WriteLine($"Group course number:{courseNumber}");

            List<Student> sortStuds = studs.OrderBy(student => student.Name).ToList();

            for(int i = 0; i < sortStuds.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {sortStuds[i].Name} - {sortStuds[i].getDateOfBirth()}");
            }
        }

        public void AddStud(Student stud)
        {
            if(stud.Name == null || stud.Name == "")
            {
                throw new Exception("Invalid name");
            }
            
            studs.Add(stud);
        }

        public void RemoveStud(Student stud)
        {
            if(studs.IndexOf(stud) == -1)
            {
                throw new Exception("Student not found");
            }

            studs.Remove(stud);
        }

        public void KickNotPasssed()
        {
            for(int i = 0; i < studs.Count(); i++)
            {
                if(!studs[i].getIsPassed())
                {
                    studs.RemoveAt(i);
                }
            }
        }

        public void KickWorst()
        {
            if(studs.Count() == 0)
            {
                throw new Exception("Student list is empty");
            }

            Student wStud = studs[0];

            for(int i = 0; i < studs.Count(); i++)
            {
                if(studs[i].AvrgGrade < wStud.AvrgGrade)
                {
                    wStud = studs[i];
                }
            }

            studs.Remove(wStud);
        }

        public static bool operator !=(Group grp1, Group grp2)
        {
            return grp1.studs.Count != grp2.studs.Count;
        }

        public static bool operator ==(Group grp1, Group grp2)
        {
            return grp1.studs.Count == grp2.studs.Count;
        }
    }
}
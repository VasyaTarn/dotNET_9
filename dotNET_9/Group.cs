using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace dotNET_9
{

    class StudentEnumerator : IEnumerator
    {
        public List<Student> studs;

        int position = -1;

        public StudentEnumerator(List<Student> list)
        {
            studs = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < studs.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return studs[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    class Group : IEnumerable
    {
        private List<Student> studs;
        private string name;
        private string specialization;
        private int courseNumber;

        public delegate bool Comparer(Student obj1, Student obj2);

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
                Console.WriteLine($"{i + 1}. {sortStuds[i].Name}({sortStuds[i].AvrgGrade}) - {sortStuds[i].GetDateOfBirth()}");
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
                if(!studs[i].GetIsPassed())
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

        public Student this[int index]
        {
            get
            {
                if (index >= 0 && index < studs.Count)
                    return studs[index];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < studs.Count)
                    studs[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(studs);
        }

        public void Sort(List<Student> stud, Comparer rate)
        {
            for (int i = 0; i < stud.Count; i++)
            {
                for (int j = i + 1; j < stud.Count; j++)
                {
                    if (rate(stud[j], stud[i]))
                    {
                        Student temp = stud[i];
                        stud[i] = stud[j];
                        stud[j] = temp;
                    }
                }
            }
        }
    }
}
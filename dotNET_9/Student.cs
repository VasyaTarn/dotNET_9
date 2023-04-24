using System;
using System.Collections;
using System.Collections.Generic;

namespace dotNET_9
{

    class Student : Person, IComparable<Student>
    {
        private string lastName;
        private string name;
        private string surname;
        private Address address;
        private string phoneN;
        private DateTime dateOfBirth;
        private int avrgGrade;
        private bool isPassed;

        public Student()
        {
            Random rand = new Random();

            this.lastName = "RandomLastName";
            this.name = "RandomName";
            this.surname = "RandomSurname";
            this.dateOfBirth = new DateTime(2000, 1, 1);
            this.address = new Address("RandStreet", 1, 1, "RandCity");
            this.phoneN = "+380777777777";
            this.avrgGrade = rand.Next(1, 100);
            this.isPassed = rand.Next(0, 2) == 1 ? true : false;

        }

        public Student(string lName, string name, string surname, string steet, int house, int apart, string city, string phone, string dateOfBirth, int avrgGrade, bool isPassed)
        {
            this.lastName = lName;
            this.name = name;
            this.surname = surname;
            this.address = new Address(steet, house, apart, city);
            this.phoneN = phone;
            try
            {
                this.dateOfBirth = DateTime.Parse(dateOfBirth);
            }
            catch (FormatException)
            {
                this.dateOfBirth = new DateTime(2000, 1, 1);
                Console.WriteLine("!!!Wrong date!!!");
            }
            this.avrgGrade = avrgGrade;
            this.isPassed = isPassed;
        }

        public string LName
        {
            get
            {
                return lastName;
            }

            set
            {
                if (LName == "")
                    throw new Exception("Value is empty");
                lastName = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (name == "")
                    throw new Exception("Value is empty");
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                if (surname == "")
                    throw new Exception("Value is empty");
                surname = value;
            }
        }

        public void SetDateOfBirth(int day, int month, int year)
        {
            dateOfBirth = new DateTime(year, month, day);
        }

        public void SetAddress(string steet, int house, int apart, string city)
        {
            address = new Address(steet, house, apart, city);
        }

        public string GetDateOfBirth()
        {
            return dateOfBirth.ToShortDateString();
        }

        public void GetAddress()
        {
            address.PrintAddressInfo();
        }

        public string PhoneN
        {
            get
            {
                return phoneN;
            }

            set
            {
                phoneN = value;
            }
        }

        public int AvrgGrade
        {
            get
            {
                return avrgGrade;
            }

            set
            {
                if (avrgGrade < 0 || avrgGrade > 100)
                    throw new Exception("Incorrect value");
                avrgGrade = value;
            }
        }

        public void SetIsPassed(bool isPassed)
        {
            this.isPassed = isPassed;
        }

        public bool GetIsPassed()
        {
            return isPassed;
        }

        public static bool operator !=(Student std1, Student std2)
        {
            return std1.avrgGrade != std2.avrgGrade;
        }

        public static bool operator ==(Student std1, Student std2)
        {
            return std1.avrgGrade == std2.avrgGrade;
        }

        public void PrintStudentInfo()
        {
            //Console.WriteLine($"Last name:{LName}");
            Console.WriteLine($"{Name}({AvrgGrade})");
            //Console.WriteLine($"Surname:{Surname}");
            //Console.WriteLine($"Date of birth:{GetDateOfBirth()}");
            //PrintPersonInfo();
            //GetAddress();
            //Console.WriteLine($"Phone number:{PhoneN}");
        }

        public int CompareTo(Student s)
        {
            if (s is null) throw new ArgumentException("Incorrect parameter value");
            return AvrgGrade - s.AvrgGrade;
        }

    }
}
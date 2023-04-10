using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_9
{
    class Person
    {
        private int age;
        private int height;
        private int weight;
        private string eyeColor;

        private string[] colors = {"Black", "Red", "Yellow", "Green", "Blue"};

        public Person()
        {
            Random rand = new Random();

            this.age = rand.Next(18, 25);
            this.height = rand.Next(160, 200);
            this.weight = rand.Next(50, 120);
            this.eyeColor = colors[rand.Next(0, colors.Length)];
        }

        public int Age
        {
            get; set;
        }
        public int Height
        {
            get; set;
        }
        public int Weight
        {
            get; set;
        }
        public string EyeColor
        {
            get; set;
        }

        public void PrintPersonInfo()
        {
            Console.WriteLine($"Age:{age}");
            Console.WriteLine($"Height:{height}");
            Console.WriteLine($"Weight:{weight}");
            Console.WriteLine($"Eye color:{eyeColor}");
        }
    }
}


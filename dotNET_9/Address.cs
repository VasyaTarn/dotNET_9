using System;

namespace dotNET_9
{
    class Address
    {
        private string street;
        private int house;
        private int apartment;
        private string city;

        public Address()
            : this("", 0, 0, "")
        { }


        public Address(string street, int house, int apartment, string city)
        {
            this.street = street;
            this.house = house;
            this.apartment = apartment;
            this.city = city;
        }

        public void PrintAddressInfo()
        {
            Console.WriteLine($"Street:{street}");
            Console.WriteLine($"House:{house}");
            Console.WriteLine($"Apartment:{apartment}");
            Console.WriteLine($"City:{city}");
        }
    }
}
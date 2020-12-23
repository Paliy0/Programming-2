using System;

namespace assignment2
{
    struct Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string City;
        public GenderType Gender;
    }
    public enum GenderType { m = 1, f }
}
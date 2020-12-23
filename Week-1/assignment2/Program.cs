using System;

namespace assignment2
{
    class Program
    {
        static void Main(string[] args) 
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            int MaxNrOfPeople = 3;

            Person[] people = new Person[MaxNrOfPeople];
            for (int i = 0; i < MaxNrOfPeople; i++)
            {
                people[i] = ReadPerson();
                Console.WriteLine("\n");    
            }
            for (int i = 0; i < MaxNrOfPeople; i++)
            {
                PrintPerson(people[i]);
            }
        }

        Person ReadPerson()
        {
            Person person1;
            person1.FirstName = ReadString("Enter first name: ");
            person1.LastName = ReadString("Enter last name: ");
            person1.Gender = ReadGender("Enter gender (m/f): ");
            person1.Age = ReadInt("Enter age: ");
            person1.City = ReadString("Enter city: ");
            return person1;

        }
        string ReadString(string question)
        {
            Console.Write(question);

            question = Console.ReadLine();

            return question;
        }

        int ReadInt(string question)
        {
            Console.Write(question);

            question = Console.ReadLine();

            return int.Parse(question);
        }

        void PrintPerson(Person p)
        {
            Console.Write("{0} {1}", p.FirstName, p.LastName);
            PrintGender(p.Gender);

            Console.WriteLine("{0} years old, {1}", p.Age, p.City);
            Console.WriteLine("\n");
        }

        GenderType ReadGender(string question)
        {
            Console.Write(question);
            question = Console.ReadLine();

            if (question == "m")
            {
                GenderType Gender = GenderType.m;
                return Gender;
            }
            else
            {
                GenderType Gender = GenderType.f;
                return Gender;
            }
        }
        void PrintGender(GenderType Gender)
        {
            Console.WriteLine(" ({0})", Gender);
        }
    }
}

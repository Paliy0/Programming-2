using System;
using System.IO;


namespace assignment1
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
            Console.Write("Enter your name: ");
            string filename = Console.ReadLine();

            if (File.Exists(filename))
            {
                Console.WriteLine("Nice to see you again, {0}!", filename);
                Console.WriteLine("We have the following information about you:");
                Person person1 = ReadPerson(filename);
                DisplayPerson(person1);
            }
            else
            {
                Console.WriteLine("Welcome! {0}", filename);
                WritePerson(ReadPerson(), filename);
            }
        }

        Person ReadPerson()
        {
            Person person1 = new Person();
            Console.Write("Enter your name: ");
            person1.name = Console.ReadLine();
            Console.Write("Enter your city: ");
            person1.city = Console.ReadLine();
            Console.Write("Enter your age: ");
            person1.age = int.Parse(Console.ReadLine());

            return person1;
        }

        void DisplayPerson(Person p)
        {
            Console.WriteLine("Name     : {0}", p.name);
            Console.WriteLine("City     : {0}", p.city);
            Console.WriteLine("Age      : {0}", p.age);
        }

        void WritePerson(Person p, string filename)
        {
            StreamWriter writer = new StreamWriter(filename);

            writer.WriteLine(p.name);
            writer.WriteLine(p.city);
            writer.WriteLine(p.age);

            writer.Close();
            Console.WriteLine("Your data is written to file.");
        }

        Person ReadPerson(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            Person person1 = new Person();

            while (!reader.EndOfStream)
            {
                person1.name = reader.ReadLine();
                person1.city = reader.ReadLine();
                person1.age = int.Parse(reader.ReadLine());
            }
            reader.Close();
            return person1;
        }
    }
}

using System;

namespace assignment0
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
            int value = ReadInt("Enter a value: ");
            Console.WriteLine("You entered {0}.", value);

            int age = ReadInt("How old are you? ", 0, 120);
            Console.WriteLine("You are {0} years old.", age);

            string name = ReadString("What is your name? ");
            Console.WriteLine("Nice meeting you {0}.", name);
        }

        int ReadInt(string question)
        {
            Console.Write("Enter a value: ");
            question = Console.ReadLine();

            return int.Parse(question);
        }

        int ReadInt(string question, int min, int max)
        {
            Console.Write("How old are you? ");
            question = Console.ReadLine();

            while (int.Parse(question) < min || int.Parse(question) > max)
            {
                Console.Write("How old are you? ");
                question = Console.ReadLine();
            }
            return int.Parse(question);
        }
        string ReadString(string question)
        {
            Console.Write("What is your name? ");
            question = Console.ReadLine();

            return question;
        }
    }
}

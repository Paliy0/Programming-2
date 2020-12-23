using System;

namespace MyTools
{
    public class ReadTools
    {
        public static int ReadInt(string question)
        {
            Console.Write("Enter a value: ");
            question = Console.ReadLine();

            return int.Parse(question);
        }

        public static int ReadInt(string question, int min, int max)
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
        public static string ReadString(string question)
        {
            Console.Write("What is your name? ");
            question = Console.ReadLine();

            return question;
        }
    }
}

using System;

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
            Console.Write("Enter a message: ");
            string message = Console.ReadLine().ToLower();

            Console.Write("Enter the secret key: ");
            string key = Console.ReadLine().ToLower();

            string encryptedMessage = ReplaceText(message, key, CreateSubstitutionAlphabet(key, message));

            Console.WriteLine(encryptedMessage);
        }

        string CreateSubstitutionAlphabet(string key, string standardAlphabet)
        {
            string alphabetTemp = key + standardAlphabet;
            string substitutionAlphabet = "";

            foreach(char c in alphabetTemp)
            {
                if (!substitutionAlphabet.Contains(c))
                {
                    substitutionAlphabet += c;
                }
            }
            return substitutionAlphabet;
        }

        string ReplaceText(string input, string standardAlphabet, string substitutionAlphabet)
        {
            string output = "";
            int index;

            foreach(char c in input)
            {
                index = standardAlphabet.IndexOf(c);

                if (!standardAlphabet.Contains(c))
                {
                    output += c;
                }
                else
                {
                    output += substitutionAlphabet[index];
                }
            }
            return output;
        }
    }
}

using System;
using System.IO;


namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[2-3] <filename>");
                return;
            }
            string filename = args[0];
            Program myProgram = new Program();
            myProgram.Start(filename);
        }
        void Start(string filename)
        {
            Console.Write("Enter a word (to search): ");
            string word = Console.ReadLine();

            int NrOfLines = SearchWordInFile(filename, word);
            Console.WriteLine("Number of lines containing the word: {0}", NrOfLines);
        }

        bool WordInLine(string line, string word)
        {
            if (line.ToUpper().Contains(word.ToUpper()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int SearchWordInFile(string filename, string word)
        {
            StreamReader reader = new StreamReader(filename);
            
            int counter = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (WordInLine(line, word))
                {
                    counter++;
                    DisplayWordInLine(line, word);
                }
            }
            reader.Close();
            return counter;
        }

        void DisplayWordInLine(string line, string word)
        {
            int index = line.ToLower().IndexOf(word);

            Console.Write(line.Substring(0, index));

            string target = line.Substring(index, word.Length);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[{0}]", target);
            Console.ResetColor();

            Console.Write(line.Substring(index + word.Length));
        }
    }
}

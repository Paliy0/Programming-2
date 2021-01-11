using System;
using System.Collections.Generic;
using System.IO;

namespace assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[3-4] <filename>");
                return;
            }
            string filename = args[0];
            Program myProgram = new Program();
            myProgram.Start(filename);
        }
        void Start(string filename)
        {

        }

        Dictionary<string, string> ReadWords(string filename)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();

            StreamReader reader = new StreamReader(filename);

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                Dict.Add(line.Split(";"));
            }
            reader.Close();
            return Dict;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace assignment3
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
            List<StateResult> stateResults = ReadStateResults("2020-votes.csv");
            DisplayStateResults(stateResults);

            ReadStateElectors("2020-electors.csv");
        }

        List<StateResult> ReadStateResults(string filename)
        {
            List<StateResult> stateResults = new List<StateResult>();
            string line = "";

            if (!File.Exists(filename))
                return stateResults;

            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                StateResult result = new StateResult();
                line = reader.ReadLine();

                string[] words = line.Split(';');

                result.StateName = words[0];
                result.CandidateName = words[1];
                result.PartyName = words[2];
                result.CandidateVotes = int.Parse(words[3]);

            }
            reader.Close();
            return stateResults;    
        }

        List<StateElectors> ReadStateElectors(string filename)
        {
            List<StateElectors> stateElectors = new List<StateElectors>();
            string line = "";

            if (!File.Exists(filename))
                return stateElectors;

            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                StateElectors elector = new StateElectors();
                line = reader.ReadLine();

                string[] words = line.Split(';');

                elector.StateName = words[0];
                elector.ElectorsCount = int.Parse(words[1]);

            }
            reader.Close();
            return stateElectors;
        }

        void DisplayStateResults(List<StateResult> results)
        {
            int count = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("State results");
            Console.ResetColor();


            foreach (StateResult result in results)
            {
                count++;
                Console.WriteLine($"{result.StateName}: {result.CandidateName} ({result.PartyName}), {result.CandidateVotes} votes");
            }
        }

    }
}

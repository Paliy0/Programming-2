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
            string filename = "TK2021-results.csv";
            List<string> parties = ReadPoliticalParties(filename);
            List<CityResult> cityResult = ReadCityResults(filename, parties.Count);

            Console.WriteLine("number of political parties: {0}", parties.Count);
            Console.WriteLine("number of city results: {0}", cityResult.Count);
        }

        List<string> ReadPoliticalParties(string filename)
        {
            List<string> parties = new List<string>();
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found");
            }
            else
            {
                StreamReader reader = new StreamReader(filename);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    parties.Add(line.Split(';')[2]);
                    break;
                }
                reader.Close();
            }
            return parties;
        }

        List<CityResult> ReadCityResults(string filename, int nrOfPoliticalParties)
        {
            int[] PartyVotes = new int[nrOfPoliticalParties];
            List<CityResult> cityResults = new List<CityResult>();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found");
            }
            else
            {
                StreamReader reader = new StreamReader(filename);
                while (!reader.EndOfStream)
                {
                    CityResult result = new CityResult();

                    string line = reader.ReadLine();
                    result.CityName = line.Split(';')[0];
                    result.TotalVotes = int.Parse(line.Split(';')[1]);

                    int index = 0;
                    for (int i = 2; i < line.Length; i++)
                    {
                        PartyVotes[index] = int.Parse(line.Split(';')[i]);
                        index++;
                    }
                    result.PartyVotes = PartyVotes;
                    cityResults.Add(result);
                }
                reader.Close();
            }
            return cityResults;
        }

        List<PoliticalPartyResult> GetPartyResults(List<string> politicalParties, List<CityResult> cityResults)
        {
            List<PoliticalPartyResult> politicalPartyResults = new List<PoliticalPartyResult>();

            foreach (string s in politicalParties)
            {

                PoliticalPartyResult result = new PoliticalPartyResult();
                result.Name = s;
                politicalPartyResults.Add(result);
            }

            foreach (CityResult r in cityResults)
            {
                for (int i = 0; i < r.PartyVotes.Length; i++)
                {
                    politicalPartyResults[i].TotalVotes += r.PartyVotes[i];
                }
            }
            return politicalPartyResults;

        }
    }
}

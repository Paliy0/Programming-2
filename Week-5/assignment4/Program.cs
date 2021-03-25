using System;
using System.Collections.Generic;
using System.IO;
using MyTools;

namespace assignment4
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
            List<string> words = ReadWords(filename, 5);

            string lingoWord = SelectWord(words);

            LingoGame lingoGame = new LingoGame();

            lingoGame.Init(lingoWord);

            //PlayLingo(lingoGame);

            if (PlayLingo(lingoGame))
            {
                Console.WriteLine("You have guessed the word!");
            }
            else
            {
                Console.WriteLine("Too bad, you did not guess the word ({0})", lingoWord);
            }
        }

        List<string> ReadWords(string filename, int wordLength)
        {
            List<string> words = new List<string>();

            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line.Length == wordLength)
                    {
                        words.Add(line);
                    }
                }
                reader.Close();
            }
            return words;
        }

        string SelectWord(List<string> words)
        {
            Random rnd = new Random();

            int index = rnd.Next(words.Count);

            return words[index];
        }

        bool PlayLingo(LingoGame lingoGame)
        {
            int attemptsLeft = 5;

            int wordLength = lingoGame.lingoWord.Length;

            while (attemptsLeft > 0 && !lingoGame.WordGuessed())
            {
                string playerWord = ReadPlayerWord(wordLength);
                LingoGame.LetterState[] letterResults = lingoGame.ProcessWord(playerWord);
                DisplayPlayerWord(playerWord, letterResults);

                attemptsLeft--;
            }
            return lingoGame.WordGuessed();
        }

        string ReadPlayerWord(int length)
        {
            string word;
            int count = 1;
            do
            {
                Console.Write("Enter a (5-letter) word, attempt {0}: ", count);
                word = Console.ReadLine().ToUpper();
                count++;
            }
            while (word.Length != length);

            return word;
        }

        void DisplayPlayerWord(string playerWord, LingoGame.LetterState[] letterResults)
        {
            for (int i = 0; i < playerWord.Length; i++)
            {
                if (letterResults[i] == LingoGame.LetterState.Correct)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                else if(letterResults[i] == LingoGame.LetterState.WrongPosition)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                Console.Write(playerWord[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace assignment2
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
            HangmanGame hangman = new HangmanGame();

            hangman.secretWord = SelectWord(ListOfWords(filename));
            //Console.WriteLine(hangman.secretWord);

            hangman.Init(hangman.secretWord);

            if (PlayHangman(hangman) == true)
            {
                Console.WriteLine(hangman.guessedWord);
                Console.WriteLine("You guessed the word!");
            }
            else
            {
                Console.WriteLine(hangman.guessedWord);
                Console.WriteLine("Too bad, you did not guess the word ({0})", hangman.secretWord);
            }
        }

        List<string> ListOfWords(string filename)
        {
            List<string> words = new List<string>();

            StreamReader reader = new StreamReader(filename);

            while (!reader.EndOfStream)
            {
                words.Add(reader.ReadLine());

            }
            reader.Close();

            return words;
        }

        string SelectWord(List<string> words)
        {
            Random rnd = new Random();
            string selectedWord;

            do
            {
                int index = rnd.Next(words.Count);
                selectedWord = words[index];

            } while (selectedWord.Length <= 3);

            return selectedWord;
        }

        bool PlayHangman(HangmanGame hangman)
        {
            List<char> enteredLetters = new List<char>();
            int attempts = 8;

            do
            {
                DisplayWord(hangman.guessedWord);

                Console.WriteLine();

                char letter = ReadLetter(enteredLetters);
                enteredLetters.Add(letter);

                if (!hangman.ProcessLetter(letter))
                {
                    attempts--;
                }


                DisplayLetters(enteredLetters);
                Console.WriteLine("Attempts left: {0}", attempts);

                Console.WriteLine();

            } while (attempts != 0 && !hangman.IsGuessed());

            if (hangman.IsGuessed()) return true;

            return false;
        }

        void DisplayWord(string word)
        {
            foreach (char c in word)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }

        void DisplayLetters(List<char> letters)
        {
            Console.Write("Entered letters: ");
            DisplayWord(new string(letters.ToArray()));
        }
        char ReadLetter(List<char> blacklistLetters)
        {
            char newLetter;

            do
            {
                Console.Write("Enter a letter: ");
                newLetter = Console.ReadLine()[0];

            } while (blacklistLetters.Contains(newLetter));

            return newLetter;
        }
    }

    class HangmanGame
    {
        public string secretWord;
        public string guessedWord;

        public void Init(string secretWord)
        {
            guessedWord = "";
            for (int i = 0; i < secretWord.Length; i++)
            {
                guessedWord += ".";
            }
        }

        public bool ContainsLetter(char letter)
        {
            return secretWord.IndexOf(letter) != -1;
        }

        public bool ProcessLetter(char letter)
        {
            if (!ContainsLetter(letter)) return false;

            int index = -1;
            char[] chars = guessedWord.ToCharArray();

            while (true)
            {
                index = secretWord.IndexOf(letter, index + 1);
                if (index == -1) break;

                chars[index] = letter;
            }
            guessedWord = new string(chars);
            return true;
        }

        public bool IsGuessed()
        {
            return guessedWord == secretWord;
        }
    }
}
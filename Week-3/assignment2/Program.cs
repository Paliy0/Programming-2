using System;
using System.Collections.Generic;

namespace assignment2
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
            HangmanGame hangman = new HangmanGame();

            hangman.secretWord = SelectWord(ListOfWords());

            hangman.Init(hangman.secretWord);

            Console.WriteLine("The secret word is: " + hangman.secretWord);
            Console.WriteLine("The guessed word is: " + hangman.guessedWord);

            PlayHangman(hangman);
        }

        List<string> ListOfWords()
        {
            List<string> words = new List<string>();

            words.Add("airplane");
            words.Add("kitchen");
            words.Add("building");
            words.Add("incredible");
            words.Add("funny");
            words.Add("trainstation");
            words.Add("neighbour");
            words.Add("different");
            words.Add("department");
            words.Add("planet");
            words.Add("presentation");
            words.Add("embarrassment");
            words.Add("integration"); 
            words.Add("scenario");
            words.Add("discount");
            words.Add("management");
            words.Add("understanding");
            words.Add("registration");
            words.Add("security");
            words.Add("language");

            return words;
        }

        string SelectWord(List<string> words)
        {
            Random rnd = new Random();

            int index = rnd.Next(words.Count);
            string selectedWord = words[index];


            return selectedWord;
        }

        bool PlayHangman(HangmanGame hangman)
        {
            List<char> enteredLetters = new List<char>();

            enteredLetters.Add('a');
            enteredLetters.Add('b');

            DisplayWord(hangman.guessedWord);
            DisplayLetters(enteredLetters);

            return true;
        }

        void DisplayWord(string word)
        {
            string temp = "";
            foreach (char c in word)
            {
                temp += c + " ";
            }
            Console.WriteLine(temp);
        }

        void DisplayLetters(List<char> letters)
        {
            Console.Write("Entered letters: ");
            foreach (char c in letters)
            {
                Console.Write(c + " ");
            }
        }
        char ReadLetter(List<char> blacklistLetters)
        {
            char newLetter;

            do
            {
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
            foreach (char c in secretWord)
            {
                guessedWord += ".";
            }
        }
    }
}

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
            hangman.Init("backdoor");
            Console.WriteLine("The secret word is: " + hangman.secretWord);
            Console.WriteLine("The guessed word is: " + hangman.guessedWord);

            SelectWord(ListOfWords());

            
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
                guessedWord += ". ";
            }
        }
    }
}

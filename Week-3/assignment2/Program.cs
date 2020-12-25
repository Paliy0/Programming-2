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
            Console.WriteLine(hangman.secretWord);

            hangman.Init(hangman.secretWord);

            if (PlayHangman(hangman) == true)
            {
                Console.WriteLine("You guessed the word!");
            }
            else
            {
                Console.WriteLine("Too bad, you did not guess the word ({0})", hangman.secretWord);
            }
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
            int attempts = 8;

            do
            {
                DisplayWord(hangman.guessedWord);

                hangman.ProcessLetter(ReadLetter(enteredLetters));

                DisplayLetters(enteredLetters);

                attempts--;
                Console.WriteLine("Attempts left: {0}", attempts);

            } while (attempts != 0 && hangman.IsGuessed() != true);

            return true;
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
            foreach (char c in secretWord)
            {
                guessedWord += ".";
            }
        }

        public bool ContainsLetter(char letter)
        {
            bool contains = false;

            if (secretWord.Contains(letter))
            {
                contains = true;
            }
            return contains;
        }
        
        public bool ProcessLetter(char letter)
        {
            int index = secretWord.IndexOf(letter);

            if (index == -1) return false;

            char[] chars = guessedWord.ToCharArray();  

            do
            {
                chars[index] = letter;

                index = secretWord.IndexOf(letter, index + 1);


            } while (index != -1);
            guessedWord = new string(chars);
            return true;
        }

        public bool IsGuessed()
        {
            if (guessedWord == secretWord)
            {
                return true;
            }
            return false;
        }
    }
}

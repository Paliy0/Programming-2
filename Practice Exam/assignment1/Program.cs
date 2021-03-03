using System;
using System.Collections.Generic;

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
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();

            string newSentence = ShuffleWords(sentence);

            Console.WriteLine("The new sentence is: {0}", newSentence);
        }

        string ShuffleWords(string sentence)
        {
            string[] words = sentence.Split(' ');

            string newSentence = "";

            for (int i = 0; i < words.Length; i++)
            {
                string shuffledWord = ShuffledWord(words[i]);
                newSentence += shuffledWord + " ";
            }

            return newSentence;
        }

        string ShuffledWord(string word)
        {
            if (word.Length <= 3) return word;

            string newWord = word[0].ToString();
            string remainingWord = word.Substring(1, word.Length - 2);

            Random rnd = new Random();

            while (remainingWord.Length > 0)
            {
                int index = rnd.Next(remainingWord.Length);
                newWord += remainingWord[index];
                remainingWord = remainingWord.Remove(index, 1);
            }

            newWord = newWord + word[word.Length - 1];
            return newWord;
        }
    }
}

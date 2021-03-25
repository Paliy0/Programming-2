using System;
using System.Collections.Generic;
using System.Text;

namespace assignment4
{
    public class LingoGame
    {
        public enum LetterState { Correct, Incorrect, WrongPosition}

        public string lingoWord;
        public string playerWord;

        public void Init(string lingoWord)
        {
            this.lingoWord = lingoWord;
            this.playerWord = "";
        }

        public bool WordGuessed()
        {
            return lingoWord == playerWord;
        }

        public LetterState[] ProcessWord(string playerWord)
        {
            this.playerWord = playerWord;
            LetterState[] letterResults = new LetterState[lingoWord.Length];

            List<char> refLetters = new List<char>();
            for (int i = 0; i < lingoWord.Length; i++)
            {
                if (lingoWord[i] != playerWord[i])
                {
                    refLetters.Add(lingoWord[i]);
                }
            }
            for (int i = 0; i < playerWord.Length; i++)
            {
                if (lingoWord[i] == playerWord[i])
                {
                    letterResults[i] = LetterState.Correct;
                }
                else if(refLetters.Contains(playerWord[i]))
                {
                    letterResults[i] = LetterState.WrongPosition;
                }
                else
                {
                    letterResults[i] = LetterState.Incorrect;
                }
            }
            return letterResults;
        }


    }
}

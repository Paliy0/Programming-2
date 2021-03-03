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
            int NrOfRows = 5;
            int NrOfColumns = 5;

            int[,] bingoCard = new int[NrOfRows, NrOfColumns];

            FillBingoCard(bingoCard);

        }

        void FillBingoColumn(int[,] bingoCard, int column, int minNumber, int maxNumber)
        {
            Random rnd = new Random();
            int rNumber = 0;

            for (int i = 0; i < bingoCard.GetLength(0); i++)
            {
                rNumber = rnd.Next(minNumber, maxNumber);

                do
                {
                    rNumber = rnd.Next(minNumber, maxNumber);
                    bingoCard[0, column] = rNumber;

                } while (rNumber != bingoCard[bingoCard.GetLength(1), column - 1]);
            }
        }

        void FillBingoCard (int[,] bingoCard)
        {
            int min = 1;
            int max = 15;

            for (int i = 0; i < bingoCard.GetLength(0); i++)
            {
                min += 15;
                max += 15;

                FillBingoColumn(bingoCard, i, min, max);
            }
            bingoCard[bingoCard.GetLength(0) / 2, bingoCard.GetLength(1) / 2] = 0; 
        }

        void DisplayBingoCard(int[,] bingoCard)
        {
            string[] letters = { "B", "I", "N", "G", "O" };

            for (int row = 0; row < bingoCard.GetLength(0); row++)
            {
                Console.Write(letters[row]);

                for (int col = 0; col < bingoCard.GetLength(1); col++)
                {
                    Console.Write("{0:00}", bingoCard[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

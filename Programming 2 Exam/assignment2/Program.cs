using System;

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
            int nrOfRows = 6;
            int nrOfColumns = 10;
            int[,] matrix = new int[nrOfRows, nrOfColumns];

            FillMatrix(matrix);
            DisplayMatrix(matrix);
            ProcessMatrix(matrix);
            DisplayMatrix(matrix);

        }

        void FillMatrix(int[,] matrix)
        {
            Random rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(0, 99);
                }
            }
        }

        void DisplayMatrix(int[,] matrix)
        {
            int colorCode;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    colorCode = matrix[i, j] / 20;

                    if (colorCode < 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (colorCode > 1 && colorCode < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if(colorCode > 2 && colorCode < 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(matrix[i, j].ToString("D2") + " ");
                    Console.ResetColor();
                }
            }
        }

        void HighestDown(int[,] matrix, int column)
        {
            int highest = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > highest)
                    {
                        highest = matrix[i, j];
                        column = j;
                    }
                }
            }
            matrix[matrix.GetLength(0), column] = highest;
        }

        void ProcessMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    HighestDown(matrix, i);
                    LowestUp(matrix, i);
                }
            }
        }

        void LowestUp(int[,] matrix, int column)
        {
            int lowest = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < lowest)
                    {
                        lowest = matrix[i, j];
                        column = j;
                    }
                }
            }
            matrix[matrix.GetLength(0), column] = lowest;
        }
    }
}

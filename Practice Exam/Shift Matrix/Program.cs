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
            int[,] matrix = new int[5, 10];
            FillMatrix(matrix);
            DisplayMatrix(matrix);
            

            Console.Write("Enter a number to search for: ");
            int searchNumber = int.Parse(Console.ReadLine());

            ShiftMatrix(matrix, searchNumber);
            DisplayMatrix(matrix);
        }

        void FillMatrix (int[,] matrix)
        {
            Random rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i,j] = rnd.Next(0, 100);
                }
            }
        }

        void DisplayMatrix (int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j].ToString("D2") + " ");
                }
            }
        }

        void ShiftMatrix(int[,] matrix, int number)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == number)
                    {
                        ShiftRow(matrix, i, j);
                        break;
                    }
                }
            }
        }

        void ShiftRow(int[,] matrix, int row, int column)
        {
            int[] temp = new int[matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(1); i++) // * * * * * * * * * *
            {
                temp[i] = matrix[row, column];
                column++;
            }
        }
    }
}

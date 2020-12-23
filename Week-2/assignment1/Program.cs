using System;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[1-3] <nrOfRows> <nrOfColumns>");
                return;
            }
            int nrOfRows = int.Parse(args[0]);
            int nrOfColumns = int.Parse(args[1]);

            Program myProgram = new Program();
            myProgram.Start(nrOfRows, nrOfColumns);
        }
        void Start(int nrOfRows, int nrOfColumns)
        {
            int[,] matrix = new int[nrOfRows, nrOfColumns];

            InitMatrix2D(matrix);

            DisplayMatrix(matrix);

            InitMatrixLinear(matrix);

            DisplayMatrixWithCross(matrix);
        }


        void InitMatrix2D(int[,] matrix)
        {
            int number = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = number;
                    number++;
                }
            }
        }

        void DisplayMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write("\n");

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(String.Format("{0,3}", matrix[row, col]) + " ");
                }
            }
            Console.Write("\n");
        }

        void InitMatrixLinear(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            for (int i = 0; i < row * col; i++)
            {
                matrix[i / col, i % col] = i + 1;
            }
        }

        void DisplayMatrixWithCross(int[,] matrix)
        {
            int middleNum = matrix[matrix.GetLength(0) / 2, matrix.GetLength(1) / 2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write("\n");

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col && row == matrix.GetLength(1) - col - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(String.Format("{0,3}", matrix[row, col]) + " ");
                        Console.ResetColor();
                    }
                    else if (row == matrix.GetLength(1) - col - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(String.Format("{0,3}", matrix[row, col]) + " ");
                        Console.ResetColor();
                    }
                    else if (row == col)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(String.Format("{0,3}", matrix[row, col]) + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(String.Format("{0,3}", matrix[row, col]) + " ");
                    }
                    
                }
            }
        }
    }
}

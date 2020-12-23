using System;

namespace assignment2
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

            InitMatrixRandom(matrix, 1, 100);

            DisplayMatrix(matrix);

            Console.Write("Enter a number (to search for): ");
            int searchVal = int.Parse(Console.ReadLine());

            Position positionF = SearchNumber(matrix, searchVal);
            Console.WriteLine("Number {0} is found (first) at position [{1},{2}]", searchVal, positionF.row, positionF.column);

            Position positionL = SearchNumberBackwards(matrix, searchVal);
            Console.WriteLine("Number {0} is found (last) at position [{1},{2}]", searchVal, positionL.row, positionL.column);
            Console.WriteLine("Test");
        }

        void InitMatrixRandom(int[,] matrix, int min, int max)
        {
            Random rnd = new Random();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rnd.Next(min, max);
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
                    Console.Write("{0,3}", matrix[row, col] + " ");
                }
            }
            Console.Write("\n");
        }

        class Position
        {
            public int row;
            public int column;
        }

        Position SearchNumber(int[,] matrix, int number)
        {
            Position position = new Position();
            bool found = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == number && !found)
                    {
                        position.row = row;
                        position.column = col;
                        found = true;
                    }
                }
            }
            return position;
        }

        Position SearchNumberBackwards(int[,] matrix, int number)
        {
            Position position = new Position();
            bool found = false;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    if (matrix[row, col] == number && !found)
                    {
                        position.row = row;
                        position.column = col;

                        found = true;
                    }
                }
            }
            return position;
        }

    }
}

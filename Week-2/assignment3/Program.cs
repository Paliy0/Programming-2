using System;

namespace assignment3
{
    class Program
    {
        public enum RegularCandies { JellyBean = 1, Lozenge, LemonDrop, GumSquare, LollipopHead, JujubeCluster }
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
            RegularCandies[,] playingField = new RegularCandies[nrOfRows, nrOfColumns];

            InitCandies(playingField);

            DisplayCandies(playingField);

            if (ScoreRowPresent(playingField) == true)
            {
                Console.WriteLine("row score");
            }
            else
            {
                Console.WriteLine("no row score");
            }

            if (ScoreColumnPresent(playingField) == true)
            {
                Console.WriteLine("column score");
            }
            else
            {
                Console.WriteLine("no column score");
            }
        }

        void InitCandies(RegularCandies[,] playingField)
        {
            Random rnd = new Random();

            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    playingField[row, col] = (RegularCandies)rnd.Next(1, 7);
                }
            }
        }

        void DisplayCandies(RegularCandies[,] playingField)
        {
            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                Console.Write("\n");

                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    if (playingField[row, col] == RegularCandies.JellyBean)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (playingField[row, col] == RegularCandies.Lozenge)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        
                    }
                    else if (playingField[row, col] == RegularCandies.LemonDrop)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (playingField[row, col] == RegularCandies.GumSquare)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (playingField[row, col] == RegularCandies.LollipopHead)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (playingField[row, col] == RegularCandies.JujubeCluster)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;;
                    }
                    Console.Write(String.Format("#", playingField[row, col]) + " ");
                    Console.ResetColor();
                }
            }
            Console.Write("\n");
        }
        bool ScoreRowPresent(RegularCandies[,] playingField)
        {
            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                RegularCandies candy = playingField[row, 0];
                int counter = 1;

                for (int col = 1; col < playingField.GetLength(1); col++)
                {
                    if (playingField[row, col] == candy)
                    {
                        counter++;

                        if (counter >= 3)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        candy = playingField[row, col];
                        counter = 1;
                        
                    }
                }
            }
            return false;
        }
        bool ScoreColumnPresent(RegularCandies[,] playingField)
        {

            for (int col = 0; col < playingField.GetLength(1); col++)
            {

                RegularCandies candy = playingField[0, col];
                int counter = 1;

                for (int row = 1; row < playingField.GetLength(0); row++)
                {
                    if (playingField[row, col] == candy)
                    {
                        counter++;

                        if (counter >= 3)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        counter = 1;
                        candy = playingField[row, col];
                    }
                }
            }
            return false;
        }
    }
}

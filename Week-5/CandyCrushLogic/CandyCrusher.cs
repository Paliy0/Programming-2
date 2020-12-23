using System;

namespace CandyCrusher
{
    public class CandyCrushLogic
    {
        public static bool ScoreRowPresent(RegularCandies[,] playingField)
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
        public static bool ScoreColumnPresent(RegularCandies[,] playingField)
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
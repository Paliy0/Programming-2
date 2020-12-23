using System;

namespace assignment3
{
    class YahtzeeGame
    {
        Dice[] dices = new Dice[5];

        public void Init()
        {
            for (int i = 0; i < dices.Length; i++)
            {
                dices[i] = new Dice();
            }
        }

        public void Throw()
        {
            foreach (Dice dice in dices)
            {
               dice.Throw();
            }
        }
        public void DisplayValues()
        {
            int counter = 0;

            foreach (Dice dice in dices)
            {
                dice.DisplayValue();

                counter++;
                if (counter % 5 == 0)
                {
                    Console.WriteLine(" ");
                }
            }
        }

        public bool Yahtzee()
        {
            bool sameVal = false;

            for (int i = 0; i < dices.Length - 1; i++)
            {
                if(dices[i].value == dices[i + 1].value)
                {
                    sameVal = true;
                }
                else
                {
                    sameVal = false;
                    break;
                }
            }
            return sameVal;
        }

    }

}
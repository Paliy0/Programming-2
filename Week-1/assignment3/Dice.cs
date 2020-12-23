using System;

namespace assignment3
{
    class Dice
    {
        public int value; 
        static Random rnd = new Random();

        public void Throw()
        {
            value = rnd.Next(1, 7);

            /*
            for (int i = 0; i < 10; i++)
            {
                value = rnd.Next(1, 7);
                dice += value;
                dice += " ";
            }
            */
        }

        public void DisplayValue()
        {
            Console.Write(value + " ");
        }
    }
}

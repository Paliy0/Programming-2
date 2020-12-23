using System;

namespace assignment1
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
            PrintMonths();

            PrintMonth(ReadMonth("Enter a month number: "));
        }

        void PrintMonth(Month month)
        {
            int num = (int)month;
            Console.WriteLine("{0} => {1}", num, month);
        }

        void PrintMonths()
        {
            for(Month m = Month.January; m <= Month.December; m++)
            {
                int num = (int)m;
                Console.WriteLine("{0}. {1}", num, m);
            }
            Console.Write("\n");
        }

        Month ReadMonth(string question)
        {
            Console.Write("Enter a month number: ");
            question = Console.ReadLine();
            Month monthNum = (Month)int.Parse(question);

            while (!Enum.IsDefined(typeof(Month), monthNum))
            {
                Console.WriteLine("{0} is not a valid value.", monthNum);
                Console.Write("Enter a month number: ");
                question = Console.ReadLine();
                monthNum = (Month)int.Parse(question);
            }
            return monthNum;

        }

    }
}

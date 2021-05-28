using System;
using System.Collections.Generic;

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
            Console.Write("Enter ISBN number: ");
            string ibsn = Console.ReadLine();

            //ISBNValidation isbnVal = ValidateISBN(ibsn);

            switch (ValidateISBN(ibsn))
            {
                case ISBNValidation.InvalidIBSN:
                    Console.WriteLine("Invalid ISBN number!");
                    break;

                case ISBNValidation.ValidIBSN:
                    Console.WriteLine("Valid ISBN number!");
                    break;
            }

        }

        ISBNValidation ValidateISBN(string isbn)
        {
            if (isbn.Length == 13)
            {
                if(IsValidISBN13(isbn)) return ISBNValidation.ValidIBSN;
            }
            return ISBNValidation.InvalidIBSN;
        }

        bool IsValidISBN13(string isbn)
        {
            isbn = isbn.Replace("-", "");
            if (isbn.Length != 13) return false;

            int sum = 0;
            int digit = 0;

            foreach(char c in isbn)
            {
                digit = isbn[c] – '0';

                try
                {
                    if (digit % 2 == 0)
                    {
                        sum += digit * 3;
                    }
                    else
                    {
                        sum += digit;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }  
            }

            if (sum % 10 == 0) return true;
            return false;
        }
    }
}

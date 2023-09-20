using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesTableTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome, what is your name? ");
            string name = Console.ReadLine();

            PlayAgain:
            Console.Write($"Hi {name}, please enter a times table from 1-12 to be tested on! ");
            int table = InputTable();

            int score = TimesTable(table);
            Console.Write($"You got {score}/10! ");

            switch (score)
            {
                case 0:
                    Console.WriteLine("You need more practice.");
                    break;

                case 10:
                    Console.WriteLine("Excellent!");
                    break;

                default:
                    Console.WriteLine("Pretty good.");
                    break;
            }

            Console.Write("Do you want to play again? ");
            string answer;
            
            do
            {
                answer = Console.ReadLine().ToLower();
            } while (!PlayAgainValid(answer));

            if (answer == "yes")
            {
                goto PlayAgain;
            }

            Console.Write("Thank you for playing!");
            Console.Read();

        }

        static bool PlayAgainValid(string answer)
        {
            bool valid = false;

            if ((answer == "yes") || (answer == "no"))
            {
                valid = true;
            }
            else
            {
                Console.Write ("Enter yes or no. ");
            }

            return valid;
        }

        static int InputTable()
        {
            int table = 0;

            bool FirstPass = true;

            do
            {

                if (!FirstPass) { Console.Write("Invalid. Please enter an integer from 1-12: "); } FirstPass = false;

                try
                {
                    table = int.Parse(Console.ReadLine());
                } catch{}


            } while ( !((table >= 1) && (table <= 12)) );
            return table;
        }

        static int TimesTable(int table)
        {
            int score = 0;
            int userAnswer = 0;
            
            for (int question = 1; question <= 10; question++)
            {
                Random random = new Random();
                int randomNum = random.Next(1,12 +1);
                int product = randomNum * table;

                bool valid = false;
                bool FirstPass = true;
                do
                {
                    SkipWriteOnFirstPass(FirstPass, "Enter a number.\n");
                    FirstPass = false;
                    

                    Console.Write($"What is {table} * {randomNum}? ");

                    try 
                    { 
                        userAnswer = int.Parse(Console.ReadLine());
                        valid = true;
                    } 
                    catch {}
                
                } while (!valid);

                if (userAnswer == product)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else 
                {
                    Console.WriteLine($"Wrong, it was {product}!");
                }
            }
            return score;
        }

        //misc
        static void SkipWriteOnFirstPass(bool FirstPass, string text)
        {
            if (!FirstPass)
            {
                Console.Write ($"{text}");
            }
            else
            {
                FirstPass = false;
            }

        }

    }
}

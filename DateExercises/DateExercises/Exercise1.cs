using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateExercises
{
    class Exercise1
    {
        public void CheckConsecutive()
        {
            Console.WriteLine("Enter a few numbers separated by a hyphen");

            string numbers = Console.ReadLine();
            string[] separatedNumbers = numbers.Split('-');

            var firstCheck = 0;
            var secondCheck = 0;

            for (int i=1; i<separatedNumbers.Length; i++)
            {
                if (!(Convert.ToInt32(separatedNumbers[i]) >= Convert.ToInt32(separatedNumbers[i - 1])))
                {
                    firstCheck = 1;
                    break;
                }
                else if (i == separatedNumbers.Length - 1)
                    Console.WriteLine("Consecutive");
            }

            for (int i = 1; i < separatedNumbers.Length; i++)
            {
                if (!(Convert.ToInt32(separatedNumbers[i]) <= Convert.ToInt32(separatedNumbers[i - 1])))
                {
                    secondCheck = 1;
                    break;
                }
                else if (i == separatedNumbers.Length - 1)
                    Console.WriteLine("Consecutive");
            }
            
            if (firstCheck + secondCheck == 2)
                Console.WriteLine("Not consecutive!");
        }

    }
}

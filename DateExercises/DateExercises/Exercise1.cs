using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DateExercises
{
    class Exercise1
    {
        public bool Compare(string[] separatedNumbers, int i, string opr)
        {
            var number = Convert.ToInt32(separatedNumbers[i]);
            var previousNumber = Convert.ToInt32(separatedNumbers[i - 1]);

            var comparison = $"{number} {opr} {previousNumber}";

            var DataTable = new DataTable();

            return Convert.ToBoolean(DataTable.Compute(comparison, ""));
        }

        public void GrowingAndDecreasing(string[] separatedNumbers)
        {
            var checkGrowing = 0;
            var checkDecreasing = 0;

            for (int i = 1; i < separatedNumbers.Length; i++)
            {
                bool isGrowing = Compare(separatedNumbers, i, ">");
                if (isGrowing)
                {
                    checkGrowing++;
                }

                bool isDecreasing = Compare(separatedNumbers, i, "<");
                if (isDecreasing)
                {
                    checkDecreasing++;
                }
            }

            if(checkGrowing == separatedNumbers.Length - 1)
                Console.WriteLine("Ascending numbers");
            else if(checkDecreasing == separatedNumbers.Length - 1)
                Console.WriteLine("Descending numbers.");
            else if (checkGrowing>=1 || checkDecreasing>=1)
                Console.WriteLine("Random numbers.");
            else
                Console.WriteLine("Numbers are equal.");
        }
        public void CheckConsecutive()
        {
            Console.WriteLine("Enter a few numbers separated by a hyphen");

            string numbers = Console.ReadLine();
            string[] separatedNumbers = numbers.Split('-');

            GrowingAndDecreasing(separatedNumbers);

            Console.WriteLine("Press any key!");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

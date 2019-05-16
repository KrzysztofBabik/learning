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

        public bool compare(string[] separatedNumbers, int i, string opr)
        {
            int number = Convert.ToInt32(separatedNumbers[i]);
            int previousNumber = Convert.ToInt32(separatedNumbers[i - 1]);

            string comparison = $"{number} {opr} {previousNumber}";
            

            DataTable dt = new DataTable();
            var comparisionResult = Convert.ToBoolean(dt.Compute(comparison, ""));

            return comparisionResult;
        }

        public byte GrowingAndDecreasing(string[] separatedNumbers)
        {

            byte check = 0;

            for (int i = 1; i < separatedNumbers.Length; i++)
            {
                bool greaterThanResult = compare(separatedNumbers, i, ">");
                if (!greaterThanResult)
                {
                    check++;
                    break;
                }
                else if (i == separatedNumbers.Length - 1)
                    Console.WriteLine("Numbers are equal.");
            }

            //for (int i = 1; i < separatedNumbers.Length; i++)
            //{
            //    if (!(Convert.ToInt32(separatedNumbers[i]) > Convert.ToInt32(separatedNumbers[i - 1])))
            //    {
            //        check++;
            //        break;
            //    }
            //    else if (i == separatedNumbers.Length - 1)
            //        Console.WriteLine("Ascending numbers");
            //}

            //for (int i = 1; i < separatedNumbers.Length; i++)
            //{
            //    if (!(Convert.ToInt32(separatedNumbers[i]) < Convert.ToInt32(separatedNumbers[i - 1])))
            //    {
            //        check++;
            //        break;
            //    }
            //    else if (i == separatedNumbers.Length - 1)
            //        Console.WriteLine("Descending numbers.");
            //}

            //for (int i = 1; i < separatedNumbers.Length; i++)
            //{
            //    if (!(Convert.ToInt32(separatedNumbers[i]) == Convert.ToInt32(separatedNumbers[i - 1])))
            //    {
            //        check++;
            //        break;
            //    }
            //    else if (i == separatedNumbers.Length - 1)
            //        Console.WriteLine("Numbers are equal.");
            //}



            return check;
        }
        public void CheckConsecutive()
        {
            Console.WriteLine("Enter a few numbers separated by a hyphen");

            string numbers = Console.ReadLine();
            string[] separatedNumbers = numbers.Split('-');

            if (GrowingAndDecreasing(separatedNumbers) == 3)
                Console.WriteLine("Random numbers!");

            Console.WriteLine("Press any key!");
            Console.ReadKey();
            Console.Clear();
        }

    }
}

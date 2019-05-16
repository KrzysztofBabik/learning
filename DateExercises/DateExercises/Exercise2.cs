using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateExercises
{
    class Exercise2
    {
        public void DuplicateOrNot(string[] separatedNumbers)
        {
            for (var i = 0; i < separatedNumbers.Length; i++)
                for (var j = 0; j < separatedNumbers.Length; j++)
                {
                    if (separatedNumbers[i] == separatedNumbers[j] && i != j)
                        Console.WriteLine("Duplicate!"); break;  
                }
        }
        public void CheckDuplicate()
        {
            Console.WriteLine("Enter a few numbers separated by a hyphen");

            string numbers = Console.ReadLine();

            if (!string.IsNullOrEmpty(numbers))
            {
                string[] separatedNumbers = numbers.Split('-');
                DuplicateOrNot(separatedNumbers);
            }
            else
                Console.WriteLine("String is empty!");

            Console.WriteLine("Press any key!");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

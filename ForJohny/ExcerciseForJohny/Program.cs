using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcerciseForJohny
{
    class Program
    {
        public string[] CorrectnessOfDate(string word)
        {
            Console.WriteLine("Enter a date of {0} (DD-MM-YYYY):", word);
            var date = Console.ReadLine();
            string[] dateArray = date.Split('-');

            int check = 0;

            if (dateArray.Length == 3)
                check++;
            else
            {
                Console.Clear();
                Console.WriteLine("A Date is invalid! Try again.");
                CorrectnessOfDate(word);
            }

            if (Convert.ToInt32(dateArray[0]) <= 31) check++;
            if (Convert.ToInt32(dateArray[1]) <= 12) check++;

            if (check != 3)
            {
                Console.Clear();
                Console.WriteLine("A Date is invalid! Try again.");
                CorrectnessOfDate(word);
            }
            return dateArray;
        }
        public void DateRange()
        {
            string[] start = CorrectnessOfDate("start");
            string[] end = CorrectnessOfDate("end");

            int dayStart = Convert.ToInt32(start[0]);
            int monthStart = Convert.ToInt32(start[1]);
            int yearStart = Convert.ToInt32(start[2]);
            int dayEnd = Convert.ToInt32(end[0]);
            int monthEnd = Convert.ToInt32(end[1]);
            int yearEnd = Convert.ToInt32(end[2]);

            Console.Clear();
            Console.WriteLine("The date of start: {0}.{1}.{2}", dayStart, monthStart, yearStart);
            Console.WriteLine("The date of end: {0}.{1}.{2}", dayEnd, monthEnd, yearEnd);

            Console.WriteLine("Data range:");

            if (dayStart == dayEnd && monthStart == monthEnd && yearStart == yearEnd)
                Console.WriteLine("There is only one day");
            else if (yearStart < yearEnd)
                Console.WriteLine("{0}.{1}.{2} - {3}.{4}.{5}", dayStart, monthStart, yearStart, dayEnd, monthEnd, yearEnd);
            else if (monthStart < monthEnd)
                Console.WriteLine("{0}.{1} - {2}.{3}.{4}", dayStart, monthStart, dayEnd, monthEnd, yearStart);
            else if (dayStart < dayEnd)
                Console.WriteLine("{0} - {1}.{2}.{3}", dayStart, dayEnd, monthStart, yearStart);
            else
                Console.WriteLine("the end date can not be before the start date.");
        }
        static void Main(string[] args)
        {
            var program = new Program();
            program.DateRange();

            Console.ReadKey();
        }
    }
}

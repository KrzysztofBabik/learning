using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DateExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //var Exercise1 = new Exercise1();
            //var Exercise2 = new Exercise2();

            //Exercise1.CheckConsecutive();
            //Exercise2.CheckDuplicate();

            DataTable dt = new DataTable();
            var v = dt.Compute("3 + 4", "");
            Console.WriteLine(v);
            Console.ReadKey();
        }
    }
}

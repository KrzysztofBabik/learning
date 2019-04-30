using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var stopwatchControl = new StopwatchControl();

            stopwatchControl.StopwatchResults();

            Console.ReadKey();
        }
    }
}

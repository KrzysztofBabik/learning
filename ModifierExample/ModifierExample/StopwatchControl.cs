using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch
{
    class StopwatchControl
    {
        public TimeSpan StopwatchControll()
        {
            var stopwatch = new StopwatchStartStop();

            var start = stopwatch.Start();
            var stop = stopwatch.Stop();

            var interval = stop - start;

            Console.WriteLine("The duration between start and stop is: {0}", interval);
            return interval;
        }

        public void StopwatchResults()
        {
            var results = new List<TimeSpan>();
            var test = 'y';

            while (test != 'n')
            {
                var result = StopwatchControll();
                results.Add(result);

                Console.WriteLine("Do you want to use Stopwatch again? y/n");
                test = Convert.ToChar(Console.ReadLine());

                Console.Clear();
            }

            foreach(var result in results)
                Console.WriteLine("{0} result: {1}", results.IndexOf(result)+1, result);
        }
    }
}

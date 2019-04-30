using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch
{
    class StopwatchStartStop
    {
        public DateTime Start()
        {
            Console.WriteLine("Press any key to start the stopwatch.");
            Console.ReadKey();
            var StartTime = DateTime.Now;
            return StartTime;
        }

        public DateTime Stop()
        {
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
            var StopTime = DateTime.Now;
            return StopTime;
        }
    }
}

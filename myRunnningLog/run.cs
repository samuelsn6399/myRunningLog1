using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myRunnningLog
{
    public class run
    {
        public double Distance { get; }
        public  TimeSpan Time { get; }
        public  DateTime Date { get; }

        public run(double distance, TimeSpan time)
        {
            Distance = distance;
            Time = time;
            Date = DateTime.Today;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycomWeeklyManager
{
    public class Event
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string HourStart { get; set; }
        public string HourEnd { get; set; }
        public bool Recurrent { get; set; }
    }
}

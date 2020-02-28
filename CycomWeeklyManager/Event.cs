using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycomWeeklyManager
{
    public class Event
    {
        public string Organizer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string HourStart { get; set; }
        public string MinStart { get; set; }
        public string HourEnd { get; set; }
        public string MinEnd { get; set; }
        public bool Recurrent { get; set; }
        public string Room { get; set; }
        public string ManagerName { get; set; }
        public string ManagerTel { get; set; }
        public string ManagerSchool { get; set; }
        public string TutorName { get; internal set; }
        public string TutorTel { get; internal set; }
        public string TutorSchool { get; internal set; }
    }
}

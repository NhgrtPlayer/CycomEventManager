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
        public string Room { get; set; }
        public string Stuff { get; internal set; }
        public string ManagerName { get; set; }
        public string ManagerTel { get; set; }
        public string ManagerSchool { get; set; }
        public string TutorName { get; internal set; }
        public string TutorTel { get; internal set; }
        public string TutorSchool { get; internal set; }
        public string StudentsNB { get; internal set; }
        public string MembersNB { get; internal set; }
        public string ExternsNB { get; internal set; }

        public Event()
        {
            this.Organizer = "";
            this.Name = "";
            this.Description = "";
            this.Date = "";
            this.HourStart = "";
            this.MinStart = "";
            this.HourEnd = "";
            this.MinEnd = "";
            this.Room = "";
            this.Stuff = "";
            this.ManagerName = "";
            this.ManagerTel = "";
            this.ManagerSchool = "";
            this.TutorName = "";
            this.TutorTel = "";
            this.TutorSchool = "";
            this.StudentsNB = "";
            this.MembersNB = "";
            this.ExternsNB = "";
        }
    }
}

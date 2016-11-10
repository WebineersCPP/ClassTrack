using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class CourseScheduleItem 
    {
        public int Id { get; set; }

        public int Section { get; set; }
        public int Units { get; set; }
        public int ClassNumber { get; set; }
        public string Instructor { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Time { get; set; }

        public string Days { get; set; }
        public string Room { get; set; }

        public string Title { get; set; }
        public string Number { get; set; }



    }
}

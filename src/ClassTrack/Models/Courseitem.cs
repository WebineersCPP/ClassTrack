using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class CourseItem : Item
    {
        public override int Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public int Units { get; set; }
        public short HighlightColor { get; set; }
        public ICollection<CourseScheduleItem> CourseScheduleItems { get; set; }

        

    }
}

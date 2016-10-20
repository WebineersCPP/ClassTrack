using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class CurriculumSheet
    {
        public int Id { get; set; }
        public DateTime Year { get; set; }
        public String Major { get; set; }
        public String Subplan { get; set; }
        public int MinUnitsReq { get; set; }

        public ICollection<Module> Modules { get; set; }
    }
}

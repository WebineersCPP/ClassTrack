using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class CPPMajor
    {
        public int Id { get; set; }
        public String Title { get; set; }

        public ICollection<CPPSubplan> Subplans { get; set; }
    }
}

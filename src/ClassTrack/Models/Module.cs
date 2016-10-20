using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class Module
    {
        public int Id { get; set; }
        public bool IsSubmodule { get; set; }
        public String Title { get; set; }
        public int Units { get; set; }
        public String Description { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}

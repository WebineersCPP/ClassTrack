using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class InfoItem : Item
    {
        public override int Id { get; set; }
        public string Text { get; set; }
    }
}

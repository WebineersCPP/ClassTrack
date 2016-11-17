using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ClassTrack.Models
{
    public class ClassTrackUser : IdentityUser
    {
        public ICollection<CurriculumSheet> CurriculumSheets { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}

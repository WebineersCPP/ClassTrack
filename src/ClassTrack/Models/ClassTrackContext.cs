using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class ClassTrackContext : DbContext
    {
        private IConfigurationRoot _config;

        public ClassTrackContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }
        
        public DbSet<CurriculumSheet> CurriculumSheets { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<CourseItem> Courses { get; set; }
        public DbSet<InfoItem> InfoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:ClassTrackContextConnection"]);
        }
    }
}

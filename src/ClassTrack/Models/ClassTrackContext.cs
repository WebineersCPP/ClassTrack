using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class ClassTrackContext : IdentityDbContext<ClassTrackUser>
    {
        private IConfigurationRoot _config;

        public ClassTrackContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }
        
        public DbSet<CurriculumSheet> CurriculumSheets { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CourseScheduleItem> CourseScheduleItems { get; set; }

        public DbSet<CPPMajor> CPPMajors { get; set; }
        public DbSet<CPPMajor> CPPSubplans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:ClassTrackContextConnection"]);
        }
    }
}

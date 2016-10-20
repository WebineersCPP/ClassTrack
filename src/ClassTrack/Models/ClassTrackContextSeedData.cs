using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class ClassTrackContextSeedData
    {
        private ClassTrackContext _context;

        public ClassTrackContextSeedData(ClassTrackContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if (!_context.Courses.Any())
            {
                var cs130 = new CourseItem()
                {
                    Title = "Discrete Structures",
                    Number = "CS130",
                    Units = 4,
                    HighlightColor = (short)Enums.Enums.HighlightColor.None
                };
                _context.Courses.Add(cs130);

                var cs140 = new CourseItem()
                {
                    Title = "Introduction to Computer Science",
                    Number = "CS140",
                    Units = 4,
                    HighlightColor = (short)Enums.Enums.HighlightColor.None
                };
                _context.Courses.Add(cs140);
            }
            await _context.SaveChangesAsync();  // push changes into database
        }

    }
}

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
            if (!_context.CurriculumSheets.Any())
            {
                CurriculumSheet cs = new CurriculumSheet()
                {
                    Year = 2012,
                    Major = "Computer Science",
                    MinUnitsReq = 180,
                    Modules = new List<Module>()
                    {
                        new Module() { Title = "Required Core Courses for Major",
                                       Units = 62,
                                       Items = new List<Item>()
                                       {
                                           new CourseItem() { Title = "Discrete Structures", Number = "CS130", Units = 4 },
                                           new CourseItem() { Title = "Introduction to Computer Science", Number = "CS140", Units = 4 },
                                           new CourseItem() { Title = "Introduction to Programming and Problem-Solving", Number = "CS141", Units = 4 },
                                           new CourseItem() { Title = "Computer Logic", Number = "CS210", Units = 4 },
                                       }
                                    },
                        new Module() { Title = "Elective Core Courses" },
                        new Module() { Title = "At least 20 units from:",
                                       Items = new List<Item>() {
                                           new CourseItem() { Title = "Programming Graphical User Interfaces", Number = "CS245", Units = 4 },
                                           new CourseItem() { Title = "Unix and Scripting", Number = "CS260", Units = 4 }
                                       }
                                    },
                        new Module() { Title = "No more than 4 units from:",
                                       Items = new List<Item>() {
                                           new CourseItem() { Title = "Special Study for Lower Division Students", Number = "CS245", Units = 2 },
                                           new CourseItem() { Title = "Senior Project", Number = "CS461", Units = 2 }
                                       }
                                    }
                    }
                };
                _context.CurriculumSheets.Add(cs);
                _context.Modules.AddRange(cs.Modules);
            }
 
            await _context.SaveChangesAsync();  // push changes into database
        }

    }
}

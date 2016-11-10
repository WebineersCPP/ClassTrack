using Microsoft.AspNetCore.Identity;
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
        private UserManager<ClassTrackUser> _userManager;

        public ClassTrackContextSeedData(ClassTrackContext context, UserManager<ClassTrackUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if (await _userManager.FindByEmailAsync("test@email.com") == null)
            {
                var user = new ClassTrackUser()
                {
                    UserName = "username",
                    Email = "test@email.com"
                };

                await _userManager.CreateAsync(user, "P@ssw0rd");
            }

            if (!_context.CurriculumSheets.Any())
            {
                CurriculumSheet cs = new CurriculumSheet()
                {
                    UserName = "username",
                    Year = 2012,
                    Major = "Computer Science",
                    MinUnitsReq = 180,
                    Modules = new List<Module>()
                    {
                        new Module() { Title = "Required Core Courses for Major",
                                       Units = 62,
                                       Items = new List<Item>()
                                       {
                                           new Item() { Title = "Discrete Structures", Number = "CS130", Units = 4 },
                                           new Item() { Title = "Introduction to Computer Science", Number = "CS140", Units = 4 },
                                           new Item() { Title = "Introduction to Programming and Problem-Solving", Number = "CS141", Units = 4 },
                                           new Item() { Title = "Computer Logic", Number = "CS210", Units = 4 },
                                       }
                                    },
                        new Module() { Title = "Elective Core Courses",
                                       Units = 23
                                    },
                        new Module() { IsSubmodule = true,
                                       Title = "At least 20 units from:",
                                       Items = new List<Item>() {
                                           new Item() { Title = "Programming Graphical User Interfaces", Number = "CS245", Units = 4 },
                                           new Item() { Title = "Unix and Scripting", Number = "CS260", Units = 4 }
                                       }
                                    },
                        new Module() { IsSubmodule = true,
                                       Title = "No more than 4 units from:",
                                       Items = new List<Item>() {
                                           new Item() { Title = "Special Study for Lower Division Students", Number = "CS245", Units = 2 },
                                           new Item() { Title = "Senior Project", Number = "CS461", Units = 2 }
                                       }
                                    },
                        new Module() { Title = "Required Support Courses",
                                       Units = 43,
                                       Description = "The following major support courses should be used to satisfy the indicated GE requirements. If these courses are not used to satisfy GE, the total units to degree may be more than 180 units.",
                                       Items = new List<Item>() {
                                           new Item() { Title = "Life Science", Number = "BIO110/11L", Units = 3 },
                                           new Item() { Title = "Computers and Society", Number = "CS375", Units = 4 }
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

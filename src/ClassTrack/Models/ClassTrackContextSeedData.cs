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
            // Seed list of Majors and Subplans 
            if(!_context.CPPMajors.Any())
            {
                CPPMajor major = new CPPMajor()
                {
                    Title = "Aerospace Engineering"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Agribusiness and Food Industry Management"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Agricultural Science"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Animal Health Science"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Animal Science",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Animal Industries Management" },
                        new CPPSubplan() { Title = "Pre_Veterinary Science/Graduate School" },
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Anthropology",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Cultural Resource Management" },
                        new CPPSubplan() { Title = "General Anthropology" },
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Apparel Merchandising and Management",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Apparel Production" },
                        new CPPSubplan() { Title = "Fashion Retailing" },
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Architecture"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Art History"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                { 
                    Title = "Biology",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Botany" },
                        new CPPSubplan() { Title = "General Biology" },
                        new CPPSubplan() { Title = "Microbiology" },
                        new CPPSubplan() { Title = "Zoology" },
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Biotechnology"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Business Administration",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Accounting" },
                        new CPPSubplan() { Title = "Computer Information Systems" },
                        new CPPSubplan() { Title = "E-Business" },
                        new CPPSubplan() { Title = "Finance, Real Estate, and Law" },
                        new CPPSubplan() { Title = "International Business" },
                        new CPPSubplan() { Title = "Management and Human Resources" },
                        new CPPSubplan() { Title = "Marketing Management" },
                        new CPPSubplan() { Title = "Technology and Operations Management" },
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Chemical Engineering"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Chemisty",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Biochemistry" },
                        new CPPSubplan() { Title = "Chemistry" },
                        new CPPSubplan() { Title = "Industrial Chemistry" },
                        new CPPSubplan() { Title = "Molecular and Modeling Simulation"},
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Civil Engineering",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Enviromental Engineering"},
                        new CPPSubplan() { Title = "General Civil Engineering"},
                        new CPPSubplan() { Title = "Geospatial Engingeering" },
                    },
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Communication",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Journalism"},
                        new CPPSubplan() { Title = "Organizational Communication"},
                        new CPPSubplan() { Title = "Public Relations" },
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Computer Engineering"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Computer Science"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Construction Engineering Technology"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Economics"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Electrical Engineering"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Electronics and Computer Engineering Technology"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Electromechanical Systems Engineering Technology"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Electronic Systems Engineering Technology"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Engineering Technology"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "English",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "English Education"},
                        new CPPSubplan() { Title = "Literature and Language"},
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Enviromental Biology"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Food Science and Technology"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Food and Nutrition",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Dietetics"},
                        new CPPSubplan() { Title = "Nutrition Science"},
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Gender, Ethnicity, and Multicultural studies",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "GEMS"},
                        new CPPSubplan() { Title = "Pre-Credential"},
                        new CPPSubplan() { Title = "BA/Credential"},
                        new CPPSubplan() { Title = "Integrated BA"},
                        new CPPSubplan() { Title = "Integrated Bilingual Authorization BA"}
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Geography",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Environmental Geography"},
                        new CPPSubplan() { Title = "Geographic Information Systems"},
                        new CPPSubplan() { Title = "Geography"},
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Geology"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Graphic Design"
                };
                _context.CPPMajors.Add(major);
                major =  new CPPMajor()
                {
                    Title = "History",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Pre-Credential"},
                        new CPPSubplan() { Title = "No Subplan"},
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Hospitality Management"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Industrial Engineering"
                };
                _context.CPPMajors.Add(major);
                major =  new CPPMajor()
                {
                    Title = "Kinesiology",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Exercise Science"},
                        new CPPSubplan() { Title = "Health Promotion"}, 
                        new CPPSubplan() { Title = "Pedagogy"}, 
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Landscape Architecture"
                };
                _context.CPPMajors.Add(major);
                major =  new CPPMajor()
                {
                    Title = "Liberal Studies",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "BA/Credential"},
                        new CPPSubplan() { Title = "Bilingual Authorization BA/Credential"}, 
                        new CPPSubplan() { Title = "Bilingual Authorization Pre-Credential"}, 
                        new CPPSubplan() { Title = "General Studies"}, 
                        new CPPSubplan() { Title = "Pre-Credential"}, 
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Manufacturing Engineering"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Mathematics",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Applied Mathematics/Statistics"},
                        new CPPSubplan() { Title = "Secondary Teacher Prep/Pure Mathematics"}, 
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Manufacturing Engineering"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Mechanical Engineering"
                };
                _context.CPPMajors.Add(major);
                major =  new CPPMajor()
                {
                    Title = "Music",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Music Education"},
                        new CPPSubplan() { Title = "Music Industry Studies"}, 
                        new CPPSubplan() { Title = "Performance Emphasis"}, 
                    }
                };
                _context.CPPMajors.Add(major);
                major =  new CPPMajor()
                {
                    Title = "Philosophy",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Law and Society"},
                        new CPPSubplan() { Title = "No Subplan"},
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Physics"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Plant Science"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Political Science"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Psychology"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Science, Technology, and Society"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Social Sciences"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Sociology",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Criminology"},
                        new CPPSubplan() { Title = "General Sociology"}, 
                        new CPPSubplan() { Title = "Social Work"}, 
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Spanish"
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Theatre",
                    Subplans = new List<CPPSubplan>() 
                    {
                        new CPPSubplan() { Title = "Acting"},
                        new CPPSubplan() { Title = "Dance"}, 
                        new CPPSubplan() { Title = "Education and Community"}, 
                        new CPPSubplan() { Title = "General Theatre"},
                        new CPPSubplan() { Title = "Technical Theatre and Design"}, 
                    }
                };
                _context.CPPMajors.Add(major);
                major = new CPPMajor()
                {
                    Title = "Urban and Regional Planning"
                };
                _context.CPPMajors.Add(major);
            } 
            await _context.SaveChangesAsync();  // push changes into database
        }
    }
}


using ClassTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Tests
{
    public class FakeClassTrackRepository : IClassTrackRepository
    {
        private List<CurriculumSheet> list;

        public FakeClassTrackRepository()
        {
            list = new List<CurriculumSheet>();
        }

        public void AddCurriculumSheet(CurriculumSheet curriculumSheet)
        {
            list.Add(curriculumSheet);
        }

        public IEnumerable<CurriculumSheet> GetAllCurriculumSheets(string username)
        {
            return list;
        }

        public CurriculumSheet GetCurriculumSheet(string username, int year, string major, string subplan)
        {
            return new CurriculumSheet()
            {
                UserName = username,
                Year = year,
                Major = major,
                Subplan = subplan,
                MinUnitsReq = 180,
                Modules = new List<Module>()
                {
                    new Module() {
                        Title = "Required Core Courses for Major",
                        Units = 62,
                        Items = new List<Item>()
                        {
                            new CourseItem() { Title = "Discrete Structures", Number = "CS130", Units = 4 },
                            new CourseItem() { Title = "Introduction to Computer Science", Number = "CS140", Units = 4 }                                                   
                        }
                    },
                    new Module() { Title = "Elective Core Courses",
                        Units = 23
                    }
                }
            };
        }

        public Task<bool> SaveChangesAsync()
        {
            return new TaskCompletionSource<bool>().Task;
        }

    }
}

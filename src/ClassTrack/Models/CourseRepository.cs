using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class CourseRepository : ICourseRepository
    {
        private ClassTrackContext _context;

        public CourseRepository(ClassTrackContext context)
        {
            _context = context;
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }
    }
}

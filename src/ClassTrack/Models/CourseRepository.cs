using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class CourseRepository : ICourseRepository
    {
        // Temporary local container. In the future, we'd use a Context class, which will help us communicate with a database
        private static List<Course> courses = new List<Course>();

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return courses;
        }
    }
}

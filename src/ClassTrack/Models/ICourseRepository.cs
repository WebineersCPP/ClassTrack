using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();

        void AddCourse(Course course);

    }
}

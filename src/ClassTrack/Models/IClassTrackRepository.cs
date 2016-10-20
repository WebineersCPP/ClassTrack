﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public interface IClassTrackRepository
    {
        IEnumerable<CourseItem> GetAllCourses();

        void AddCourse(CourseItem course);

        Task<bool> SaveChangesAsync();
    }
}

using ClassTrack.Models;
using ClassTrack.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassTrack.Controllers.Api
{
    public class TestGetAvailableCourse : Controller
    {
        [HttpGet("api/testCourseFromSchedule")]
        public async Task<IActionResult> Get()
        {




            //////////////////////////////

            ICollection<CourseScheduleItem> list = new List<CourseScheduleItem>();


            GETCourseFromPublicSchedule test = new GETCourseFromPublicSchedule();

            list = await test.GetAvailableCourse("mat310");



            return Ok(list);
        }
    }
}

using ClassTrack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Controllers.Api
{
    public class CourseController : Controller
    {
        private ICourseRepository _repository;

        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }

        /* Sample WebAPI method */
        [HttpGet("api/test")]
        public IActionResult Test()
        {
            return Ok("Testing webAPI method");
        }

        [HttpGet("api/courses")]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllCourses();

                // Ok returns a 200 ok page
                return Ok(results);
            }
            catch (Exception ex)
            {
                // Badrequest returns a 404 error page
                return BadRequest("Error occurred");
            }
        }

        [HttpPost("api/courses")]
        public IActionResult Post([FromBody]Course course)
        {
            try
            {
                // Save to list. In future, we'd save to database
                _repository.AddCourse(course);

                // Created returns a 201 created page
                return Created("api/courses/", course);
            }
            catch(Exception ex)
            {
                return BadRequest("Unable to add course");
            }
        }

        
    }
}

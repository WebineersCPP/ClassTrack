﻿using ClassTrack.Models;
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

        /* Another test method to satisfy Assignment 3 for Paul Chiou */
        [HttpGet("api/test2")]
        public IActionResult Test2()
        {
            return Ok("Another test method to satisfy Assignment 3 for Paul Chiou...  I think I'm getting a hang of this! :)");
        }

        //Andrea Schmidt Assignment 3 part 3
        [HttpGet("api/test3")]
        public IActionResult Test3()
        {
            return Ok("Test method 3 for Andrea Schmidt");
        }

        //Ian Stodart Assignment 3 Part 3
        [HttpGet("api/test3")]
        public IActionResult Test4()
        {
            return Ok("3 Test methods are not enough, we need a 4th! - Ian xD");
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

using ClassTrack.Models;
using ClassTrack.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClassTrack.Controllers.Api
{
    [Authorize]
    [Route("/api/cpp")]
    public class CPPController : Controller
    {
        private IClassTrackRepository _repository;

        public CPPController(IClassTrackRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("majors")]
        public IActionResult GetCPPMajors()
        {
            try
            {
                var results = _repository.GetAllCPPMajors();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while retrieving majors from school's site");
            }
        }

    }
}

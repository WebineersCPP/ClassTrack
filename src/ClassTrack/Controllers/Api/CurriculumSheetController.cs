using AutoMapper;
using ClassTrack.Models;
using ClassTrack.Repositories;
using ClassTrack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClassTrack.Controllers.Api
{
    [Authorize]
    [Route("/api/curriculum-sheet")]
    public class CurriculumSheetController : Controller
    {
        private IClassTrackRepository _repository;

        public CurriculumSheetController(IClassTrackRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetCurriculumSheet()
        {
            var results = _repository.GetAllCurriculumSheets(this.User.Identity.Name);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCurriculumSheet(int id)
        {
            try
            {
                var result = _repository.GetCurriculumSheet(this.User.Identity.Name, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error while retrieving curriculum sheets for {this.User.Identity.Name}");
            }
        }

    }
}

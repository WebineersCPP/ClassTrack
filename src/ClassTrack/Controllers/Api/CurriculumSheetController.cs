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
                return BadRequest($"Error while retrieving curriculum sheet for {this.User.Identity.Name}");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> PostCurriculumSheet([FromBody]CurriculumSheetViewModel sheet)
        {
            try
            {
                // Given the user params, 
                // call a service that would retrieve the proper curriculum sheet link from school's website
                // and then transform that html data into json format
                // then, use that json format to create the appropriate CurriculumSheet object 
                // Code below stores that object into the database

                var curriculumSheet = Mapper.Map<CurriculumSheet>(sheet);
                _repository.AddCurriculumSheet(curriculumSheet);

                if (await _repository.SaveChangesAsync())
                {
                    return Created("{sheet.Year}/{sheet.Major}/", curriculumSheet);
                }

                return BadRequest("Unable to add curriculum sheet");
            }
            catch (Exception ex)
            {
                return BadRequest("Error while adding curriculum sheet");
            }
        }

    }
}

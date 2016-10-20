using AutoMapper;
using ClassTrack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheWorld.ViewModels;

namespace ClassTrack.Controllers.Api
{
    [Route("/api/curriculum-sheet")]
    public class CurriculumSheetController : Controller
    {
        private IClassTrackRepository _repository;

        public CurriculumSheetController(IClassTrackRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public IActionResult GetAllCurriculumSheets()
        {
            try
            {
                var results = _repository.GetAllCurriculumSheets();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while retrieving all curriculum sheets");
            }
        }

        [HttpGet("{sheet.Year}/{sheet.Major}")]
        public IActionResult GetCurriculumSheet(CurriculumSheetViewModel sheet)
        {
            try
            {
                var result = _repository.GetCurriculumSheet(sheet.Year, sheet.Major, sheet.Subplan);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while retrieving curriculum sheet");
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

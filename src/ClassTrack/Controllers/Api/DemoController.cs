using ClassTrack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Controllers.Api
{
    public class DemoController : Controller
    {
        private IClassTrackRepository _repository;

        public DemoController(IClassTrackRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("api/curriculum-sheets")]
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

        [HttpGet("api/curriculum-sheet")]
        public IActionResult GetCurriculumSheet()
        {
            try
            {
                var result = _repository.GetCurriculumSheet("Computer Science", 2012); // in future, insert params using ViewModel
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while retrieving curriculum sheet");
            }
        }

        [HttpPost("api/curriculum-sheet")]
        public async Task<IActionResult> Post([FromBody]CurriculumSheet sheet)
        {
            try
            {
                _repository.AddCurriculumSheet(sheet);

                if (await _repository.SaveChangesAsync())
                {
                    return Created("api/curriculum-sheet/", sheet);
                }
                return BadRequest("Unable to add curriculum sheet");
            }
            catch (Exception ex)
            {
                return BadRequest("Unable to add curriculum sheet");
            }
        }


    }
}

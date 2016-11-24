﻿using AutoMapper;
using ClassTrack.Models;
using ClassTrack.Repositories;
using ClassTrack.Services;
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

        [HttpPost]
        public async Task<IActionResult> PostCurriculumSheet([FromBody]CurriculumSheetViewModel cs)
        {
            try
            {
                // Services
                HTMLToCurriculumSheetService htmlParser = new HTMLToCurriculumSheetService();
                // UrlRetriever Service

                string url = "https://catalog.cpp.edu/preview_program.php?catoid=10&poid=2715&returnto=1210";
                // urRetriever.getUrl(cs.year, cs.major, cs.subplan);

                // Create curriculum sheet from school's website based on user's input 
                CurriculumSheet sheet = await htmlParser.getCurriculumSheet(url);
                sheet.UserName = this.User.Identity.Name;

                var result = _repository.PostCurriculumSheet(sheet);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error while adding curriculum sheet for {this.User.Identity.Name}");
            }
        }

    }
}

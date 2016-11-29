using ClassTrack.Models;
using ClassTrack.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Controllers.Api
{
    public class TestFetchCatalogURLController : Controller
    {
        [HttpGet("api/FetchURL")]
        public async Task<IActionResult> Get()
        {
            //Testing to see what is returned by the FetchCatalogURL Service
            FetchCatalogURLService testService = new FetchCatalogURLService();
            //string url = "http://catalog.cpp.edu/preview_program.php?catoid=4&poid=983&returnto=751";
            //<h3 id="ent1592">Accounting </h3>

            string message = testService.GetMajorPlanUrl(2013,"Spanish","");//testService.chooseCatalogYear("2013");//
            return Ok(message);
        }
    }
}

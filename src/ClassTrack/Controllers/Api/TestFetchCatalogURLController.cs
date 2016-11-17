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
            // TESTING THE HTMLToCurriculumSheetService BY CALLING IT **SEE DEBUGGING CONSOLE FOR RETURNED CURRICULUM SHEET**
            // PASS IN ANY CATALOG URL
            // BREAKPOINT IS SET IN THE LINE OF RETURN AT THE END OF HTMLToCurriculumSheetService CLASS
            FetchCatalogURLService testService = new FetchCatalogURLService();
            //string url = "http://catalog.cpp.edu/preview_program.php?catoid=4&poid=983&returnto=751";

            string message = await testService.GetMajorPlanUrl("CS","SCI","2013");
            return Ok(message);
        }
    }
}

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
    public class TestHTMLToCSController : Controller
    {
        // Here we are maintaining our private variable, which will be initialized in contructor
        private GeoCoordsService _coordsService;

        public TestHTMLToCSController(GeoCoordsService coordsService)
        {
            // we are injecting this service in this controller so it can use it
            // recall that this service is injectable because we specified it in Startup.cs under ConfigureServices() line 51 services.AddTransient<GeoCoordsService>();
            _coordsService = coordsService;
        }

        [HttpGet("api/testHTMLToCS")]
        // for some reason this returns a 401 error. :(
        // but either way, say method from service works, it would return our expected result
        public async Task<IActionResult> Get()
        {


            // TESTING THE HTMLToCurriculumSheetService BY CALLING IT **SEE DEBUGGING CONSOLE FOR RETURNED CURRICULUM SHEET**
            // PASS IN ANY CATALOG URL
            // BREAKPOINT IS SET IN THE LINE OF RETURN AT THE END OF HTMLToCurriculumSheetService CLASS
            HTMLToCurriculumSheetService testService = new HTMLToCurriculumSheetService();
            string url = "https://catalog.cpp.edu/preview_program.php?catoid=4&poid=983&returnto=751";
            CurriculumSheet returnTestCS = await testService.getCurriculumSheet(url);




            // Use the method GetCoordAsync from the service GeoCoordsService.cs
            var result = await _coordsService.GetCoordsAsync("Atlanta, GA");
            if (!result.Success)
            {
                throw new Exception(result.Message);
            }
            else
            {
                GeoCoordsResult var = new GeoCoordsResult();
                var.Latitude = result.Latitude;
                var.Longitude = result.Longitude;

                return Ok(var);
            }
        }
    }
}

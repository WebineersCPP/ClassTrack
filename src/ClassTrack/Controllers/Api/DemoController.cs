using ClassTrack.Services;
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
        private GeoCoordsService _coordsService;

        public DemoController(GeoCoordsService coordsService)
        {
            // we are injecting this service in this controller so it can use it
            // recall that this service is injectable because we specified it in Startup.cs under ConfigureServices()
            _coordsService = coordsService;
        }

        [HttpGet("api/demo")]
        public async Task<IActionResult> Get()
        {
            // Use a method from the service --> Lookup the Geocodes
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

                // If service works correctly, our variable would be initialized as expected.
                // In our case, we want to create a 2 services (2 diff classes, like this GeoCoordsService.cs):
                // 1. one that retrieves the appropriate website link to get the curriculum sheet
                //    based on which year, major, subplan input params
                // 2. one that converts an html code into json format given a web link input param
                //    (please refer to Models/ClassTrackContextSeedData.cs and EnsureSeedData() for a sample structure that can be converted from json
                return Ok(var);
            }
        }
    }
}

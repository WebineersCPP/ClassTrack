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
        [HttpGet("api/testHTMLToCS")]
        public async Task<IActionResult> Get()
        {
            // TESTING THE HTMLToCurriculumSheetService BY CALLING IT **SEE DEBUGGING CONSOLE FOR RETURNED CURRICULUM SHEET**
            // PASS IN ANY CATALOG URL
            // BREAKPOINT IS SET IN THE LINE OF RETURN AT THE END OF HTMLToCurriculumSheetService CLASS
            HTMLToCurriculumSheetService testService = new HTMLToCurriculumSheetService();
            string url = "http://catalog.cpp.edu/preview_program.php?catoid=4&poid=918&returnto=743";
            CurriculumSheet returnTestCS = await testService.getCurriculumSheet(url);

            return Ok(returnTestCS);
        }
    }
}

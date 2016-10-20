using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Controllers.Web
{
    public class AppController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}

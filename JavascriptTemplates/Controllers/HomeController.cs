using System;
using System.Collections.Generic;
using System.Linq;
using JavascriptTemplates.Models;
using Microsoft.AspNetCore.Mvc;

namespace JavascriptTemplates.Controllers
{


    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult NoTemplate()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WithTemplate()
        {
            return View();
        }


    
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class DemoController : Controller
    {
        public DemoController()
        {
            Demo = new DemoModel();
        }

        [BindProperty]
        public DemoModel Demo { get; set; }

        public IActionResult Index()
        {
            Demo.Value1 = 10;

            return View(Demo);
        }

        [HttpPost("submit", Name = "submit")]
        public IActionResult OnSubmit()
        {
            return View("Index", Demo);
        }
    }
}
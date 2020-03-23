using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sol_Demo.Controllers
{
    // https://stackoverflow.com/questions/59136221/blazor-in-mvc-component-gets-rendered-but-onclick-not-working-problem-with-c
    public class ClickEventDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
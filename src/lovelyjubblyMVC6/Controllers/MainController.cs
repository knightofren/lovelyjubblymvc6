using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace lovelyjubblyMVC6.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HallOfFame()
        {
            return View();
        }

        public IActionResult SuperbowlOdds()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }

        public IActionResult SeasonPredictions()
        {
            return View();
        }
    }
}
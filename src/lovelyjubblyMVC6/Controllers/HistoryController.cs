using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lovelyjubblyMVC6.Contracts;
using lovelyjubblyMVC6.DataAccess;
using lovelyjubblyMVC6.Models;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;  //use this for include
using Microsoft.Data.Entity.Storage;
using Microsoft.Framework.Logging;

namespace lovelyjubblyMVC6.Controllers
{
    public class HistoryController : Controller
    {
        //use ActionName attribute to allow you to start your action with a number or 
        //include any character that .net does not allow in an identifier
        [ActionName("2021")]
        public ActionResult Season2021()
        {
            return View("Season2021");
        }

        [ActionName("2020")]
        public ActionResult Season2020()
        {
            return View("Season2020");
        }

        [ActionName("2019")]
        public ActionResult Season2019()
        {
            return View("Season2019");
        }

        [ActionName("2018")]
        public ActionResult Season2018()
        {
            return View("Season2018");
        }
    }
}
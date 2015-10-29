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
    public class DivisionsController : Controller
    {
        private readonly IMainRepository _repository = new MainRepository();

        //GET : api/Divisions
        [HttpGet("api/Divisions")]
        public IQueryable<Division> GetAllDivisions()
        {
            return _repository.GetDivisions();
        }

        //GET : api/Divisions/5
        [HttpGet("api/Divisions/{divisionId:int}")]
        public IActionResult GetDivisionById(int divisionId)
        {
            var division = _repository.GetDivisionById(divisionId);

            if (division == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(division);
        }

        //GET : api/Divisions/AFC East
        [HttpGet("api/Divisions/{divisionName}")]
        public IActionResult GetDivisionByName(string divisionName)
        {
            var division = _repository.GetDivisionByDivisionName(divisionName);

            if (division == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(division);
        }
    }
}
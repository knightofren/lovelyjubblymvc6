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
    public class FixturesController : Controller
    {
        private readonly IMainRepository _repository = new MainRepository();
        private lovelyjubblyMVC6WebApiContext _context;

        public FixturesController(lovelyjubblyMVC6WebApiContext context)
        {
            _context = context;
        }

        [Route("Fixtures")]
        public ActionResult Fixtures()
        {
            return View();
        }

        //GET : api/Fixtures
        [HttpGet("api/Fixtures")]
        public IQueryable<Fixture> GetAllFixtures()
        {
            return _repository.GetFixtures();
        }

        //GET : api/Fixtures/5
        [HttpGet("api/Fixtures/{fixtureId:int}")]
        public IActionResult GetFixtureById(int fixtureId)
        {
            var fixture = _repository.GetFixtureById(fixtureId);

            if (fixture == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(fixture);
        }

        //POST : api/Fixtures/Add
        [HttpPost("api/Fixtures/Add")]
        public Fixture AddFixture([FromBody]Fixture fixture)
        {
            Fixture addedFixture = null;

            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                addedFixture = _repository.AddFixture(fixture);
            }

            return addedFixture;
        }

        [HttpPut("api/Fixtures/Update")]
        //[ValidateAntiForgeryToken]
        public Fixture Update([FromBody]Fixture fixture)
        {
            try
            {
                var updatedFixture = _repository.UpdateFixture(fixture);
                return updatedFixture;
            }
            catch (DataStoreException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return fixture;
        }

        //DELETE : api/Fixtures/Delete/4
        [HttpDelete("api/Fixtures/Delete/{fixtureId:int}")]
        public IActionResult DeleteFixture(int fixtureId)
        {
            bool success = _repository.DeleteFixture(fixtureId);

            if (!success)
            {
                return HttpNotFound();
            }
            else
            {
                return new HttpStatusCodeResult(204); // 201 No Content
            }
        }
    }
}
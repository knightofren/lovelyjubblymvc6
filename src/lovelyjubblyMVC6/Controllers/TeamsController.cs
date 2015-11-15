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
    public class TeamsController : Controller
    {
        private readonly IMainRepository _repository = new MainRepository();

        [Route("Teams")]
        public IActionResult Teams()
        {
            return View();
        }

        public ActionResult Arizona()
        {
            return View("Arizona");
        }

        public ActionResult Atlanta()
        {
            return View("Atlanta");
        }

        public ActionResult Buffalo()
        {
            return View("Buffalo");
        }

        public ActionResult Carolina()
        {
            return View("Carolina");
        }

        //GET : api/Teams
        [HttpGet("api/Teams")]
        public IQueryable<Team> GetAllTeams()
        {
            return _repository.GetTeams();
        }

        //GET : api/Teams/5
        [HttpGet("api/Teams/{teamId:int}")]
        public IActionResult GetTeamById(int teamId)
        {
            var team = _repository.GetTeamById(teamId);

            if (team == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(team);
        }

        //GET : api/Teams/Chicago Bears
        [HttpGet("api/Teams/{teamName}")]
        public IActionResult GetTeamByName(string teamName)
        {
            var team = _repository.GetTeamByTeamName(teamName);

            if (team == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(team);
        }

        //POST : api/Teams/Add
        [HttpPost("api/Teams/Add")]
        public Team AddTeam([FromBody]Team team)
        {
            Team addedTeam = null;

            if (!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
            }
            else
            {
                addedTeam = _repository.AddTeam(team);
            }

            return addedTeam;
        }

        [HttpPut("api/Teams/Update")]
        //[ValidateAntiForgeryToken]
        public Team Update([FromBody]Team team)
        {
            try
            {
                var updatedTeam = _repository.UpdateTeam(team);
                return updatedTeam;
            }
            catch (DataStoreException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes.");
            }
            return team;
        }

        //DELETE : api/Teams/Delete/4
        [HttpDelete("api/Teams/Delete/{teamId:int}")]
        public IActionResult DeleteTeam(int teamId)
        {
            bool success = _repository.DeleteTeam(teamId);
            
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
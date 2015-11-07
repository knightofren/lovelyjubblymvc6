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
    public class QBRatingsController : Controller
    {
        private readonly IMainRepository _repository = new MainRepository();

        [Route("QBRatings")]
        public IActionResult QBRatings()
        {
            return View();
        }

        //GET : api/QBRatings
        [HttpGet("api/QBRatings")]
        public IQueryable<QBRating> GetAllQBRatings()
        {
            return _repository.GetQBRatings();
        }

        //GET : api/QBRatings/5
        [HttpGet("api/QBRatings/{qbRatingId:int}")]
        public IActionResult GetQBRatingById(int qbRatingId)
        {
            var qbRating = _repository.GetQBRatingById(qbRatingId);

            if (qbRating == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(qbRating);
        }
    }
}
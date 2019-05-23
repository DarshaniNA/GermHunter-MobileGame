using GameLeaderboard.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameLeaderboard.Controllers
{
    public class LevelsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var dbHelper = new DataHelper();
                return Ok(dbHelper.GetLevels());
            }
            catch (Exception EX)
            {
                return InternalServerError(EX);
            }
        }
        [HttpPost]
        public IHttpActionResult Post(string levelName)
        {
            try
            {
                var dbHelper = new DataHelper();
                return Ok(dbHelper.NewLevel(levelName));
            }
            catch (Exception EX)
            {
                return InternalServerError(EX);
            }
        }
    }
}

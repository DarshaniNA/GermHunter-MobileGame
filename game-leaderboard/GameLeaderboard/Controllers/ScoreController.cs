using GameLeaderboard.Helpers;
using GameLeaderboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameLeaderboard.Controllers
{
    public class ScoreController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var dbHelper = new DataHelper();
                return Ok(dbHelper.GetScore());
            }
            catch (Exception EX)
            {
                return InternalServerError(EX);
            }
        }
        [HttpPost]
        public IHttpActionResult Post(ScoreDTO score)
        {
            try
            {
                var dbHelper = new DataHelper();
                return Ok(dbHelper.NewScore(score));
            }
            catch (Exception EX)
            {
                return InternalServerError(EX);
            }
        }
        [HttpGet]
        [Route("scores/{playerId}")]
        public IHttpActionResult GetPlayerScore(int playerId)
        {
            try
            {
                var dbHelper = new DataHelper();
                return Ok(dbHelper.GetPlayerScore(playerId));
            }
            catch (Exception EX)
            {
                return InternalServerError(EX);
            }
        }
    }
}

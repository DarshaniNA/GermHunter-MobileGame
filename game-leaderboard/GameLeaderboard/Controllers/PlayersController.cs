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
    public class PlayersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var dbHelper = new DataHelper();
                return Ok(dbHelper.GetPlayers());
            }
            catch (Exception EX)
            {
                return InternalServerError(EX);
            }
        }
        [HttpPost]
        public IHttpActionResult Post(PlayerDTO player)
        {
            try
            {
                var dbHelper = new DataHelper();
                return Ok(dbHelper.NewPlayer(player));
            }
            catch (Exception EX)
            {
                return InternalServerError(EX);
            }
        }
        [HttpGet]
        [Route("playes/{playerId}")]
        public IHttpActionResult GetPlayer(int playerId)
        {
            try
            {
                var dbHelper = new DataHelper();
                return Ok(dbHelper.GetPlayer(playerId));
            }
            catch (Exception EX)
            {
                return InternalServerError(EX);
            }
        }
    }
}

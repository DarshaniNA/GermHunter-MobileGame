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
    public class LoginController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(LoginDTO login)
        {
            try
            {
                var dbHelper = new DataHelper();
                return Ok(dbHelper.Login(login));
            }
            catch (Exception EX)
            {
                return InternalServerError(EX);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameLeaderboard.Models
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string GamerTag { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string  Password { get; set; }
        public bool IsActive { get; set; }
    }
}
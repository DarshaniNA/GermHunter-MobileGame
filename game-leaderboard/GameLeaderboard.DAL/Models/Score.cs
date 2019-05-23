using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLeaderboard.DAL.Models
{
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int LevelId { get; set; }
        public DateTime Time { get; set; }
        public int Pickups { get; set; }
        public int Points { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }
        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }
    }
}

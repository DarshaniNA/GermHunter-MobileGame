using System;

namespace GameLeaderboard.Models
{
    public class ScoreDTO
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public DateTime Time { get; set; }
        public int Pickups { get; set; }
        public int Points { get; set; }
    }
}
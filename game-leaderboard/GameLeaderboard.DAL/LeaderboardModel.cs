namespace GameLeaderboard.DAL
{
    using GameLeaderboard.DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LeaderboardModel : DbContext
    {
        // Your context has been configured to use a 'LeaderboardModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GameLeaderboard.DAL.LeaderboardModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LeaderboardModel' 
        // connection string in the application configuration file.
        public LeaderboardModel()
            : base("name=LeaderboardModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
    }
}
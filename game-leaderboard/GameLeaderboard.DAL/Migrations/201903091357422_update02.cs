namespace GameLeaderboard.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update02 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PlayerLevels", newName: "Scores");
            AddColumn("dbo.Scores", "Points", c => c.Int(nullable: false));
            DropColumn("dbo.Scores", "Score");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scores", "Score", c => c.Int(nullable: false));
            DropColumn("dbo.Scores", "Points");
            RenameTable(name: "dbo.Scores", newName: "PlayerLevels");
        }
    }
}

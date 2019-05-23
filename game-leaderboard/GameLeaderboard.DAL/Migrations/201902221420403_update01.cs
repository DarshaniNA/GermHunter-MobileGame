namespace GameLeaderboard.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update01 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PlayerLevels", "PlayerId");
            CreateIndex("dbo.PlayerLevels", "LevelId");
            AddForeignKey("dbo.PlayerLevels", "LevelId", "dbo.Levels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PlayerLevels", "PlayerId", "dbo.Players", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerLevels", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.PlayerLevels", "LevelId", "dbo.Levels");
            DropIndex("dbo.PlayerLevels", new[] { "LevelId" });
            DropIndex("dbo.PlayerLevels", new[] { "PlayerId" });
        }
    }
}

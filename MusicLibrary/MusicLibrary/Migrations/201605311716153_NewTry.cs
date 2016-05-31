namespace MusicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "playlistId", "dbo.Playlists");
            DropIndex("dbo.Songs", new[] { "playlistId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Songs", "playlistId");
            AddForeignKey("dbo.Songs", "playlistId", "dbo.Playlists", "id", cascadeDelete: true);
        }
    }
}

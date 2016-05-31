namespace MusicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryToFixTheError : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        songName = c.String(),
                        artist = c.String(),
                        imageSrc = c.String(),
                        fileSrc = c.String(),
                        playlistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Playlists", t => t.playlistId, cascadeDelete: true)
                .Index(t => t.playlistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Playlists", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Songs", "playlistId", "dbo.Playlists");
            DropIndex("dbo.Playlists", new[] { "User_Id" });
            DropIndex("dbo.Songs", new[] { "playlistId" });
            DropTable("dbo.Songs");
            DropTable("dbo.Playlists");
        }
    }
}

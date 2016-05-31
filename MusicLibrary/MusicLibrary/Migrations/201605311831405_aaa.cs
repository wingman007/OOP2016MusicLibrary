namespace MusicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlaylistSongs", "PlaylistId", "dbo.Playlists");
            DropIndex("dbo.PlaylistSongs", new[] { "PlaylistId" });
            AddColumn("dbo.Songs", "playlistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Songs", "playlistId");
            AddForeignKey("dbo.Songs", "playlistId", "dbo.Playlists", "id", cascadeDelete: true);
            DropTable("dbo.PlaylistSongs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlaylistSongs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        songName = c.String(),
                        artist = c.String(),
                        imageSrc = c.String(),
                        fileSrc = c.String(),
                        PlaylistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.Songs", "playlistId", "dbo.Playlists");
            DropIndex("dbo.Songs", new[] { "playlistId" });
            DropColumn("dbo.Songs", "playlistId");
            CreateIndex("dbo.PlaylistSongs", "PlaylistId");
            AddForeignKey("dbo.PlaylistSongs", "PlaylistId", "dbo.Playlists", "id", cascadeDelete: true);
        }
    }
}

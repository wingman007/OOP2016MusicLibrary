namespace MusicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewClassAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaylistSongs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Playlist_id = c.Int(),
                        Song_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Playlists", t => t.Playlist_id)
                .ForeignKey("dbo.Songs", t => t.Song_id)
                .Index(t => t.Playlist_id)
                .Index(t => t.Song_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaylistSongs", "Song_id", "dbo.Songs");
            DropForeignKey("dbo.PlaylistSongs", "Playlist_id", "dbo.Playlists");
            DropIndex("dbo.PlaylistSongs", new[] { "Song_id" });
            DropIndex("dbo.PlaylistSongs", new[] { "Playlist_id" });
            DropTable("dbo.PlaylistSongs");
        }
    }
}

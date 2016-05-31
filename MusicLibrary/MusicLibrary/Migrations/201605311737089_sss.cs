namespace MusicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlaylistSongs", "Song_id", "dbo.Songs");
            DropIndex("dbo.PlaylistSongs", new[] { "Song_id" });
            AddColumn("dbo.PlaylistSongs", "songName", c => c.String());
            AddColumn("dbo.PlaylistSongs", "artist", c => c.String());
            AddColumn("dbo.PlaylistSongs", "imageSrc", c => c.String());
            AddColumn("dbo.PlaylistSongs", "fileSrc", c => c.String());
            DropColumn("dbo.PlaylistSongs", "Song_id");
            DropColumn("dbo.Songs", "playlistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "playlistId", c => c.Int(nullable: false));
            AddColumn("dbo.PlaylistSongs", "Song_id", c => c.Int());
            DropColumn("dbo.PlaylistSongs", "fileSrc");
            DropColumn("dbo.PlaylistSongs", "imageSrc");
            DropColumn("dbo.PlaylistSongs", "artist");
            DropColumn("dbo.PlaylistSongs", "songName");
            CreateIndex("dbo.PlaylistSongs", "Song_id");
            AddForeignKey("dbo.PlaylistSongs", "Song_id", "dbo.Songs", "id");
        }
    }
}

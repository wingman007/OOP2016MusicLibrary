namespace MusicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ssssssssss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlaylistSongs", "Playlist_id", "dbo.Playlists");
            DropIndex("dbo.PlaylistSongs", new[] { "Playlist_id" });
            RenameColumn(table: "dbo.PlaylistSongs", name: "Playlist_id", newName: "playlistId");
            AlterColumn("dbo.PlaylistSongs", "playlistId", c => c.Int(nullable: false));
            CreateIndex("dbo.PlaylistSongs", "playlistId");
            AddForeignKey("dbo.PlaylistSongs", "playlistId", "dbo.Playlists", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaylistSongs", "playlistId", "dbo.Playlists");
            DropIndex("dbo.PlaylistSongs", new[] { "playlistId" });
            AlterColumn("dbo.PlaylistSongs", "playlistId", c => c.Int());
            RenameColumn(table: "dbo.PlaylistSongs", name: "playlistId", newName: "Playlist_id");
            CreateIndex("dbo.PlaylistSongs", "Playlist_id");
            AddForeignKey("dbo.PlaylistSongs", "Playlist_id", "dbo.Playlists", "id");
        }
    }
}

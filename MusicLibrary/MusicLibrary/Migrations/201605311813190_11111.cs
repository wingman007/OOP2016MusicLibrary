namespace MusicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11111 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PlaylistSongs", "playlistId", "dbo.Playlists");
            DropIndex("dbo.PlaylistSongs", new[] { "playlistId" });
            AlterColumn("dbo.PlaylistSongs", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PlaylistSongs", "PlaylistId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.PlaylistSongs");
            AddPrimaryKey("dbo.PlaylistSongs", "id");
            CreateIndex("dbo.PlaylistSongs", "PlaylistId");
            AddForeignKey("dbo.PlaylistSongs", "PlaylistId", "dbo.Playlists", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlaylistSongs", "PlaylistId", "dbo.Playlists");
            DropIndex("dbo.PlaylistSongs", new[] { "PlaylistId" });
            DropPrimaryKey("dbo.PlaylistSongs");
            AddPrimaryKey("dbo.PlaylistSongs", "Id");
            AlterColumn("dbo.PlaylistSongs", "PlaylistId", c => c.Int(nullable: false));
            AlterColumn("dbo.PlaylistSongs", "id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.PlaylistSongs", "playlistId");
            AddForeignKey("dbo.PlaylistSongs", "playlistId", "dbo.Playlists", "id", cascadeDelete: true);
        }
    }
}

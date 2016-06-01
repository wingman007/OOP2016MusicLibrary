namespace OOP2016MusicLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoImg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Songs", "imageSrc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "imageSrc", c => c.String());
        }
    }
}

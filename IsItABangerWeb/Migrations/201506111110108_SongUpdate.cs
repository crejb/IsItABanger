namespace IsItABangerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "Artist", c => c.String());
            AddColumn("dbo.Songs", "IsItABanger", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "IsItABanger");
            DropColumn("dbo.Songs", "Artist");
        }
    }
}

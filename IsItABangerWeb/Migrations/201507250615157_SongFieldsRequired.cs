namespace IsItABangerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongFieldsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Songs", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Songs", "Artist", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Songs", "Artist", c => c.String());
            AlterColumn("dbo.Songs", "Name", c => c.String());
        }
    }
}

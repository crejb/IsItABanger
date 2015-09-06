namespace IsItABangerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Banger.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "Banger.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Banger.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Banger.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Banger.Songs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Artist = c.String(nullable: false),
                        Bpm = c.Int(nullable: false),
                        Drops = c.Int(nullable: false),
                        DropsAreDope = c.Boolean(nullable: false),
                        HasAcousticInstruments = c.Boolean(nullable: false),
                        IsItABanger = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "Banger.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "Banger.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Banger.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Banger.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("Banger.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Banger.AspNetUserRoles", "UserId", "Banger.AspNetUsers");
            DropForeignKey("Banger.AspNetUserLogins", "UserId", "Banger.AspNetUsers");
            DropForeignKey("Banger.AspNetUserClaims", "UserId", "Banger.AspNetUsers");
            DropForeignKey("Banger.AspNetUserRoles", "RoleId", "Banger.AspNetRoles");
            DropIndex("Banger.AspNetUserLogins", new[] { "UserId" });
            DropIndex("Banger.AspNetUserClaims", new[] { "UserId" });
            DropIndex("Banger.AspNetUsers", "UserNameIndex");
            DropIndex("Banger.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("Banger.AspNetUserRoles", new[] { "UserId" });
            DropIndex("Banger.AspNetRoles", "RoleNameIndex");
            DropTable("Banger.AspNetUserLogins");
            DropTable("Banger.AspNetUserClaims");
            DropTable("Banger.AspNetUsers");
            DropTable("Banger.Songs");
            DropTable("Banger.AspNetUserRoles");
            DropTable("Banger.AspNetRoles");
        }
    }
}

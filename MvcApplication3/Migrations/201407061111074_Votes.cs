namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Votes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 256),
                        Wallet = c.Int(nullable: false),
                        RoleName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Ip = c.String(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        BannerUrl = c.String(nullable: false),
                        SiteUrl = c.String(nullable: false),
                        RewardHash = c.String(),
                        RewardUrl = c.String(),
                        OwnerID = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ip = c.String(),
                        Nickname = c.String(),
                        ProjectId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Voters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vk = c.String(),
                        LastVote = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ServerMods",
                c => new
                    {
                        Server_Id = c.Int(nullable: false),
                        Mod_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Server_Id, t.Mod_Id })
                .ForeignKey("dbo.Servers", t => t.Server_Id, cascadeDelete: true)
                .ForeignKey("dbo.Mods", t => t.Mod_Id, cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Servers", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "OwnerID", "dbo.Accounts");
            DropForeignKey("dbo.ServerMods", "Mod_Id", "dbo.Mods");
            DropForeignKey("dbo.ServerMods", "Server_Id", "dbo.Servers");
            DropIndex("dbo.Votes", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "OwnerID" });
            DropIndex("dbo.Servers", new[] { "ProjectID" });
            DropTable("dbo.ServerMods");
            DropTable("dbo.Voters");
            DropTable("dbo.Votes");
            DropTable("dbo.Projects");
            DropTable("dbo.Servers");
            DropTable("dbo.Mods");
            DropTable("dbo.Accounts");
        }
    }
}

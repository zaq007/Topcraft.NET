namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Servers : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Mods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ServerMods",
                c => new
                    {
                        Mod_Id = c.Int(nullable: false),
                        Server_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Mod_Id, t.Server_Id })
                .ForeignKey("dbo.Mods", t => t.Mod_Id, cascadeDelete: true)
                .ForeignKey("dbo.Servers", t => t.Server_Id, cascadeDelete: true);
            
            DropColumn("dbo.Projects", "ServersCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ServersCount", c => c.Int(nullable: false));
            DropForeignKey("dbo.Servers", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ModServers", "Server_Id", "dbo.Servers");
            DropForeignKey("dbo.ModServers", "Mod_Id", "dbo.Mods");
            DropIndex("dbo.Servers", new[] { "ProjectID" });
            DropTable("dbo.ModServers");
            DropTable("dbo.Mods");
            DropTable("dbo.Servers");
        }
    }
}

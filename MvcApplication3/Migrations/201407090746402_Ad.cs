namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Banner = c.String(),
                        Start = c.DateTime(nullable: false),
                        Position = c.Int(nullable: false),
                        Goal = c.Int(nullable: false),
                        End = c.DateTime(nullable: false),
                        Clicks = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ads", "OwnerId", "dbo.Accounts");
            DropIndex("dbo.Ads", new[] { "OwnerId" });
            DropTable("dbo.Ads");
        }
    }
}

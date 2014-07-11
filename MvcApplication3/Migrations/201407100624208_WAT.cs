namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WAT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ads", "EndClicks", c => c.Int(nullable: false));
            AddColumn("dbo.Ads", "EndViews", c => c.Int(nullable: false));
            DropColumn("dbo.Ads", "End");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ads", "End", c => c.DateTime(nullable: false));
            DropColumn("dbo.Ads", "EndViews");
            DropColumn("dbo.Ads", "EndClicks");
            DropColumn("dbo.Ads", "EndTime");
        }
    }
}

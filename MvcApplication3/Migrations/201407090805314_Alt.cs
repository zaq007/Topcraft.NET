namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ads", "Alt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ads", "Alt");
        }
    }
}

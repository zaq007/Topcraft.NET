namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ads", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ads", "EndTime", c => c.DateTime(nullable: false));
        }
    }
}

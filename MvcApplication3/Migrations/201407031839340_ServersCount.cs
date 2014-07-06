namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServersCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ServersCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ServersCount");
        }
    }
}

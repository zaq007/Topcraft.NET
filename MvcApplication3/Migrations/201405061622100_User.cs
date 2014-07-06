namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {         
            AddColumn("dbo.Projects", "Owner_Id", c => c.Int());
            CreateIndex("dbo.Projects", "Owner_Id");
            AddForeignKey("dbo.Projects", "Owner_Id", "dbo.Accounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Owner_Id", "dbo.Accounts");
            DropIndex("dbo.Projects", new[] { "Owner_Id" });
            DropColumn("dbo.Projects", "Owner_Id");
            DropTable("dbo.Accounts");
        }
    }
}

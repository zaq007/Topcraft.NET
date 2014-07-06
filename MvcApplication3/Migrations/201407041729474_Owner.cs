namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Owner : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Owner_Id", "dbo.Accounts");
            DropIndex("dbo.Projects", new[] { "Owner_Id" });
            RenameColumn(table: "dbo.Projects", name: "Owner_Id", newName: "OwnerID");
            AlterColumn("dbo.Projects", "OwnerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "OwnerID");
            AddForeignKey("dbo.Projects", "OwnerID", "dbo.Accounts", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "OwnerID", "dbo.Accounts");
            DropIndex("dbo.Projects", new[] { "OwnerID" });
            AlterColumn("dbo.Projects", "OwnerID", c => c.Int());
            RenameColumn(table: "dbo.Projects", name: "OwnerID", newName: "Owner_Id");
            CreateIndex("dbo.Projects", "Owner_Id");
            AddForeignKey("dbo.Projects", "Owner_Id", "dbo.Accounts", "Id");
        }
    }
}

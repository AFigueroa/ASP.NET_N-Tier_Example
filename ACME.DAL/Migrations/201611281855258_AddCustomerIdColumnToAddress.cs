namespace ACME.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerIdColumnToAddress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Addresses", new[] { "Customer_CustomerId" });
            RenameColumn(table: "dbo.Addresses", name: "Customer_CustomerId", newName: "CustomerId");
            AlterColumn("dbo.Addresses", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "CustomerId");
            AddForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Addresses", new[] { "CustomerId" });
            AlterColumn("dbo.Addresses", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.Addresses", name: "CustomerId", newName: "Customer_CustomerId");
            CreateIndex("dbo.Addresses", "Customer_CustomerId");
            AddForeignKey("dbo.Addresses", "Customer_CustomerId", "dbo.Customers", "CustomerId");
        }
    }
}

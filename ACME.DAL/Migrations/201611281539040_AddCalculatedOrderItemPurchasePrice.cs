namespace ACME.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCalculatedOrderItemPurchasePrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Product_ProductId", c => c.Int());
            AlterColumn("dbo.Products", "CurrentPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.OrderItems", "Product_ProductId");
            AddForeignKey("dbo.OrderItems", "Product_ProductId", "dbo.Products", "ProductId");
            DropColumn("dbo.OrderItems", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderItems", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "Product_ProductId" });
            AlterColumn("dbo.Products", "CurrentPrice", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.OrderItems", "Product_ProductId");
        }
    }
}

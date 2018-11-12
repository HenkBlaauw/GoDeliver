namespace GoDeliverWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test21 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Orders", new[] { "Foods_FoodId" });
            RenameColumn(table: "dbo.Foods", name: "Foods_FoodId", newName: "Order_OrderId");
            CreateIndex("dbo.Foods", "Order_OrderId");
            DropColumn("dbo.Orders", "Foods_FoodId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Foods_FoodId", c => c.Int());
            DropIndex("dbo.Foods", new[] { "Order_OrderId" });
            RenameColumn(table: "dbo.Foods", name: "Order_OrderId", newName: "Foods_FoodId");
            CreateIndex("dbo.Orders", "Foods_FoodId");
        }
    }
}

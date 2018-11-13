namespace GoDeliverWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Foods", new[] { "RestaurantId" });
            DropIndex("dbo.Orders", new[] { "Foods_FoodId" });
            RenameColumn(table: "dbo.Foods", name: "Foods_FoodId", newName: "Order_OrderId");
            AddColumn("dbo.Foods", "Restaurant_RestaurantId", c => c.Int());
            AddColumn("dbo.Orders", "State", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "Adress", c => c.String());
            AlterColumn("dbo.Foods", "RestaurantId", c => c.Long(nullable: false));
            CreateIndex("dbo.Foods", "Order_OrderId");
            CreateIndex("dbo.Foods", "Restaurant_RestaurantId");
            AddForeignKey("dbo.Foods", "Restaurant_RestaurantId", "dbo.Restaurants", "RestaurantId");
            DropColumn("dbo.Orders", "Foods_FoodId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Foods_FoodId", c => c.Int());
            DropForeignKey("dbo.Foods", "Restaurant_RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Foods", new[] { "Restaurant_RestaurantId" });
            DropIndex("dbo.Foods", new[] { "Order_OrderId" });
            AlterColumn("dbo.Foods", "RestaurantId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Adress", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Orders", "State");
            DropColumn("dbo.Foods", "Restaurant_RestaurantId");
            RenameColumn(table: "dbo.Foods", name: "Order_OrderId", newName: "Foods_FoodId");
            CreateIndex("dbo.Orders", "Foods_FoodId");
            CreateIndex("dbo.Foods", "RestaurantId");
            AddForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants", "RestaurantId", cascadeDelete: true);
        }
    }
}

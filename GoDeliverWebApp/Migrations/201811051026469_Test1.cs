namespace GoDeliverWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Foods_FoodId", "dbo.Foods");
            DropForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Foods", new[] { "RestaurantId" });
            DropIndex("dbo.Orders", new[] { "Foods_FoodId" });
            DropTable("dbo.Foods");
            DropTable("dbo.Orders");
            DropTable("dbo.Restaurants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        CreatedAtDate = c.DateTime(nullable: false),
                        UpdatedAtDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        TimeAtRestaurant = c.DateTime(nullable: false),
                        RestaurantAddress = c.String(),
                        CustomerAddress = c.String(),
                        TotalCost = c.Single(nullable: false),
                        CreatedAtDate = c.DateTime(nullable: false),
                        UpdatedAtDate = c.DateTime(nullable: false),
                        Foods_FoodId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 100),
                        Cost = c.Single(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        CreatedAtDate = c.DateTime(nullable: false),
                        UpdatedAtDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId);
            
            CreateIndex("dbo.Orders", "Foods_FoodId");
            CreateIndex("dbo.Foods", "RestaurantId");
            AddForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants", "RestaurantId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "Foods_FoodId", "dbo.Foods", "FoodId");
        }
    }
}

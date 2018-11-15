namespace GoDeliverWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JohanSaves : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Adress = c.String(),
                        CreatedAtDate = c.DateTime(nullable: false),
                        UpdatedAtDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreatedAtDate = c.DateTime(nullable: false),
                        UpdatedAtDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        Cost = c.Single(nullable: false),
                        RestaurantId = c.Long(nullable: false),
                        CreatedAtDate = c.DateTime(nullable: false),
                        UpdatedAtDate = c.DateTime(nullable: false),
                        Order_OrderId = c.Int(),
                        Restaurant_RestaurantId = c.Int(),
                    })
                .PrimaryKey(t => t.FoodId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_RestaurantId)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Restaurant_RestaurantId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        TimeAtRestaurant = c.DateTime(nullable: false),
                        RestaurantAddress = c.String(nullable: false, maxLength: 255),
                        CustomerAddress = c.String(nullable: false, maxLength: 255),
                        TotalCost = c.Single(nullable: false),
                        State = c.String(nullable: false, maxLength: 255),
                        CreatedAtDate = c.DateTime(nullable: false),
                        UpdatedAtDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        Adress = c.String(maxLength: 255),
                        CreatedAtDate = c.DateTime(nullable: false),
                        UpdatedAtDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Food", "Restaurant_RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Food", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Food", new[] { "Restaurant_RestaurantId" });
            DropIndex("dbo.Food", new[] { "Order_OrderId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.Orders");
            DropTable("dbo.Food");
            DropTable("dbo.Drivers");
            DropTable("dbo.Customers");
        }
    }
}

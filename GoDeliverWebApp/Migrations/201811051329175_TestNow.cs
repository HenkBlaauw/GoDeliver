namespace GoDeliverWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestNow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        Cost = c.Single(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        CreatedAtDate = c.DateTime(nullable: false),
                        UpdatedAtDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
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
                        CreatedAtDate = c.DateTime(nullable: false),
                        UpdatedAtDate = c.DateTime(nullable: false),
                        Foods_FoodId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Foods", t => t.Foods_FoodId)
                .Index(t => t.Foods_FoodId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Adress = c.String(nullable: false, maxLength: 255),
                        CreatedAtDate = c.DateTime(nullable: false),
                        UpdatedAtDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
            AlterColumn("dbo.Drivers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Orders", "Foods_FoodId", "dbo.Foods");
            DropIndex("dbo.Orders", new[] { "Foods_FoodId" });
            DropIndex("dbo.Foods", new[] { "RestaurantId" });
            AlterColumn("dbo.Drivers", "Name", c => c.String(nullable: false, maxLength: 50));
            DropTable("dbo.Restaurants");
            DropTable("dbo.Orders");
            DropTable("dbo.Foods");
        }
    }
}

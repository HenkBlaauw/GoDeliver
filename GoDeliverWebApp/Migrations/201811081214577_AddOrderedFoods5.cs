namespace GoDeliverWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderedFoods5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Foods", new[] { "RestaurantId" });
            AddColumn("dbo.Foods", "Restaurant_RestaurantId", c => c.Int());
            AlterColumn("dbo.Foods", "RestaurantId", c => c.Long(nullable: false));
            CreateIndex("dbo.Foods", "Restaurant_RestaurantId");
            AddForeignKey("dbo.Foods", "Restaurant_RestaurantId", "dbo.Restaurants", "RestaurantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "Restaurant_RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Foods", new[] { "Restaurant_RestaurantId" });
            AlterColumn("dbo.Foods", "RestaurantId", c => c.Int(nullable: false));
            DropColumn("dbo.Foods", "Restaurant_RestaurantId");
            CreateIndex("dbo.Foods", "RestaurantId");
            AddForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants", "RestaurantId", cascadeDelete: true);
        }
    }
}

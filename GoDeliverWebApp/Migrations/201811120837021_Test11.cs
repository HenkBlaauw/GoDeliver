namespace GoDeliverWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Adress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Adress", c => c.String(nullable: false, maxLength: 100));
        }
    }
}

namespace EF_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}

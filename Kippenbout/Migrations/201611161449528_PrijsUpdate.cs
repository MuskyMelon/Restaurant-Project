namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrijsUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gerechts", "Prijs", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Menus", "Prijs", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "Prijs", c => c.Single(nullable: false));
            AlterColumn("dbo.Gerechts", "Prijs", c => c.Single(nullable: false));
        }
    }
}

namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrijsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserverings", "Prijs", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserverings", "Prijs");
        }
    }
}

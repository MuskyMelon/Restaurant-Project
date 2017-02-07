namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class totaalprijs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserverings", "Totaal_Prijs", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserverings", "Totaal_Prijs");
        }
    }
}

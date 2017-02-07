namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aanwezig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserverings", "Aanwezig", c => c.Boolean(nullable: false));
            AddColumn("dbo.Reserverings", "Gerecht_Klaar", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserverings", "Gerecht_Klaar");
            DropColumn("dbo.Reserverings", "Aanwezig");
        }
    }
}

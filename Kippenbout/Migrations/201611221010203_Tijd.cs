namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tijd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserverings", "Datum", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserverings", "Datum");
        }
    }
}

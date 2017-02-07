namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserverings", "Tijd", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Reserverings", "Datum_tijd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserverings", "Datum_tijd");
            DropColumn("dbo.Reserverings", "Tijd");
        }
    }
}

namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EndTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserverings", "BeginTijd", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Reserverings", "EindTijd", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Reserverings", "BeginDatum_tijd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reserverings", "EindDatum_tijd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reserverings", "Tijd");
            DropColumn("dbo.Reserverings", "Datum_tijd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reserverings", "Datum_tijd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reserverings", "Tijd", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.Reserverings", "EindDatum_tijd");
            DropColumn("dbo.Reserverings", "BeginDatum_tijd");
            DropColumn("dbo.Reserverings", "EindTijd");
            DropColumn("dbo.Reserverings", "BeginTijd");
        }
    }
}

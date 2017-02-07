namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tijd2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reserverings", "Datum", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reserverings", "Datum", c => c.DateTime(nullable: false));
        }
    }
}

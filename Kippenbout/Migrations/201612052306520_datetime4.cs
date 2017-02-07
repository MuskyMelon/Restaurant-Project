namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reserverings", "Datum", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reserverings", "Datum_tijd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reserverings", "Datum_tijd", c => c.DateTime());
            AlterColumn("dbo.Reserverings", "Datum", c => c.DateTime());
        }
    }
}

namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reserverings", "Datum_tijd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reserverings", "Datum_tijd", c => c.DateTime(nullable: false));
        }
    }
}

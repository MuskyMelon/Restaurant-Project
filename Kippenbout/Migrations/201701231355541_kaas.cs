namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kaas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reserverings", "Tafel_Nummer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reserverings", "Tafel_Nummer", c => c.String());
        }
    }
}

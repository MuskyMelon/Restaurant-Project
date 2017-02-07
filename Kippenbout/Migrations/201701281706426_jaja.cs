namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jaja : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reserverings", "Aanwezig");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reserverings", "Aanwezig", c => c.Boolean(nullable: false));
        }
    }
}

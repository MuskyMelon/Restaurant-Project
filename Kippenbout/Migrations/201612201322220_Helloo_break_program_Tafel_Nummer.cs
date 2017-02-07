namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Helloo_break_program_Tafel_Nummer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserverings", "Tafel_Nummer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserverings", "Tafel_Nummer");
        }
    }
}

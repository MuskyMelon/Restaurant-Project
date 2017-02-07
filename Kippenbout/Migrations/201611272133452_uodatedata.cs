namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uodatedata : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reserverings", "Tijd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reserverings", "Tijd", c => c.DateTime(nullable: false));
        }
    }
}

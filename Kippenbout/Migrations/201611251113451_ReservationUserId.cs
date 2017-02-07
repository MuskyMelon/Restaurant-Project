namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserverings", "contact_Id", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserverings", "contact_Id");
        }
    }
}

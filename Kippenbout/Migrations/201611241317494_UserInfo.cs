namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reserverings", "Contact_Naam", c => c.String());
            AddColumn("dbo.Reserverings", "Contact_Email", c => c.String());
            AddColumn("dbo.Reserverings", "Contact_Telefoonnummer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reserverings", "Contact_Telefoonnummer");
            DropColumn("dbo.Reserverings", "Contact_Email");
            DropColumn("dbo.Reserverings", "Contact_Naam");
        }
    }
}

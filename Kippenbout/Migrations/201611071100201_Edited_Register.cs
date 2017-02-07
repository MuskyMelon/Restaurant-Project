namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edited_Register : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Achternaam", c => c.String());
            AddColumn("dbo.AspNetUsers", "Geboortedatum", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Huisnummer", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Plaats", c => c.String());
            AddColumn("dbo.AspNetUsers", "Postcode", c => c.String());
            AddColumn("dbo.AspNetUsers", "StraatNaam", c => c.String());
            AddColumn("dbo.AspNetUsers", "TelefoonNummer", c => c.String());
            AddColumn("dbo.AspNetUsers", "Toevoegsel", c => c.String());
            AddColumn("dbo.AspNetUsers", "Tussenvoegsel", c => c.String());
            AddColumn("dbo.AspNetUsers", "Voornaam", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Voornaam");
            DropColumn("dbo.AspNetUsers", "Tussenvoegsel");
            DropColumn("dbo.AspNetUsers", "Toevoegsel");
            DropColumn("dbo.AspNetUsers", "TelefoonNummer");
            DropColumn("dbo.AspNetUsers", "StraatNaam");
            DropColumn("dbo.AspNetUsers", "Postcode");
            DropColumn("dbo.AspNetUsers", "Plaats");
            DropColumn("dbo.AspNetUsers", "Huisnummer");
            DropColumn("dbo.AspNetUsers", "Geboortedatum");
            DropColumn("dbo.AspNetUsers", "Achternaam");
        }
    }
}

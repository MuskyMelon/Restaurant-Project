namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_Profiel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ProfielModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProfielModels",
                c => new
                    {
                        GebruikerId = c.String(nullable: false, maxLength: 128),
                        Voornaam = c.String(nullable: false),
                        Achternaam = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        TelefoonNummer = c.Int(nullable: false),
                        Adres = c.String(nullable: false),
                        Woonplaats = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GebruikerId);
            
        }
    }
}

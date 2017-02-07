namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelsbeter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gerechts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false),
                        Soort = c.String(nullable: false),
                        Omschrijving = c.String(nullable: false),
                        Prijs = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false),
                        Prijs = c.Single(nullable: false),
                        Hoofdgerecht_Id = c.Int(nullable: false),
                        Nagerecht_Id = c.Int(nullable: false),
                        Voorgerecht_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gerechts", t => t.Hoofdgerecht_Id, cascadeDelete: false)
                .ForeignKey("dbo.Gerechts", t => t.Nagerecht_Id, cascadeDelete: false)
                .ForeignKey("dbo.Gerechts", t => t.Voorgerecht_Id, cascadeDelete: false)
                .Index(t => t.Hoofdgerecht_Id)
                .Index(t => t.Nagerecht_Id)
                .Index(t => t.Voorgerecht_Id);

            DropTable("dbo.MenuModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MenuModels",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        MenuNaam = c.String(nullable: false),
                        Voorgerecht = c.String(nullable: false),
                        Hoofdgerecht = c.String(nullable: false),
                        Nagerecht = c.String(nullable: false),
                        Prijs = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MenuID);
            
            CreateTable(
                "dbo.GerechtModels",
                c => new
                    {
                        GerechtID = c.Int(nullable: false, identity: true),
                        Gerechtnaam = c.String(nullable: false),
                        GerechtSoort = c.String(nullable: false),
                        Omschrijving = c.String(nullable: false),
                        Prijs = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.GerechtID);
            
            DropForeignKey("dbo.Menus", "Voorgerecht_Id", "dbo.Gerechts");
            DropForeignKey("dbo.Menus", "Nagerecht_Id", "dbo.Gerechts");
            DropForeignKey("dbo.Menus", "Hoofdgerecht_Id", "dbo.Gerechts");
            DropIndex("dbo.Menus", new[] { "Voorgerecht_Id" });
            DropIndex("dbo.Menus", new[] { "Nagerecht_Id" });
            DropIndex("dbo.Menus", new[] { "Hoofdgerecht_Id" });
            DropTable("dbo.Menus");
            DropTable("dbo.Gerechts");
        }
    }
}

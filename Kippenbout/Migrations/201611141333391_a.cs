namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "Hoofdgerecht_Id", "dbo.Gerechts");
            DropForeignKey("dbo.Menus", "Nagerecht_Id", "dbo.Gerechts");
            DropForeignKey("dbo.Menus", "Voorgerecht_Id", "dbo.Gerechts");
            DropIndex("dbo.Menus", new[] { "Hoofdgerecht_Id" });
            DropIndex("dbo.Menus", new[] { "Nagerecht_Id" });
            DropIndex("dbo.Menus", new[] { "Voorgerecht_Id" });
            AlterColumn("dbo.Menus", "Hoofdgerecht_Id", c => c.Int());
            AlterColumn("dbo.Menus", "Nagerecht_Id", c => c.Int());
            AlterColumn("dbo.Menus", "Voorgerecht_Id", c => c.Int());
            CreateIndex("dbo.Menus", "Hoofdgerecht_Id");
            CreateIndex("dbo.Menus", "Nagerecht_Id");
            CreateIndex("dbo.Menus", "Voorgerecht_Id");
            AddForeignKey("dbo.Menus", "Hoofdgerecht_Id", "dbo.Gerechts", "Id");
            AddForeignKey("dbo.Menus", "Nagerecht_Id", "dbo.Gerechts", "Id");
            AddForeignKey("dbo.Menus", "Voorgerecht_Id", "dbo.Gerechts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "Voorgerecht_Id", "dbo.Gerechts");
            DropForeignKey("dbo.Menus", "Nagerecht_Id", "dbo.Gerechts");
            DropForeignKey("dbo.Menus", "Hoofdgerecht_Id", "dbo.Gerechts");
            DropIndex("dbo.Menus", new[] { "Voorgerecht_Id" });
            DropIndex("dbo.Menus", new[] { "Nagerecht_Id" });
            DropIndex("dbo.Menus", new[] { "Hoofdgerecht_Id" });
            AlterColumn("dbo.Menus", "Voorgerecht_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Menus", "Nagerecht_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Menus", "Hoofdgerecht_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Menus", "Voorgerecht_Id");
            CreateIndex("dbo.Menus", "Nagerecht_Id");
            CreateIndex("dbo.Menus", "Hoofdgerecht_Id");
            AddForeignKey("dbo.Menus", "Voorgerecht_Id", "dbo.Gerechts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Menus", "Nagerecht_Id", "dbo.Gerechts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Menus", "Hoofdgerecht_Id", "dbo.Gerechts", "Id", cascadeDelete: true);
        }
    }
}

namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Reservering_Id1", c => c.Int());
            AddColumn("dbo.Reserverings", "Menu_Id", c => c.Int());
            CreateIndex("dbo.Menus", "Reservering_Id1");
            CreateIndex("dbo.Reserverings", "Menu_Id");
            AddForeignKey("dbo.Menus", "Reservering_Id1", "dbo.Reserverings", "Id");
            AddForeignKey("dbo.Reserverings", "Menu_Id", "dbo.Menus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserverings", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.Menus", "Reservering_Id1", "dbo.Reserverings");
            DropIndex("dbo.Reserverings", new[] { "Menu_Id" });
            DropIndex("dbo.Menus", new[] { "Reservering_Id1" });
            DropColumn("dbo.Reserverings", "Menu_Id");
            DropColumn("dbo.Menus", "Reservering_Id1");
        }
    }
}

namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inlog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reserverings", "Menu_Id", "dbo.MenusList");
            DropIndex("dbo.Reserverings", new[] { "Menu_Id" });
            AlterColumn("dbo.Reserverings", "Menu_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Reserverings", "Menu_Id");
            AddForeignKey("dbo.Reserverings", "Menu_Id", "dbo.MenusList", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserverings", "Menu_Id", "dbo.MenusList");
            DropIndex("dbo.Reserverings", new[] { "Menu_Id" });
            AlterColumn("dbo.Reserverings", "Menu_Id", c => c.Int());
            CreateIndex("dbo.Reserverings", "Menu_Id");
            AddForeignKey("dbo.Reserverings", "Menu_Id", "dbo.MenusList", "Id");
        }
    }
}

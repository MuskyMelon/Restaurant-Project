namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_reservering_Create : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reserverings", "Menu_Id", "dbo.MenusList");
            DropIndex("dbo.Reserverings", new[] { "Menu_Id" });
            AddColumn("dbo.MenusList", "Reservering_Id", c => c.Int());
            CreateIndex("dbo.MenusList", "Reservering_Id");
            AddForeignKey("dbo.MenusList", "Reservering_Id", "dbo.Reserverings", "Id");
            DropColumn("dbo.Reserverings", "Menu_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reserverings", "Menu_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.MenusList", "Reservering_Id", "dbo.Reserverings");
            DropIndex("dbo.MenusList", new[] { "Reservering_Id" });
            DropColumn("dbo.MenusList", "Reservering_Id");
            CreateIndex("dbo.Reserverings", "Menu_Id");
            AddForeignKey("dbo.Reserverings", "Menu_Id", "dbo.MenusList", "Id", cascadeDelete: true);
        }
    }
}

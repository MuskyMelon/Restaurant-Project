namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class help : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ReserveerModels", newName: "Reserverings");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Reserverings", newName: "ReserveerModels");
        }
    }
}

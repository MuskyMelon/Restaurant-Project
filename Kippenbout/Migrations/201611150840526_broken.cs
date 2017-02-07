namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class broken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReserveerModels",
                c => new
                    {
                        RevereringID = c.Int(nullable: false, identity: true),
                        Menu = c.String(),
                        Personen = c.Int(nullable: false),
                        Tijd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RevereringID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReserveerModels");
        }
    }
}

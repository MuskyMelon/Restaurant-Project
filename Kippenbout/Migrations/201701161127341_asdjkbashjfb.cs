namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdjkbashjfb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tafels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TafelNummer = c.Int(nullable: false),
                        Xcor = c.Int(nullable: false),
                        Ycor = c.Int(nullable: false),
                        Bezet = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tafels");
        }
    }
}

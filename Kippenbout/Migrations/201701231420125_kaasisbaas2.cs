namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kaasisbaas2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tafels", "Xcor");
            DropColumn("dbo.Tafels", "Ycor");
            DropColumn("dbo.Tafels", "Bezet");
            DropColumn("dbo.Tafels", "begin");
            DropColumn("dbo.Tafels", "Eind");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tafels", "Eind", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tafels", "begin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tafels", "Bezet", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tafels", "Ycor", c => c.Int(nullable: false));
            AddColumn("dbo.Tafels", "Xcor", c => c.Int(nullable: false));
        }
    }
}

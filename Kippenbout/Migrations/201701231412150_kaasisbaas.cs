namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kaasisbaas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tafels", "begin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tafels", "Datum", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tafels", "Eind", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tafels", "TafelNummer", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tafels", "TafelNummer", c => c.Int(nullable: false));
            DropColumn("dbo.Tafels", "Eind");
            DropColumn("dbo.Tafels", "Datum");
            DropColumn("dbo.Tafels", "begin");
        }
    }
}

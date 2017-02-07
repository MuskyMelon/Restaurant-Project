namespace Kippenbout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menu2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MenuModels", "StateList_DataGroupField");
            DropColumn("dbo.MenuModels", "StateList_DataTextField");
            DropColumn("dbo.MenuModels", "StateList_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuModels", "StateList_DataValueField", c => c.String());
            AddColumn("dbo.MenuModels", "StateList_DataTextField", c => c.String());
            AddColumn("dbo.MenuModels", "StateList_DataGroupField", c => c.String());
        }
    }
}

namespace NyvaProdBC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class troubles_20220810 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NyvaProdGoods", "RecievedOn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NyvaProdGoods", "RecievedOn");
        }
    }
}

namespace NyvaProdBC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveError11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NyvaProdGoods", "ProductionDate", c => c.String());
            AlterColumn("dbo.NyvaProdGoods", "ConsumedUntil", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NyvaProdGoods", "ConsumedUntil", c => c.DateTime(nullable: false));
            AlterColumn("dbo.NyvaProdGoods", "ProductionDate", c => c.DateTime(nullable: false));
        }
    }
}

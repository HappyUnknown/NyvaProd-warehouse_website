namespace NyvaProdBC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WishesInplied : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NyvaProdGoods", "APF", c => c.Double(nullable: false));
            AddColumn("dbo.NyvaProdGoods", "Profit", c => c.Double(nullable: false));
            AddColumn("dbo.NyvaProdGoods", "TotalAmount", c => c.Int(nullable: false));
            AddColumn("dbo.NyvaProdGoods", "AmountSold", c => c.Int(nullable: false));
            DropColumn("dbo.NyvaProdGoods", "SellPrice");
            DropColumn("dbo.NyvaProdGoods", "InWare");
            DropColumn("dbo.NyvaProdGoods", "ProductionDate");
            DropColumn("dbo.NyvaProdGoods", "ConsumedUntil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NyvaProdGoods", "ConsumedUntil", c => c.String());
            AddColumn("dbo.NyvaProdGoods", "ProductionDate", c => c.String());
            AddColumn("dbo.NyvaProdGoods", "InWare", c => c.Int(nullable: false));
            AddColumn("dbo.NyvaProdGoods", "SellPrice", c => c.Double(nullable: false));
            DropColumn("dbo.NyvaProdGoods", "AmountSold");
            DropColumn("dbo.NyvaProdGoods", "TotalAmount");
            DropColumn("dbo.NyvaProdGoods", "Profit");
            DropColumn("dbo.NyvaProdGoods", "APF");
        }
    }
}

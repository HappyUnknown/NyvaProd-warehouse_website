namespace NyvaProdBC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrderPrice = c.Double(nullable: false),
                        SellPrice = c.Double(nullable: false),
                        WeightKg = c.Double(nullable: false),
                        InWare = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        ProductionDate = c.DateTime(nullable: false),
                        ConsumedUntil = c.DateTime(nullable: false),
                        Barcode_RegionCode = c.Int(nullable: false),
                        Barcode_ProducerCode = c.Int(nullable: false),
                        Barcode_GoodCode = c.Int(nullable: false),
                        Barcode_ControlDigit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Goods");
        }
    }
}

namespace NyvaProdBC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveError1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Goods", newName: "NyvaProdGoods");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.NyvaProdGoods", newName: "Goods");
        }
    }
}

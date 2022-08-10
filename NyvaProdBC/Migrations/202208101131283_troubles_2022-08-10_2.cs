namespace NyvaProdBC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class troubles_20220810_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NyvaProdGoods", "ImagesUrl", c => c.String());
            DropColumn("dbo.NyvaProdGoods", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NyvaProdGoods", "ImageUrl", c => c.String());
            DropColumn("dbo.NyvaProdGoods", "ImagesUrl");
        }
    }
}

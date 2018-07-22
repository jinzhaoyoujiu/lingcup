namespace LinJiaYou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Counties", "CityId", c => c.Int());
            AddColumn("dbo.Counties", "ProvinceId", c => c.Int());
            CreateIndex("dbo.Counties", "CityId");
            CreateIndex("dbo.Counties", "ProvinceId");
            AddForeignKey("dbo.Counties", "CityId", "dbo.Cities", "Id");
            AddForeignKey("dbo.Counties", "ProvinceId", "dbo.Provinces", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Counties", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Counties", "CityId", "dbo.Cities");
            DropIndex("dbo.Counties", new[] { "ProvinceId" });
            DropIndex("dbo.Counties", new[] { "CityId" });
            DropColumn("dbo.Counties", "ProvinceId");
            DropColumn("dbo.Counties", "CityId");
        }
    }
}

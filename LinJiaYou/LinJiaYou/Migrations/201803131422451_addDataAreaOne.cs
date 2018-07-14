namespace LinJiaYou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataAreaOne : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Counties", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Counties", new[] { "ProvinceId" });
            DropColumn("dbo.Counties", "ProvinceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Counties", "ProvinceId", c => c.Int());
            CreateIndex("dbo.Counties", "ProvinceId");
            AddForeignKey("dbo.Counties", "ProvinceId", "dbo.Provinces", "Id");
        }
    }
}

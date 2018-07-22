namespace LinJiaYou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_foreign_key : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cities", "ProvinceId", c => c.Int());
            CreateIndex("dbo.Cities", "ProvinceId");
            AddForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropColumn("dbo.Cities", "ProvinceId");
        }
    }
}

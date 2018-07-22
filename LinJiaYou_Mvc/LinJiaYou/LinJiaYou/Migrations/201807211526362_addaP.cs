namespace LinJiaYou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addaP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shops", "Position", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shops", "Position");
        }
    }
}

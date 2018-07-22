namespace LinJiaYou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExceptionLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Source = c.String(),
                        TargetSite = c.String(),
                        AddDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneVeriCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(nullable: false),
                        VerificationCode = c.String(nullable: false, maxLength: 4),
                        AddTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Url = c.String(),
                        TouristID = c.Int(),
                        FromDealshot_Id = c.Int(),
                        FromHeadshot_Id = c.Int(),
                        FromUsed_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FromDealshot_Id)
                .ForeignKey("dbo.Users", t => t.FromHeadshot_Id)
                .ForeignKey("dbo.Users", t => t.FromUsed_Id)
                .ForeignKey("dbo.Tourists", t => t.TouristID)
                .Index(t => t.TouristID)
                .Index(t => t.FromDealshot_Id)
                .Index(t => t.FromHeadshot_Id)
                .Index(t => t.FromUsed_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tourists",
                c => new
                    {
                        PrimaryTrackingKeyID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FirstPicUrl = c.String(),
                        Intro = c.String(),
                        Is_delete = c.Boolean(),
                        touristDescription = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.PrimaryTrackingKeyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "TouristID", "dbo.Tourists");
            DropForeignKey("dbo.Pictures", "FromUsed_Id", "dbo.Users");
            DropForeignKey("dbo.Pictures", "FromHeadshot_Id", "dbo.Users");
            DropForeignKey("dbo.Pictures", "FromDealshot_Id", "dbo.Users");
            DropIndex("dbo.Pictures", new[] { "FromUsed_Id" });
            DropIndex("dbo.Pictures", new[] { "FromHeadshot_Id" });
            DropIndex("dbo.Pictures", new[] { "FromDealshot_Id" });
            DropIndex("dbo.Pictures", new[] { "TouristID" });
            DropTable("dbo.Tourists");
            DropTable("dbo.Users");
            DropTable("dbo.Pictures");
            DropTable("dbo.PhoneVeriCodes");
            DropTable("dbo.ExceptionLogs");
        }
    }
}

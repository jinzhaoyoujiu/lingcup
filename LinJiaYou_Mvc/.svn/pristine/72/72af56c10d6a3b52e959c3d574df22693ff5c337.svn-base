namespace LinJiaYou.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mew : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pictures", name: "FromDealshot_Id", newName: "UserFromDealshot");
            RenameColumn(table: "dbo.Pictures", name: "FromHeadshot_Id", newName: "UserFromHeadshot");
            RenameColumn(table: "dbo.Pictures", name: "FromUsed_Id", newName: "UserFromUsedID");
            RenameIndex(table: "dbo.Pictures", name: "IX_FromUsed_Id", newName: "IX_UserFromUsedID");
            RenameIndex(table: "dbo.Pictures", name: "IX_FromHeadshot_Id", newName: "IX_UserFromHeadshot");
            RenameIndex(table: "dbo.Pictures", name: "IX_FromDealshot_Id", newName: "IX_UserFromDealshot");
            DropPrimaryKey("dbo.Pictures");
            CreateTable(
                "dbo.fManager",
                c => new
                    {
                        manangerName = c.String(maxLength: 4000),
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Essays",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Author = c.String(maxLength: 10),
                        EssayType = c.Int(nullable: false),
                        TouristID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tourists", t => t.TouristID)
                .Index(t => t.TouristID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.QiNiuPictures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Shops",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(),
                        Area = c.Double(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Managers", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Pictures", "QiNiuPictureID", c => c.Int(nullable: false));
            AddColumn("dbo.Pictures", "Is_Cover", c => c.Boolean());
            AddColumn("dbo.Pictures", "ShopID", c => c.Int());
            AddPrimaryKey("dbo.Pictures", "QiNiuPictureID");
            CreateIndex("dbo.Pictures", "QiNiuPictureID");
            CreateIndex("dbo.Pictures", "ShopID");
            AddForeignKey("dbo.Pictures", "QiNiuPictureID", "dbo.QiNiuPictures", "ID");
            AddForeignKey("dbo.Pictures", "ShopID", "dbo.Shops", "ID");
            DropColumn("dbo.Pictures", "Id");
            DropColumn("dbo.Pictures", "Type");
            DropColumn("dbo.Pictures", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pictures", "Url", c => c.String());
            AddColumn("dbo.Pictures", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Pictures", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Pictures", "ShopID", "dbo.Shops");
            DropForeignKey("dbo.Pictures", "QiNiuPictureID", "dbo.QiNiuPictures");
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.Essays", "TouristID", "dbo.Tourists");
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.Pictures", new[] { "ShopID" });
            DropIndex("dbo.Pictures", new[] { "QiNiuPictureID" });
            DropIndex("dbo.Essays", new[] { "TouristID" });
            DropPrimaryKey("dbo.Pictures");
            DropColumn("dbo.Pictures", "ShopID");
            DropColumn("dbo.Pictures", "Is_Cover");
            DropColumn("dbo.Pictures", "QiNiuPictureID");
            DropColumn("dbo.Managers", "TimeStamp");
            DropTable("dbo.Shops");
            DropTable("dbo.QiNiuPictures");
            DropTable("dbo.Products");
            DropTable("dbo.Essays");
            DropTable("dbo.fManager");
            AddPrimaryKey("dbo.Pictures", "Id");
            RenameIndex(table: "dbo.Pictures", name: "IX_UserFromDealshot", newName: "IX_FromDealshot_Id");
            RenameIndex(table: "dbo.Pictures", name: "IX_UserFromHeadshot", newName: "IX_FromHeadshot_Id");
            RenameIndex(table: "dbo.Pictures", name: "IX_UserFromUsedID", newName: "IX_FromUsed_Id");
            RenameColumn(table: "dbo.Pictures", name: "UserFromUsedID", newName: "FromUsed_Id");
            RenameColumn(table: "dbo.Pictures", name: "UserFromHeadshot", newName: "FromHeadshot_Id");
            RenameColumn(table: "dbo.Pictures", name: "UserFromDealshot", newName: "FromDealshot_Id");
        }
    }
}
